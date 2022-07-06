using System;
using System.Collections.Generic;

namespace back.Models
{
    public partial class Comment
    {
        
        public Comment() { }
        public Comment(int commentId, DateTime creationDate, DateTime modifDate, string content, User commentUser, Topic commentTopic)
        {
            CommentId = commentId;
            CreationDate = creationDate;
            ModifDate = modifDate;
            Content = content;
            CommentUser = commentUser;
            CommentTopic = commentTopic;
        }

        
        public int CommentId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifDate { get; set; }
        public string Content { get; set; } = null!;

        public virtual User CommentUser { get; set; } = null!;
        public virtual Topic CommentTopic { get; set; } = null!;
    }
}
