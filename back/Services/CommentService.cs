﻿using back.Models;
using back.Repositories.Interfaces;
using back.Services.Interfaces;

namespace back.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public Comment GetById(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("You must specify an id !");
            }

            return _commentRepository.GetById(id);
        }

        public Comment Create(Comment comment)
        {
            
            if (comment.Content?.Length > 500)
            {
                throw new ArgumentException("Your comment content has a 500 maximum character limit");
            }

            if (comment.CommentId > 0)
            {
                throw new ArgumentException("Comment is not new !");
            }

            return _commentRepository.Create(comment);
            
        }

        public Comment Update(Comment comment)
        {
            if (comment.CommentId <= 0)
                throw new ArgumentException("The comment must exist to be updated");

            return _commentRepository.Update(comment);
        }
    }
}
