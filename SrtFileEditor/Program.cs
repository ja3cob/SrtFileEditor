namespace SrtFileEditor;

internal class Program
{
    private const long MilisecondsToShift = 5 * TimeParser.MilisecondsInSecond + 880;
    private const string FileName = "napisy do filmu.srt";
    private const string NewFileName = "napisy do filmu1.srt";

    private static void ShiftAllTimes(long amountMiliseconds, ref List<Subtitle> subtitles)
    {
        foreach(Subtitle subtitle in subtitles)
        {
            subtitle.TimeRange.Shift(amountMiliseconds);
        }
    }

    private static List<Subtitle> ExtractAndRemoveSubtitlesWithFullSecond(ref List<Subtitle> subtitles)
    {
        var result = new List<Subtitle>();

        int subtitlesCount = subtitles.Count;
        for (int i = 0; i < subtitlesCount; i++)
        {
            if (subtitles[i].TimeRange.StartTime % 1000 != 0) { continue; }

            result.Add(subtitles[i]);
            subtitles.RemoveAt(i);

            i--;
            subtitlesCount--;
        }

        return result;
    }

    private static void FixIds(ref List<Subtitle> subtitles)
    {
        for (int i = 0; i < subtitles.Count; i++)
        {
            subtitles[i].Id = i + 1;
        }
    }

    static void Main()
    {
        List<Subtitle> subtitles = SRTFile.Read(FileName);
        ShiftAllTimes(MilisecondsToShift, ref subtitles);

        var extractedSubtitles = ExtractAndRemoveSubtitlesWithFullSecond(ref subtitles);

        FixIds(ref subtitles);
        FixIds(ref extractedSubtitles);

        SRTFile.Write(FileName, subtitles);
        SRTFile.Write(NewFileName, extractedSubtitles);
    }
}