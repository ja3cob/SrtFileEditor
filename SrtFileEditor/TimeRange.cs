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
}
