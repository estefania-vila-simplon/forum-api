using back.Exceptions;
using back.Models;
using back.Repositories.Interfaces;

namespace back.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        private readonly forumdbContext _dbContext;

        public TopicRepository()
        {
            this._dbContext = new forumdbContext();
        }

        public Topic Create(Topic topic)
        {
            using var transaction = _dbContext.Database.BeginTransaction();

            if(!_dbContext.Topics.Contains(topic))
            {
                _dbContext.Topics.Add(topic);
                _dbContext.SaveChanges();
                transaction.Commit();
            }
            return topic;

        }

        public void Delete(Topic topic)
        {
            _dbContext.Topics.Remove(topic);
            _dbContext.SaveChanges();
        }

        public List<Topic> GetAllTopics()
        {
            List<Topic> topics = _dbContext.Topics.ToList();

            return topics;
        }

        public Topic? GetById(int id)
        {
            try
            {
                return _dbContext.Topics.Where(t => t.TopicId == id).FirstOrDefault();
            }
            catch (ArgumentNullException)
            {
                throw new BDDException("Error during the fetch of data");
            }
        }

        public Topic? Update(Topic topic)
        {
            using var transaction = _dbContext.Database.BeginTransaction();
            if (_dbContext.Topics.Contains(topic))
            {
                var topicToUpdate = GetById(topic.TopicId);

                topicToUpdate.CreationDate = topic.CreationDate;
                topicToUpdate.ModifDate = topic.ModifDate;
                topicToUpdate.TopicTitle = topic.TopicTitle;

                _dbContext.Topics.Update(topicToUpdate);
                _dbContext.SaveChanges();
                transaction.Commit();
            }

        return _dbContext.Topics.Where(u => u.TopicId == topic.TopicId).FirstOrDefault();
        }
    }

}
