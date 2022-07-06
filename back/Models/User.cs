using System;
using System.Collections.Generic;

namespace back.Models
{
    public partial class User
    {
        public User (){ }
        public User(int userId, string userName, string userLastName, string userEmail, Comment comment, Topic topic)
        {
            UserId = userId;
            UserName = userName;
            UserLastName = userLastName;
            UserEmail = userEmail;
            Comment = comment;
            Topic = topic;
        }

        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string UserLastName { get; set; } = null!;
        public string UserEmail { get; set; } = null!;

        public virtual Comment Comment { get; set; } = null!;
        public virtual Topic Topic { get; set; } = null!;
    }
}
