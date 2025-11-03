using Microsoft.AspNetCore.Mvc;
using System;

namespace ex9.Controllers
{
    // POCO (Plain Old CLR Object) Controller
    // This is a simple class that doesn't inherit from Controller or ControllerBase
    [Route("home")]
    [ApiController]
    public class HomeController
    {
        // GET /home
        [HttpGet("")]
        public string Index()
        {
            return "Welcome to the Home page of ex9 - POCO Controller Demo";
        }

        // GET /home/today
        [HttpGet("today")]
        public string Today()
        {
            // Return current date and time
            DateTime now = DateTime.Now;
            return $"Current Date and Time: {now:dddd, MMMM dd, yyyy HH:mm:ss}";
        }

        // GET /home/http/{id}
        [HttpGet("http/{id}")]
        public string HttpId(int id)
        {
            // Display the ID number passed in the route
            return $"The ID number is: {id}";
        }
    }
}
