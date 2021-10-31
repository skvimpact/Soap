using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soap
{
    public class Base64
    {
        public static string Encode(string plainText) =>
            Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));        

        public static string Decode(string base64EncodedData)  =>
            Encoding.UTF8.GetString(Convert.FromBase64String(base64EncodedData));        
    }
}
