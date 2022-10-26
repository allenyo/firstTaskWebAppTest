using api1Domain.Models;
using FluentValidation;

namespace api1Domain.Validation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(m => m.Model).NotEmpty().MinimumLength(1).MaximumLength(45);
            RuleFor(m => m.Year).GreaterThanOrEqualTo(1960).LessThanOrEqualTo(2025);
            RuleFor(m => m.Make).NotEmpty().MinimumLength(1).MaximumLength(15);
            RuleFor(m => m.EngineType).NotEmpty().MinimumLength(3).MaximumLength(10);
            RuleFor(m=>m.GearboxType).NotEmpty().MinimumLength(1).MaximumLength(15);    

        }
    }
}
