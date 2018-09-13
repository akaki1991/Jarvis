using Domain.DAO.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.DAO
{
    public class EMobileContext : DbContext
    {
      

        public EMobileContext(DbContextOptions<EMobileContext> options) : base(options)
        {
        }
        public DbSet<Mobile> Mobiles { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}
