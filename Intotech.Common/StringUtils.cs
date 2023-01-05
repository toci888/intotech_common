using System.Security.Cryptography;
using System.Text;
using System.Net.Mail;

namespace Intotech.Common;

public static class StringUtils
{
    private static Random randomizer = new Random();
    private static string alphabet = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890!@#$%^&*()_+";
    private static string alphabetLetters = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
    private static string vowel = "eyuioa";
    private static string consonant = "qwrtpsdfghjklzxcvbnm";
    public static string VowelConsonants(int length)
    {
        Random rnd = new Random();
        string returned = string.Empty;
        for (int i = 0; i < length; i++)
        {
            if (i % 2 == 1)
            {
                returned += vowel[rnd.Next(0, vowel.Length - 1)];
            }
            else
            {
                returned += consonant[rnd.Next(0, consonant.Length - 1)];
            }
        }

        return returned;
    }

    public static string CreateChat(int wordCount)
    {
        Random rnd = new Random();
        string result = string.Empty;
        for (int i = 0; i < wordCount; i++)
        {
            result += VowelConsonants(rnd.Next(4, 11)) + " ";
        }
        return result;
    }
    public static string GetRandomText(int maxLength)
    {
        string result = string.Empty;

        for (int i = 0; i < randomizer.Next(5, maxLength); i++)
        {
            result += alphabetLetters[randomizer.Next(0, alphabetLetters.Length - 1)];
        }

        return result;
    }

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

    public static bool IsEmailAddress(string emailCandidate)
    {
        try
        {
            MailAddress emailAddress = new MailAddress(emailCandidate);

            return true;
        }
        catch
        {
            return false;
        }
    }
}
