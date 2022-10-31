using TaxApi.Logic;
using TaxApi.Models;

namespace TaxApi.Tests.Logic;

[TestClass]
public class GetTaxCarTests
{
    [DataTestMethod]
    [DataRow("2013-01-14T21:00:00", 0)]  // Mon
    [DataRow("2013-01-15T21:00:00", 0)]  // Tue
    [DataRow("2013-02-07T06:23:27", 8)]  // Thu
    [DataRow("2013-02-07T15:27:00", 13)] // Thu
    [DataRow("2013-02-08T06:27:00", 8)]  // Fri
    [DataRow("2013-02-08T06:20:27", 8)]  // Fri
    [DataRow("2013-02-08T14:35:00", 8)]  // Fri
    [DataRow("2013-02-08T15:29:00", 13)] // Fri
    [DataRow("2013-02-08T15:47:00", 18)] // Fri
    [DataRow("2013-02-08T16:01:00", 18)] // Fri
    [DataRow("2013-02-08T16:48:00", 18)] // Fri
    [DataRow("2013-02-08T17:49:00", 13)] // Fri
    [DataRow("2013-02-08T18:29:00", 8)]  // Fri
    [DataRow("2013-02-08T18:35:00", 0)]  // Fri
    [DataRow("2013-03-26T14:25:00", 0)]  // Tue
    [DataRow("2013-03-28T14:07:27", 0)]  // Thu (Holiday)
    [DataRow("2013-07-26T14:07:27", 0)]  // Fri (July)
    public void TestSingleDateCarTax(string dateString, int expectedTax)
    {
        var ctc = new TaxCalculator();

        if (DateTime.TryParse(dateString, out var date))
        {
            var tax = ctc.GetTax(new Car(), new[] { date });
            Assert.AreEqual(expectedTax, tax);
        }
        else
        {
            Assert.Fail("Bad test data");
        }
    }

    [DataTestMethod]
    [DataRow(new[] { "2013-02-08T06:20:27" }, 8)] // Fri
    [DataRow(new[] { "2013-02-08T14:35:00" }, 8)] 
    [DataRow(new[] { "2013-02-08T17:49:00" }, 13)] 
    [DataRow(new[] { "2013-02-08T18:29:00" }, 8)] 
    [DataRow(new[] { "2013-02-08T06:20:27", "2013-02-08T14:35:00" }, 8 + 8)]  
    [DataRow(new[] { "2013-02-08T17:49:00", "2013-02-08T18:29:00" }, 13)]   
    public void TestMultiHourCarTax(string[] dateStrings, int expectedTax)
    {
        var ctc = new TaxCalculator();

        IEnumerable<DateTime> dates = dateStrings.Select(DateTime.Parse);

        var tax = ctc.GetTax(new Car(), dates.ToArray());
        Assert.AreEqual(expectedTax, tax);
    }
}
