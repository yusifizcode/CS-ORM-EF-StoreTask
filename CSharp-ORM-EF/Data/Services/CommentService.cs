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
    internal class CommentService
    {
        BravoStoreDbContext bravoStoreDbContext = new BravoStoreDbContext();
        CommentsData commentsData = new CommentsData();
        UsersData usersData = new UsersData();


        public void CheckAddComment(Comments comment)
        {
            if ((bravoStoreDbContext.Users.Find(comment.UserId) != null) && (bravoStoreDbContext.Products.Find(comment.ProductId) != null))
            {
                commentsData.AddComment(comment);
            }
            else
            {
                throw new NotFoundException("Bu id'li user veya mehsul yoxdur!");
            }
        }

        public void CheckIdForComment(int id)
        {
            var comment = bravoStoreDbContext.Comments.Find(id);

            if (comment == null)
            {
                throw new NotFoundException("Comment yoxdur!");
            }
            else
            {
                commentsData.DeleteComment(comment);
            }
        }


        public void CheckCommentForProductId(int id)
        {
            var comments = bravoStoreDbContext.Comments.Where(x => x.ProductId==id).ToList();
            if (comments.Count > 0)
            {
                commentsData.GetCommentsByProductId(id);
            }
            else
            {
                throw new NotFoundException("Bu productda comment yoxdur!");
            }
        }

        public void CheckCommentForUserId(int id)
        {
            var comments = bravoStoreDbContext.Comments.Where(x => x.UserId == id).ToList();
            if (comments.Count > 0)
            {
                usersData.GetCommentsByUserId(id);
            }
            else
            {
                throw new NotFoundException("Bu userin commenti yoxdur!");
            }
        }

        public void CheckCommentForDelete(int id)
        {
            var comment = bravoStoreDbContext.Comments.Find(id);
            if (comment != null)
            {
                commentsData.DeleteComment(comment);
            }
            else
            {
                throw new NotFoundException("Bele bir comment yoxdur!");
            }
        }

        public void CheckCommentForDate(DateTime startDate, DateTime endDate)
        {
            var comments = bravoStoreDbContext.Comments.Where(x => x.CreatedAt > startDate && x.CreatedAt < endDate).ToList();
            if (comments.Count>0)
            {
                commentsData.GetCommentsForDate(startDate, endDate);
            }
            else
            {
                throw new NotFoundException("Bu tarixde comment yoxdur!");
            }
        }


    }
}
