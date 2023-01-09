namespace Intotech.Common;

public static class TimeUtils
{
    public static string GetCorrectTime(int hourMinute)
    {
        if (hourMinute < 10)
        {
            return "0" + hourMinute;
        }

        return hourMinute.ToString();
    }


}