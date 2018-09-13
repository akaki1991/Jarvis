using System.Collections.Generic;

namespace Domain.DTO.ViewModels
{

   
   public class MobileViewModel
    {
        public int MobileId { get; set; }
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
        public IEnumerable<Photo> Photos { get; set; }
    }
    public class Photo
    {
        public int PhotoId { get; set; }
        public string Base64 { get; set; }
    }
}
