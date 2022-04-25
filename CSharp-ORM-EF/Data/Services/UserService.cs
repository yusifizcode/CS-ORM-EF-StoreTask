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
    internal class UserService
    {
        BravoStoreDbContext bravoStoreDbContext = new BravoStoreDbContext();
        UsersData usersData = new UsersData();
        public void CheckExistsUser(Users user)
        {
            var users = bravoStoreDbContext.Users.Where(x => x.Username == user.Username || x.Email==user.Email).ToList();
            if (users.Count>0)
            {
                throw new DataIsAlreadyExistsException("Bu istifadeci adi veya emaili artiq movcuddur1");
            }
            else
            {
                usersData.AddUser(user);
            }
        }

        public void CheckIdForUser(int id)
        {
            var user = bravoStoreDbContext.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                usersData.GetCommentsByUserId(id);
            }
            else
            {
                throw new NotFoundException("Bele bir user yoxdur!");
            }
        }
    }
}
