﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MG.Core.Utilities.Security.Common
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
