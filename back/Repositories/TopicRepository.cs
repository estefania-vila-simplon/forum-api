using back.DataAccess.DataObjects;
using back.Exceptions;


namespace back.Repositories
{
   

  
    
        public class TopicRepository
        {
            private readonly forumdbContext _dbContext;

            public TopicRepository()
            {
                this._dbContext = new forumdbContext();
            }

            public Topic Create(Topic topic)
            {
                _dbContext.Topics.Add(topic);

                return topic;
            }

            public void Delete(Topic topic)
            {
                _dbContext.Topics.Remove(topic);
                _dbContext.SaveChanges();
            }

            public List<Topic> GetAllTopics()
            {
                return _dbContext.Topics.ToList();
            }

            public Topic? GetById(int id)
            {
                try
                {
                    return _dbContext.Topics.Where(u => u.TopicId == id).FirstOrDefault();
                }
                catch (ArgumentNullException)
                {
                    throw new BDDException("Error during the fetch of data");
                }
            }


            public Topic? Update(Topic topic)
            {
                _dbContext.Topics.Update(topic);
                _dbContext.SaveChanges();
                return _dbContext.Topics.Where(u => u.TopicId == topic.TopicId).FirstOrDefault();
            }

        }
    }

