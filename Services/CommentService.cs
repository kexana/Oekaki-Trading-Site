using OekakiTradingSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Services class to house all functions relating to use of comments.
/// </summary>

namespace OekakiTradingSite.Services
{
    public class CommentService : ICommentService
    {
        private DataContext dbContext;
        public CommentService(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }
        /// <summary>
        /// Gets all of the currently active comments - the list of comments present in the dbContext.
        /// </summary>
        /// <returns>List of comments.</returns>
        public List<Comment> GetAll()
        {
            return dbContext.Comments.ToList();
        }
        /// <summary>
        /// Finds the Comment by its Id property by acessing the dbContext list of comments and checking wether the ids match.
        /// </summary>
        /// <param name="id">The int Id property of the Comment to be returned.</param>
        /// <returns>A single Comment which's Id matches the provided parameter.</returns>
        public Comment FindById(int id)
        {
            Comment comment = dbContext.Comments.FirstOrDefault(c => c.Id == id);
            return comment;
        }
        /// <summary>
        /// Adds a new Comment to the database (dbContext) and sets its PostDate to the current time and date.
        /// </summary>
        /// <param name="newComment">A Comment with set values for Contents, DrawingPostId, WritterId.</param>
        public void AddComment(Comment newComment)
        {
            newComment.CommentPostDate = DateTime.Now;
            dbContext.Comments.Add(newComment);

            dbContext.SaveChanges();
        }
        /// <summary>
        /// Edits the values for Contents in an already existing in the database Comment.
        /// The value is passed from a new AlteredComment possesing the same Id, to the existing one. 
        /// </summary>
        /// <param name="alteredComment">A Comment with set value for new Contents and Id representing the Comment in the database to be altered.</param>
        public void EditComment(Comment alteredComment)
        {
            Comment comment = FindById(alteredComment.Id);
            comment.Contents = alteredComment.Contents;

            dbContext.SaveChanges();
        }
        /// <summary>
        /// Finds the Comment in the database with the provided id and deletes it from the
        /// dbContext comments list which in turns removes it from the database.
        /// </summary>
        /// <param name="id">The int Id value of the Comment to be deleted.</param>
        public void DeleteComment(int id)
        {
            Comment commentToDelete = FindById(id);
            dbContext.Comments.Remove(commentToDelete);

            dbContext.SaveChanges();
        }
        /// <summary>
        /// Deletes all the comments refering to the same drawing id provided as a parameter 
        /// by cycling trough each Comment from the returned GetAll() list and checks wether the DrawingPostId 
        /// property of the comment matches that one. When it does it invokes the DeleteComment method.
        /// </summary>
        /// <param name="drawingId">int Id property of the Drawing which's comments have to be deleted.</param>
        public void DeleteAllCommentsOnDrawingId( int drawingId)
        {
            foreach (Comment c in GetAll())
            {
                if (c.DrawingPostId == drawingId)
                {
                    DeleteComment(c.Id);
                }
            }
        }
    }
}
