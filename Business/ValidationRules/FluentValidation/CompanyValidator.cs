using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            //RuleFor(company => company.Name).NotEmpty();
            RuleFor(company => company.Name).MinimumLength(3).WithMessage("Şirket adı 3 karakterden az olamaz");
        }
    }
}
