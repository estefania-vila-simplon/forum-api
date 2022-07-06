using back.Models;
using back.Repositories;
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
        private Mock<CommentRepository> _repository;
        private List<Comment> _comments;

        [TestInitialize]

        public void Initialize()
        {
            _commentService = new CommentService();
            _repository = new Mock<CommentRepository>();
            _comments = new List<Comment>();
            _comments.Add(new Comment(1, new DateTime(), new DateTime(), "blabla", new User(), new Topic()));
            _comments.Add(new Comment(2, new DateTime(), new DateTime(), "blabla", new User(), new Topic()));
            _comments.Add(new Comment(3, new DateTime(), new DateTime(), "blabla", new User(), new Topic()));
        }



        [TestMethod()]
        public void CommentTest()
        {
            Assert.Fail();
        }
    }
}

