using System.Diagnostics;

namespace SrtFileEditor;

internal class Program
{
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

    }
}