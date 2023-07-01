namespace SrtFileEditor;

internal class TimeRange
{ 
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

    public override string ToString()
    {
        return $"{TimeParser.MilisecondsToTime(StartTime)} {TimeSeparator} {TimeParser.MilisecondsToTime(EndTime)}";
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
