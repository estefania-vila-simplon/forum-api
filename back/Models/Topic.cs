using System;
using System.Collections.Generic;

namespace back.Models
{
    public partial class Topic
    {

        public Topic() { }

        public Topic(int topicId, DateTime creationDate, Nullable<DateTime> modifDate, string topicTitle, string createdBy, List<Comment> comment)
        {
            TopicId = topicId;
            CreationDate = creationDate;
            ModifDate = modifDate;
            TopicTitle = topicTitle;
            CreatedBy = createdBy;
            Comment = comment;
        }

        public int TopicId { get; set; }
        public DateTime CreationDate { get; set; }
        public Nullable<DateTime> ModifDate { get; set; }
        public string TopicTitle { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;

        public virtual List<Comment> Comment { get; set; } = new List<Comment>();
    }
}
