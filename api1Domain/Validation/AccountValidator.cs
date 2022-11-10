using api1Domain.Models;
using FluentValidation;
using System.Text.RegularExpressions;

namespace api1Domain.Validation
{
    public class AccountValidator : AbstractValidator<Accounts>
    {
        public AccountValidator()
        {
            RuleFor(p => p.UserId).NotEmpty().GreaterThanOrEqualTo(1);
            RuleFor(p => p.Account).NotEmpty().Custom((Account, context) =>
            {
                var Regex = new Regex(@"^(\d{16}|\d{14})");

                if (!Regex.IsMatch(Account.ToString()))
                {
                    context.AddFailure("Invalid account.");
                }

                if (!int.TryParse(Account, out int value))
                {
                    context.AddFailure("Invalid account.");
                }

            });
            RuleFor(p => p.Currency).IsInEnum();
            RuleFor(p=>p.Type).Length(5,20);
        }
    }
}
