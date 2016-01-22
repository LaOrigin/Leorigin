using System.Collections.Generic;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Nop.Admin.Validators.Directory;
using Nop.Web.Framework;
using Nop.Web.Framework.Localization;
using Nop.Web.Framework.Mvc;

namespace Nop.Admin.Models.Directory
{
    [Validator(typeof(ZipcodeValidator))]
    public partial class ZipcodeModel : BaseNopEntityModel
        //, ILocalizedModel<CityLocalizedModel>
    {
        //public CityLocalizedModel()
        //{
        //    Locales = new List<CityLocalizedModel>();
        //}
        public int ZipcodeID { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Countries.City.Zipcode.Fields.CityName")]
        [AllowHtml]
        public string ZipcodeNumber { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Countries.City.Zipcode.Fields.State")]
        //[AllowHtml]
        public int StateID { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Countries.City.Zipcode.Fields.City")]
        public int CityID { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Countries.City.Zipcode.Fields.IsActive")]
        public bool IsActive { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Countries.City.Zipcode.Fields.IsDeleted")]
        public bool IsDeleted { get; set; }

        //public IList<CityLocalizedModel> Locales { get; set; }
    }

    //public partial class CityLocalizedModel : ILocalizedModelLocal
    //{
    //    public int LanguageId { get; set; }
        
    //    [NopResourceDisplayName("Admin.Configuration.Countries.States.Fields.Name")]
    //    [AllowHtml]
    //    public string Name { get; set; }
    //}
}