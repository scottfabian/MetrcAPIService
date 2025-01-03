using FabToolKit.Api;
using System.Text.Json;

namespace MetrcAPIService;

public class MetrcAPI : ApiServiceBase
{
    public              string?                 FacilityLicense;
    private             string                  userApiKey;
    private             string                  vendorApiKey;
    private             string                  baseURL; 
    private             string                  dateRangeFormat;
    private static      JsonSerializerOptions   _jsonSerializerOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

    public MetrcAPI(string baseUrl, HttpClient httpClient, string vendorApiKey, string userApiKey) : base(baseUrl, httpClient, vendorApiKey, userApiKey)
    {
        this.baseURL = baseUrl;
        this.vendorApiKey = vendorApiKey;
        this.userApiKey = userApiKey;
        this.dateRangeFormat = "yyyy-MM-dd";
    }

    public MetrcAPI(string baseUrl, HttpClient httpClient, string vendorApiKey, string userApiKey, string facilityLicense) : base(baseUrl, httpClient, vendorApiKey, userApiKey)
    {
        this.baseURL = baseUrl;
        this.vendorApiKey = vendorApiKey;
        this.userApiKey = userApiKey;
        this.FacilityLicense = facilityLicense;
        this.dateRangeFormat = "yyyy-MM-dd";
    }

    #region GetRequests


    #region Generic

    private async Task<T> GetEntityByID<T>(string id, string endpoint)
    {
        var request = SetEndpoint(endpoint)
                         .InjectQueryParameter("id", id)
                         .AddFacilityLicense(FacilityLicense);

        var response = await request.GetAsync();

        return ParseAndReturnDTO<T>(response, request);
    }

    private async Task<T> GetEntitiesByDate<T>(string endpoint, DateTime startDate, DateTime endDate, int pageNumber = 1)
    {
        ApiRequestBuilder request = SetEndpoint(endpoint);

        if (!pageNumber.Equals(1))
        {
            request.AddQueryParameter("pageNumber", pageNumber.ToString());
        }

        request.AddFacilityLicense(FacilityLicense)
                                .AddQueryParameter("lastModifiedStart", startDate.ToString(dateRangeFormat))                             
                                .AddQueryParameter("lastModifiedEnd", endDate.ToString(dateRangeFormat));

        var response = await request.GetAsync();

        return ParseAndReturnDTO<T>(response, request);

    }

    #endregion Generic

    #region Items

    public async Task<ItemDTO> GetItemByID(string id)
    {
        return await GetEntityByID<ItemDTO>(id, MetrcEndpoints.GetItemByID);
    }

    public async Task<GenericDataResponseDTO<ItemDTO>> GetActiveItems(int pageNumber = 1)
    {
        ApiRequestBuilder request = SetEndpoint(MetrcEndpoints.GetActiveItems)
                                        .AddFacilityLicense(FacilityLicense);

        if (!pageNumber.Equals(1))
        {
            request.AddQueryParameter("pageNumber", pageNumber.ToString());
        }

        var response = await request.GetAsync();

        return ParseAndReturnDTO<GenericDataResponseDTO<ItemDTO>>(response, request);

    }

    public async Task<GenericDataResponseDTO<ItemDTO>> GetInactiveItems(int pageNumber = 1)
    {
        ApiRequestBuilder request = SetEndpoint(MetrcEndpoints.GetInactiveItems)
                                        .AddFacilityLicense(FacilityLicense);

        if (!pageNumber.Equals(1))
        {
            request.AddQueryParameter("pageNumber", pageNumber.ToString());
        }

        var response = await request.GetAsync();

        return ParseAndReturnDTO<GenericDataResponseDTO<ItemDTO>>(response, request);
    }

    #endregion Items

    #region Packages

    public async Task<PackageDTO> GetPackageByID(string id)
    {
        return await GetEntityByID<PackageDTO>(id, MetrcEndpoints.GetPackageByID);
    }

    public async Task<GenericDataResponseDTO<PackageDTO>> GetActivePackages(DateTime startDate, DateTime endDate, int pageNumber = 1)
    {
        if (pageNumber > 1)
        {
            return await GetEntitiesByDate<GenericDataResponseDTO<PackageDTO>>(MetrcEndpoints.GetActivePackages, startDate, endDate, pageNumber);
        }

        return await GetEntitiesByDate<GenericDataResponseDTO<PackageDTO>>(MetrcEndpoints.GetActivePackages, startDate, endDate);
    } 

    public async Task<GenericDataResponseDTO<PackageDTO>> GetActivePackages(string startDate, string endDate, int pageNumber = 1)
    {
        DateTime startDateTime = Convert.ToDateTime(startDate);
        DateTime endDateTime = Convert.ToDateTime(endDate);

        if (pageNumber > 1)
        {
            return await GetEntitiesByDate<GenericDataResponseDTO<PackageDTO>>(MetrcEndpoints.GetActivePackages, startDateTime, endDateTime, pageNumber);
        }

        return await GetEntitiesByDate<GenericDataResponseDTO<PackageDTO>>(MetrcEndpoints.GetActivePackages, startDateTime, endDateTime);
    }

    public async Task<GenericDataResponseDTO<PackageDTO>> GetInactivePackages(DateTime startDate, DateTime endEndDate, int pageNumber = 1)
    {
        return await GetEntitiesByDate<GenericDataResponseDTO<PackageDTO>>(MetrcEndpoints.GetInactivePackages, startDate, endEndDate, pageNumber);
    }

    public async Task<GenericDataResponseDTO<PackageDTO>> GetInactivePackages(string startDate, string endDate, int pageNumber = 1)
    {
        DateTime startDateTime = Convert.ToDateTime(startDate);
        DateTime endDateTime = Convert.ToDateTime(endDate);

        if (pageNumber > 1)
        {
            return await GetEntitiesByDate<GenericDataResponseDTO<PackageDTO>>(MetrcEndpoints.GetActivePackages, startDateTime, endDateTime, pageNumber);
        }

        return await GetEntitiesByDate<GenericDataResponseDTO<PackageDTO>>(MetrcEndpoints.GetActivePackages, startDateTime, endDateTime);
    }


    #endregion Packages

    #region Harvests

    public async Task<HarvestDTO> GetHarvestByID(string id)
    {
        return await GetEntityByID<HarvestDTO>(id, MetrcEndpoints.GetHarvestByID);
    }

    public async Task<GenericDataResponseDTO<HarvestDTO>> GetActiveHarvests(DateTime startDate, DateTime endDate, int pageNumber = 1)
    {
        if (pageNumber > 1)
        {
            return await GetEntitiesByDate<GenericDataResponseDTO<HarvestDTO>>(MetrcEndpoints.GetActiveHarvests, startDate, endDate, pageNumber);
        }

        return await GetEntitiesByDate<GenericDataResponseDTO<HarvestDTO>>(MetrcEndpoints.GetActiveHarvests, startDate, endDate);
    }

    public async Task<GenericDataResponseDTO<HarvestDTO>> GetActiveHarvests(string startDate, string endDate, int pageNumber = 1)
    {
        DateTime startDateTime = Convert.ToDateTime(startDate);
        DateTime endDateTime = Convert.ToDateTime(endDate);

        if (pageNumber > 1)
        {
            return await GetEntitiesByDate<GenericDataResponseDTO<HarvestDTO>>(MetrcEndpoints.GetActiveHarvests, startDateTime, endDateTime, pageNumber);
        }

        return await GetEntitiesByDate<GenericDataResponseDTO<HarvestDTO>>(MetrcEndpoints.GetActiveHarvests, startDateTime, endDateTime);
    }

    public async Task<GenericDataResponseDTO<HarvestDTO>> GetInactiveHarvests(DateTime startDate, DateTime endDate, int pageNumber = 1)
    {
        return await GetEntitiesByDate<GenericDataResponseDTO<HarvestDTO>>(MetrcEndpoints.GetInactiveHarvests, startDate, endDate);
    }

    #endregion Harvests

    #region LabTests

    public async Task<GenericDataResponseDTO<LabTestBatchDTO>> GetLabTestBatches()
    {
        var request = SetEndpoint(MetrcEndpoints.GetLabTestBatches);

        var response = await request.GetAsync();

        return ParseAndReturnDTO<GenericDataResponseDTO<LabTestBatchDTO>>(response, request);
    }

    public async Task<GenericDataResponseDTO<LabTestTypeDTO>> GetLabTestTypes(int pageNumber = 1)
    {
        var request = SetEndpoint(MetrcEndpoints.GetLabTestTypes)
                            .AddQueryParameter("pageNumber", pageNumber.ToString());

        var response = await request.GetAsync();

        return ParseAndReturnDTO<GenericDataResponseDTO<LabTestTypeDTO>>(response, request);
    }

    public async Task<GenericDataResponseDTO<LabTestResultDTO>> GetLabResultsForPackage(int packageID, int pageNumber = 0)
    {
        var request = SetEndpoint(MetrcEndpoints.GetLabResults)
                        .AddQueryParameter("packageId", packageID.ToString());

        if (pageNumber != 0)
        {
            request.AddQueryParameter("pageNumber", pageNumber.ToString());
        }


        request.AddFacilityLicense(this.FacilityLicense);

        var response = await request.GetAsync();


        return ParseAndReturnDTO<GenericDataResponseDTO<LabTestResultDTO>>(response, request);
    }

    #endregion LabTests

    #region Strains

    public async Task<StrainDTO> GetStrainByID(string id)
    {
        return await GetEntityByID<StrainDTO>(id, MetrcEndpoints.GetStrainByID);
    }

    public async Task<GenericDataResponseDTO<StrainDTO>> GetActiveStrains(int pageNumber = 1)
    {
        ApiRequestBuilder request = SetEndpoint(MetrcEndpoints.GetActiveStrains)
                                        .AddFacilityLicense(FacilityLicense);

        if (!pageNumber.Equals(1))
        {
            request.AddQueryParameter("pageNumber", pageNumber.ToString());
        }

        var response = await request.GetAsync();

        return ParseAndReturnDTO<GenericDataResponseDTO<StrainDTO>>(response, request);
    }

    #endregion Strains


    #region Misc

    public async Task<FacilityDTO[]> GetActiveFacilities()
    {
        var request = SetEndpoint(MetrcEndpoints.GetActiveFacilities);
        var response = await request.GetAsync();

        if (!response.IsSuccessStatusCode)
        {
            ThrowMetrcException(response, request.FullRequestURI);
        }

        return ParseAndReturnDTO<FacilityDTO[]>(response, request);
    }

    #endregion Misc



    #endregion GetRequests

    #region Utilities

    private static T ParseAndReturnDTO<T>(HttpResponseMessage response, ApiRequestBuilder request)
    {
        if (!response.IsSuccessStatusCode)
        {
            ThrowMetrcException(response, request.FullRequestURI);
        }

        string responseContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

        T dto = JsonSerializer.Deserialize<T>(responseContent, _jsonSerializerOptions);
        return dto;
    }

    private static void ThrowMetrcException(HttpResponseMessage response, string requestURI)
    {
        int responseCode = (int)response.StatusCode;
        string content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

        switch (responseCode)
        {
            case 400:
                throw new BadRequestException(response.StatusCode, content, requestURI);
            case 401:
                throw new UnauthorizedRequestException(response.StatusCode, content, requestURI);
            case 403:
                throw new ForbiddenRequestException(response.StatusCode, content, requestURI);
            case 404:
                throw new ResourceNotFoundException(response.StatusCode, content, requestURI);
            case 413:
                throw new ContentTooLargeException(response.StatusCode, content, requestURI);
            case 429:
                throw new TooManyRequestsException(response.StatusCode, content, requestURI);
            case 500:
                throw new InternalServerErrorException(response.StatusCode, content, requestURI);
            default:
                throw new MetrcApiException($"Request returned failure http status code {responseCode.ToString()}, check Metrc documentation for information");
        }
    }

    #endregion Utilities
}