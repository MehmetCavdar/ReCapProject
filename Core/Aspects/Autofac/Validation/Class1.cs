using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir dogrulama sinifi degil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); // reflektion: calisma aninda birseyleri calistirmanizi saglar
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; // base tipini ilkini bul ve parameterlerini bul
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); //invocation metod demektir
            foreach (var entity in entities)  // bulunan parametrelerin her birini bu tool'u kullanrak valide et
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
