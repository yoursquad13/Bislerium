using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Blog
{
    public class BlogLogDto
    {
        public int BlogId { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
