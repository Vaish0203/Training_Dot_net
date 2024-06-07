using System;
using Vaishnavi_Dere_03_Assignement.Models;
using Vaishnavi_Dere_03_Assignement.Services;

namespace LibraryManagementSystem
{
    class Program
    {
        private static BookService bookService = new BookService();
        private static MemberService memberService = new MemberService();
        private static IssueService issueService = new IssueService();

        static void Main(string[] args)
        {
            // Add sample data
            AddSampleData();

            // Example usage
            var books = bookService.GetAllBooks();
            Console.WriteLine("Books in library:");
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} by {book.Author}");
            }

            // Add more interactive features as needed
        }

        private static void AddSampleData()
        {
            // Add sample books
            bookService.AddBook(new Book { UId = "1", Title = "Book 1", Author = "Author 1", PublishedDate = DateTime.Now, ISBN = "12345", IsIssued = false });
            bookService.AddBook(new Book { UId = "2", Title = "Book 2", Author = "Author 2", PublishedDate = DateTime.Now, ISBN = "67890", IsIssued = false });

            // Add sample members
            memberService.AddMember(new Member { UId = "1", Name = "Member 1", DateOfBirth = new DateTime(1990, 1, 1), Email = "member1@example.com" });
            memberService.AddMember(new Member { UId = "2", Name = "Member 2", DateOfBirth = new DateTime(1991, 2, 2), Email = "member2@example.com" });

            // Add sample issues
            issueService.AddIssue(new Issue { UId = "1", BookId = "1", MemberId = "1", IssueDate = DateTime.Now, IsReturned = false });
        }
    }
}
