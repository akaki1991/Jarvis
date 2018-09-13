using Domain.DAO;
using Domain.DAO.Entities;
using Services.Repository.Interface;

namespace Services.Repository.Concrete
{
    public class MobileRepository : BaseRepository<Mobile>,IMobileRepository
    {
        public MobileRepository(EMobileContext context):base(context)
        {
        }


    }
}
