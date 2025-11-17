using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ex12.Models;

namespace ex12.Pages;

public class EmployeesModel : PageModel
{
    public List<Employee> Employees { get; set; } = new();

    public void OnGet()
    {
        // Populate sample employee data
        Employees = new List<Employee>
        {
            new Employee
            {
                EmployeeId = 1,
                EmployeeName = "Jini Sharma",
                EmployeeDesignation = "Software Architect",
                CompanyName = "Google Inc",
                CompanyLocation = "United States"
            },
            new Employee
            {
                EmployeeId = 2,
                EmployeeName = "Raj Kumar",
                EmployeeDesignation = "Senior Developer",
                CompanyName = "Microsoft Corp",
                CompanyLocation = "India"
            },
            new Employee
            {
                EmployeeId = 3,
                EmployeeName = "Priya Patel",
                EmployeeDesignation = "Product Manager",
                CompanyName = "Amazon Inc",
                CompanyLocation = "Canada"
            },
            new Employee
            {
                EmployeeId = 4,
                EmployeeName = "Ahmed Hassan",
                EmployeeDesignation = "DevOps Engineer",
                CompanyName = "Apple Inc",
                CompanyLocation = "United Kingdom"
            }
        };

        // Set ViewData for the page
        ViewData["PageTitle"] = "Employees Directory";
        ViewData["TotalEmployees"] = Employees.Count;
        ViewData["Department"] = "Engineering";
        ViewData["LastUpdated"] = DateTime.Now.ToString("dddd, MMMM dd, yyyy");
    }
}
