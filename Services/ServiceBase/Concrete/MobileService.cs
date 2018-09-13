using System.Threading.Tasks;
using Domain.DTO.ServiceModels;
using Microsoft.Extensions.Logging;
using Services.Repository.Concrete;
using Services.Repository.Interface;
using Services.Extensions;
using System;
using Service;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static Domain.DTO.ServiceModels.InsertMobileModel;
using Domain.DAO.Entities;

namespace Services.ServiceBase
{
    public class MobileService : IMobileService
    {
        
        private readonly ILogger<MobileService> _logger;
        private readonly IMobileRepository _mobilieRepository;
        private readonly IPhotoRepository _photoRepository;
        public MobileService(ILogger<MobileService>  logger,
            IMobileRepository mobileRepository,
            IPhotoRepository photoRepository)
        {
            this._mobilieRepository = mobileRepository;
            this._photoRepository = photoRepository;
            this._logger = logger;
        }
        public async Task<BaseResponse> GetMobilelist(GetMobileListRequest request)
        {
            BaseResponse<List<MobileListItem>> response = null;
            try
            {
                var result = await (_mobilieRepository as MobileRepository)
                    .FindBy(x => (x.FilterProductByQueryString(request.QueryString)) && (x.FilterProductByPriceRange(request.PriceFrom, request.PriceTo)))
                    .Include(x=>x.Photos).ToListAsync();
                
                response = BaseResponse.Ok(new List<MobileListItem>());
              
                foreach (var item in result)
                {
                    response.Data.Add(new MobileListItem()
                    {
                        Brand = item.Brand,
                        CPU = item.CPU,
                        InternalMemory = item.InternalMemory,
                        MobileId = item.Id,
                        Name = item.Name,
                        OS = item.OS,
                        Price = item.Price,
                        RAM = item.RAM,
                        ScreenResolution = item.ScreenResolution,
                        ScreenSize = item.ScreenSize,
                        Size = item.Size,
                        VideoUrl = item.VideoUrl,
                        Weight = item.Weight,
                        Photos = (item.Photos as List<Domain.DAO.Entities.Photo>).Select(x=>new Domain.DTO.ServiceModels.Photo() { Base64=x.Value,PhotoId=x.Id}).ToList()


                    });
                }
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                response = BaseResponse.Fail<List<MobileListItem>>(new Error() { Code = ErrorCode.Internal, ErrorMessage = "Could not find products." });
            }
            return response;           
        }

        public async Task<BaseResponse> GetMobile(int id)
        {
            BaseResponse<MobileListItem> response = null;
            try
            {
                var item = await  (_mobilieRepository as MobileRepository).FindBy(m => m.Id == id)
                    .Include(m => m.Photos).SingleOrDefaultAsync();

                var responseItem = new MobileListItem
                {
                    Brand = item.Brand,
                    CPU = item.CPU,
                    InternalMemory = item.InternalMemory,
                    MobileId = item.Id,
                    Name = item.Name,
                    OS = item.OS,
                    Price = item.Price,
                    RAM = item.RAM,
                    ScreenResolution = item.ScreenResolution,
                    ScreenSize = item.ScreenSize,
                    Size = item.Size,
                    VideoUrl = item.VideoUrl,
                    Weight = item.Weight,
                    Photos = (item.Photos as List<Domain.DAO.Entities.Photo>).Select(x => new Domain.DTO.ServiceModels.Photo() { Base64 = x.Value, PhotoId = x.Id }).ToList()

                };

                response = BaseResponse.Ok(responseItem);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                response = BaseResponse.Fail<MobileListItem>(new Error() { Code = ErrorCode.Internal, ErrorMessage = "Could not find product" });
            }

            return response;
        }

        public async Task<BaseResponse> InsertMobile(InsertMobileModel model)
        {
            BaseResponse response = null;
            try
            {
                var repo = (_mobilieRepository as MobileRepository);

                response = BaseResponse.Ok();

                var mobile = new Mobile
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
                    var photo = new Domain.DAO.Entities.Photo()
                    {
                        Value = item.Base64                      
                    };
                    mobile.Photos.Add(photo);
                }

                repo.Add(mobile);

                repo.Save();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = BaseResponse.Fail($"Could not add item");
            }

            return response;         

        }

        public async Task<BaseResponse> DeleteMobile(int id)
        {
            BaseResponse response = null;
            try
            {
                
                var repo = (_mobilieRepository as MobileRepository);
                var result =  repo.FindBy(m => m.Id == id);

                response = BaseResponse.Ok();

                repo.Delete(result as Domain.DAO.Entities.Mobile);
                repo.Save();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = BaseResponse.Fail($"Could not update item");
            }

            return response;
        }

        public async Task<BaseResponse> UpdateMobile(MobileListItem model)
        {
            BaseResponse response = null;

            try
            {
                var repo = (_mobilieRepository as MobileRepository);
                response = BaseResponse.Ok();

                var existingMobile = repo.FindBy(m => m.Id == model.MobileId)
                                 .Include(p => p.Photos)
                                 .SingleOrDefault();
                
                
                if (existingMobile != null)
                {
                    var mobile = new Mobile
                    {
                        Id = model.MobileId,
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

                    repo.Context.Entry(existingMobile).CurrentValues.SetValues(mobile);

                    foreach (var existingPhoto in existingMobile.Photos.ToList())
                    {
                        if (model.Photos.Any(p => p.PhotoId == existingPhoto.Id))
                            repo.Context.Photos.Remove(existingPhoto);
                    }

                    foreach (var photo in model.Photos)
                    {
                        var existingPhoto = existingMobile.Photos
                            .Where(p => p.Id == photo.PhotoId)
                            .SingleOrDefault();

                        if (existingPhoto != null)
                            repo.Context.Entry(existingPhoto).CurrentValues.SetValues(photo);
                        else
                        {
                            var newPhoto = new Domain.DAO.Entities.Photo
                            {
                                Value = photo.Base64
                            };

                            existingMobile.Photos.Add(newPhoto);
                        }            
                    }

                    repo.Context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = BaseResponse.Fail($"Could not update item");
            }

            return response;
        }
        
    }
}
