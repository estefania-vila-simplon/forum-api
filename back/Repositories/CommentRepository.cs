using back.Models;
using back.Exceptions;
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
            _dbContext.Comments.Add(comment);

            return comment;
        }

        public void Delete(Comment comment)
        {
            _dbContext.Comments.Remove(comment);
            _dbContext.SaveChanges();
        }

        public List<Comment> GetAllComments()
        {           
            List<Comment> comments = _dbContext.Comments.ToList();
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
