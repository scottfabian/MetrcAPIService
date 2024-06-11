namespace MetrcAPIService;

internal class MetrcEndpoints
{
    public const string GetItemByID = "/items/v2/{id}";
    public const string GetPackageByID = "/packages/v2/{id}";
    public const string GetActivePackages = "/packages/v2/active";
    public const string GetActiveFacilities = "/facilities/v2";
    public const string GetHarvestByID = "/harvests/v2/{id}";
    public const string GetActiveHarvests = "/harvests/v2/active";
}
