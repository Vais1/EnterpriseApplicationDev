using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ex8.Controllers
{
    [Route("goto")]
    [ApiController]
    public class ToursController : Controller
    {
        // Dictionary of cities with their descriptions
        private static Dictionary<string, (string FullName, string Description)> Cities = new()
        {
            { "nyc", ("New York City", "The Big Apple - Known for skyscrapers, Broadway, and the Statue of Liberty.") },
            { "london", ("London", "The capital of England - Famous for Big Ben, Tower Bridge, and royal palaces.") },
            { "paris", ("Paris", "The City of Light - Known for the Eiffel Tower, museums, and romantic atmosphere.") },
            { "tokyo", ("Tokyo", "Japan's capital - A blend of tradition and modern technology with vibrant culture.") },
            { "dubai", ("Dubai", "City of luxury - Known for the Burj Khalifa, desert safaris, and shopping.") },
            { "sydney", ("Sydney", "Australia's harbor city - Famous for the Opera House and beautiful beaches.") },
            { "bangkok", ("Bangkok", "Thailand's capital - Known for temples, street food, and vibrant night markets.") },
            { "barcelona", ("Barcelona", "Spain's architectural gem - Famous for Gaudí's Sagrada Familia and Park Güell.") },
            { "lasvegas", ("Las Vegas", "The entertainment capital - Known for casinos, shows, and the famous Strip.") },
            { "rome", ("Rome", "The Eternal City - Home to ancient ruins, Vatican, and incredible history.") },
            { "amsterdam", ("Amsterdam", "City of canals - Known for bicycles, museums, and Dutch culture.") },
            { "singapur", ("Singapore", "Asian Lion City - Modern metropolis with diverse culture and cuisine.") },
            { "istanbul", ("Istanbul", "Transcontinental city - Where Europe meets Asia with historic mosques and bazaars.") },
            { "buenosaires", ("Buenos Aires", "The Paris of South America - Known for tango, European architecture, and passionate culture.") },
            { "moscow", ("Moscow", "Russia's capital - Home to the Kremlin, Red Square, and iconic cathedrals.") },
            { "mumbai", ("Mumbai", "India's financial hub - Known for Bollywood, street food, and vibrant markets.") },
            { "berlin", ("Berlin", "Germany's capital - Rich history, world-class museums, and vibrant nightlife.") }
        };

        // GET /goto/{city}
        [HttpGet("{city}")]
        public IActionResult City(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                return Content("City name is required.");
            }

            // Normalize the city name to lowercase for case-insensitive lookup
            string normalizedCity = city.ToLower();

            if (Cities.TryGetValue(normalizedCity, out var cityInfo))
            {
                // Return only the city name
                return Content(cityInfo.FullName);
            }

            // Invalid city - return city not found message
            return NotFound(Content($"City '{city}' not found. Try: /goto/paris or /goto/tokyo"));
        }

        // GET /goto
        // Returns list of available cities
        [HttpGet("")]
        public IActionResult Index()
        {
            var availableCities = new[]
            {
                new { Route = "nyc", Name = "New York City" },
                new { Route = "london", Name = "London" },
                new { Route = "paris", Name = "Paris" },
                new { Route = "tokyo", Name = "Tokyo" },
                new { Route = "dubai", Name = "Dubai" },
                new { Route = "sydney", Name = "Sydney" },
                new { Route = "bangkok", Name = "Bangkok" },
                new { Route = "barcelona", Name = "Barcelona" },
                new { Route = "lasvegas", Name = "Las Vegas" },
                new { Route = "rome", Name = "Rome" },
                new { Route = "amsterdam", Name = "Amsterdam" },
                new { Route = "singapur", Name = "Singapore" },
                new { Route = "istanbul", Name = "Istanbul" },
                new { Route = "buenosaires", Name = "Buenos Aires" },
                new { Route = "moscow", Name = "Moscow" },
                new { Route = "mumbai", Name = "Mumbai" },
                new { Route = "berlin", Name = "Berlin" }
            };

            return Ok(new
            {
                Status = "Available Tours",
                Message = "Here are all available city tours. Try: /goto/{cityname}",
                Cities = availableCities
            });
        }
    }
}
