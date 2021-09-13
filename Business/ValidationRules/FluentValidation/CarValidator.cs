using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.DailyPrice).GreaterThan(1);
            RuleFor(c => c.Description).MinimumLength(2);
            RuleFor(c => c.ModelYear).GreaterThanOrEqualTo(2000);
            RuleFor(p => p.Description).Must(ContainsCar).WithMessage("Araba açıklamaları içinde 'car' olmalı ");
        }

        private bool ContainsCar(string arg)
        {
            return arg.Contains("car");
        }
    }
}
