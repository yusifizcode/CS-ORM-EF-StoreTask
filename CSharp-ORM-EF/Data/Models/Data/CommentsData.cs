using CSharp_ORM_EF.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp_ORM_EF.Data.Models.Data
{

    internal class CommentsData
    {
        BravoStoreDbContext bravoStoreDbContext = new BravoStoreDbContext();


        public void AddComment(Comments comment)
        {
            bravoStoreDbContext.Comments.Add(comment);
            bravoStoreDbContext.SaveChanges();
        }


        public void GetCommentsByProductId(int productId)
        {
            foreach (var item in bravoStoreDbContext.Comments.Where(x => x.ProductId == productId).ToList())
            {
                Console.WriteLine(item.Text);
            };
        }

        public void DeleteComment(Comments comment)
        {
            //var comment = bravoStoreDbContext.Comments.Find(id);
            bravoStoreDbContext.Comments.Remove(comment);
            bravoStoreDbContext.SaveChanges();
        }


        public void GetCommentsForDate(DateTime startDate, DateTime endDate)
        {
            foreach (var item in bravoStoreDbContext.Comments.Where(x => x.CreatedAt > startDate && x.CreatedAt < endDate).ToList())
            {
                Console.WriteLine(item.Text);
            };
        }
    }
}
