namespace BookManagerApi.Models
{
    public class Author
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public string BriefBio { get; set; }
        public DateTime Birthday { get; set; }
    }
}
