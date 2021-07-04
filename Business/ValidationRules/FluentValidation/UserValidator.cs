using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator() {

            RuleFor(u => u.FirstName).NotEmpty().WithMessage(AspectMessages.CAN_NOT_BLANK);
            RuleFor(u => u.FirstName).MinimumLength(2);

            RuleFor(u => u.LastName).NotEmpty().WithMessage(AspectMessages.CAN_NOT_BLANK);
            RuleFor(u => u.LastName).MinimumLength(2);

            RuleFor(u => u.Email).NotEmpty().WithMessage(AspectMessages.CAN_NOT_BLANK);
            RuleFor(u => u.Email).EmailAddress().WithMessage(AspectMessages.INVALID_EMAIL_ADDRESS);
        }
        
    }
}
