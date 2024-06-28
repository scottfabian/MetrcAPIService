namespace MetrcAPIService;

public class FacilityDTO : IMetrcDTO
{
    public string HireDate { get; set; }
    public bool IsOwner { get; set; }
    public bool IsManager { get; set; }
    public object[] Occupations { get; set; }
    public string Name { get; set; }
    public string Alias { get; set; }
    public string DisplayName { get; set; }
    public string? CredentialedDate { get; set; }
    public string? SupportActivationDate { get; set; }
    public string? SupportExpirationDate { get; set; }
    public string? SupportLastPaidDate { get; set; }
    public FacilityTypeDTO FacilityType { get; set; }
    public LicenseDTO License { get; set; }
}
