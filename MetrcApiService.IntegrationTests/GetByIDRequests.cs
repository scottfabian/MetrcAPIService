namespace MetrcApiService.IntegrationTests;

[TestClass]
public class GetByIDRequests
{
    [TestMethod]
    public void GetItemByID_ValidItemAndCredentials_ShouldReturnItemDTO()
    {
        //Arrange
        var metrc = MetrcAPIServiceInstantiator.InstantiateMetrcAPIService();
        string itemID = "91201";

        //Act
        var itemDTO = metrc.GetItemByID(itemID).GetAwaiter().GetResult();

        //Assert
        bool isCorrectItem = 
    }

    [TestMethod]
    [ExpectedException(typeof(UnauthorizedAccessException))]
    public void GetItemByID_BadCredentials_ShouldThrowUnauthorizedAccessException()
    {
        string vendorKey = "RxwslAgoPK4YinPORltFssWHCXVnPGdo9JtP0K0BlwiZ52bP";
        string userKey = "wxJMHOyXOyHsNC4QGEadNxBmbJo1ba5JFgfkbExN3ip7z";
        string baseUrl = "https://sandbox-api-mi.metrc.com";
        string facilityLicense = "AU-G-EX-000001";
        var httpClient = new HttpClient();
        string itemID = "91201";

        var metrc = new MetrcAPIService.MetrcAPIService(baseUrl, httpClient, vendorKey, userKey, facilityLicense);

        var item = metrc.GetItemByID(itemID).GetAwaiter().GetResult();

    }
}