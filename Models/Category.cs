namespace MovieApplication.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<CategoryMovie> CategoryMovies { get; set; } = new HashSet<CategoryMovie>();
    }
}
