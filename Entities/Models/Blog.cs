using Entities.Base;

namespace Entities.Models
{
    public class Blog : BaseEntity<int>
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public string Location { get; set; }

        public string Reaction { get; set; }           

        public virtual ICollection<BlogImage> BlogImages { get; set; }
    }
}
