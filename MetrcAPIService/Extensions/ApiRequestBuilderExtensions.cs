using FabToolKit.Api;

namespace MetrcAPIService;

public static class ApiRequestBuilderExtensions
{
    public static ApiRequestBuilder AddFacilityLicense(this ApiRequestBuilder builder, string facilityLicense)
    {
        return builder.AddQueryParameter("licenseNumber", facilityLicense);
    }
}
