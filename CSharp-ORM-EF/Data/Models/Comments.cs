using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_ORM_EF.Data.Models
{
    internal class Comments
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public Users Users { get; set; }
        public Products Products { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
