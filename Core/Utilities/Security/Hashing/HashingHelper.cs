using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper  //ciplak kalabilir
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())  // kullanilacak algortima
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); // string gelen passwordun byte degerini buraya vermeliyiz
            }
        }
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt) // out iptal
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)) // burada Önceki salti göndermeliyiz
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));  // dizilerin degerlerini karslastiracagiz

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }

                }
            }
            return true;
        }
    }

}
