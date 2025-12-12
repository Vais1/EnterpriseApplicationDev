using MVCEF.Models;
using System.ComponentModel.DataAnnotations;

namespace MVCEF.ViewModels
{
    public class EmployeeAddViewModel
    {
        public List<Employee> EmployeesList { get; set; } = new List<Employee>();
        
        [Required(ErrorMessage = "Employee Name is required")]
        public string Name { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Employee Designation is required")]
        [MinLength(5, ErrorMessage = "Minimum length of designation should be 5 characters")]
        public string Designation { get; set; } = string.Empty;
        
        [Required]
        [Range(1000, 9999.99)]
        public decimal Salary { get; set; }
    }
}