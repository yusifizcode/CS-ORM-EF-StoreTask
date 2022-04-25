using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_ORM_EF.Data.Models
{
    internal class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
