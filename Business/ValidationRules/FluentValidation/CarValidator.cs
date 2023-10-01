using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator() 
        { 
            RuleFor(c=>c.ModelYear).NotEmpty();
            RuleFor(c=>c.ModelYear).GreaterThan(2015);
            RuleFor(c=>c.BrandId).NotEmpty();
            RuleFor(c=>c.ColorId).NotEmpty();
            RuleFor(c=>c.DailyPrice).NotEmpty();
            RuleFor(c=>c.DailyPrice).GreaterThan(0);
            RuleFor(c=>c.Description).MinimumLength(5);
            RuleFor(c => c.Description).Must(StartWithA).WithMessage("Açıklama A harfi ile başlamaldıır");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
