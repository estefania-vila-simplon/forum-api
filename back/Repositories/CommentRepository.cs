using back.Models;
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
            return _dbContext.Comments.ToList();
        }

        public Comment? GetById(int id)
        {
            return _dbContext.Comments.Where(u => u.CommentId == id).FirstOrDefault();

        }


        public Comment? Update(Comment comment)
        {
            _dbContext.Comments.Update(comment);
            _dbContext.SaveChanges();
            return _dbContext.Comments.Where(u => u.CommentId == comment.CommentId).FirstOrDefault();
        }

    }
}
