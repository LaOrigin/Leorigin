using FluentValidation;
using Nop.Admin.Models.Directory;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;

namespace Nop.Admin.Validators.Directory
{
    public class ZipcodeValidator : BaseNopValidator<ZipcodeModel>
    {
        public ZipcodeValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.ZipcodeNumber).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Countries.States.Zipcode.Fields.Zipcode.Required"));
        }
    }
}