using Core.Interface.Facade;
using Core.Interface.IRepository;
using Core.Service;
using Infrastructure;
using Infrastructure.Repository.Abstract;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<EreftSystemDbContext>();

builder.Services.AddScoped(typeof(IUnitOfWork), u =>
{
    var context = u.GetService<EreftSystemDbContext>();
    return new UnitOfWork(context);
});

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IRequestService, RequestService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCors(options => options.AddPolicy("CorsPolicy", p => p.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<Hubs>("hubs/notifications");

app.Run();
