using OekakiTradingSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OekakiTradingSite.Services
{
    public class CommentService : ICommentService
    {
        private IData data;
        public CommentService(IData data)
        {
            this.data = data;
        }
        public List<Comment> GetAll()
        {
            return data.Comments;
        }
        public Comment FindById(int id)
        {
            Comment comment = data.Comments.FirstOrDefault(c => c.Id == id);
            return comment;
        }
        public void AddComment(Comment newComment)
        {
            Comment comment = new Comment(newComment.Contents, newComment.WriterId, newComment.DrawingPostId, DateTime.Now);
            data.Comments.Add(comment);
        }
        public void EditComment(Comment alteredComment, int id)
        {
            Comment comment = FindById(id);
            comment.Contents = alteredComment.Contents;
        }
        public void DeleteComment(int id)
        {
            Comment commentToDelete = FindById(id);
            data.Comments.Remove(commentToDelete);
        }
    }
}
