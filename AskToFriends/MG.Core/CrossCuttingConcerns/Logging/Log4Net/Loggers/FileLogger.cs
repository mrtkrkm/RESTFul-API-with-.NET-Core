﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MG.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    public class FileLogger : LoggerServiceBase
    {
        public FileLogger() : base("JsonFileLogger")
        {

        }
    }
}
