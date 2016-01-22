using System.Collections.Generic;
using Nop.Core.Domain.Catalog;

namespace Nop.Services.Catalog
{
    /// <summary>
    /// Recently viewed products service
    /// </summary>
    public partial interface IProductCitiesService
    {
        /// <summary>
        /// Gets a "recently viewed products" list
        /// </summary>
        /// <param name="number">Number of products to load</param>
        /// <returns>"recently viewed products" list</returns>
        IList<ProductCities> GetProductsCitiesByProductId(int productId);

        ProductCities GetProductsCitiesById(int productcityId);
        /// <summary>
        /// Adds a product to a recently viewed products list
        /// </summary>
        /// <param name="productId">Product identifier</param>
        void AddProductCities(ProductCities productcity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productcity"></param>
        void UpdateProductCities(ProductCities productcity);

        void DeleteProductCities(ProductCities productcity);
    }
}
