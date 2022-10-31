namespace TaxApi.Models;

public class Car : IVehicle
{
    public string GetVehicleType()
    {
        return TollVehicles.Car.ToString();
    }
}
