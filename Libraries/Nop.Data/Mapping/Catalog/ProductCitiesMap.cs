using Nop.Core.Domain.Catalog;

namespace Nop.Data.Mapping.Catalog
{
    public partial class ProductCitiesMap : NopEntityTypeConfiguration<ProductCities>
    {
        public ProductCitiesMap()
        {
            this.ToTable("ProductCities");
            this.HasKey(c => c.Id);
        }
    }
}