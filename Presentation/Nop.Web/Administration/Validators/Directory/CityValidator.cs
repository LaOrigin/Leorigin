using FluentValidation;
using Nop.Admin.Models.Directory;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;

namespace Nop.Admin.Validators.Directory
{
    public class CityValidator : BaseNopValidator<CityModel>
    {
        public CityValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.CityName).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Countries.States.City.Fields.Name.Required"));
            RuleFor(x => x.zipcodesbulk).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Countries.States.City.Fields.Zipcode.Required"));
            RuleFor(x => x.StateID).GreaterThan(0).WithMessage(localizationService.GetResource("Admin.Configuration.Countries.States.City.Fields.State.Required"));
            RuleFor(x => x.CountryId).GreaterThan(0).WithMessage(localizationService.GetResource("Admin.Configuration.Countries.States.City.Fields.Country.Required"));
        }
    }
}