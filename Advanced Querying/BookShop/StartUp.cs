using System;
using System.Text;

namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);
                //Console.WriteLine(GetBooksByAgeRestriction(db));
                //Console.WriteLine(GetGoldenBooks(db));
                //Console.WriteLine(GetBooksByPrice(db));
                //Console.WriteLine(GetBooksNotReleasedIn(db, 2000));
                //Console.WriteLine(GetBooksByCategory(db, Console.ReadLine()));
                //Console.WriteLine(GetBooksReleasedBefore(db, Console.ReadLine()));
                GetAuthorNamesEndingIn(db, Console.ReadLine());
            }
        }

        public static string GetBooksByAgeRestriction(BookShopContext context)
        {
            string command = Console.ReadLine();

            command = command[0].ToString().ToUpper() + command.Substring(1, command.Length - 1).ToLower();

            StringBuilder response = new StringBuilder();

            var content = (AgeRestriction)Enum.Parse(typeof(AgeRestriction), command);

            context.Books.Where(book => book.AgeRestriction == content)
                .OrderBy(book => book.Title)
                .Select(book => book.Title)
                .ToList()
                .ForEach(book => 
                {
                    response.Append($"{book} \n");
                });

            return response.ToString();
        }
        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder response = new StringBuilder();

            context.Books.Where(book => (book.EditionType == EditionType.Gold) && book.Copies < 5000)
                .Select(book => book.Title)
                .ToList()
                .ForEach(book =>
                {
                    response.Append(book + Environment.NewLine);
                });

            return response.ToString();
        }
        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder response = new StringBuilder();

            context.Books.Where(book => book.Price > 40)
                .OrderByDescending(book => book.Price)
                .Select(book => new { book.Title, book.Price })
                .ToList()
                .ForEach(book => 
                {
                    response.Append($"{book.Title} ${book.Price} \n");
                });

            return response.ToString();
        }
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder response = new StringBuilder();

            context.Books.Where(book => book.ReleaseDate.Value.Year != year)
                .Select(book => book.Title)
                .ToList()
                .ForEach(book => 
                {
                    response.Append($"{book} \n");
                });

            return response.ToString();
        }
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            StringBuilder response = new StringBuilder();

            var genres =  input.Split(" ");

            (from book in context.Books
             join bookCategory in context.BooksCategories on book.BookId equals bookCategory.BookId
             join category in context.Categories on bookCategory.CategoryId equals category.CategoryId
             where genres.Any(genre => genre == category.Name)             
             select new
             {
                 book.Title
             })
             .OrderBy(book => book.Title)
             .ToList()
             .ForEach(book => 
             {
                 response.Append($"{book.Title} \n");
             });

            return response.ToString();
        }
        public static string GetBooksReleasedBefore(BookShopContext context, string date) 
        {

            string[] dateFragments =  date.Split(new char[] { '-' });
            var targetDateTime = new DateTime(Convert.ToInt32(dateFragments[2]), Convert.ToInt32(dateFragments[1]), Convert.ToInt32(dateFragments[0]));

            StringBuilder response = new StringBuilder();

            context.Books.Where(book => book.ReleaseDate < targetDateTime)
                .OrderByDescending(book => book.ReleaseDate)
                .Select(book => new
                {
                    book.Title,
                    book.EditionType,
                    book.Price
                })
                .ToList()
                .ForEach(book =>
                {
                    response.Append($"{book.Title} - {book.EditionType.ToString()} - {book.Price} \n");
                });

            return response.ToString();

        }
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            string response = string.Empty;

            //var count = context.Authors.Where(author => author.FirstName.EndsWith(input)).ToList();

            var authors = context.Authors.Where(author => author.FirstName.EndsWith(input))
                .OrderBy(author => author.FirstName)
                .ToList();

            foreach (var author in authors)
            {
                response += $"{author.FirstName} {author.LastName} \n";
            }

            return response.ToString();
        }
    }
}
