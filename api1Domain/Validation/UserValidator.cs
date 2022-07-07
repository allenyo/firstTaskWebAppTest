using api1Domain.Models;
using FluentValidation;
using System.Text.RegularExpressions;

namespace api1Domain.Validation
{
   public class UserValidator : AbstractValidator<User>
    {

        public UserValidator()
        {
          
            RuleFor(x => x.FullName).Must(p => p == string.Empty || (p.Contains(' ') && char.IsUpper(p.Split(" ", 
                StringSplitOptions.RemoveEmptyEntries)[0].ElementAt(0)) && char.IsUpper(p.Split(" ",
                StringSplitOptions.RemoveEmptyEntries)[1].ElementAt(0)) && !p.Any(p=> char.IsDigit(p))) );
            RuleFor(x => x.Email).Must(p => p == string.Empty || (p.Contains('.') && p.Contains('@') && p.Length>4));
            RuleFor(x => x.Phone).Must(s => (s == string.Empty) || (s.StartsWith("+") && s.Skip('+').All(char.IsDigit) && s.Length > 4) || (s.All(char.IsDigit) && s.Length > 4));
            RuleFor(x => x.Time).LessThanOrEqualTo(DateTime.Now);
            RuleFor(x => x.BirthDay).Must(x => (x == string.Empty) || Regex.IsMatch(x, @"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$"));  

        }
    }
}
