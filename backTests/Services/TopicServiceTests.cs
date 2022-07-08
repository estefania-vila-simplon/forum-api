using back.Exceptions;
using back.Models;
using back.Repositories.Interfaces;
using back.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backTests.Services
{
    [TestClass()]
    public class TopicServiceTests
    {
        private TopicService _topicService;
        private Mock<ITopicRepository> _repository;
        private Mock<forumDbContext> _forumDbContext;
        private List<Topic> _topics;

        [TestInitialize]

        public void Initialize()
        {
            _forumDbContext = new Mock<forumDbContext>();
            _repository = new Mock<ITopicRepository>();

            _topicService = new TopicService(_repository.Object);
            _topics = new List<Topic>();
        }

        [TestMethod()]
       
        public void CreateTopic_CreateTopicFail()
        {
            //GIVEN
            var topic = new Topic();
            topic.TopicTitle = "Git Push: 'Origin' Does Not Appear To Be A Git Repository.";

            //WHEN

            //THEN
            Assert.ThrowsException<ArgumentException>(() =>
            {
                _topicService.Create(topic);
            });

        }

        [TestMethod]

        public void Create_TopicCreationDateIsOk()
        {
            //GIVEN 
            var dateToTest = new DateTime(2022, 8, 8, 00, 10, 10);

            var topic = new Topic(0, dateToTest, null, "title", "Superman");

            Assert.AreEqual(0, topic.TopicId);

            _repository.Setup(repo => repo.Create(topic)).Returns(topic);

            var topicCreated = _topicService.Create(topic);

            //after the creation the comment id must be filled
            topicCreated.TopicId = 1;

            Assert.AreEqual(1, topicCreated.TopicId);

            _repository.Setup(repo => repo.GetById(1)).Returns(topicCreated);

            Assert.IsNotNull(topicCreated);
            Assert.AreEqual(dateToTest, topicCreated.CreationDate);
            Assert.IsNull(topicCreated.ModifDate);

        }

        [TestMethod()]
        [DataRow(2)]
        public void FindById_IdOk(int id)
        {
            //GIVEN
            _repository.Setup(repo => repo.GetById(id))
                .Returns(_topics.Find(t => t.TopicId == id));
            Topic expectedTopic = _topics.Find(t => t.TopicId == id);
            //WHEN
            Topic topic = _topicService.GetById(id);
            //THEN
            Assert.AreEqual(expectedTopic, topic);

        }

        [TestMethod]
        [DataRow(142)]

        public void FindById_IdNoTopic(int id)
        {
            //GIVEN

            _repository.Setup(repo => repo.GetById(id))
                .Returns(_topics.Find(topic=> topic.TopicId == id));
                  
            //WHEN
            Topic topic = _topicService.GetById(id);

            //THEN
            Assert.IsNull(topic);
        }

        [TestMethod]
        [DataRow(0)]
        public void FindById_IdNotOk(int id)
        {
            //GIVEN

            //THEN
            Assert.ThrowsException<ArgumentException>(() =>
            {
                _topicService.GetById(id);
            });

            //WHEN
        }

        [TestMethod]
        [DataRow(1)]
        public void FindById_IdNotOk_ErrorBDD(int id)
        {
            //GIVEN
            _repository.Setup((repo) => repo.GetById(id)).Throws(new BDDException());
            //WHEN
            Assert.ThrowsException<BDDException>(() =>
            {
                _topicService.GetById(id);
            });
            //THEN
        }

        [TestMethod]
        public void Create_UpdateTopicIsOk()
        {
            //GIVEN
            var dateToTest = new DateTime(2022, 2, 2, 00, 08, 23);

            var topic = new Topic(0, dateToTest, null, "blablabla", "Thomas");

            Assert.AreEqual(0, topic.TopicId);

            _repository.Setup(repo => repo.Create(topic)).Returns(topic);

            var topicCreated = _topicService.Create(topic);

            //after the creation the topic id must be filled
            topicCreated.TopicId = topic.TopicId = 1;

            Assert.AreEqual(1, topicCreated.TopicId);

            _repository.Setup(repo => repo.GetById(1)).Returns(topicCreated);

            var topicCreatedFromService = _topicService.GetById(1);

            Assert.IsNotNull(topicCreatedFromService);
            Assert.AreEqual(dateToTest, topicCreatedFromService.CreationDate);
            Assert.IsNull(topicCreatedFromService.ModifDate);

            var updatedTopic = topicCreated;
            updatedTopic.ModifDate = DateTime.Now;

            _repository.Setup(repo => repo.Update(topic)).Returns(updatedTopic);

            var topicUdatedFromService = _topicService.Update(updatedTopic);

            Assert.IsNotNull(topicUdatedFromService);
            Assert.IsNotNull(topicUdatedFromService.ModifDate);
            Assert.IsTrue(topicUdatedFromService.CreationDate.CompareTo(topicUdatedFromService.ModifDate) < 0);


            //WHEN

            //THEN
        }

        [TestMethod]
        public void Create_UpdateTopic_ShouldKo()
        {
            //GIVEN
            var dateToTest = new DateTime(2022, 1, 1, 00, 12, 15);

            var topic = new Topic(0, dateToTest, null, "blabla", "Thomas");

            Assert.ThrowsException<ArgumentException>(() =>
            _topicService.Update(topic));

            //WHEN

            //THEN


        }

        [TestMethod]

        public void FindAllTopics()
        {
            //GIVEN

            var topicList = new List<Topic>();

            //WHEN
            _repository.Setup(repo => repo.GetAllTopics()).Returns(topicList);
            var topics = _topicService.GetAllTopics();

            //THEN
            Assert.IsNotNull(topics);
        }

    [TestMethod]
    public void Delete_DeleteTopic_ShouldOk()
    {
        //GIVEN
        var topic = new Topic(1, new DateTime(2022, 7 , 7 , 00 , 10, 15),
            new DateTime(2022, 7, 7, 00, 10, 15), "blablabla", "Thomas");

        //WHEN
        var topicDeleted = _repository.Setup(repo => repo.Delete(topic));
        Assert.IsNotNull(topicDeleted);

        //THEN
    }


        
    }
}
