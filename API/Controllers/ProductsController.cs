using System.Threading.Tasks;
using API.Models;
using Domain.DTO.ServiceModels;
using Domain.DTO.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Service;
using Services.ServiceBase;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IMobileService _mobileService;
        public ProductsController(IMobileService mobileService)
        {
            this._mobileService = mobileService;
        }

        /// <summary>
        /// This list all details
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<BaseResponse> Get(FilterParams parameters)
        {
            GetMobileListRequest request = new GetMobileListRequest()
            {
                QueryString = parameters.Query,
                PriceFrom = parameters.PriceFrom ?? null,
                PriceTo = parameters.PriceTo ?? null
            };
            return  await _mobileService.GetMobilelist(request);

        }
        
        /// <summary>
        /// This will provide details for spesific ID which is beeing passed
        /// </summary>
        /// <param name="id">Mandatory</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<BaseResponse> Get(int id)
        {
            return await _mobileService.GetMobile(id);
        }
        /// <summary>
        /// This will insert new Item
        /// </summary>
        /// <param name="model">Mandatory</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<BaseResponse> Post([FromBody]MobileViewModel model)
        {
            
                InsertMobileModel insertModel = new InsertMobileModel
                {
                    Brand = model.Brand,
                    CPU = model.CPU,
                    InternalMemory = model.InternalMemory,
                    Name = model.Name,
                    OS = model.OS,
                    Price = model.Price,
                    RAM = model.RAM,
                    ScreenResolution = model.ScreenResolution,
                    ScreenSize = model.ScreenSize,
                    Size = model.Size,
                    VideoUrl = model.VideoUrl,
                    Weight = model.Weight
                };

                foreach (var item in model.Photos)
                {
                    Domain.DTO.ServiceModels.Photo photo = new Domain.DTO.ServiceModels.Photo
                    {
                        Base64 = item.Base64,
                        PhotoId = item.PhotoId
                    };
                    insertModel.Photos.Add(photo);
                }

                return await _mobileService.InsertMobile(insertModel);
            
        }
        /// <summary>
        /// This will Update existing item with ID and provided fields
        /// </summary>
        /// <param name="id">Mandatory</param>
        /// <param name="model">Mandatory</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public Task<BaseResponse> Put(int id, [FromBody] MobileViewModel model)
        {
            MobileListItem updateModel = new MobileListItem
            {
                Brand = model.Brand,
                CPU = model.CPU,
                InternalMemory = model.InternalMemory,
                Name = model.Name,
                OS = model.OS,
                Price = model.Price,
                RAM = model.RAM,
                ScreenResolution = model.ScreenResolution,
                ScreenSize = model.ScreenSize,
                Size = model.Size,
                VideoUrl = model.VideoUrl,
                Weight = model.Weight
            };

            foreach (var item in model.Photos)
            {
                Domain.DTO.ServiceModels.Photo photo = new Domain.DTO.ServiceModels.Photo
                {
                    Base64 = item.Base64,
                    PhotoId = item.PhotoId
                };
                updateModel.Photos.Add(photo);
            }

            return _mobileService.UpdateMobile(updateModel);
        }

        /// <summary>
        /// This will remove item by the provided ID 
        /// </summary>
        /// <param name="id">Mandatory</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _mobileService.DeleteMobile(id);
        }

    }
}
