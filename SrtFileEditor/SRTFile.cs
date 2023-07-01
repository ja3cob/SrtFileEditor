namespace SrtFileEditor;

internal static class SRTFile
{
    private const string TimeSeparator = "-->";
    public static List<Subtitle> Read(string fileName)
    {
        string[] fileContents = File.ReadAllLines(fileName);

        var result = new List<Subtitle>();
        int lineNumber = 0;
        while (lineNumber < fileContents.Length)
        {
            result.Add(ReadSubtitle(fileContents, ref lineNumber));
        }

        return result;
    }

    private static Subtitle ReadSubtitle(string[] fileContents, ref int lineNumber)
    {
        int id;
        TimeRange timeRange;
        string text;

        id = int.Parse(fileContents[lineNumber]);
        lineNumber++;

        timeRange = ReadTimeRange(fileContents[lineNumber]);
        lineNumber++;

        text = "";
        while (lineNumber < fileContents.Length && !string.IsNullOrWhiteSpace(fileContents[lineNumber]))
        {
            text += fileContents[lineNumber] + "\n";
            lineNumber++;
        }
        text = text.Remove(text.LastIndexOf("\n"));
        lineNumber++;

        return new Subtitle(id, timeRange, text);
    }

    private static TimeRange ReadTimeRange(string stimeRange)
    { 
        if(!stimeRange.Contains($" {TimeSeparator} ")) { throw new ArgumentException($"{nameof(stimeRange)} was in an incorrect format"); }
        if(!stimeRange.EndsWith(' ')) { stimeRange += ' '; }

        int separatorStartIndex = stimeRange.LastIndexOf(TimeSeparator);
        int separatorEndIndex = separatorStartIndex + TimeSeparator.Length + 1;

        return new TimeRange(stimeRange.Remove(separatorStartIndex).ParseTime(), stimeRange.Remove(0, separatorEndIndex).ParseTime());
    }
}
