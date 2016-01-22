namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// Represents a Product Cities
    /// </summary>
    public partial class ProductCities : BaseEntity
    {
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the  City identifier
        /// </summary>
        public int CityID { get; set; }

        /// <summary>
        /// Gets or sets the  product identifier
        /// </summary>
        public int ProductID { get; set; }

    }

}
