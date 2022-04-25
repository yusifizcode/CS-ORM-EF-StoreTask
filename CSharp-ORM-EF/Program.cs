using CSharp_ORM_EF.Data.DAL;
using CSharp_ORM_EF.Data.Exceptions;
using CSharp_ORM_EF.Data.Models;
using CSharp_ORM_EF.Data.Models.Data;
using CSharp_ORM_EF.Data.Services;
using System;
using System.Linq;

namespace CSharp_ORM_EF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BravoStoreDbContext bravoStoreDbContext = new BravoStoreDbContext();
            ProductService productService = new ProductService();
            CommentService commentService = new CommentService();
            UserService userService = new UserService();
            string ans = "";
            string prodName = "";
            string prodPriceStr;
            double prodPrice;
            string prodSearch = "";
            string prodIdStr;
            int prodId;
            string userIdStr;
            int userId;
            string commentIdStr;
            int commentId;
            string startDateStr;
            string endDateStr;
            DateTime startDate;
            DateTime endDate;
            string commentText = "";
            string username = "";
            string email = "";



            do
            {

                Console.WriteLine("1. Product elave et\n2. Productlar uzre axtarish et\n3. Secilmis productin commentlerine bax (productİd ile)\n4. Secilmis userin commentlerine bax (userİd ile)\n5. Commenti sil (id ile)\n6. Productlarin ortalama qiymetine bax\n7. Verilmis 2 tarix araligindaki Commentlere bax\n8. Comment elave et\n9. User elave et\n0.Proqrami bitir.");
                ans = Console.ReadLine();


                switch (ans)
                {
                    case "1":
                        do
                        {
                            Console.WriteLine("Productin adini daxil edin: ");
                            prodName = Console.ReadLine();
                        } while (String.IsNullOrWhiteSpace(prodName));

                        do
                        {
                            Console.WriteLine("Productin qiymetini daxil edin: ");
                            prodPriceStr = Console.ReadLine();
                        } while (!double.TryParse(prodPriceStr, out prodPrice));

                        Products product = new Products
                        {
                            Name = prodName,
                            Price = prodPrice,
                            CreatedAt = DateTime.Now,
                        };
                        try
                        {
                            productService.CheckExistsProduct(product);
                        }
                        catch (DataIsAlreadyExistsException) { Console.WriteLine("Bu mehsul artiq movcuddur!"); };
                        break;
                    case "2":

                        do
                        {
                            Console.WriteLine("Axtarish deyerini daxil edin: ");
                            prodSearch = Console.ReadLine();
                        } while (String.IsNullOrWhiteSpace(prodSearch));

                        try
                        {
                            productService.CheckSearchData(prodSearch);
                        }
                        catch (NotFoundException)
                        {

                            Console.WriteLine("Bele bir mehsul yoxdur!"); ;
                        };
                        break;

                    case "3":

                        Console.WriteLine("===================Products===================");
                        foreach (var item in bravoStoreDbContext.Products.ToList())
                        {
                            Console.WriteLine(item.Id + " - " + item.Name);
                        }

                        do
                        {
                            Console.WriteLine("Product id daxil edin: ");
                            prodIdStr = Console.ReadLine();
                        } while (!int.TryParse(prodIdStr, out prodId));

                        try
                        {
                            commentService.CheckCommentForProductId(prodId);
                        }
                        catch (NotFoundException)
                        {

                            Console.WriteLine("Bu mehsulun commenti yoxdur!"); ;
                        };
                        break;

                    case "4":

                        Console.WriteLine("===================Users===================");
                        foreach (var item in bravoStoreDbContext.Users.ToList())
                        {
                            Console.WriteLine(item.Id + " - " + item.Username);
                        }

                        do
                        {
                            Console.WriteLine("User id daxil edin: ");
                            userIdStr = Console.ReadLine();
                        } while (!int.TryParse(userIdStr, out userId));

                        try
                        {
                            commentService.CheckCommentForUserId(userId);
                        }
                        catch (NotFoundException)
                        {

                            Console.WriteLine("Bu userin commenti yoxdur!"); ;
                        };
                        break;
                    case "5":

                        Console.WriteLine("===================Comments===================");
                        foreach (var item in bravoStoreDbContext.Comments.ToList())
                        {
                            Console.WriteLine(item.Id + " - " + item.Text);
                        }

                        do
                        {
                            Console.WriteLine("Silmek istediyiniz commentin id'sini yazin: ");
                            commentIdStr = Console.ReadLine();
                        } while (!int.TryParse(commentIdStr, out commentId));

                        try
                        {
                            commentService.CheckCommentForDelete(commentId);
                        }
                        catch (NotFoundException)
                        {

                            Console.WriteLine("Bele bir comment yoxdur!"); ;
                        };
                        break;
                    case "6":

                        try
                        {
                            productService.CheckProductsPrice();
                        }
                        catch (NotFoundException)
                        {

                            Console.WriteLine("Mehsul yoxdur!"); ;
                        };

                        break;

                    case "7":

                        do
                        {
                            Console.WriteLine("Birinci tarixi yazin: ");
                            startDateStr = Console.ReadLine();
                        } while (!DateTime.TryParse(startDateStr, out startDate));

                        do
                        {
                            Console.WriteLine("Ikinci tarixi yazin: ");
                            endDateStr = Console.ReadLine();
                        } while (!DateTime.TryParse(endDateStr, out endDate));

                        try
                        {
                            commentService.CheckCommentForDate(startDate, endDate);
                        }
                        catch (NotFoundException)
                        {

                            Console.WriteLine("Bu tarix araliginda comment yoxdur!"); ;
                        };

                        break;

                    case "8":

                        Console.WriteLine("===================Users===================");
                        foreach (var item in bravoStoreDbContext.Users.ToList())
                        {
                            Console.WriteLine(item.Id + " - " + item.Username);
                        }

                        Console.WriteLine("===================Products===================");
                        foreach (var item in bravoStoreDbContext.Products.ToList())
                        {
                            Console.WriteLine(item.Id + " - " + item.Name);
                        }

                        do
                        {
                            Console.WriteLine("User id daxil edin: ");
                            userIdStr = Console.ReadLine();
                        } while (!int.TryParse(userIdStr, out userId));

                        do
                        {
                            Console.WriteLine("Product id daxil edin: ");
                            prodIdStr = Console.ReadLine();
                        } while (!int.TryParse(prodIdStr, out prodId));

                        do
                        {
                            Console.WriteLine("Comment daxil edin: ");
                            commentText = Console.ReadLine();
                        } while (String.IsNullOrWhiteSpace(commentText));

                        Comments comment = new Comments
                        {
                            ProductId = prodId,
                            UserId = userId,
                            Text = commentText,
                            CreatedAt = DateTime.Now,
                        };

                        try
                        {
                            commentService.CheckAddComment(comment);
                        }
                        catch (NotFoundException)
                        {

                            Console.WriteLine("Bu id'li user veya mehsul yoxdur!"); ;
                        };
                        break;
                    case "9":

                        do
                        {
                            Console.WriteLine("Username daxil edin: ");
                            username = Console.ReadLine();
                        } while (String.IsNullOrWhiteSpace(username));

                        do
                        {
                            Console.WriteLine("Email daxil edin: ");
                            email = Console.ReadLine();
                        } while (String.IsNullOrWhiteSpace(email));

                        Users user = new Users
                        {
                            Username = username,
                            Email = email,
                            CreatedAt = DateTime.Now,
                        };

                        try
                        {
                            userService.CheckExistsUser(user);
                        }
                        catch (DataIsAlreadyExistsException)
                        {

                            Console.WriteLine("Bu username veya email artiq movcuddur!");
                        };
                        break;
                }


            } while (ans != "0");

        }
    }
}
