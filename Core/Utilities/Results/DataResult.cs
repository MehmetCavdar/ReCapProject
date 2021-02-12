using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>  // public  // IDataResult ve Iresult interface inherit 
    {
        public DataResult(T data, bool success, string message) : base(success, message) // resulttan tek farki datasinin olmasi
        {
            Data = data;
        }

        public DataResult(T data, bool success) : base(success) //mesajsiz formati
        {
            Data = data;
        }

        public T Data { get; }
    }
}
