
using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Directory
{
    /// <summary>
    /// Represents a Zipcodes
    /// </summary>
    public partial class Zipcodes : BaseEntity, ILocalizedEntity
    {
        
        /// <summary>
        /// Gets or sets the Zipcodes identifier
        /// </summary>
        public int ZipcodeID { get; set; }

        /// <summary>
        /// Gets or sets the City Name
        /// </summary>
        public string ZipcodeNumber { get; set; }

        /// <summary>
        /// Gets or sets the StateID
        /// </summary>
        public int StateID { get; set; }

        /// <summary>
        /// Gets or sets the StateID
        /// </summary>
        public int CityID { get; set; }

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
        public virtual City City { get; set; }
    }

}
