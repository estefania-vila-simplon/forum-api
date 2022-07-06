using back.Models;
using System.Linq;

namespace back.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public User Create (User user);
        public User? Update (User user);
        public void Delete (User user);

       
        public List<User> GetAllUsers ();
        public User? GetById (int id);
        
    }
}
