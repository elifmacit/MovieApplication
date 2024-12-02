namespace MovieApplication.Models
{
    public class Movie : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Author { get; set; }
        public string Picture { get; set; }
        public ICollection<CategoryMovie> CategoryMovies { get; set; } = new HashSet<CategoryMovie>();
    }
}
