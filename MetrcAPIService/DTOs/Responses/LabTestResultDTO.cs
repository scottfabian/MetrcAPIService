namespace MetrcAPIService;

public class LabTestResultDTO
{
    public int PackageId { get; set; }
    public int LabTestResultId { get; set; }
    public string LabFacilityLicenseNumber { get; set; }
    public string LabFacilityName { get; set; }
    public string SourcePackageLabel { get; set; }
    public string ProductName { get; set; }
    public string ProductCategoryName { get; set; }
    public string TestPerformedDate { get; set; }
    public bool OverallPassed { get; set; }
    public DateTime? RevokedDate { get; set; }
    public int? LabTestResultDocumentFileId { get; set; }
    public bool ResultReleased { get; set; }
    public DateTime? ResultReleaseDateTime { get; set; }
    public DateTime? ExpirationDateTime { get; set; }
    public string TestTypeName { get; set; }
    public bool TestPassed { get; set; }
    public double TestResultLevel { get; set; }
    public string TestComment { get; set; }
    public bool TestInformationalOnly { get; set; }
    public DateTime? LabTestDetailRevokedDate { get; set; }
}
