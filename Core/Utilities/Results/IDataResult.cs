using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T> : IResult  // public, T herhangi tipte veri dönecek ve Inherit (mesajlardan faydalanacak)
    {
        T Data { get; }
    }
}
