﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MG.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    public class DatabaseLogger : LoggerServiceBase
    {
        public DatabaseLogger() : base("DatabaseLogger")
        {

        }
    }
}
