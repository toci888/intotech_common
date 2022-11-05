using System.Security.Cryptography;
using System.Text;

namespace Intotech.Common;

public class HashGenerator
{
    public static string Md5(string text)
    {
        if (text == null)
        {
            return null;
        }

        // Creates an instance of the default implementation of the MD5 hash algorithm.
        using (var md5Hash = MD5.Create())
        {
            // Byte array representation of source string
            var sourceBytes = Encoding.UTF8.GetBytes(text);

            // Generate hash value(Byte Array) for input data
            var hashBytes = md5Hash.ComputeHash(sourceBytes);

            // Convert hash byte array to string
            var hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);

            return hash;
        }
    }
}
