using System.Text.Json;

namespace MetrcApiService.IntegrationTests;

[TestClass]
public class GetByIDRequests
{
    [TestMethod]
    public void GetItemByID_ValidItemAndCredentials_ShouldReturnRequestedItemDTO()
    {
        //Arrange
        string jsonFromPostman = @"{""Id"":91201,""Name"":""Buds Item"",""ProductCategoryName"":""Buds"",""ProductCategoryType"":""Buds"",""IsExpirationDateRequired"":false,""HasExpirationDate"":false,""IsSellByDateRequired"":false,""HasSellByDate"":false,""IsUseByDateRequired"":false,""HasUseByDate"":false,""QuantityType"":""WeightBased"",""DefaultLabTestingState"":""NotSubmitted"",""UnitOfMeasureName"":""Grams"",""ApprovalStatus"":""Approved"",""ApprovalStatusDateTime"":""2023-08-04T18:51:25+00:00"",""StrainId"":64301,""StrainName"":""Good Land"",""ItemBrandId"":0,""ItemBrandName"":null,""AdministrationMethod"":"""",""UnitCbdPercent"":null,""UnitCbdContent"":null,""UnitCbdContentUnitOfMeasureName"":null,""UnitCbdContentDose"":null,""UnitCbdContentDoseUnitOfMeasureName"":null,""UnitThcPercent"":null,""UnitThcContent"":null,""UnitThcContentUnitOfMeasureName"":null,""UnitThcContentDose"":null,""UnitThcContentDoseUnitOfMeasureName"":null,""UnitVolume"":null,""UnitVolumeUnitOfMeasureName"":null,""UnitWeight"":null,""UnitWeightUnitOfMeasureName"":null,""ServingSize"":"""",""SupplyDurationDays"":null,""NumberOfDoses"":null,""UnitQuantity"":null,""UnitQuantityUnitOfMeasureName"":null,""PublicIngredients"":"""",""Description"":"""",""Allergens"":"""",""ProductImages"":[],""ProductPhotoDescription"":"""",""LabelImages"":[],""LabelPhotoDescription"":"""",""PackagingImages"":[],""PackagingPhotoDescription"":"""",""ProductPDFDocuments"":[],""IsUsed"":false}";
        ItemDTO itemDtoFromPostman = JsonSerializer.Deserialize<ItemDTO>(jsonFromPostman);
        var metrc = TestHelper.InstantiateMetrcAPIService();
        string itemID = "91201";

        //Act
        var itemDTO = metrc.GetItemByID(itemID).GetAwaiter().GetResult();

        //Assert
        bool isCorrectItem = TestHelper.AreObjectsEqual(itemDTO, itemDtoFromPostman);
        Assert.IsTrue(isCorrectItem);
    }

    [TestMethod]
    public void GetPackageByID_ValidItemAndCredentials_ShouldReturnRequestedPackageDTO()
    {
        //Arrange
        string jsonFromPostman = @"{""Id"":98203,""Label"":""1A4FF0300000515000000039"",""PackageType"":""Product"",""SourceHarvestCount"":1,""SourcePackageCount"":1,""SourceProcessingJobCount"":0,""SourceHarvestNames"":""2023-10-06 - TEKLYNX"",""SourcePackageLabels"":""1A4FF0300000515000000036"",""LocationId"":84801,""LocationName"":""TEKLYNX Updated Location Name"",""LocationTypeName"":""Default Location Type"",""Quantity"":0.0000,""UnitOfMeasureName"":""Grams"",""UnitOfMeasureAbbreviation"":""g"",""PatientLicenseNumber"":"""",""ItemFromFacilityLicenseNumber"":""AU-G-EX-000001"",""ItemFromFacilityName"":""MI AU Excess Grower 1"",""Note"":""TEKLYNX"",""PackagedDate"":""2023-10-11"",""ExpirationDate"":null,""SellByDate"":null,""UseByDate"":null,""InitialLabTestingState"":""NotSubmitted"",""LabTestingState"":""NotSubmitted"",""LabTestingStateDate"":""2023-10-11"",""LabTestResultExpirationDateTime"":null,""LabTestingRecordedDate"":null,""IsProductionBatch"":false,""ProductionBatchNumber"":"""",""SourceProductionBatchNumbers"":"""",""IsTradeSample"":false,""IsTradeSamplePersistent"":false,""SourcePackageIsTradeSample"":false,""IsDonation"":false,""IsDonationPersistent"":false,""SourcePackageIsDonation"":false,""IsTestingSample"":false,""IsProcessValidationTestingSample"":false,""ProductRequiresRemediation"":false,""ContainsRemediatedProduct"":false,""RemediationDate"":null,""ReceivedDateTime"":null,""ReceivedFromManifestNumber"":null,""ReceivedFromFacilityLicenseNumber"":null,""ReceivedFromFacilityName"":null,""IsOnHold"":false,""ArchivedDate"":null,""FinishedDate"":null,""IsOnTrip"":false,""IsOnRetailerDelivery"":false,""PackageForProductDestruction"":null,""LastModified"":""2023-10-11T18:56:40+00:00"",""Item"":{""Id"":93701,""Name"":""TEKLYNX New Buds Item"",""ProductCategoryName"":""Buds"",""ProductCategoryType"":""Buds"",""IsExpirationDateRequired"":false,""HasExpirationDate"":false,""IsSellByDateRequired"":false,""HasSellByDate"":false,""IsUseByDateRequired"":false,""HasUseByDate"":false,""QuantityType"":""WeightBased"",""DefaultLabTestingState"":""NotSubmitted"",""UnitOfMeasureName"":""Grams"",""ApprovalStatus"":""Approved"",""ApprovalStatusDateTime"":""2023-10-11T16:14:50+00:00"",""StrainId"":41901,""StrainName"":""Beginning Inventory Strain"",""ItemBrandId"":0,""ItemBrandName"":null,""AdministrationMethod"":"""",""UnitCbdPercent"":null,""UnitCbdContent"":null,""UnitCbdContentUnitOfMeasureName"":null,""UnitCbdContentDose"":null,""UnitCbdContentDoseUnitOfMeasureName"":null,""UnitThcPercent"":null,""UnitThcContent"":null,""UnitThcContentUnitOfMeasureName"":null,""UnitThcContentDose"":null,""UnitThcContentDoseUnitOfMeasureName"":null,""UnitVolume"":null,""UnitVolumeUnitOfMeasureName"":null,""UnitWeight"":null,""UnitWeightUnitOfMeasureName"":null,""ServingSize"":"""",""SupplyDurationDays"":null,""NumberOfDoses"":null,""UnitQuantity"":null,""UnitQuantityUnitOfMeasureName"":null,""PublicIngredients"":"""",""Description"":"""",""Allergens"":"""",""ProductImages"":[],""ProductPhotoDescription"":"""",""LabelImages"":[],""LabelPhotoDescription"":"""",""PackagingImages"":[],""PackagingPhotoDescription"":"""",""ProductPDFDocuments"":[],""IsUsed"":false}}";
        PackageDTO packageDtoFromPostman = JsonSerializer.Deserialize<PackageDTO>(jsonFromPostman);
        var metrc = TestHelper.InstantiateMetrcAPIService();
        string packageID = "98203";

        //Act
        var packageDTO = metrc.GetPackageByID(packageID).GetAwaiter().GetResult();

        //Assert
        bool isCorrectPackage = TestHelper.AreObjectsEqual<PackageDTO>(packageDTO, packageDtoFromPostman);
        Assert.IsTrue(isCorrectPackage);
    }
}