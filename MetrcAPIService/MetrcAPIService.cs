using FabToolKit.Api;
using System.Text.Json;

namespace MetrcAPIService;

public class MetrcAPIService : ApiServiceBase
{
    private string userApiKey;
    private string vendorApiKey;
    private string baseURL;
    public string facilityLicense;


    public MetrcAPIService(string baseUrl, HttpClient httpClient, string vendorApiKey, string userApiKey, string facilityLicense) : base(baseUrl, httpClient, vendorApiKey, userApiKey)
    {
        this.baseURL = baseUrl;
        this.vendorApiKey = vendorApiKey;
        this.userApiKey = userApiKey;
        this.facilityLicense = facilityLicense;
    }

    #region GetRequests

    public async Task<ItemDTO> GetItemByID(string id)
    {
        var response = await SetEndpoint(MetrcEndpoints.GetItemByID)
                                .InjectQueryParameter("id", id)
                                .AddFacilityLicense(facilityLicense)
                                .GetAsync();

        if (!response.IsSuccessStatusCode)
        {
            ThrowMetrcException(response);
        }

        return ParseAndReturnDTO<ItemDTO>(response);
    }

    public async Task<PackageDTO> GetPackageByID(string id)
    {
        var response = await SetEndpoint(MetrcEndpoints.GetPackageByID)
                                .InjectQueryParameter("id", id)
                                .AddFacilityLicense(facilityLicense)
                                .GetAsync();

        return ParseAndReturnDTO<PackageDTO>(response);
    }

    #endregion GetRequests

    #region Utilities

    private static T ParseAndReturnDTO<T>(HttpResponseMessage response)
    {

        string responseContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

        try
        {
            T dto = JsonSerializer.Deserialize<T>(responseContent);
            return dto;
        }
        catch (MetrcApiException)
        {
            ThrowMetrcException(response);
        }
        catch
        {
            throw;
        }

        throw new MetrcApiException("Unknown error, check trace logs for details");
    }

    private static void ThrowMetrcException(HttpResponseMessage response)
    {
        int responseCode = (int)response.StatusCode;
        string content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

        switch (responseCode)
        {
            case 401:
                throw new UnauthorizedRequestException(response.StatusCode, content);
            case 403:
                throw new ForbiddenRequestException(response.StatusCode, content);
            case 404:
                throw new ResourceNotFoundException(response.StatusCode, content);
            case 413:
                throw new ContentTooLargeException(response.StatusCode, content);
            case 429:
                throw new TooManyRequestsException(response.StatusCode, content);
            case 500:
                throw new InternalServerErrorException(response.StatusCode, content);
        }
    }

    #endregion Utilities
}