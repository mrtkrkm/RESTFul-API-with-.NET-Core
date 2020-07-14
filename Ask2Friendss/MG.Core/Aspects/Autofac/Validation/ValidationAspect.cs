﻿using Castle.DynamicProxy;
using FluentValidation;
using MG.Core.CrossCuttingConcerns.Validation.FluentValidation;
using MG.Core.Utilities.Interceptors;
using MG.Core.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MG.Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;

        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception(AspectMessages.WrongValidationType);
            }

            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var objType = _validatorType.BaseType.GetGenericArguments()[0];
            var objList = invocation.Arguments.Where(o => o.GetType() == objType);

            foreach (var obj in objList)
            {
                ValidationTool.Validate(validator, obj);
            }
        }
    }
}
