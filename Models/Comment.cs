using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OekakiTradingSite.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public String Contents { get; set; }
        public int WriterId { get; set; }
        public int DrawingPostId { get; set; }
        public DateTime CommentPostDate { get; set; }
    }
}
