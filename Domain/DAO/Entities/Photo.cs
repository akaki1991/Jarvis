using System.ComponentModel.DataAnnotations;

namespace Domain.DAO.Entities
{
    public class Photo
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int MobileId { get; set; }
        public Mobile Mobile { get; set; }
    }
}