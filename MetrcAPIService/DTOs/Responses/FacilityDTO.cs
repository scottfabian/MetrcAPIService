namespace MetrcAPIService;

public class FacilityDTO
{
    public string HireDate { get; set; }
    public bool IsOwner { get; set; }
    public bool IsManager { get; set; }
    public object[] Occupations { get; set; }
    public string Name { get; set; }
    public string Alias { get; set; }
    public string DisplayName { get; set; }
    public string CredentialedDate { get; set; }
    public object SupportActivationDate { get; set; }
    public object SupportExpirationDate { get; set; }
    public object SupportLastPaidDate { get; set; }
    public FacilityTypeDTO FacilityType { get; set; }
    public LicenseDTO License { get; set; }
}
