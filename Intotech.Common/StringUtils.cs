using System.Security.Cryptography;
using System.Text;

namespace Intotech.Common;

public static class StringUtils
{
    private static Random randomizer = new Random();
    private static string alphabet = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890!@#$%^&*()_+";

    public static string GetRandomString(int maxLength)
    {
        string result = string.Empty;

        for (int i = 0; i < randomizer.Next(5, maxLength); i++)
        {
            result += alphabet[randomizer.Next(0, alphabet.Length - 1)];
        }

        return result;
    }

    public static bool IsNumber(string candidate)
    {
        if (candidate == null)
        {
            return false;
        }

        return candidate.All(char.IsDigit);
    }

    public static bool IsEmail(string candidate)
    {
        return candidate.Contains("@");
    }

    public static string HashPassword(string password)
    {
        if (password == null)
        {
            return null;
        }

        SHA256 algorithm = SHA256.Create();
        StringBuilder sb = new StringBuilder();
        foreach (Byte b in algorithm.ComputeHash(Encoding.UTF8.GetBytes(password)))
        {
            sb.Append(b.ToString("X2"));
        }

        return sb.ToString();
    }
}
