namespace MetrcAPIService;

public class ItemDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? ProductCategoryName { get; set; }
    public string? ProductCategoryType { get; set; }
    public bool IsExpirationDateRequired { get; set; }
    public bool HasExpirationDate { get; set; }
    public bool IsSellByDateRequired { get; set; }
    public bool HasSellByDate { get; set; }
    public bool IsUseByDateRequired { get; set; }
    public bool HasUseByDate { get; set; }
    public string? QuantityType { get; set; }
    public string? DefaultLabTestingState { get; set; }
    public string? UnitOfMeasureName { get; set; }
    public string? ApprovalStatus { get; set; }
    public DateTime ApprovalStatusDateTime { get; set; }
    public int StrainId { get; set; }
    public string? StrainName { get; set; }
    public int ItemBrandId { get; set; }
    public object? ItemBrandName { get; set; }
    public string? AdministrationMethod { get; set; }
    public object? UnitCbdPercent { get; set; }
    public object? UnitCbdContent { get; set; }
    public object? UnitCbdContentUnitOfMeasureName { get; set; }
    public object? UnitCbdContentDose { get; set; }
    public object? UnitCbdContentDoseUnitOfMeasureName { get; set; }
    public object? UnitThcPercent { get; set; }
    public object? UnitThcContent { get; set; }
    public object? UnitThcContentUnitOfMeasureName { get; set; }
    public object? UnitThcContentDose { get; set; }
    public object? UnitThcContentDoseUnitOfMeasureName { get; set; }
    public object? UnitVolume { get; set; }
    public object? UnitVolumeUnitOfMeasureName { get; set; }
    public object? UnitWeight { get; set; }
    public object? UnitWeightUnitOfMeasureName { get; set; }
    public string? ServingSize { get; set; }
    public object? SupplyDurationDays { get; set; }
    public object? NumberOfDoses { get; set; }
    public object? UnitQuantity { get; set; }
    public object? UnitQuantityUnitOfMeasureName { get; set; }
    public string? PublicIngredients { get; set; }
    public string? Description { get; set; }
    public string? Allergens { get; set; }
    public object[]? ProductImages { get; set; }
    public string? ProductPhotoDescription { get; set; }
    public object[]? LabelImages { get; set; }
    public string? LabelPhotoDescription { get; set; }
    public object[]? PackagingImages { get; set; }
    public string? PackagingPhotoDescription { get; set; }
    public object[]? ProductPDFDocuments { get; set; }
    public bool IsUsed { get; set; }
}
