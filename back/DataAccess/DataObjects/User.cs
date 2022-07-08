using System;
using System.Collections.Generic;

namespace back.DataAccess.DataObjects
{
    public partial class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string UserLastName { get; set; } = null!;
        public string UserEmail { get; set; } = null!;

        public virtual Comment Comment { get; set; } = null!;
        public virtual Topic Topic { get; set; } = null!;
    }
}
