using Domain.DAO;
using Domain.DAO.Entities;
using Services.Repository.Interface;

namespace Services.Repository.Concrete
{
    public class PhotoRepository:BaseRepository<Photo>,IPhotoRepository
    {
        public PhotoRepository(EMobileContext context):base(context)
        {
                
        }
    }
}
