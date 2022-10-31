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

app.MapPost("/tax", (TaxCalculator ctc, VehicleFactory f, [FromBody] TollingData data) =>
{
    IVehicle? vehicle = f.CreateFromTypeString(data.VehicleType);

    var tax = ctc.GetTax(vehicle, data.TimeStamps);
    return tax;
   
});

app.Run();
