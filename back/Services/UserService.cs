using back.Models;
using back.Repositories.Interfaces;
using back.Services.Interfaces;

namespace back.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void Create (User user)
        {
            userRepository.Create (user);
        }

        public void Delete(object user)
        {
            throw new NotImplementedException();
        }

        public object? GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public object GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers()
        {
            List<User> users = this.userRepository.GetAllUsers();
            return users;
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
