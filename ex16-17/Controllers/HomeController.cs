using Microsoft.AspNetCore.Mvc;
using MVCEF.Models;
using MVCEF.ViewModels;

namespace MVCEF.Controllers
{
    public class HomeController : Controller
    {
        readonly EmployeeDbContext employeeDbContext;

        public HomeController(EmployeeDbContext employeeDbContext)
        {
            this.employeeDbContext = employeeDbContext;
        }

        // GET: /Home/
        public IActionResult Index()
        {
            EmployeeAddViewModel employeeAddViewModel = new EmployeeAddViewModel();
            var db = this.employeeDbContext;
            employeeAddViewModel.EmployeesList = db.Employees.ToList();
            return View(employeeAddViewModel);
        }

        [HttpPost]
        public IActionResult Index(EmployeeAddViewModel employeeAddViewModel)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee
                {
                    Name = employeeAddViewModel.Name,
                    Designation = employeeAddViewModel.Designation,
                    Salary = employeeAddViewModel.Salary
                };
                
                var db = this.employeeDbContext;
                db.Employees.Add(employee);
                db.SaveChanges();
                // Redirect to get Index GET method
                return RedirectToAction("Index");
            }
            
            // If model is not valid, reload the employee list and return the view with validation errors
            var database = this.employeeDbContext;
            employeeAddViewModel.EmployeesList = database.Employees.ToList();
            return View(employeeAddViewModel);
        }
    }
}