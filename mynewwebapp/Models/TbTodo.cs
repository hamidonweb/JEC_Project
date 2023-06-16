using System;
using System.Collections.Generic;

namespace mynewwebapp.Models
{
    public partial class TbTodo
    {
        public int Id { get; set; }
        public string? TodoDesc { get; set; }
        public int? Sequence { get; set; }
        public bool? Status { get; set; }
        public int? CategoryId { get; set; }
        public int? UserId { get; set; }
    }
}
