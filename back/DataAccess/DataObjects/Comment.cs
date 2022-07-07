using System;
using System.Collections.Generic;

namespace back.DataAccess.DataObjects
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifDate { get; set; }
        public string Content { get; set; } = null!;

        public virtual User Comment1 { get; set; } = null!;
        public virtual Topic CommentNavigation { get; set; } = null!;
    }
}
