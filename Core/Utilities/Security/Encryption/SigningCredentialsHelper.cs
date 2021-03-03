using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {

        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)  // elimizdeki secuyort kullan
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature); //anahtar olarak bu keyi kullan, sifrelem olarak ta güvenlik algortmalarindan hmac 512 kullan
        }

    }
}
