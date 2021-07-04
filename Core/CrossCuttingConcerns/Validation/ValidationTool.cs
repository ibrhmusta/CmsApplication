using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {

        public static void Validate(IValidator validator,object entity)
        {
            var context = new ValidationContext<object>(entity);           
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(string.Join('\n',result.Errors.Select(error=>error.ErrorMessage)));
            }
        }
    }
}
