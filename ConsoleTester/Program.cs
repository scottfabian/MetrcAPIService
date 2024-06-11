using MetrcAPIService;
using System.Text.Json;
using System.Threading.Channels;

namespace ConsoleTester;

internal class Program
{
    static async Task Main(string[] args)
    {
        string westVirginiaVendorKey = "eXlucI51ZFoquvNCJ23rHEgTZY6vJVu1LP0hHJe0ZVawO0Uq";
        string altSolWVUserKey = "zJKm-Ox7u2XRwDZJtNT2d3lwTslorA8acVWDB5r2087TXOoF";
        string altSolWestVirginiaFacilityLicense = "G490006";
        string westVirginiaProdBaseUrl = "https://api-wv.metrc.com";
        string sandboxMichiganVendorKey = "RxwslAgoPK4YinPORltFssWHCXVnPGdo9JtP0K0BlwiZ52bP";
        string sandboxMichiganUserKey = "wxJMHOyXOyHsNC4QGEadNxBmbJo1ba5JFgfkbExN3ip7tYwz";
        string sandboxMichiganBaseUrl = "https://sandbox-api-mi.metrc.com";
        string sandboxMichiganFacilityLicense = "AU-G-EX-000001";
        
        var httpClient = new HttpClient();
        string startDate = "2021-01-01";
        string endDate = "2021-01-02";

        DateTime dStart = DateTime.Parse(startDate);
        DateTime dEnd = DateTime.Parse(endDate);

        var metrc = new MetrcAPIService.MetrcAPI(westVirginiaProdBaseUrl, httpClient, westVirginiaVendorKey, altSolWVUserKey, altSolWestVirginiaFacilityLicense);

        int dateDiff = (DateTime.Now - dStart).Days;

        List<HarvestDTO> harvests = new();

        for (int i = 0; i < dateDiff; i++)
        {
            try
            {
                var retrieved = await metrc.GetActiveHarvests(dStart, dEnd);
                harvests.AddRange(retrieved.Data);
            }
            catch (MetrcApiException e)
            {
                await Task.Run(() => Console.WriteLine("--------------------"));
                await Task.Run(() => Console.WriteLine(e.Message));
                await Task.Run(() => Console.WriteLine(e.RequestURI));
                await Task.Run(() => Console.WriteLine(e.Response));
                await Task.Run(() => Console.WriteLine("--------------------"));
            }
            catch { }

            dStart = dStart.AddDays(1);
            dEnd = dEnd.AddDays(1);

        }

        string jsonData = JsonSerializer.Serialize(harvests);

    }
}
