using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.DAO.Entities
{
    public class Mobile
    {
        public int Id { get; set; }
        [MaxLength(15)]
        public string Name { get; set; }
        [MaxLength(15)]
        public string Brand { get; set; }
        [MaxLength(30)]
        public string Size { get; set; }
        [MaxLength(10)]
        public string Weight { get; set; }
        [MaxLength(30)]
        public string ScreenSize { get; set; }
        [MaxLength(30)]
        public string ScreenResolution { get; set; }
        [MaxLength(15)]
        public string CPU { get; set; }
        [MaxLength(15)]
        public string RAM { get; set; }
        [MaxLength(15)]
        public string InternalMemory { get; set; }
        [MaxLength(30)]
        public string OS { get; set; }
        public decimal Price { get; set; }
        public string VideoUrl { get; set; }
        public IList<Photo> Photos { get; set; }
    }
}
