using FabToolKit.Api;
using System.Text.Json;

namespace MetrcAPIService;

public class MetrcAPIService : ApiServiceBase
{
    private string userApiKey;
    private string vendorApiKey;
    private string baseURL;
    public string facilityLicense;
    private string dateRangeFormat;


    public MetrcAPIService(string baseUrl, HttpClient httpClient, string vendorApiKey, string userApiKey, string facilityLicense) : base(baseUrl, httpClient, vendorApiKey, userApiKey)
    {
        this.baseURL = baseUrl;
        this.vendorApiKey = vendorApiKey;
        this.userApiKey = userApiKey;
        this.facilityLicense = facilityLicense;
        this.dateRangeFormat = "yyyy-MM-dd";
    }

    #region GetRequests

    #region Generic

    private async Task<T> GetEntityByID<T>(string id, string endpoint)
    {
        var response = await SetEndpoint(endpoint)
                                .InjectQueryParameter("id", id)
                                .AddFacilityLicense(facilityLicense)
                                .GetAsync();

        if (!response.IsSuccessStatusCode)
        {
            ThrowMetrcException(response);
        }

        return ParseAndReturnDTO<T>(response);
    }

    private async Task<T> GetEntitiesByDate<T>(string endpoint, DateTime startDate, DateTime endDate, int pageNumber = 0)
    {
        ApiRequestBuilder request = SetEndpoint(endpoint);

        if (!pageNumber.Equals(0))
        {
            request.AddQueryParameter("pageNumber", pageNumber.ToString());
        }

        //var response = await request.AddQueryParameter("lastModifiedStart", startDate.ToString(dateRangeFormat))
        //                        .AddFacilityLicense(facilityLicense)
        //                        .AddQueryParameter("lastModifiedEnd", endDate.ToString(dateRangeFormat))
        //                        .GetAsync();

        request.AddFacilityLicense(facilityLicense)
                                .AddQueryParameter("lastModifiedStart", startDate.ToString(dateRangeFormat))                             
                                .AddQueryParameter("lastModifiedEnd", endDate.ToString(dateRangeFormat));

        var response = await request.GetAsync();

        if (!response.IsSuccessStatusCode)
        {
            ThrowMetrcException(response);
            //will throw exception, no need for return
        }

        return ParseAndReturnDTO<T>(response);

    }

    #endregion Generic

    #region Items

    public async Task<ItemDTO> GetItemByID(string id)
    {
        return await GetEntityByID<ItemDTO>(id, MetrcEndpoints.GetItemByID);
    }

    #endregion Items

    #region Packages

    public async Task<PackageDTO> GetPackageByID(string id)
    {
        return await GetEntityByID<PackageDTO>(id, MetrcEndpoints.GetPackageByID);
    }

    public async Task<GetPackagesByDateDTO> GetActivePackages(DateTime startDate, DateTime endDate, int pageNumber = 0)
    {
        if (pageNumber > 0)
        {
            return await GetEntitiesByDate<GetPackagesByDateDTO>(MetrcEndpoints.GetActivePackages, startDate, endDate, pageNumber);
        }

        return await GetEntitiesByDate<GetPackagesByDateDTO>(MetrcEndpoints.GetActivePackages, startDate, endDate);
    }

    public async Task<GetPackagesByDateDTO> GetActivePackages(string startDate, string endDate, int pageNumber = 0)
    {
        DateTime startDateTime = Convert.ToDateTime(startDate);
        DateTime endDateTime = Convert.ToDateTime(endDate);

        if (pageNumber > 0)
        {
            return await GetEntitiesByDate<GetPackagesByDateDTO>(MetrcEndpoints.GetActivePackages, startDateTime, endDateTime, pageNumber);
        }

        return await GetEntitiesByDate<GetPackagesByDateDTO>(MetrcEndpoints.GetActivePackages, startDateTime, endDateTime);
    }

    #endregion Packages

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
            case 400:
                throw new BadRequestException(response.StatusCode, content);
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
            default:
                throw new Exception($"Request returned failure http status code {responseCode.ToString()}, check Metrc documentation for information");
        }
    }

    #endregion Utilities
}