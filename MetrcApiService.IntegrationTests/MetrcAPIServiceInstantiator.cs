namespace MetrcApiService.IntegrationTests;

internal static class MetrcAPIServiceInstantiator
{
    public static MetrcAPIService.MetrcAPIService InstantiateMetrcAPIService()
    {
        string vendorKey = "RxwslAgoPK4YinPORltFssWHCXVnPGdo9JtP0K0BlwiZ52bP";
        string userKey = "wxJMHOyXOyHsNC4QGEadNxBmbJo1ba5JFgfkbExN3ip7tYwz";
        string baseUrl = "https://sandbox-api-mi.metrc.com";
        string facilityLicense = "AU-G-EX-000001";
        HttpClient httpClient = new HttpClient();

        return new MetrcAPIService.MetrcAPIService(baseUrl, httpClient, vendorKey, userKey, facilityLicense);
    }
}
