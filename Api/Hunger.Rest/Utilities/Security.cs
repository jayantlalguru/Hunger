using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace Hunger.Rest.Utilities
{
    public static class Security
    {
        internal static string Sha512Encryption(string input, Guid salt = new Guid())
        {
            SHA512CryptoServiceProvider sha512 = new SHA512CryptoServiceProvider();
            byte[] bs;
            if (!salt.Equals(new Guid()))
            {
                bs = Encoding.Unicode.GetBytes(input + salt);
            }
            else
            {
                bs = Encoding.Unicode.GetBytes(input);  
            }
                      
            //at this point hash.hash will be the same as HashBytes('sha1', cast('test' as varchar(30)))
            bs = sha512.ComputeHash(bs);
            //OR YOU CAN USE THE BELOW - at this point hash.hash will be the same as HashBytes('sha1', cast('test' as Nvarchar(30)))
            //sha512.ComputeHash(Encoding.ASCII.GetBytes(password));
            
            System.Text.StringBuilder sbuilder = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                sbuilder.Append(b.ToString("x2").ToLower());
            }
            return sbuilder.ToString();
        }
    }
}