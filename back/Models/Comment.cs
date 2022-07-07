using System;
using System.Collections.Generic;

namespace back.Models
{
    public partial class Comment
    {
        public Comment() { }
        public Comment(int commentId, DateTime creationDate, DateTime? modifDate, string content, string createdBy, int commentTopicId, Topic commentTopic)
        {
            CommentId = commentId;
            CreationDate = creationDate;
            ModifDate = modifDate;
            Content = content;
            CreatedBy = createdBy;
            CommentTopicId = commentTopicId;
            CommentTopic = commentTopic;
        }
        
        public Comment(int commentId, DateTime creationDate, DateTime? modifDate, string content, string createdBy, Topic commentTopic)
        {
            CommentId = commentId;
            CreationDate = creationDate;
            ModifDate = modifDate;
            Content = content;
            CreatedBy = createdBy;
            CommentTopic = commentTopic;
        }

        public int CommentId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModifDate { get; set; }
        public string Content { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
        public int CommentTopicId { get; set; }

        public Topic CommentTopic { get; set; } = null!;
    }
}
