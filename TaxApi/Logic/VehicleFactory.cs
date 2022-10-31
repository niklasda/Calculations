using TaxApi.Models;

namespace TaxApi.Logic;

public class VehicleFactory
{
    public IVehicle? CreateFromTypeString(string vehicleTypeString)
    {
        if (Enum.TryParse<TollVehicles>(vehicleTypeString, out var vehicleType))
        {
            if (vehicleType == TollVehicles.Car)
            {
                return new Car();
            }
            else
            {
                return new Motorbike();
            }
        }

        return null;
    }

}