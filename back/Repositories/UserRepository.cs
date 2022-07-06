using back.Models;
using back.Repositories.Interfaces;

namespace back.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly forumdbContext _dbContext;

        public UserRepository()
        {
            this._dbContext = new forumdbContext();
        }

        public User Create (User user)
        {
            _dbContext.Users.Add(user);

            return user;
        }

        public void Delete (User user)
        {
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();            
        }

        public List<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public User? GetById(int id)
        {
            return _dbContext.Users.Where(u => u.UserId == id).FirstOrDefault();
            
        }

        
        public User? Update(User user)
        {
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
            return _dbContext.Users.Where(u => u.UserId == user.UserId).FirstOrDefault();
        }

        
    }
}
