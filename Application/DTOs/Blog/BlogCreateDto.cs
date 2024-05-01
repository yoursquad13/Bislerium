namespace Application.DTOs.Blog
{
    public class BlogCreateDto
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public string Location { get; set; }

        public string Reaction { get; set; }

        public List<string> Images { get; set; }
    }
}
