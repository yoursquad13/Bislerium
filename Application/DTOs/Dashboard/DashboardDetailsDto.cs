namespace Application.DTOs.Dashboard
{
    public class DashboardDetailsDto
    {
        public DashboardCount DashboardCount { get; set; }

        public List<PopularBlog> PopularBlogs { get; set; }

        public List<PopularBlogger> PopularBloggers { get; set; }
    }

    public class DashboardCount
    {
        public int Posts { get; set; }

        public int UpVotes { get; set; }

        public int DownVotes { get; set; }

        public int Comments { get; set; }
    }

    public class PopularBlog
    {
        public int BlogId { get; set; }

        public string Blog { get; set; }
    }

    public class PopularBlogger
    {
        public int BloggerId { get; set; }

        public string BloggerName { get; set; }
    }

    public class BlogDetails : PopularBlog
    {
        public int BloggerId { get; set; }

        public int Popularity { get; set; }
    }

    public class BloggerDetails : PopularBlogger
    {
        public int Popularity { get; set; }
    }
}
