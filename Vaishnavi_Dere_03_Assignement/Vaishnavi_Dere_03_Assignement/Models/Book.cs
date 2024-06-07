using System;

namespace Vaishnavi_Dere_03_Assignement.Models
{
    public class Book
    {
        public string UId { get; set; }
        public required string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublishedDate { get; set; }
        public string ISBN { get; set; }
        public bool IsIssued { get; set; }
    }
}
