using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Firstname).NotEmpty();
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.Password).Must(PasswordRules).WithMessage("Parolanızda kullandığınız karakterler uyumsuz.");
            RuleFor(u => u.Email).NotEmpty();
        }

        private bool PasswordRules(string arg)
        {
            bool result =
            arg.Any(c => char.IsLetter(c)) &&
            arg.Any(c => char.IsDigit(c)) &&
            arg.Any(c => char.IsSymbol(c));
            return result;
        }
    }
}
