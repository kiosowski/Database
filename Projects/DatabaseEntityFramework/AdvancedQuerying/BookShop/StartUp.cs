namespace BookShop
{
    using BookShop.Data;
    using BookShop.Initializer;
    using BookShop.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                // string command = Console.ReadLine();
                //string result = GetBooksByAgeRestriction(db, command);
                int result = RemoveBooks(db);
                Console.WriteLine(result);
            }
        }
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)

        {
            var ageRestriction = (AgeRestriction)Enum.Parse(typeof(AgeRestriction), command, true);
            var books = context.Books
                .Where(x => x.AgeRestriction == ageRestriction)
                .OrderBy(x => x.Title).Select(x => x.Title)
                .ToArray();
            return String.Join(Environment.NewLine, books);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                               .Where(c => c.Copies < 5000 && c.EditionType == EditionType.Gold)
                               .OrderBy(b => b.BookId)
                               .Select(x => x.Title)
                               .ToArray();

            return String.Join(Environment.NewLine, books);
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books.Where(x => x.Price > 40)
                                     .OrderByDescending(x => x.Price)
                                     .Select(x => $"{x.Title} - ${x.Price:f2}")
                                     .ToArray();

            return String.Join(Environment.NewLine, books);
        }

        public static string GetBooksNotRealeasedIn(BookShopContext context, int year)
        {
            var books = context.Books.Where(x => x.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(x => x.Title)
                .ToArray();


            return String.Join(Environment.NewLine, books);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var books = context.Books
                               .Where(x => x.BookCategories.Any(c => categories.Contains(c.Category.Name.ToLower())))
                               .Select(t => t.Title)
                               .OrderBy(x => x)
                               .ToArray();
            return String.Join(Environment.NewLine, books);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime inputDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            StringBuilder sb = new StringBuilder();
            var books = context.Books
                               .Where(x => x.ReleaseDate.Value < inputDate)
                               .OrderByDescending(x => x.ReleaseDate)
                               .Select(x => new
                               {
                                   x.Title,
                                   x.EditionType,
                                   x.Price
                               })
                               .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }


            return sb.ToString().TrimEnd(); ;
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();
            var authors = context.Authors
                                .Where(f => EF.Functions.Like(f.FirstName, "%" + input))
                                .Select(x => new
                                {
                                    x.FirstName,
                                    x.LastName
                                })
                                .OrderBy(x => x.FirstName)
                                .ThenBy(x => x.LastName)
                                .ToArray();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName}");
            }


            return sb.ToString().TrimEnd(); ;
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                               .Where(x => EF.Functions.Like(x.Title, $"%{input}%"))
                               .Select(x => x.Title)
                               .OrderBy(x => x)
                               .ToArray();

            return String.Join(Environment.NewLine, books);
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                               .Where(x => EF.Functions.Like(x.Author.LastName, $"{input}%"))
                               .OrderBy(x => x.BookId)
                               .Select(x => $"{x.Title} ({x.Author.FirstName} {x.Author.LastName})")
                               .ToArray();

            return String.Join(Environment.NewLine, books);
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books.Where(x => x.Title.Length > lengthCheck)
                .Count();

            return books;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            var authors = context.Authors
                                 .Select(x => new
                                 {
                                     FullName = x.FirstName + " " + x.LastName,
                                     TotalCopies = x.Books.Sum(s => s.Copies)
                                 })
                                 .OrderByDescending(c => c.TotalCopies)
                                 .ToArray();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FullName} - {author.TotalCopies}");

            }
            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            var categories = context.Categories
                                    .Select(x => new
                                    {
                                        x.Name,
                                        TotalProfit = x.CategoryBooks.Sum(s => s.Book.Price * s.Book.Copies)
                                    })
                                    .OrderByDescending(x => x.TotalProfit)
                                    .ThenBy(x => x.Name)
                                        .ToArray();

            foreach (var category in categories)
            {
                sb.AppendLine($"{category.Name} ${category.TotalProfit:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            var categories = context.Categories
                                    .OrderBy(x => x.Name)
                                    .Select(x => new
                                    {
                                        x.Name,
                                        Books = x.CategoryBooks.Select(s => new
                                        {
                                            s.Book.Title,
                                            s.Book.ReleaseDate
                                        })
                                        .OrderByDescending(r => r.ReleaseDate)
                                        .Take(3)
                                        .ToArray()
                                    })
                                    .ToArray();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.Name}");
                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books.Where(x => x.ReleaseDate.Value.Year < 2010)
                .ToArray();

            foreach (var book in books)
            {
                book.Price += 5m;
            }
            context.SaveChanges();

        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                                .Where(x => x.Copies < 4200)
                                .ToArray();
            int count = books.Length;
            context.Books.RemoveRange(books);
            context.SaveChanges();
            return count;
        }

    }
}
