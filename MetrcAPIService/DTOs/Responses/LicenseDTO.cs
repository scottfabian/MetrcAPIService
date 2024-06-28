namespace MetrcAPIService;

public class LicenseDTO : IMetrcDTO
{
    public string Number { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public string LicenseType { get; set; }
}
