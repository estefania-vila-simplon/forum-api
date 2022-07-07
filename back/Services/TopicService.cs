using back.DataAccess.DataObjects;
using back.Repositories.Interfaces;

namespace back.Services
{
    public class TopicService
    {
        private readonly ITopicRepository _topicRepository;

        public TopicService(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public Topic GetById(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("You must specify an id !");
            }

            return _topicRepository.GetById(id);
        }

        public Topic Create(Topic topic)
        {

            if (topic.Content?.Length > 500)
            {
                throw new ArgumentException("Your comment content has a 500 maximum character limit");
            }

            if (topic.TopicId > 0)
            {
                throw new ArgumentException("Comment is not new !");
            }

            return _topicRepository.Create(topic);

        }

        public Topic Update(Topic topic)
        {
            if (topic.TopicId <= 0)
                throw new ArgumentException("The comment must exist to be updated");

            return _topicRepository.Update(topic);
        }
    }
}

