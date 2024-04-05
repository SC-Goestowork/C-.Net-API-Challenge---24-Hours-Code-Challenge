using Microsoft.EntityFrameworkCore;
using Pizza_Place_Sales_API.Data;
using CsvHelper;
using System.Globalization;
using System;
using Pizza_Place_Sales_API.Models;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Add DB context for our data
builder.Services.AddDbContext<OrdersApiContext>(opt => opt.UseInMemoryDatabase("Orders"));
builder.Services.AddDbContext<PizzasApiContext>(opt => opt.UseInMemoryDatabase("Pizzas"));
builder.Services.AddDbContext<OrderDetailsApiContext>(opt => opt.UseInMemoryDatabase("OrderDetailss"));
builder.Services.AddDbContext<PizzaTypesApiContext>(opt => opt.UseInMemoryDatabase("PizzaTypes"));

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
