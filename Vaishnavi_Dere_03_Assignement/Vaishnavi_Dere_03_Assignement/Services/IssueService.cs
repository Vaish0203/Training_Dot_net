using System.Collections.Generic;
using System.Linq;
using Vaishnavi_Dere_03_Assignement.Models;

namespace Vaishnavi_Dere_03_Assignement.Services
{
    public class IssueService
    {
        private List<Issue> issues = new List<Issue>();

        public void AddIssue(Issue issue)
        {
            issues.Add(issue);
        }

        public Issue GetIssueById(string uid)
        {
            return issues.FirstOrDefault(i => i.UId == uid);
        }

        public void UpdateIssue(Issue updatedIssue)
        {
            var issue = issues.FirstOrDefault(i => i.UId == updatedIssue.UId);
            if (issue != null)
            {
                issue.BookId = updatedIssue.BookId;
                issue.MemberId = updatedIssue.MemberId;
                issue.IssueDate = updatedIssue.IssueDate;
                issue.ReturnDate = updatedIssue.ReturnDate;
                issue.IsReturned = updatedIssue.IsReturned;
            }
        }
    }
}
