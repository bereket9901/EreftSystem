namespace Core.ViewModel
{
    public class UpdateOrderViewModel
    {
        public int OrderId { get; set; }

        public int OrderStatusId { get; set; }

        public bool ChiefOrderStatus { get; set; }

        public bool BaristaOrderStatus { get; set; }

    }
}