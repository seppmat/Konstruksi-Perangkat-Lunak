namespace modul9_103082400017
{
    public class Movie
    {
        public string Title { get; set; } = "";
        public string Director { get; set; } = "";
        public List<string> Stars { get; set; } = new();
        public string Description { get; set; } = "";

        public Movie() { }
    }
}
