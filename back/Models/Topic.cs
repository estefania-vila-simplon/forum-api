using System;
using System.Collections.Generic;

namespace back.Models
{
    public partial class Topic
    {
        public Topic()
        {
            //Comments = new HashSet<Comment>();
        }

        public Topic(int topicId, DateTime creationDate, DateTime? modifDate, string topicTitle, string createdBy)
        {
            TopicId = topicId;
            CreationDate = creationDate;
            ModifDate = modifDate;
            TopicTitle = topicTitle;
            CreatedBy = createdBy;
            //Comments = comments;
        }

        public int TopicId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModifDate { get; set; }
        public string TopicTitle { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;

        //public virtual ICollection<Comment> Comments { get; set; }
    }
}
