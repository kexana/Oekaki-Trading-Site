using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OekakiTradingSite.Models
{
    public class Comment
    {
        private static int id=0;
        private string contents;
        private int writerId;
        private int drawingPostId;
        private DateTime commentPostDate;
        public Comment(string contents,int writerId, int drawingPostId, DateTime commentPostDate)
        {
            Contents = contents;
            WriterId = writerId;
            DrawingPostId = drawingPostId;
            CommentPostDate = commentPostDate;
            Id = ++id;
        }
        public int Id { get; }
        public string Contents
        {
            get { return contents; }
            set { contents = value; }
        }
        public int WriterId
        {
            get { return writerId; }
            private set { writerId = value; }
        }
        public int DrawingPostId
        {
            get { return drawingPostId; }
            private set { drawingPostId = value; }
        }
        public DateTime CommentPostDate
        {
            get { return commentPostDate; }
            private set { commentPostDate = value; }
        }
    }
}
