namespace MetrcAPIService;

internal class MetrcEndpoints
{
    public const string GetItemByID = "/items/v2/{id}";
    public const string GetActiveItems = "/items/v2/active";
    public const string GetInactiveItems = "/items/v2/inactive";
    public const string GetPackageByID = "/packages/v2/{id}";
    public const string GetActivePackages = "/packages/v2/active";
    public const string GetInactivePackages = "/packages/v2/inactive";
    public const string GetActiveFacilities = "/facilities/v2";
    public const string GetHarvestByID = "/harvests/v2/{id}";
    public const string GetActiveHarvests = "/harvests/v2/active";
    public const string GetOnHoldHarvests = "/harvests/v2/onhold";
    public const string GetInactiveHarvests = "/harvests/v2/inactive";
    public const string GetLabResults = "/labtests/v2/results";
    public const string GetLabTestBatches = "/labtests/v2/batches";
    public const string GetLabTestTypes = "/labtests/v2/types";
    public const string GetStrainByID = "/strains/v2/{id}";
    public const string GetActiveStrains = "/strains/v2/active";
}
