using System;
using System.Collections.Generic;
using System.Text;

namespace MG.Core.CrossCuttingConcerns.Logging
{
    public class LogDetailWithException : LogDetail
    {
        public string ExceptionMessage { get; set; }
    }
}
