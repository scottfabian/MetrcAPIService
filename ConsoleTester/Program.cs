using MetrcAPIService;
using FabToolKit;
using System.Linq.Expressions;
using System.Net;
using System.Diagnostics.Metrics;
using System.Threading;

namespace ConsoleTester;

internal class Program
{
    static async Task Main(string[] args)
    {
        string vendorKey = "RxwslAgoPK4YinPORltFssWHCXVnPGdo9JtP0K0BlwiZ52bP";
        string userKey = "wxJMHOyXOyHsNC4QGEadNxBmbJo1ba5JFgfkbExN3ip7tYwz";
        string baseUrl = "https://sandbox-api-mi.metrc.com";
        string facilityLicense = "AU-G-EX-000001";
        var httpClient = new HttpClient();

        string itemID = "91201";

        var metrc = new MetrcAPIService.MetrcAPIService(baseUrl, httpClient, vendorKey, userKey, facilityLicense);

        var item = metrc.GetItemByID(itemID);

    }
}
