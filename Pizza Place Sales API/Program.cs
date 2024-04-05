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
builder.Services.AddDbContext<OrdersApiContext>(option => option.UseSqlServer("DefaultConnection"));
builder.Services.AddDbContext<PizzasApiContext>(option => option.UseSqlServer("DefaultConnection"));
builder.Services.AddDbContext<OrderDetailsApiContext>(option => option.UseSqlServer("DefaultConnection"));
builder.Services.AddDbContext<PizzaTypesApiContext>(option => option.UseSqlServer("DefaultConnection"));

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
