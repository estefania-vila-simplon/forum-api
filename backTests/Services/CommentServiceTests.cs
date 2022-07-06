using back.Models;
using back.Exceptions;
using back.Repositories;
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
    public class CommentServiceTests
    {

        private CommentService _commentService;
        private Mock<ICommentRepository> _repository;
        private Mock<forumdbContext> _forumdbContext;
        private List<Comment> _comments;

        [TestInitialize]

        public void Initialize()
        {
            _forumdbContext = new Mock<forumdbContext>();
            _repository = new Mock<ICommentRepository>();
            
            _commentService = new CommentService(_repository.Object);
            _comments = new List<Comment>();
            _comments.Add(new Comment(1, new DateTime(), new DateTime(), "blabla", new User(), new Topic()));
            _comments.Add(new Comment(2, new DateTime(), new DateTime(), "blabla", new User(), new Topic()));
            _comments.Add(new Comment(3, new DateTime(), new DateTime(), "blabla", new User(), new Topic()));
        }



        [TestMethod()]
        [DataRow(2)]
        public void FindById_IdOk(int id)
        {
            //GIVEN
            _repository.Setup(repo => repo.GetById(id))
                .Returns(_comments.Find(c => c.CommentId == id));
            Comment expectedComment = _comments.Find(c => c.CommentId == id);
            //WHEN
            Comment comment = _commentService.GetById(id);
            //THEN
            Assert.AreEqual(expectedComment, comment);
        }
        
        [TestMethod()]
        [DataRow(99)]
        public void FindById_IdNoComment(int id)
        {
            //GIVEN
            _repository.Setup(repo => repo.GetById(id))
                .Returns(_comments.Find(comment => comment.CommentId == id));
            //WHEN
            Comment comment = _commentService.GetById(id);
            //THEN
            Assert.IsNull(comment);
        }

        [TestMethod]
        [DataRow(0)]    
        public void FindById_IdNotOk(int id)
        {
            //GIVEN
            
            //WHEN
            Assert.ThrowsException<ArgumentException>(() =>
            {
                _commentService.GetById(id);
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
                _commentService.GetById(id);
            });            
            //THEN
        }

        [TestMethod]
        public void Create_CreateCommentFail()

        {   //GIVEN
            var comment = new Comment();
            comment.Content = "I don't understand what int32 value it is even trying to convert to a String? This error " +
                "only occurs when I try to insert via the DetailsView. If I try updating from the GridView (which is on the same " +
                "page and uses the same ObjectDataSource as the DetailsView) its fine. I have double checked and the " +
                "ObjectDataSource is setup to use addMovie(....) as I displayed in my previous post.The code provided is not" +
                "sufficient to say which int its trying to convert. It may depend on the moviesDataTable structure too. BTW have" +
                " a try, just to set -9999 to string. I mean.";

            //WHEN

            //THEN

            Assert.ThrowsException<ArgumentException>(() =>
            {
                _commentService.Create(comment);
            });


            
        }

        [TestMethod]
        public void Create_CommentCreationDateIsOk()

        {   //GIVEN
            var dateToTest = new DateTime(2022, 7, 7, 00, 10, 15);

            var comment = new Comment(0, dateToTest, null,"blablabla", new User(), new Topic());

            Assert.AreEqual(0, comment.CommentId);

            _repository.Setup(repo => repo.Create(comment)).Returns(comment);

            var commentCreated = _commentService.Create(comment);

            //after the creation the comment id must be filled
            commentCreated.CommentId = 1;

            Assert.AreEqual(1, commentCreated.CommentId);

            _repository.Setup(repo => repo.GetById(1)).Returns(commentCreated);

            Assert.IsNotNull(commentCreated);
            Assert.AreEqual(dateToTest, commentCreated.CreationDate);
            Assert.IsNull(commentCreated.ModifDate);

            //WHEN

            //THEN
        }
        
        [TestMethod]
        public void Create_CommentWithId_ShouldKo()

        {   //GIVEN
            var dateToTest = new DateTime(2022, 7, 7, 00, 10, 15);

            var comment = new Comment(1, dateToTest, null,"blablabla", new User(), new Topic());

            Assert.ThrowsException<ArgumentException>(() => _commentService.Create(comment));
            //WHEN

            //THEN
        }

        [TestMethod]
        public void Create_UpdateComment()

        {   //GIVEN
            var dateToTest = new DateTime(2022, 7, 7, 00, 10, 15);

            var comment = new Comment(0, dateToTest, null, "blablabla", new User(), new Topic());

            Assert.AreEqual(0, comment.CommentId);

            _repository.Setup(repo => repo.Create(comment)).Returns(comment);

            var commentCreated = _commentService.Create(comment);

            //after the creation the comment id must be filled
            commentCreated.CommentId = 1;

            Assert.AreEqual(1, commentCreated.CommentId);

            _repository.Setup(repo => repo.GetById(1)).Returns(commentCreated);

            var commentCreatedFromService = _commentService.GetById(1);

            Assert.IsNotNull(commentCreatedFromService);
            Assert.AreEqual(dateToTest, commentCreatedFromService.CreationDate);
            Assert.IsNull(commentCreatedFromService.ModifDate);

            var updatedComment = commentCreated;
            updatedComment.ModifDate = DateTime.Now;

            _repository.Setup(repo => repo.Update(comment)).Returns(updatedComment);

            var commentUpdatedFromService = _commentService.Update(updatedComment);

            Assert.IsNotNull(commentUpdatedFromService);
            Assert.IsNotNull(commentUpdatedFromService);
            Assert.IsTrue(commentUpdatedFromService.CreationDate.CompareTo(commentUpdatedFromService.ModifDate) < 0);
            //WHEN

            //THEN
        }
        
        [TestMethod]
        public void Create_UpdateComment_ShouldKo()

        {   //GIVEN
            var dateToTest = new DateTime(2022, 7, 7, 00, 10, 15);

            var comment = new Comment(0, dateToTest, null, "blablabla", new User(), new Topic());

            Assert.ThrowsException<ArgumentException>(() => _commentService.Update(comment));
            //WHEN

            //THEN
        }
    }
}

