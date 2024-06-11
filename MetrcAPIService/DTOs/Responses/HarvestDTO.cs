namespace MetrcAPIService;

public class HarvestDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string HarvestType { get; set; }
    public int SourceStrainCount { get; set; }
    public string? SourceStrainNames { get; set; }
    public object[] Strains { get; set; }
    public int DryingLocationId { get; set; }
    public string DryingLocationName { get; set; }
    public string? DryingLocationTypeName { get; set; }
    public string? PatientLicenseNumber { get; set; }
    public double CurrentWeight { get; set; }
    public double TotalWasteWeight { get; set; }
    public int PlantCount { get; set; }
    public double TotalWetWeight { get; set; }
    public double TotalRestoredWeight { get; set; }
    public int PackageCount { get; set; }
    public double TotalPackagedWeight { get; set; }
    public string UnitOfWeightName { get; set; }
    public string? LabTestingState { get; set; }
    public DateTime? LabTestingStateDate { get; set; }
    public bool IsOnHold { get; set; }
    public DateTime? HarvestStartDate { get; set; }
    public DateTime? FinishedDate { get; set; }
    public DateTime? ArchivedDate { get; set; }
    public bool IsOnTrip { get; set; }
    public DateTime LastModified { get; set; }
}
