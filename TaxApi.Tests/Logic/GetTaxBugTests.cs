using TaxApi.Logic;
using TaxApi.Models;

namespace TaxApi.Tests.Logic;

[TestClass]
public class GetTaxBugTests
{
    [DataTestMethod]
    [DataRow("2013-01-15T09:20:00", 8)] // Tue
    [DataRow("2013-01-15T10:20:00", 8)] 
    [DataRow("2013-01-15T11:20:00", 8)] 
    [DataRow("2013-01-15T12:20:00", 8)] 
    [DataRow("2013-01-15T13:20:00", 8)] 
    [DataRow("2013-01-15T14:20:00", 8)] 
    public void TestSingleDateCarTaxRule5(string dateString, int expectedTax)
    {
        // logic for 08:30–14:59 => SEK 8 is wrong
        var ctc = new TaxCalculator();

        if (DateTime.TryParse(dateString, out var date))
        {
            int tax = ctc.GetTax(new Car(), new[] { date });
            Assert.AreEqual(expectedTax, tax);
        }
        else
        {
            Assert.Fail("Bad test data");
        }
    }

    [DataTestMethod]
    [DataRow("2013-01-15T15:20:00", 13)] // Tue
    [DataRow("2013-01-15T15:30:00", 18)] 
    [DataRow("2013-01-15T16:20:00", 18)]  
    public void TestSingleDateCarTaxRule7(string dateString, int expectedTax)
    {
        // Unclear 15:30–16:59 SEK 18

        var ctc = new TaxCalculator();

        if (DateTime.TryParse(dateString, out var date))
        {
            int tax = ctc.GetTax(new Car(), new[] { date });
            Assert.AreEqual(expectedTax, tax);
        }
        else
        {
            Assert.Fail("Bad test data");
        }
    }
}

