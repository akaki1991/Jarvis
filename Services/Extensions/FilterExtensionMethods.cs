using Domain.DAO.Entities;

namespace Services.Extensions
{
    public static class FilterExtensionMethods
    {
        public static bool FilterProductByQueryString(this Mobile product,string query)
        {
            if (string.IsNullOrEmpty(query))
                return true;
            else
               query = query.ToLower().Trim();

            if (product.Name.ToLowerInvariant().Contains(query)
                || product.OS.ToLowerInvariant().Contains(query)
                || product.InternalMemory.ToLowerInvariant().Contains(query)
                || product.RAM.ToLowerInvariant().Contains(query)
                || product.ScreenResolution.ToLowerInvariant().Contains(query)
                || product.Size.ToLowerInvariant().Contains(query)
                || product.Weight.ToLowerInvariant().Contains(query)
                || product.Brand.ToLowerInvariant().Contains(query)
                || product.CPU.ToLowerInvariant().Contains(query))
                return true;
            else
                return false;
        }

        public static bool FilterProductByPriceRange(this Mobile product, decimal? priceFrom,decimal? priceTo)
        {
            priceFrom = priceFrom ?? 0;
            priceTo = priceTo ?? decimal.MaxValue;

            if (product.Price > priceFrom.Value && product.Price < priceTo.Value)
                return true;
            return false;
        }
    }
}
