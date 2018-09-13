using System.Collections.Generic;

namespace Web.Models
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
        public IEnumerable<PhotoViewModel> Photos { get; set; }
        public class FilterParamsViewModel
        {
            public string Query { get; set; }
            public decimal? PriceFrom { get; set; }
            public decimal? PriceTo { get; set; }
        }
    }
    public class PhotoViewModel
    {
        public int PhotoId { get; set; }
        public string Base64 { get; set; }
    }
}
