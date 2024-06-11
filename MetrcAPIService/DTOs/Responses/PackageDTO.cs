namespace MetrcAPIService;

public class PackageDTO
{
    public int Id { get; set; }
    public string? Label { get; set; }
    public string? PackageType { get; set; }
    public int SourceHarvestCount { get; set; }
    public int SourcePackageCount { get; set; }
    public int SourceProcessingJobCount { get; set; }
    public string? SourceHarvestNames { get; set; }
    public string? SourcePackageLabels { get; set; }
    public int LocationId { get; set; }
    public string? LocationName { get; set; }
    public string? LocationTypeName { get; set; }
    public float Quantity { get; set; }
    public string? UnitOfMeasureName { get; set; }
    public string? UnitOfMeasureAbbreviation { get; set; }
    public string? PatientLicenseNumber { get; set; }
    public string? ItemFromFacilityLicenseNumber { get; set; }
    public string? ItemFromFacilityName { get; set; }
    public string? Note { get; set; }
    public string? PackagedDate { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public DateTime? SellByDate { get; set; }
    public DateTime? UseByDate { get; set; }
    public string? InitialLabTestingState { get; set; }
    public string? LabTestingState { get; set; }
    public string? LabTestingStateDate { get; set; }
    public DateTime? LabTestResultExpirationDateTime { get; set; }
    public DateTime? LabTestingRecordedDate { get; set; }
    public bool IsProductionBatch { get; set; }
    public string? ProductionBatchNumber { get; set; }
    public string? SourceProductionBatchNumbers { get; set; }
    public bool IsTradeSample { get; set; }
    public bool IsTradeSamplePersistent { get; set; }
    public bool SourcePackageIsTradeSample { get; set; }
    public bool IsDonation { get; set; }
    public bool IsDonationPersistent { get; set; }
    public bool SourcePackageIsDonation { get; set; }
    public bool IsTestingSample { get; set; }
    public bool IsProcessValidationTestingSample { get; set; }
    public bool ProductRequiresRemediation { get; set; }
    public bool ContainsRemediatedProduct { get; set; }
    public DateTime? RemediationDate { get; set; }
    public DateTime? ReceivedDateTime { get; set; }
    public string? ReceivedFromManifestNumber { get; set; }
    public string? ReceivedFromFacilityLicenseNumber { get; set; }
    public string? ReceivedFromFacilityName { get; set; }
    public bool IsOnHold { get; set; }
    public DateTime? ArchivedDate { get; set; }
    public DateTime? FinishedDate { get; set; }
    public bool IsOnTrip { get; set; }
    public bool IsOnRetailerDelivery { get; set; }
    public string? PackageForProductDestruction { get; set; }
    public DateTime LastModified { get; set; }
    public ItemDTO? Item { get; set; }
}