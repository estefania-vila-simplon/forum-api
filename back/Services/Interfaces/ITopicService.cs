using back.DataAccess.DataObjects;

namespace back.Services.Interfaces
{
    public interface ITopicService
    {
        public Topic Create(Topic topic);
        public Topic? Update(Topic topic);
        public void Delete(Topic topic);


        public List<Topic> GetAllComments();
        public Topic? GetById(int id);
    }
}
