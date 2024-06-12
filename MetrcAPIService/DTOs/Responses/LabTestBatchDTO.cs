namespace MetrcAPIService;

public class LabTestBatchDTO
{
    public string Name { get; set; }
    public int LabTestTypeCount { get; set; }
    public LabTestTypeDTO[] LabTestTypes { get; set; }
    public int ItemCategoryCount { get; set; }
    public object[] ItemCategories { get; set; }
}
