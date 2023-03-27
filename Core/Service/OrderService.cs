using Core.Entities;
using Core.Interface.Facade;
using Core.Interface.IRepository;
using System.Threading.Tasks;
using System.Linq;
using Core.ViewModel;
using Core.Enums;
using Core.DTOs.Order;
using Core.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using System;

namespace Core.Service
{
    public class OrderService:IOrderService
    {
        private readonly IUnitOfWork _iuow;
        private readonly IRepository<Order> _orderRepo;
        private readonly IRepository<DailySales> _dailySalesRepo;
        private readonly IHubContext<Hubs> _hubContext;

        public OrderService(IUnitOfWork iuow, IHubContext<Hubs> hubContext)
        {
            _iuow = iuow;
            _orderRepo = _iuow.Repository<Order>();
            _dailySalesRepo = _iuow.Repository<DailySales>();
            _hubContext = hubContext;
        }

        public async Task<bool> CreateOrder(CreateOrderViewModel order)
        {

            var orderDb = new Order {

                CreatedBy = order.CreatedBy,
                OrderStatusId = (int)OrderStatusEnum.Created,
                TotalPrice = order.TotalPrice,
                OrderMenuItems = order.OrderMenuItems.Select(om => new OrderMenuItem {  MenuItemId = om.MenuItemId, Amount = om.Amount, Price = om.Price}).ToList()
            };

            await _orderRepo.InsertAsync(orderDb);

            await _iuow.SaveChangesAsync();

            await _hubContext.Clients.All.SendAsync("ReceiveMessage", new NotifyMessage
            {
                Message = "order created successfully!"
            });

            return true;
        }

        public async Task<IList<KitchenOrderDTO>> GetKithenOrder(bool kitchen)
        {
            var result = new List<KitchenOrderDTO>();

            var orders = new List<Order>();
            if (kitchen)
            {
                orders = await _orderRepo.All.Include(o => o.OrderMenuItems).ThenInclude(m => m.MenuItem).Where(o => o.OrderStatusId == (int)OrderStatusEnum.Created && o.ChiefOrderStatus == false).ToListAsync();
            }

            if(!kitchen)
            {
                orders = await _orderRepo.All.Include(o => o.OrderMenuItems).ThenInclude(m => m.MenuItem).Where(o => o.OrderStatusId == (int)OrderStatusEnum.Created && o.BaristaOrderStatus == false).ToListAsync();
            }
            foreach (var order in orders) {

                if (order.OrderMenuItems.Count(o => o.MenuItem.ChiefMenu == kitchen) > 0) {
                    result.Add(new KitchenOrderDTO
                    {
                        Id = order.Id,
                        Items = order.OrderMenuItems.Where(om => om.MenuItem.ChiefMenu == kitchen).Select(m => new KithenOrderItem
                        {
                            Name = m.MenuItem.Name,
                            Amount = m.Amount,
                        }).ToList()
                    });
                }

            }

            return result;
        }

        public async Task<string> UpdateKitchenOrderStatus(UpdateOrderViewModel model)
        {
            var order = await _orderRepo.GetAsync(model.OrderId);

            var orders = await _orderRepo.All.Include(o => o.OrderMenuItems).ThenInclude(m => m.MenuItem).Where(o => o.OrderStatusId == (int)OrderStatusEnum.Created &&  o.Id==model.OrderId).ToListAsync();

            if (order == null || order.OrderStatusId != (int)OrderStatusEnum.Created)
            {
                return "false";
            }
            if (model.OrderStatusId == (int)OrderStatusEnum.Delivered)
            {
                foreach (var o in orders)
                {

                    if (!(o.OrderMenuItems.Count(o => o.MenuItem.ChiefMenu == true) > 0))
                    {
                        model.ChiefOrderStatus = true;
                    }
                    if (!(o.OrderMenuItems.Count(o => o.MenuItem.ChiefMenu == false) > 0))
                    {
                        model.BaristaOrderStatus = true;
                    }
                }

                if (order.BaristaOrderStatus == true) {
                    order.ChiefOrderStatus = model.ChiefOrderStatus;
                }
                if (order.ChiefOrderStatus == true)
                {
                    order.BaristaOrderStatus = model.BaristaOrderStatus;
                }
                if (order.ChiefOrderStatus == false && order.BaristaOrderStatus == false)
                {
                    order.ChiefOrderStatus = model.ChiefOrderStatus;
                    order.BaristaOrderStatus = model.BaristaOrderStatus;
                }
               
                if (order.ChiefOrderStatus == true && order.BaristaOrderStatus == true)
                {
                    if(model.OrderStatusId == (int)OrderStatusEnum.Delivered)
                    {
                        order.OrderStatusId = (int)OrderStatusEnum.Delivered;
                    }
                    
                }
                _orderRepo.Update(order);

                await _iuow.SaveChangesAsync();

                return "true";

            }

            if(model.OrderStatusId == (int)OrderStatusEnum.Canceled && order.CreateDateTime.AddMinutes(5) >= DateTime.UtcNow && order.ChiefOrderStatus==false && order.BaristaOrderStatus==false)
            {
                order.BaristaOrderStatus = false;

                order.ChiefOrderStatus = false;

                order.OrderStatusId = (int)OrderStatusEnum.Canceled;

                _orderRepo.Update(order);

                await _iuow.SaveChangesAsync();

                return "true";
            }

            if (order.CreateDateTime.AddMinutes(5) < DateTime.UtcNow)
            {
                return "can not cancel this order it took you more than 5 minute!";
            }
             
            if (order.BaristaOrderStatus == true || order.ChiefOrderStatus == true)
            {
                return "can not cancel this order it is in progress!";
            }
            return "false";

        }
   
        public async Task<IList<KitchenOrderDailyDTO>> GetAllKitchenOrder()
        {

            var orders = await _orderRepo.All.Where(o=>o.CreateDateTime.Day==DateTime.UtcNow.Day).Include(o => o.OrderStatus).Include(r => r.User).Include(o => o.OrderMenuItems).ThenInclude(o=>o.MenuItem).ToListAsync();

            var result = orders.Select(o => new KitchenOrderDailyDTO
            {
                Id = o.Id,
                Status=o.OrderStatus.Name,
                dateTime = o.CreateDateTime,
                CreatedBy = $"{o.User.FirstName} {o.User.LastName}",
                TotalPrice=o.TotalPrice,
                Items = o.OrderMenuItems.Select(m => new KithenOrderDailyItem
                {
                    Name = m.MenuItem.Name,
                    Amount = m.Amount,
                    Price = m.Price,
                    
                }).ToList()
            }).OrderByDescending(r => r.dateTime).ToList();

            return result;
        }
        public async Task<IList<KitchenOrderDeliveredDTO>> GetDeliveredKitchenOrder()
        {

            var orders = await _orderRepo.All.Where(o => o.CreateDateTime.Day == DateTime.UtcNow.Day && o.OrderStatusId == (int)OrderStatusEnum.Delivered).Include(o => o.OrderMenuItems).ThenInclude(o => o.MenuItem).ToListAsync();

            var orderMenuItems = new List<OrderMenuItem>();

            foreach (var item in orders) {

                foreach (var orderItem in item.OrderMenuItems)
                {
                    var existingMenuItem = orderMenuItems.Where(om => om.MenuItemId == orderItem.MenuItemId).FirstOrDefault();
                    if (existingMenuItem != null)
                    {
                        existingMenuItem.Amount += orderItem.Amount;
                        existingMenuItem.Price += orderItem.Price;
                    }
                    else {
                        orderMenuItems.Add(orderItem);
                    }
                }

            }

            var result = orderMenuItems.Select(o => new KitchenOrderDeliveredDTO
            {
                Id = o.Id,
                Name = o.MenuItem.Name,
                Amount = o.Amount,
                UnitPrice = o.MenuItem.UnitPrice,
                TotalPrice = o.Price
            }).ToList();

            var totalMenuItem = new KitchenOrderDeliveredDTO
            {
                Name = "Total",
                TotalPrice = orderMenuItems.Aggregate(0f, (current, item) => current + item.Price)
            };
            
            var onHandMenuItem = new KitchenOrderDeliveredDTO
            {
                Name = "OnHand",
                TotalPrice = 0
            };
            
            result.Add(totalMenuItem);
            result.Add(onHandMenuItem);

            return result;
        }
        public async Task<bool> CreateDailySales(CreateDailySalesViewModel model)
        {
            var dailySales = _dailySalesRepo.All.Where(ds=>ds.CreateDateTime.Day==DateTime.UtcNow.Day);
           
            if (!dailySales.Any())
            {
                var dailySalesdb = new DailySales { ActualTotalSales = model.ActualTotalSales, CalculatedTotalSales = model.CalculatedTotalSales };

                await _dailySalesRepo.InsertAsync(dailySalesdb);

                await _iuow.SaveChangesAsync();

                return true;
            }
            else if(dailySales.Any())
            {
                var dailySalesId = dailySales.Select(o => o.Id).First();

                var sales = await _dailySalesRepo.GetAsync(dailySalesId);

                sales.ActualTotalSales = model.ActualTotalSales;

                sales.CalculatedTotalSales = model.CalculatedTotalSales;

                await _dailySalesRepo.InserOrUpdateAsync(sales);

                await _iuow.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}
