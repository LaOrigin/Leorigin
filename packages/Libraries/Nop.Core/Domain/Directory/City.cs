
using Nop.Core.Domain.Localization;
using System.Collections.Generic;
using Nop.Core.Domain.Catalog;

namespace Nop.Core.Domain.Directory
{
    /// <summary>
    /// Represents a City
    /// </summary>
    public partial class City : BaseEntity, ILocalizedEntity
    {
        private ICollection<Zipcodes> _zipcodes;
        private ICollection<Product> _appliedToProducts;
        
        /// <summary>
        /// Gets or sets the City identifier
        /// </summary>
        public int CityID { get; set; }

        /// <summary>
        /// Gets or sets the City Name
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// Gets or sets the StateID
        /// </summary>
        public int StateID { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is IsActive
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the IsDeleted
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the country
        /// </summary>
        public virtual StateProvince StateProvince { get; set; }

        public virtual ICollection<Zipcodes> Zipcodes
        {
            get { return _zipcodes ?? (_zipcodes = new List<Zipcodes>()); }
            protected set { _zipcodes = value; }
        }
        public virtual ICollection<Product> ProductApplied
        {
            get { return _appliedToProducts ?? (_appliedToProducts = new List<Product>()); }
            protected set { _appliedToProducts = value; }
        }
    }

}
