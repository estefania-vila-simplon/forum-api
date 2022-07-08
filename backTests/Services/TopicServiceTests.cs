using Microsoft.VisualStudio.TestTools.UnitTesting;
using back.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using back.Repositories.Interfaces;
using Moq;
using back.DataAccess.DataObjects;
using back.Exceptions;

namespace back.Services.Tests
{
    [TestClass()]
    public class TopicServiceTests
    {
        private TopicService _topicService;
        private Mock<ITopicRepository> _repository;
        private Mock<forumdbContext> _forumdbContext;
        private List<Topic> _topics;

        [TestInitialize]

        public void Initialize()
        {
            _forumdbContext = new Mock<forumdbContext>();
            _repository = new Mock<ITopicRepository>();

            _topicService = new TopicService(_repository.Object);
            _topics = new List<Topic>();

        }



        [TestMethod()]
        [DataRow(2)]
        public void FindById_IdOk(int id)
        {
            //GIVEN
            _repository.Setup(repo => repo.GetById(id))
                .Returns(_topics.Find(c => c.TopicId == id));
            Topic expectedTopic = _topics.Find(c => c.TopicId == id);
            //WHEN
            Topic topic = _topicService.GetById(id);
            //THEN
            Assert.AreEqual(expectedTopic, topic);
        }

        [TestMethod()]
        [DataRow(99)]
        public void FindById_IdNoComment(int id)
        {
            //GIVEN
            _repository.Setup(repo => repo.GetById(id))
                .Returns(_topics.Find(topic => topic.TopicId == id));
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

            //WHEN
            Assert.ThrowsException<ArgumentException>(() =>
            {
                _topicService.GetById(id);
            });

            //THEN
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
        public void Create_CreateCommentFail()

        {   //GIVEN
            var topic = new Topic();
            topic.Content = "I don't understand what int32 value it is even trying to convert to a String? This error " +
                "only occurs when I try to insert via the DetailsView. If I try updating from the GridView (which is on the same " +
                "page and uses the same ObjectDataSource as the DetailsView) its fine. I have double checked and the " +
                "ObjectDataSource is setup to use addMovie(....) as I displayed in my previous post.The code provided is not" +
                "sufficient to say which int its trying to convert. It may depend on the moviesDataTable structure too. BTW have" +
                " a try, just to set -9999 to string. I mean.";

            //WHEN

            //THEN

            Assert.ThrowsException<ArgumentException>(() =>
            {
                _topicService.Create(topic);
            });

        }
    }
}

        //[TestMethod]
        //public void Create_CommentCreationDateIsOk()

        //{   //GIVEN
        //    var dateToTest = new DateTime(2022, 7, 7, 00, 10, 15);

        //    var topic = new Topic(0, dateToTest, dateToTest, null, "b");
             

        //    Assert.AreEqual(0, topic.TopicId);

        //    _repository.Setup(repo => repo.Create(topic)).Returns(topic);

        //    var topicCreated = _topicService.Create(topic);

        //    //after the creation the comment id must be filled
        //    topicCreated.TopicId = 1;

        //    Assert.AreEqual(1, topicCreated.TopicId);

        //    _repository.Setup(repo => repo.GetById(1)).Returns(topicCreated);

        //    Assert.IsNotNull(topicCreated);
        //    Assert.AreEqual(dateToTest, topicCreated.CreationDate);
        //    Assert.IsNull(topicCreated.ModifDate);

        //    //WHEN

        //    //THEN
        //}


        //[TestMethod]
        //public void Create_UpdateCommentIsOk()

        //{   //GIVEN
        //    var dateToTest = new DateTime(2022, 7, 7, 00, 10, 15);

        //    var topic = /*new /*Topic(0, dateToTest, null, "blablabla", "")*/;


        //    Assert.AreEqual(0, topic.TopicId);

        //    _repository.Setup(repo => repo.Create(topic)).Returns(topic);

        //    var topicCreated = _topicService.Create(topic);

        //    //after the creation the comment id must be filled
        //    topicCreated.TopicId = 1;

        //    Assert.AreEqual(1, topicCreated.TopicId);

        //    _repository.Setup(repo => repo.GetById(1)).Returns(topicCreated);

        //    var topicCreatedFromService = _topicService.GetById(1);

        //    Assert.IsNotNull(topicCreatedFromService);
        //    Assert.AreEqual(dateToTest, topicCreatedFromService.CreationDate);
        //    Assert.IsNull(topicCreatedFromService.ModifDate);

        //    var updatedTopic = topicCreated;
        //    updatedTopic.ModifDate = DateTime.Now;

        //    _repository.Setup(repo => repo.Update(topic)).Returns(updatedTopic);

        //    var topicUpdatedFromService = _topicService.Update(updatedTopic);

        //    Assert.IsNotNull(topicUpdatedFromService);
        //    Assert.IsNotNull(topicUpdatedFromService.ModifDate);
        //    Assert.IsTrue(topicUpdatedFromService.CreationDate.CompareTo(topicUpdatedFromService.ModifDate) < 0);
        //    //WHEN

        //    //THEN
        //}

        //[TestMethod]
        //public void Create_UpdateComment_ShouldKo()

        //{   //GIVEN
        //    var dateToTest = new DateTime(2022, 7, 7, 00, 10, 15);

        //    var topic = /*new Topic(0, dateToTest, null, "blablabla", "")*/;

        //    Assert.ThrowsException<ArgumentException>(() => _topicService.Update(topic));
        //    //WHEN

        //    //THEN
        //}


        //[TestMethod]

        //public void Delete_DeleteComment_ShouldOk()
        //{
        //    ////GIVEN
        //    //var topic = new Topic(1, new DateTime(2022, 7, 7, 00, 10, 15),
        //    //    new DateTime(2022, 7, 10, 00, 10, 15), "blablabla", "", new Topic());

        //    ////WHEN
        //    //var topicDeleted = _repository.Setup(repo => repo.Delete(topic));
        //    //Assert.IsNotNull(topicDeleted);

        //    ////THEN

        //}

   
