using System;
using System.Collections.Generic;

namespace mynewwebapp.Models
{
    public partial class TbUser
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
