using System;
using System.Collections.Generic;

namespace back.DataAccess.DataObjects
{
    public partial class Topic
    {
        public int TopicId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifDate { get; set; }
        public string TopicTitle { get; set; } = null!;

        public virtual User TopicNavigation { get; set; } = null!;
        public virtual Comment Comment { get; set; } = null!;
        public string Content { get; set; } = null!;

    }
}
