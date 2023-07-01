namespace SrtFileEditor;

internal static class SRTFile
{
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

        timeRange = TimeRange.Convert(fileContents[lineNumber]);
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
    public static void Write(string fileName, List<Subtitle> contents)
    {
        var scontents = new List<string>();

        foreach(Subtitle subtitle in contents) 
        {
            scontents.Add(subtitle.ToString());
        }

        File.WriteAllLines(fileName, scontents);
    }
}
