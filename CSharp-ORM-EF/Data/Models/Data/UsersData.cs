using CSharp_ORM_EF.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp_ORM_EF.Data.Models.Data
{
    internal class UsersData
    {
        BravoStoreDbContext bravoStoreDbContext = new BravoStoreDbContext();


        public void AddUser(Users user)
        {
            bravoStoreDbContext.Users.Add(user);
            bravoStoreDbContext.SaveChanges();
        }


        public void GetCommentsByUserId(int userId)
        {
            foreach (var item in bravoStoreDbContext.Comments.Where(x => x.UserId == userId).ToList())
            {
                Console.WriteLine(item.Text);
            };
        }

    }
}
