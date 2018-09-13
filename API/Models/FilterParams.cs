namespace API.Models
{
    public class FilterParams
    {
        public string Query { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }

    }
}
