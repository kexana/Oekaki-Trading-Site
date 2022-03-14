using OekakiTradingSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OekakiTradingSite.Services
{
    public class CommentService : ICommentService
    {
        private DataContext dbContext;
        public CommentService(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<Comment> GetAll()
        {
            return dbContext.Comments.ToList();
        }
        public Comment FindById(int id)
        {
            Comment comment = dbContext.Comments.FirstOrDefault(c => c.Id == id);
            return comment;
        }
        public void AddComment(Comment newComment)
        {
            dbContext.Comments.Add(newComment);

            dbContext.SaveChanges();
        }
        public void EditComment(Comment alteredComment)
        {
            Comment comment = FindById(alteredComment.Id);
            comment.Contents = alteredComment.Contents;

            dbContext.SaveChanges();
        }
        public void DeleteComment(int id)
        {
            Comment commentToDelete = FindById(id);
            dbContext.Comments.Remove(commentToDelete);

            dbContext.SaveChanges();
        }
    }
}
