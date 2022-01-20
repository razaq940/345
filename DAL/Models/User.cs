using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class User
    {
        public long Id { get; set; }
        public bool? IsActivation { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public long? FkAddres { get; set; }
        public long FkRoleBase { get; set; }
        public long? FkStore { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UdatedAt { get; set; }
    }
}
