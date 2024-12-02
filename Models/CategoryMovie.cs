namespace MovieApplication.Models
{
    public class CategoryMovie
    {
        public Guid CategoryId { get; set; }
        public Guid MovieId { get; set; }



        public Category Category { get; set; }
        public Movie Movie { get; set; }
    }
}
