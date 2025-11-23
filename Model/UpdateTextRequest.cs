namespace School_Site.Model
{
    public class UpdateTextRequest
    {
        public string Key { get; set; } = null!;
        public string Language { get; set; } = null!;
        public string Value { get; set; } = null!;
    }
}
