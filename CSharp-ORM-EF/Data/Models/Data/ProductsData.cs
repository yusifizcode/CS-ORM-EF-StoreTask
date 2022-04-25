using CSharp_ORM_EF.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp_ORM_EF.Data.Models.Data
{
    internal class ProductsData
    {
        BravoStoreDbContext bravoStoreDbContext = new BravoStoreDbContext();
        public void AddProduct(Products product)
        {
            bravoStoreDbContext.Products.Add(product);
            bravoStoreDbContext.SaveChanges();
        }

        public void SearchProduct(string searchStr)
        {
            foreach (var item in bravoStoreDbContext.Products.Where(x => x.Name.Contains(searchStr)).ToList())
            {
                Console.WriteLine(item.Name);
            };
        }

        public void GetProductsAVGPrice()
        {
            double sum = 0;
            var prods = bravoStoreDbContext.Products.ToList();
            foreach (var pr in prods)
            {
                sum += pr.Price;
            }
            Console.WriteLine(sum/ prods.Count);

        }
    }
}
