namespace School_Site.Model
{
    public class SiteText
    {
        public int Id { get; set; }
        public string Key { get; set; } = null!;
        public string Language { get; set; } = null!; // "en", "ru", "he"
        public string Value { get; set; } = null!;
    }
}
