using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiPost.Models
{
    public partial class RoleOperation
    {
        public int Id { get; set; }
        public int IdRole { get; set; }
        public int IdOperation { get; set; }
        public string IdStatus { get; set; }

        public virtual Operation IdOperationNavigation { get; set; }
        public virtual Role IdRoleNavigation { get; set; }
    }
}
