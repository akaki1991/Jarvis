using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Service;
using Web.Helpers;
using Web.Models;
using Web.Utility;

namespace Web.Controllers
{
    public class AppController : Controller
    {
        private readonly IOptions<AppSettings> _appSettings;

        public AppController(IOptions<AppSettings> appSettings )
        {
            this._appSettings = appSettings;
            ExternalUrlHelper.WebApiUrl = _appSettings.Value.WebApiBaseUrl;
        }
        public async Task<IActionResult> Index()
        {
            FilterParamsViewModel filter = new FilterParamsViewModel();
            var _apiClient = ApiClientFactory.RestClient;
            var collection = new Dictionary<string, object>
            {
                { nameof(filter.PriceFrom), filter.PriceFrom?.ToString() },
                { nameof(filter.PriceTo), filter.PriceTo?.ToString() },
                { nameof(filter.Query), filter.Query?.ToString() }
            };

            var queryString = _apiClient.ToQueryString(collection);

            var data = await _apiClient.GetAsync<BaseResponse<object>>(_apiClient.CreateRequestUri("Products", queryString));           

            var result = JsonConvert.DeserializeObject<List<MobileViewModel>>(data.Data.ToString());

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> FilterProducts([FromForm] FilterParamsViewModel filter)
        {
            var _apiClient = ApiClientFactory.RestClient;
            var collection = new Dictionary<string, object>
            {
                { nameof(filter.PriceFrom), filter.PriceFrom?.ToString() },
                { nameof(filter.PriceTo), filter.PriceTo?.ToString() },
                { nameof(filter.Query), filter.Query?.ToString() }
            };

            var queryString = _apiClient.ToQueryString(collection);

            var data = await _apiClient.GetAsync<BaseResponse<object>>(_apiClient.CreateRequestUri("Products", queryString));

            var result = JsonConvert.DeserializeObject<List<MobileViewModel>>(data.Data.ToString());
            return View("Index",result);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
