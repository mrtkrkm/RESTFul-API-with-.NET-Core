﻿using Castle.DynamicProxy;
using MG.Core.CrossCuttingConcerns.Logging;
using MG.Core.CrossCuttingConcerns.Logging.Log4Net;
using MG.Core.Utilities.Interceptors;
using MG.Core.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MG.Core.Aspects.Autofac.Exception
{
    public class ExceptionLogAspect : MethodInterception
    {
        private LoggerServiceBase _loggerServiceBase;

        public ExceptionLogAspect(Type loggerServiceBase)
        {
            if (loggerServiceBase.BaseType != typeof(LoggerServiceBase))
            {
                throw new System.Exception(AspectMessages.WrongLoggerType);
            }

            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerServiceBase);
        }

        protected override void OnException(IInvocation invocation, System.Exception e)
        {
            LogDetailWithException logDetailWithException = GetLogDetail(invocation, e);
            _loggerServiceBase.Error(logDetailWithException);
        }

        private LogDetailWithException GetLogDetail(IInvocation invocation, System.Exception e)
        {
            var logParameters = new List<LogParameter>();
            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i].GetType().Name
                });
            }

            var logDetail = new LogDetailWithException
            {
                MethodName = invocation.Method.Name,
                LogParameters = logParameters,
                ExceptionMessage = e.Message
            };

            return logDetail;
        }
    }
}
