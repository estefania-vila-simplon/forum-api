using back.Models;

namespace back.Repositories.Interfaces
{
    public interface ITopicRepository
    {
        public Topic Create(Topic topic);
        public Topic? Update(Topic topic);
        public void Delete(Topic topic);


        public List<Topic> GetAllTopics();
        public Topic? GetById(int id);
    }
}
