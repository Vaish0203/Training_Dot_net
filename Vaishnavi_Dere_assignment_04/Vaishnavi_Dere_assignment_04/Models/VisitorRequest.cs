namespace Vaishnavi_Dere_assignment_04.Models
{
    public class VisitorRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string CompanyName { get; set; }
        public string Purpose { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime ExitTime { get; set; }
        public string Status { get; set; }
        public string PassFilePath { get; set; }
    }

}
