namespace SrtFileEditor;

internal class TimeRange
{
    public long StartTime { get; set; }
    public long EndTime { get; set; }
    public TimeRange(long startTime, long endTime)
    {
        StartTime = startTime;
        EndTime = endTime;
    }
}
