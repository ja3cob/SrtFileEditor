namespace SrtFileEditor;

internal class TimeRange
{
    public const int MilisecondsInSecond = 1000;
    public const int MilisecondsInMinute = MilisecondsInSecond * 60;
    public const int MilisecondsInHour = MilisecondsInMinute * 60;
    private const string TimeSeparator = "-->";

    public long StartTime { get; set; }
    public long EndTime { get; set; }
    public TimeRange(long startTime, long endTime)
    {
        StartTime = startTime;
        EndTime = endTime;
    }

    public void Shift(long amountMiliseconds)
    {
        StartTime += amountMiliseconds;
        EndTime += amountMiliseconds;
    }
    private static string MilisecondsToTime(long timeInMiliseconds)
    {
        long hours = timeInMiliseconds / MilisecondsInHour;
        long minutes = timeInMiliseconds / MilisecondsInMinute - hours * 60;
        long seconds = timeInMiliseconds / MilisecondsInSecond - minutes * 60 - hours * 60 * 60;
        long miliseconds = timeInMiliseconds % MilisecondsInSecond;

        return $"{hours:00}:{minutes:00}:{seconds:00},{miliseconds:000}";
    }
    public override string ToString()
    {
        return $"{MilisecondsToTime(StartTime)} {TimeSeparator} {MilisecondsToTime(EndTime)}";
    }
    public static TimeRange Convert(string stimeRange)
    {
        if (!stimeRange.Contains($" {TimeSeparator} ")) { throw new ArgumentException($"{nameof(stimeRange)} was in an incorrect format ({stimeRange})"); }
        if (!stimeRange.EndsWith(' ')) { stimeRange += ' '; }

        int separatorStartIndex = stimeRange.LastIndexOf(TimeSeparator);
        int separatorEndIndex = separatorStartIndex + TimeSeparator.Length + 1;

        return new TimeRange(stimeRange.Remove(separatorStartIndex).TimeToMiliseconds(), stimeRange.Remove(0, separatorEndIndex).TimeToMiliseconds());
    }
}
