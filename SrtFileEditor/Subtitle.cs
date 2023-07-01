namespace SrtFileEditor
{
    internal class Subtitle
    {
        public int Id { get; set; }
    public TimeRange TimeRange { get; set; }
        public string Text { get; set; }

        public Subtitle(int id, TimeRange range, string text)
        {
            Id = id;
        TimeRange = range;
            Text = text;
        }
    }
}
