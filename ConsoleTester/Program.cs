using MetrcAPIService;
using System.Linq.Expressions;
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
        string startDate = "2024-06-01";
        string endDate = "2024-06-02";

        DateTime dStart = DateTime.Parse(startDate);
        DateTime dEnd = DateTime.Parse(endDate);

        var metrc = new MetrcAPIService.MetrcAPI(westVirginiaProdBaseUrl, httpClient, westVirginiaVendorKey, altSolWVUserKey, altSolWestVirginiaFacilityLicense);

        int dateDiff = (DateTime.Now - dStart).Days;



        var testBatchesResponseObj = await metrc.GetLabTestBatches();

        var testBatches = testBatchesResponseObj.Data;

        List<PackageDTO> packages = new();

        for (int i = 0; i < dateDiff; i++)
        {

            try
            {
                var retrieved = await metrc.GetActivePackages(dStart, dEnd);
                packages.AddRange(retrieved.Data);
            }
            catch (MetrcApiException e)
            {
                await Task.Run(() => Console.WriteLine("--------------------"));
                await Task.Run(() => Console.WriteLine(e.Message));
                await Task.Run(() => Console.WriteLine(e.RequestURI));
                await Task.Run(() => Console.WriteLine(e.Response));
                await Task.Run(() => Console.WriteLine("--------------------"));
            }
            catch (Exception ex)
            {
                await Task.Run(() => Console.WriteLine("--------------------"));
                await Task.Run(() => Console.WriteLine(ex.Message));
                await Task.Run(() => Console.WriteLine("--------------------"));
            }

            dStart = dStart.AddDays(1);
            dEnd = dEnd.AddDays(1);

        }

        List<int> packageIDs = packages.Select(x => x.Id).ToList();

        List<LabTestResultDTO> results = new();
        var packageResults = await metrc.GetLabResultsForPackage(635524);

        results.AddRange(packageResults.Data);
        //List<LabTestResultsDTO> results = new();

        //foreach (var packageID in packageIDs)
        //{
        //    var localResults = await metrc.GetLabResults(packageID);

        //    results.AddRange(localResults.Data);
        //}

        HashSet<string> batchTypes = new();

        foreach (var batch in testBatches)
        {
            string testBatchName = batch.Name;

            if (testBatchName.Contains("retest", StringComparison.OrdinalIgnoreCase))
            {
                batchTypes.Add(testBatchName);
                continue;
            }

            if (testBatchName.Contains("R&D Testing"))
            {
                if (!testBatchName.Contains('('))
                {
                    int startIndex = testBatchName.IndexOf('-');
                    string batchType = testBatchName.Substring(startIndex + 2);
                    batchTypes.Add(batchType.Trim());
                    continue;
                }

                int hyphenIndex = testBatchName.IndexOf('-');
                int parenIndex = testBatchName.IndexOf('(');

                string newName = testBatchName.Substring(hyphenIndex + 2, parenIndex - (hyphenIndex + 1) - 1);
                batchTypes.Add(newName.Trim());
                continue;
            }


            if (testBatchName.Contains('(') && testBatchName.Contains(')'))
            {
                int startIndex = testBatchName.IndexOf('(');
                int endIndex = testBatchName.IndexOf(')');

                string batchType = testBatchName.Substring(startIndex + 1, endIndex - startIndex - 1);

                batchTypes.Add(batchType.Trim());
                continue;
            }


            batchTypes.Add(testBatchName);

        }

        batchTypes = batchTypes.OrderBy(x => x).ToHashSet();

    }
}
