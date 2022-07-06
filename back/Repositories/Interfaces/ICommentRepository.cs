using back.Models;

namespace back.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        public Comment Create(Comment comment);
        public Comment? Update(Comment comment);
        public void Delete(Comment comment);


        public List<Comment> GetAllComments();
        public Comment? GetById(int id);

    }
}
