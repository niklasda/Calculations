using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using TaxApi.Logic;
using TaxApi.Models;

[assembly: InternalsVisibleTo("TaxApi.Tests")]

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<TaxCalculator>();
builder.Services.AddTransient<VehicleFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseHttpLogging();

app.MapPost("/tax", (TaxCalculator calculator, VehicleFactory factory, [FromBody] TollingData data) =>
{
    IVehicle? vehicle = factory.CreateFromTypeString(data.VehicleType);
    if (vehicle == null || !data.TimeStamps.Any())
        return Results.BadRequest();

    var tax = calculator.GetTax(vehicle, data.TimeStamps);
    return Results.Ok(tax);
});

app.Run();
