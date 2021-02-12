using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T> // public ve DataResult Class inherit
    {
        public SuccessDataResult(T data, string message) : base(data, true, message)
        {
        }
        public SuccessDataResult(T data) : base(data, true) // mesajsiz formati
        {
        }
        public SuccessDataResult(string message) : base(default, true, message)
        {
        }
        public SuccessDataResult() : base(default, true)
        {
        }

    }
}
