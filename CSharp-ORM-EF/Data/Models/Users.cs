using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_ORM_EF.Data.Models
{
    internal class Users
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
