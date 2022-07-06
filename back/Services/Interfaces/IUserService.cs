using back.Models;

namespace back.Services.Interfaces
{
    public interface IUserService
    {
        object? GetAllUsers();
        object GetById(int id);
        void Update(User user);
        void Create (User user);
        void Delete(object user);
    }
}
