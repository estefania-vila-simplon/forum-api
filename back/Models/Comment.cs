using System;
using System.Collections.Generic;

namespace back.Models
{
    public partial class Comment
    {

        public Comment()
        {

        }

        public Comment(int commentId, DateTime creationDate, Nullable<DateTime> modifDate, string content, string createdBy, Topic commentTopic)
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
        public Nullable<DateTime>ModifDate { get; set; }
        public string Content { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;

        public virtual Topic CommentTopic { get; set; } = null!;
    }
}
