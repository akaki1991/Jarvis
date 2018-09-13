using System;
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
    public class ProductsController : Controller
    {
        private readonly IOptions<AppSettings> _appSettings;

        public ProductsController(IOptions<AppSettings> appSettings)
        {
            this._appSettings = appSettings;
            ExternalUrlHelper.WebApiUrl = _appSettings.Value.WebApiBaseUrl;
        }
        
        public async Task<IActionResult> ProductDeteils(int? id)
        {
            var _apiClient = ApiClientFactory.RestClient;

            var data = await _apiClient.GetAsync<BaseResponse<object>>(_apiClient.CreateRequestUri($"Products/{id}"));

            var result = JsonConvert.DeserializeObject<MobileViewModel>(data.Data.ToString());

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody]MobileViewModel model)
        {
            //var _apiClient = ApiClientFactory.RestClient;
            //var result = await _apiClient.PostAsync<object>(_apiClient.CreateRequestUri("Products"), model);
            //throw new Exception();
            return View();
        }
    }
}
