namespace SrtFileEditor;

internal static class TimeParser
{
    public static long TimeToMiliseconds(this string time)

    public static long ParseTime(this string time)
    {
        long result;
        try
        {
            if (time.Length != 13) { throw new Exception(); }
            result = ParseInternal(time);
        }
        catch (Exception) { throw new ArgumentException($"String {nameof(time)} was in an incorrect format ({time})"); }

        return result;
    }
    private static long ParseInternal(string time)
    {
        short hour;
        short minute;
        short second;
        short microsecond;

        byte index = 0;
        hour = ReadUntilToken(time, ref index, ':');
        minute = ReadUntilToken(time, ref index, ':');
        second = ReadUntilToken(time, ref index, ',');
        microsecond = ReadUntilToken(time, ref index, ' ');

        return microsecond + second * TimeRange.MilisecondsInSecond + minute * TimeRange.MilisecondsInMinute + hour * TimeRange.MilisecondsInHour;
    }

    private static short ReadUntilToken(string source, ref byte index, char token)
    {
        string temp = "";

        while (source[index] != token && index < source.Length)
        {
            temp += source[index];
            index++;
        }
        index++;
        
        return short.Parse(temp);
    }
}
