using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacija_swe.Controllers
{

    public class Encript
    {
        public static string Key = "adef@@kfxcbv@";

        public static string ConvertToEncrypt(string password)
        {
            if(string.IsNullOrWhiteSpace(password))
             return "";
            password += Key;
            //GetBytes
            //When overridden in a derived class,
            // encodes all the characters in the specified character array into a sequence of bytes.

            //ENCODE
            //Your app might need to encode many input characters to a code page and process the 
            //characters using multiple calls. In this case, you probably need to maintain state between calls, 
            //taking into account the state that is persisted by the Encoder object being used. 
            //(For example, a character sequence that includes surrogate pairs might end with a high surrogate. 
            //The Encoder will remember 
           // that high surrogate so that it can be combined with a low surrogate at the beginning of a following call.

            var passwordBytes = Encoding.UTF8.GetBytes(password);
            //Converts the value of an array of 8-bit unsigned integers to 
            //its equivalent string representation that is encoded with base-64 digits.
            return Convert.ToBase64String(passwordBytes);
        }

        public static string ConverToDecrypt(string base64EncodeData)
        {
            if(string.IsNullOrWhiteSpace(base64EncodeData))
             return "";
            var base64EncodeBytes = Convert.FromBase64String(base64EncodeData);
            var result = Encoding.UTF8.GetString(base64EncodeBytes);
            result = result.Substring(0, result.Length - Key.Length);
            return result;
        }

    }
}