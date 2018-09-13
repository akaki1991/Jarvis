using System;
using System.Threading;
using Web.Utility;

namespace Web.Helpers
{
    internal static class ApiClientFactory
    {
        static Uri ApiUrl { get; set; }

        static Lazy<ApiClient> restClient = new Lazy<ApiClient>(() => new ApiClient(ApiUrl), LazyThreadSafetyMode.ExecutionAndPublication);

        public static ApiClient RestClient { get { return restClient.Value; } }
        static ApiClientFactory()
        {
            ApiUrl = new Uri(ExternalUrlHelper.WebApiUrl);
        }
    }
}
