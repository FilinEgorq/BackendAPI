using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using DataAccess.Wrapper;
using Domain.Interfaces;
using BusinessLogic.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<InternetShopContext>(options =>
                                options.UseSqlServer("Server= DESKTOP-TKK652L;Database= InternetShop;Integrated Security= True;"));

builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IFilterService, FilterService>();
builder.Services.AddScoped<IGoodCharachteristicService, GoodCharachteristicService>();
builder.Services.AddScoped<IGoodService, GoodService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
