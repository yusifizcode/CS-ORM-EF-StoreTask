using CSharp_ORM_EF.Data.DAL;
using CSharp_ORM_EF.Data.Exceptions;
using CSharp_ORM_EF.Data.Models;
using CSharp_ORM_EF.Data.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp_ORM_EF.Data.Services
{
    internal class ProductService
    {
        BravoStoreDbContext bravoStoreDbContext = new BravoStoreDbContext();
        ProductsData productsData = new ProductsData();

        public void CheckExistsProduct(Products product)
        {
            var prod = bravoStoreDbContext.Products.Where(x => x.Name == product.Name).ToList();
            if (prod.Count>0)
            {
                throw new DataIsAlreadyExistsException("Bu mehsul artiq var!");
            }
            else
            {
                productsData.AddProduct(product);
            }
        }

        public void CheckSearchData(string searchStr)
        {
            var products = bravoStoreDbContext.Products.Where(x => x.Name.Contains(searchStr)).ToList();
            if (products.Count > 0)
            {
                productsData.SearchProduct(searchStr);
            }
            else
            {
                throw new NotFoundException("Bele bir product yoxdur!");
            }
        }

        public void CheckProductsPrice()
        {
            var products = bravoStoreDbContext.Products.ToList();
            if (products.Count > 0)
            {
                productsData.GetProductsAVGPrice();
            }
            else
            {
                throw new NotFoundException("Mehsul yoxdur!");
            }
        }
    }
}
