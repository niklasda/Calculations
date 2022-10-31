using System.ComponentModel.DataAnnotations;

namespace TaxApi.Models;

public class TollingData
{
    [Required]
    public string VehicleType { get; set; }
    
    [Required]
    [MinLength(1)]
    public DateTime[] TimeStamps { get; set; }
}