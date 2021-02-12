using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result :IResult   // public ve Iresult ile inherit
    {

        public Result(bool success, string message): this(success)   //bu durumda aşağıdaki ayni isimdeki tek parametreli constructor da çalışır 
        {
            Message = message;  // set edilemez demistik get'ler constructor icinde set edilebilir
                                //Success = success;  // buradan silebiliriz- cünkü assagida zaten calisiyor. gerek yok        }
        }

            public Result(bool success) // bu yapi hem tek başına hem de yukarıdaki yapı çalıştığında çalışır
            {
                Success = success;
            }

        public bool Success { get; }  // DIKKAT

        public string Message { get; }


    }
}
