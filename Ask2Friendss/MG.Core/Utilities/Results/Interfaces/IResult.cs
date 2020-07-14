using System;
using System.Collections.Generic;
using System.Text;

namespace MG.Core.Utilities.Results.Interfaces
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
