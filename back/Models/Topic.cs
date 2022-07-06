using System;
using System.Collections.Generic;

namespace back.Models
{
    public partial class Topic
    {
        public Topic() { }
        public Topic(int topicId, DateTime creationDate, DateTime modifDate, string topicTitle, User topicUser, Comment topicComment)
        {
            TopicId = topicId;
            CreationDate = creationDate;
            ModifDate = modifDate;
            TopicTitle = topicTitle;
            TopicUser = topicUser;
            TopicComment = topicComment;
        }

        public int TopicId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifDate { get; set; }
        public string TopicTitle { get; set; } = null!;

        public virtual User TopicUser { get; set; } = null!;
        public virtual Comment TopicComment { get; set; } = null!;
    }
}
