using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.ServiceModels
{
    public class InsertMobileModel
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Size { get; set; }
        public string Weight { get; set; }
        public string ScreenSize { get; set; }
        public string ScreenResolution { get; set; }
        public string CPU { get; set; }
        public string RAM { get; set; }
        public string InternalMemory { get; set; }
        public string OS { get; set; }
        public decimal Price { get; set; }
        public string VideoUrl { get; set; }
        public ICollection<Photo> Photos { get; set; }        
    }
        
}
