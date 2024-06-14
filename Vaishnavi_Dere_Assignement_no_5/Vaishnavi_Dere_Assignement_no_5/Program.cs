using System;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;

namespace Vaishnavi_dere_Assignment_no_3
{
    public class BaseEntity
    {
        public int Id { get; set; }
    }

    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }

    public class EmployeeBasicDetails : BaseEntity
    {
        public string Salutory { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string EmployeeID { get; set; }
        public string Role { get; set; }
        public string ReportingManagerUId { get; set; }
        public string ReportingManagerName { get; set; }
        public Address Address { get; set; }
    }

    public class WorkInfo
    {
        public string DesignationName { get; set; }
        public string DepartmentName { get; set; }
        public string LocationName { get; set; }
        public string EmployeeStatus { get; set; } 
        public string SourceOfHire { get; set; }
        public DateTime DateOfJoining { get; set; }
    }

    public class PersonalDetails
    {
        public DateTime DateOfBirth { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Religion { get; set; }
        public string Caste { get; set; }
        public string MaritalStatus { get; set; }
        public string BloodGroup { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
    }

    public class IdentityInfo
    {
        public string PAN { get; set; }
        public string Aadhar { get; set; }
        public string Nationality { get; set; }
        public string PassportNumber { get; set; }
        public string PFNumber { get; set; }
    }

    public class EmployeeAdditionalDetails : BaseEntity
    {
        public string EmployeeBasicDetailsUId { get; set; }
        public string AlternateEmail { get; set; }
        public string AlternateMobile { get; set; }
        public WorkInfo WorkInformation { get; set; }
        public PersonalDetails PersonalDetails { get; set; }
        public IdentityInfo IdentityInformation { get; set; }
    }

    class Program
    {
        static List<EmployeeBasicDetails> employeeBasicDetailsList = new List<EmployeeBasicDetails>();
        static List<EmployeeAdditionalDetails> employeeAdditionalDetailsList = new List<EmployeeAdditionalDetails>();

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Employee Management System");
                Console.WriteLine("1. Create Employee");
                Console.WriteLine("2. Read Employee");
                Console.WriteLine("3. Update Employee");
                Console.WriteLine("4. Delete Employee");
                Console.WriteLine("5. Import from Excel");
                Console.WriteLine("6. Export to Excel");
                Console.WriteLine("7. Exit");
                Console.Write("Select an option: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        CreateEmployee();
                        break;
                    case "2":
                        ReadEmployee();
                        break;
                    case "3":
                        UpdateEmployee();
                        break;
                    case "4":
                        DeleteEmployee();
                        break;
                    case "5":
                        ImportFromExcel();
                        break;
                    case "6":
                        ExportToExcel();
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

        static void CreateEmployee()
        {
            var basicDetails = new EmployeeBasicDetails();
            var workInfo = new WorkInfo();
            var personalDetails = new PersonalDetails();
            var identityInfo = new IdentityInfo();
            var additionalDetails = new EmployeeAdditionalDetails();

            Console.WriteLine("Enter basic details:");
            Console.Write("First Name: ");
            basicDetails.FirstName = Console.ReadLine();
            Console.Write("Last Name: ");
            basicDetails.LastName = Console.ReadLine();
            Console.Write("Email: ");
            basicDetails.Email = Console.ReadLine();

            Console.WriteLine("Enter work information:");
            Console.Write("Designation Name: ");
            workInfo.DesignationName = Console.ReadLine();
            Console.Write("Department Name: ");
            workInfo.DepartmentName = Console.ReadLine();
            workInfo.DateOfJoining = DateTime.Now;  

            Console.WriteLine("Enter personal details:");
            Console.Write("Date of Birth (yyyy-mm-dd): ");
            personalDetails.DateOfBirth = DateTime.Parse(Console.ReadLine());
            Console.Write("Gender: ");
            personalDetails.Gender = Console.ReadLine();

            Console.WriteLine("Enter identity information:");
            Console.Write("PAN: ");
            identityInfo.PAN = Console.ReadLine();
            Console.Write("Aadhar: ");
            identityInfo.Aadhar = Console.ReadLine();

            basicDetails.EmployeeID = Guid.NewGuid().ToString();
            additionalDetails.EmployeeBasicDetailsUId = basicDetails.EmployeeID;
            additionalDetails.WorkInformation = workInfo;
            additionalDetails.PersonalDetails = personalDetails;
            additionalDetails.IdentityInformation = identityInfo;

            employeeBasicDetailsList.Add(basicDetails);
            employeeAdditionalDetailsList.Add(additionalDetails);

            Console.WriteLine("Employee created successfully!");
            Console.WriteLine($"Employee ID: {basicDetails.EmployeeID}");
        }

        static void ReadEmployee()
        {
            if (employeeBasicDetailsList.Count == 0)
            {
                Console.WriteLine("No employees found.");
                return;
            }

            Console.Write("Enter Employee ID to read: ");
            var empId = Console.ReadLine();

            if (string.IsNullOrEmpty(empId))
            {
                Console.WriteLine("Employee ID cannot be empty.");
                return;
            }

            var basicDetails = employeeBasicDetailsList.Find(e => e.EmployeeID == empId);
            var additionalDetails = employeeAdditionalDetailsList.Find(e => e.EmployeeBasicDetailsUId == empId);

            if (basicDetails != null && additionalDetails != null)
            {
                Console.WriteLine($"Employee: {basicDetails.FirstName} {basicDetails.LastName}");
                Console.WriteLine($"Email: {basicDetails.Email}");
                Console.WriteLine($"Date of Joining: {additionalDetails.WorkInformation.DateOfJoining}");
            }

            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        static void UpdateEmployee()
        {
            if (employeeBasicDetailsList.Count == 0)
            {
                Console.WriteLine("No employees found.");
                return;
            }

            Console.Write("Enter Employee ID to update: ");
            var empId = Console.ReadLine();

            if (string.IsNullOrEmpty(empId))
            {
                Console.WriteLine("Employee ID cannot be empty.");
                return;
            }

            var basicDetails = employeeBasicDetailsList.Find(e => e.EmployeeID == empId);
            var additionalDetails = employeeAdditionalDetailsList.Find(e => e.EmployeeBasicDetailsUId == empId);

            if (basicDetails != null && additionalDetails != null)
            {
                Console.WriteLine("Enter new details (leave blank to keep current value):");

                Console.Write("First Name: ");
                var firstName = Console.ReadLine();
                if (!string.IsNullOrEmpty(firstName)) basicDetails.FirstName = firstName;

                Console.Write("Last Name: ");
                var lastName = Console.ReadLine();
                if (!string.IsNullOrEmpty(lastName)) basicDetails.LastName = lastName;

                Console.Write("Email: ");
                var email = Console.ReadLine();
                if (!string.IsNullOrEmpty(email)) basicDetails.Email = email;


                Console.WriteLine("Employee updated successfully!");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        static void DeleteEmployee()
        {
            if (employeeBasicDetailsList.Count == 0)
            {
                Console.WriteLine("No employees found.");
                return;
            }

            Console.Write("Enter Employee ID to delete: ");
            var empId = Console.ReadLine();

            if (string.IsNullOrEmpty(empId))
            {
                Console.WriteLine("Employee ID cannot be empty.");
                return;
            }

            var basicDetails = employeeBasicDetailsList.Find(e => e.EmployeeID == empId);
            var additionalDetails = employeeAdditionalDetailsList.Find(e => e.EmployeeBasicDetailsUId == empId);

            if (basicDetails != null && additionalDetails != null)
            {
                employeeBasicDetailsList.Remove(basicDetails);
                employeeAdditionalDetailsList.Remove(additionalDetails);

                Console.WriteLine("Employee deleted successfully!");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        static void ImportFromExcel()
        {
            Console.Write("Enter the path of the Excel file to import: ");
            var filePath = Console.ReadLine();

            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                Console.WriteLine("Invalid file path.");
                return;
            }

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0]; 
                int rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++) 
                {
                    var basicDetails = new EmployeeBasicDetails
                    {
                        FirstName = worksheet.Cells[row, 2].Text,
                        LastName = worksheet.Cells[row, 3].Text,
                        Email = worksheet.Cells[row, 4].Text,
                        Mobile = worksheet.Cells[row, 5].Text,
                        ReportingManagerName = worksheet.Cells[row, 6].Text,
                        EmployeeID = Guid.NewGuid().ToString() 
                    };

                    var workInfo = new WorkInfo
                    {
                        DateOfJoining = DateTime.Parse(worksheet.Cells[row, 8].Text)
                    };

                    var personalDetails = new PersonalDetails
                    {
                        DateOfBirth = DateTime.Parse(worksheet.Cells[row, 7].Text)
                    };

                    var additionalDetails = new EmployeeAdditionalDetails
                    {
                        EmployeeBasicDetailsUId = basicDetails.EmployeeID,
                        WorkInformation = workInfo,
                        PersonalDetails = personalDetails
                    };

                    employeeBasicDetailsList.Add(basicDetails);
                    employeeAdditionalDetailsList.Add(additionalDetails);
                }
            }

            Console.WriteLine("Data imported successfully!");
        }

        static void ExportToExcel()
        {
            Console.Write("Enter the path to save the Excel file: ");
            var filePath = Console.ReadLine();

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Employees");

                worksheet.Cells[1, 1].Value = "Sr.No";
                worksheet.Cells[1, 2].Value = "First Name";
                worksheet.Cells[1, 3].Value = "Last Name";
                worksheet.Cells[1, 4].Value = "Email";
                worksheet.Cells[1, 5].Value = "Phone No";
                worksheet.Cells[1, 6].Value = "Reporting Manager Name";
                worksheet.Cells[1, 7].Value = "Date Of Birth";
                worksheet.Cells[1, 8].Value = "Date of Joining";

                for (int i = 0; i < employeeBasicDetailsList.Count; i++)
                {
                    var basicDetails = employeeBasicDetailsList[i];
                    var additionalDetails = employeeAdditionalDetailsList.Find(e => e.EmployeeBasicDetailsUId == basicDetails.EmployeeID);

                    worksheet.Cells[i + 2, 1].Value = i + 1; 
                    worksheet.Cells[i + 2, 2].Value = basicDetails.FirstName;
                    worksheet.Cells[i + 2, 3].Value = basicDetails.LastName;
                    worksheet.Cells[i + 2, 4].Value = basicDetails.Email;
                    worksheet.Cells[i + 2, 5].Value = basicDetails.Mobile;
                    worksheet.Cells[i + 2, 6].Value = basicDetails.ReportingManagerName;
                    worksheet.Cells[i + 2, 7].Value = additionalDetails.PersonalDetails.DateOfBirth.ToShortDateString();
                    worksheet.Cells[i + 2, 8].Value = additionalDetails.WorkInformation.DateOfJoining.ToShortDateString();
                }

                package.SaveAs(new FileInfo(filePath));
            }

            Console.WriteLine("Data exported successfully!");
        }
    }
}