using back.Models;
using back.Exceptions;
using System.Data.Entity;
using back.Repositories.Interfaces;

namespace back.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly forumdbContext _dbContext;

        public CommentRepository()
        {
            this._dbContext = new forumdbContext();
        }

        public Comment Create(Comment comment)
        {
            using var transaction = _dbContext.Database.BeginTransaction();

            if (_dbContext.Comments.Contains(comment))
            {
                comment.CommentTopic = _dbContext.Topics.Find(comment.CommentTopicId);

                if( comment.CommentTopic != null)
                {
                    _dbContext.Comments.Add(comment);
                    _dbContext.SaveChanges();
                }
               
                transaction.Commit();
            }
            

            return comment;
        }

        public void Delete(Comment comment)
        {
            _dbContext.Comments.Remove(comment);
            _dbContext.SaveChanges();
        }

        public List<Comment> GetAllComments()
        {
            List<Comment> comments = _dbContext.Comments.Include("Topics").ToList();

            comments.ForEach(c =>
            {
                c.CommentTopic = _dbContext.Topics.Find(c.CommentTopicId);
            });

            return comments;
            
        }

        public Comment? GetById(int id)
        {
            try
            {
                return _dbContext.Comments.Where(u => u.CommentId == id).FirstOrDefault();
            }
            catch (ArgumentNullException)
            {
                throw new BDDException("Error during the fetch of data");
            }
        }


        public Comment? Update(Comment comment)
        {
            _dbContext.Comments.Update(comment);
            _dbContext.SaveChanges();
            return _dbContext.Comments.Where(u => u.CommentId == comment.CommentId).FirstOrDefault();
        }

    }
}
