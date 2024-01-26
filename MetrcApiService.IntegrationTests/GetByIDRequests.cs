namespace MetrcApiService.IntegrationTests;

[TestClass]
public class GetByIDRequests
{
    [TestMethod]
    public void GetItemByID_ValidItemAndCredentials_ShouldReturnRequestedItemDTO()
    {
        //Arrange
        var metrc = TestHelper.InstantiateMetrcAPIService();
        string itemID = "91201";

        //Act
        var itemDTO = metrc.GetItemByID(itemID).GetAwaiter().GetResult();

        //Assert
        bool isCorrectItem = itemDTO.Id == Int32.Parse(itemID);
        Assert.IsTrue(isCorrectItem);
    }

    [TestMethod]
    [ExpectedException(typeof(UnauthorizedRequestException))]
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

    [TestMethod]
    [ExpectedException(typeof(TooManyRequestsException))]
    public void GetItemByID_SendManyRequests_ShouldThrowTooManyRequestsException()
    {
        //Arrange
        var metrc = TestHelper.InstantiateMetrcAPIService();
        string itemID = "91201";

        //Act
        try
        {
            for (int i = 0; i < 100; i++)
            {
                var itemDTO = metrc.GetItemByID(itemID).GetAwaiter().GetResult();
            }
        }
        catch (TooManyRequestsException)
        {
            //Sleep for 5 seconds to clean up the rate at which requests are being sent
            Task.Delay(5000).GetAwaiter().GetResult();
            throw;
        }
        //should throw TooManyRequestsException
    }

    [TestMethod]
    [ExpectedException(typeof(ResourceNotFoundException))]
    public void GetItemByID_IDNotValid_ShouldThrowResourceNotFoundException()
    {
        var metrc = TestHelper.InstantiateMetrcAPIService();
        string itemID = "thisisaninvalidid";

        var itemDTO = metrc.GetItemByID(itemID).GetAwaiter().GetResult();
    }
}