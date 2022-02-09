using Core.CCC.Validation;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Filters.Validation
{
    public class ValidationFilterAttribute : ActionFilterAttribute
    {
        private readonly Type _validatorType;
        public ValidationFilterAttribute(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception("Yanlış doğrulama türü");
            }
            _validatorType = validatorType;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = context.ActionArguments.Select(x => x.Value).Where(x => x.GetType() == entityType);

            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }

            base.OnActionExecuting(context);
        }
    }
}
