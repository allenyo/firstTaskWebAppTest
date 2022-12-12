using api1Domain.Models;
using FluentValidation;

namespace api1Domain.Validation
{
    public class ConvertRequestModelValidator : AbstractValidator<ConvertRequestModel>
    {
        public ConvertRequestModelValidator()
        {
            RuleFor(p => p.Value).NotNull();
            RuleFor(p => p.InType).IsInEnum();
            RuleFor(p => p.OutType).IsInEnum();
        }
    }
}
