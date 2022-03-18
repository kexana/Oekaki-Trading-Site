using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OekakiTradingSite.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public String Contents { get; set; }

        [ForeignKey("Writer")]
        public int WriterId { get; set; }

        public User Writer { get; set; }

        [ForeignKey("DrawingPost")]
        public int DrawingPostId { get; set; }

        public Drawing DrawingPost { get; set; }

        public DateTime CommentPostDate { get; set; }
    }
}
