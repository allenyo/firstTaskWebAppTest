using Domain.Models;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Domain.Validation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
         
          /*  RuleFor(x => x.FirstName).Must(p => p == string.Empty || (char.IsUpper(p.Trim()[0]) && !p.Any(p => char.IsDigit(p))));
            RuleFor(x => x.LastName).Must(p => p == string.Empty || (char.IsUpper(p.Trim()[0]) && !p.Any(p => char.IsDigit(p))));
            RuleFor(x => x.Email).Must(p => p == string.Empty || (p.Contains('.') && p.Contains('@') && p.Length > 4));
            RuleFor(x => x.Phone).Must(s => (s == string.Empty) || (s.StartsWith("+") && s.Skip('+').All(char.IsDigit) && s.Length > 4) || (s.All(char.IsDigit) && s.Length > 4));
            RuleFor(x => x.BirthYear).Must(p=> int.TryParse(p, out int pp) && pp<2023 && pp>1920);
            RuleFor(x => x.BirthMonth).Must(p => int.TryParse(p, out int pp) && pp<=12 && pp>0 );
            RuleFor(x => x.BirthDay).Must(x => (x == string.Empty) || Regex.IsMatch(x, @"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$"));
            RuleFor(x => x.Time).LessThanOrEqualTo(DateTime.Now);*/

        }

    }
}
