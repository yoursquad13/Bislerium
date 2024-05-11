using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Home
{
    public class CommentLogDto
    {
        public int CommentId { get; set; }

        public string Text { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CommentedAt { get; set; }
    }
}
