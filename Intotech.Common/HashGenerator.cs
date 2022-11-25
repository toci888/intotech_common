using System.Security.Cryptography;
using System.Text;

namespace Intotech.Common;

public static class HashGenerator
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

    public static string HashSHA256(string item)
    {
        if (item == null)
        {
            return null;
        }

        SHA256 algorithm = SHA256.Create();
        StringBuilder sb = new StringBuilder();
        foreach (Byte b in algorithm.ComputeHash(Encoding.UTF8.GetBytes(item)))
        {
            sb.Append(b.ToString("X2"));
        }

        return sb.ToString();
    }
}
