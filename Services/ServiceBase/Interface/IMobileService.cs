using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.DTO.ServiceModels;
using Service;

namespace Services.ServiceBase
{
    public interface IMobileService
    {
        Task<BaseResponse> GetMobilelist(GetMobileListRequest request);
        Task<BaseResponse> GetMobile(int id);
        Task<BaseResponse> InsertMobile(InsertMobileModel model);
        Task<BaseResponse> DeleteMobile(int id);
        Task<BaseResponse> UpdateMobile(MobileListItem model);
    }
}