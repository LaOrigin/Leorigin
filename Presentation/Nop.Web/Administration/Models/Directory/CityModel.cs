using System.Collections.Generic;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Nop.Admin.Validators.Directory;
using Nop.Web.Framework;
using Nop.Web.Framework.Localization;
using Nop.Web.Framework.Mvc;

namespace Nop.Admin.Models.Directory
{
    [Validator(typeof(CityValidator))]
    public partial class CityModel: BaseNopEntityModel
        , ILocalizedModel<CityLocalizedModel>
    {
        public CityModel() {
            Locales = new List<CityLocalizedModel>();
            this.Countries = new List<SelectListItem>();
            this.States = new List<SelectListItem>();
        }
        public int CityID { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Countries.City.Fields.CityName")]
        [AllowHtml]
        public string CityName { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Countries.City.Fields.Country")]
        public int CountryId { get; set; }
        public IList<SelectListItem> Countries { get; set; }
        [NopResourceDisplayName("Admin.Configuration.Countries.City.Fields.State")]
        [AllowHtml]
        public int StateID { get; set; }

        public string StateName { get; set; }
        public IList<SelectListItem> States { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Countries.City.Fields.IsActive")]
        public bool IsActive { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Countries.City.Fields.IsDeleted")]
        public bool IsDeleted { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Countries.City.Fields.Zipcodes")]
        public string zipcodesbulk { get; set; }

        public IList<CityLocalizedModel> Locales { get; set; }
    }

    public partial class CityLocalizedModel : ILocalizedModelLocal
    {
        public int LanguageId { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Countries.States.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }
    }
}