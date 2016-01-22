using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nop.Core.Domain.Catalog;
using Nop.Core.Data;

namespace Nop.Services.Catalog
{
    /// <summary>
    /// Recently viewed products service
    /// </summary>
    public partial class ProductCitiesService : IProductCitiesService
    {
        #region Fields

        private readonly HttpContextBase _httpContext;
        private readonly IProductService _productService;
        private readonly IRepository<ProductCities> _productCitiesRepository;
        private readonly CatalogSettings _catalogSettings;

        #endregion

        #region Ctor
        
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="httpContext">HTTP context</param>
        /// <param name="productService">Product service</param>
        /// <param name="catalogSettings">Catalog settings</param>
        public ProductCitiesService(HttpContextBase httpContext, IProductService productService,IRepository<ProductCities> productCitiesRepository,
            CatalogSettings catalogSettings)
        {
            this._httpContext = httpContext;
            this._productService = productService;
            this._productCitiesRepository = productCitiesRepository;
            this._catalogSettings = catalogSettings;
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Gets a "recently viewed products" identifier list
        /// </summary>
        /// <returns>"recently viewed products" list</returns>
        protected IList<int> GetRecentlyViewedProductsIds()
        {
            return GetRecentlyViewedProductsIds(int.MaxValue);
        }

        /// <summary>
        /// Gets a "recently viewed products" identifier list
        /// </summary>
        /// <param name="number">Number of products to load</param>
        /// <returns>"recently viewed products" list</returns>
        protected IList<int> GetRecentlyViewedProductsIds(int number)
        {
            var productIds = new List<int>();
            var recentlyViewedCookie = _httpContext.Request.Cookies.Get("NopCommerce.RecentlyViewedProducts");
            if (recentlyViewedCookie == null)
                return productIds;
            string[] values = recentlyViewedCookie.Values.GetValues("RecentlyViewedProductIds");
            if (values == null)
                return productIds;
            foreach (string productId in values)
            {
                int prodId = int.Parse(productId);
                if (!productIds.Contains(prodId))
                {
                    productIds.Add(prodId);
                    if (productIds.Count >= number)
                        break;
                }

            }

            return productIds;
        }

        #endregion

        #region Methods


        /// <summary>
        /// Gets a "recently viewed products" list
        /// </summary>
        /// <param name="number">Number of products to load</param>
        /// <returns>"recently viewed products" list</returns>
        public virtual IList<ProductCities> GetProductsCitiesByProductId(int productId)
        {
            //var products = new List<Product>();
            //var productIds = GetRecentlyViewedProductsIds(number);
            //foreach (var product in _productService.GetProductsByIds(productIds.ToArray()))
            //    if (product.Published && !product.Deleted)
            //        products.Add(product);
            if (productId == 0) {
                return null;
            }
            var r = _productCitiesRepository.Table;
            r= r.Where(x => x.ProductID == productId);
            return r.ToList();
        }
        public virtual void AddProductCities(ProductCities productcity) {
            if (productcity == null)
                throw new ArgumentNullException("productcity");
            //insert
            _productCitiesRepository.Insert(productcity);
        }
        public virtual void UpdateProductCities(ProductCities productcity)
        {
            if (productcity == null)
                throw new ArgumentNullException("productcity");
            //update
            _productCitiesRepository.Update(productcity);
        }

        public virtual void DeleteProductCities(ProductCities productcity) {

            if (productcity == null)
                throw new ArgumentNullException("productcity");
            //delete
            _productCitiesRepository.Delete(productcity);
        }

        public virtual ProductCities GetProductsCitiesById(int productcityId)
        {
            if (productcityId == 0)
                throw new ArgumentNullException("productcityID");
           var r= _productCitiesRepository.GetById(productcityId);
           return r;
        }
        /// <summary>
        /// Adds a product to a recently viewed products list
        /// </summary>
        /// <param name="productId">Product identifier</param>
        //public virtual void AddProductToRecentlyViewedList(int productId)
        //{
        //    if (!_catalogSettings.RecentlyViewedProductsEnabled)
        //        return;

        //    var oldProductIds = GetRecentlyViewedProductsIds();
        //    var newProductIds = new List<int>();
        //    newProductIds.Add(productId);
        //    foreach (int oldProductId in oldProductIds)
        //        if (oldProductId != productId)
        //            newProductIds.Add(oldProductId);

        //    var recentlyViewedCookie = _httpContext.Request.Cookies.Get("NopCommerce.RecentlyViewedProducts");
        //    if (recentlyViewedCookie == null)
        //    {
        //        recentlyViewedCookie = new HttpCookie("NopCommerce.RecentlyViewedProducts");
        //        recentlyViewedCookie.HttpOnly = true;
        //    }
        //    recentlyViewedCookie.Values.Clear();
        //    int maxProducts = _catalogSettings.RecentlyViewedProductsNumber;
        //    if (maxProducts <= 0)
        //        maxProducts = 10;
        //    int i = 1;
        //    foreach (int newProductId in newProductIds)
        //    {
        //        recentlyViewedCookie.Values.Add("RecentlyViewedProductIds", newProductId.ToString());
        //        if (i == maxProducts)
        //            break;
        //        i++;
        //    }
        //    recentlyViewedCookie.Expires = DateTime.Now.AddDays(10.0);
        //    _httpContext.Response.Cookies.Set(recentlyViewedCookie);
        //}
        
        #endregion
    }
}
