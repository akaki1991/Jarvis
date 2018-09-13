namespace Web.Models
{
    public class FilterParamsViewModel
    {
            public string Query { get; set; }
            public decimal? PriceFrom { get; set; }
            public decimal? PriceTo { get; set; }        
    }
}
