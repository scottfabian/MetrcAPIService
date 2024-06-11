using MetrcAPIService;
using System.Text.Json;

namespace ConsoleTester;

internal class Program
{
    static async Task Main(string[] args)
    {
        string vendorKey = "eXlucI51ZFoquvNCJ23rHEgTZY6vJVu1LP0hHJe0ZVawO0Uq";
        string userKey = "zJKm-Ox7u2XRwDZJtNT2d3lwTslorA8acVWDB5r2087TXOoF";
        string baseUrl = "https://api-wv.metrc.com";
        string facilityLicense = "G490006";
        var httpClient = new HttpClient();
        string startDate = "2024-04-01";
        string endDate = "2024-04-02";
        string itemID = "test";

        DateTime dStart = DateTime.Parse(startDate);
        DateTime dEnd = DateTime.Parse(endDate);

        var metrc = new MetrcAPIService.MetrcAPI(baseUrl, httpClient, vendorKey, userKey, facilityLicense);

        int dateDiff = (DateTime.Now - dStart).Days;

        List<PackageDTO> packages = new();

        for (int i = 0; i < dateDiff; i++)
        {
            var retrieved = await metrc.GetActivePackages(dStart, dEnd);
            packages.AddRange(retrieved.Data);

            dStart = dStart.AddDays(1);
            dEnd = dEnd.AddDays(1);

        }

        string jsonData = JsonSerializer.Serialize(packages);

    }
}
