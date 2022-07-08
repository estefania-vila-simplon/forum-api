using back.Models;
using back.Services.Interfaces;
using back.Repositories.Interfaces;


namespace back.Services
{
    public class TopicService : ITopicService
    { 

        private readonly ITopicRepository _topicRepository;

        public TopicService(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public Topic Create(Topic topic)
        {

            if (topic.TopicTitle.Length > 50)
            {
                throw new ArgumentException("Your topic has a 50 maximum character limit");
            }

            return _topicRepository.Create(topic);
        }

        public void Delete(Topic topic)
        {
            _topicRepository.Delete(topic);
        }

        public List<Topic> GetAllTopics()
        {
            return _topicRepository.GetAllTopics();
        }

        public Topic? GetById(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("You must specify an id !");
            }

            return _topicRepository.GetById(id);
        }

        public Topic? Update(Topic topic)
        {
            if (topic.TopicId <= 0)
                throw new ArgumentException("The topic must exist to be updated");

            return _topicRepository.Update(topic); ;
        }
    
    }
}
