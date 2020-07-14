using System;
using System.Collections.Generic;
using System.Text;

namespace MG.Core.Utilities.Results.Interfaces
{
    public interface IDataResult<out T> : IResult
    {
        T Data { get; }
    }
}
