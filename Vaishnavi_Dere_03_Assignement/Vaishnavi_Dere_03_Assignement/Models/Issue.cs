using System;

namespace Vaishnavi_Dere_03_Assignement.Models
{
    public class Issue
    {
        public string UId { get; set; }
        public string BookId { get; set; }
        public string MemberId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool isReturned { get; set; }
        public bool IsReturned { get; internal set; }
    }
}
