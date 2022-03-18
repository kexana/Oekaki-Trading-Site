using OekakiTradingSite.Models;
using System.Collections.Generic;

namespace OekakiTradingSite.Services
{
    public interface ICommentService
    {
        void AddComment(Comment newComment, User user);
        void DeleteComment(int id);
        void EditComment(Comment alteredComment);
        Comment FindById(int id);
        List<Comment> GetAll();
        void DeleteAllCommentsOnDrawingId(int drawingId);
    }
}