# Enterprise Application Development (2601-PRG2224)

Muhammad Awais Ghaffar — Student ID: 22116024

This repository contains small ASP.NET Core projects used in tutorial classes. Each project is minimal and focused on a single concept.

## Projects

- ex4 — Static files demo (Razor Pages)
  - Simple page with H1 "file server demo", shows image (`wwwroot/img/mountain.png`), solid background color.

- ex5-routing1 — Basic MVC routing
  - Conventional routing with `HomeController` and `ProductsController`, with Views.
  - **Routing Examples:**
    - `HomeController`: `/Home/Index`, `/Home/About`
    - `ProductsController` with attribute routing `[Route("shop/[controller]")]`:
      - `/shop/products` — List products (Index)
      - `/shop/products/list` — List products (alternate route)
      - `/shop/products/item/5` — Get product details for ID 5

- ex6-routing — Attribute routing example
  - Controller-based routing with `DateController` and a simple view under `Views/Date`.
  - **Routing Examples:**
    - `DateController`:
      - `/date` — Index page
      - `/date/day/8` — Returns date 8 days after base date (2025-06-17), displaying 2025-06-25

- ex7 — Simple controller sample
  - Minimal MVC project with `HelloController` illustrating a basic controller action.
  - **Routing Examples (Conventional routing with default controller=Hello):**
    - `/Hello` or `/` — Returns "Hello from HelloController.Index"
    - `/Hello/Greet?name=Bob` — Returns "Hello, Bob!"
    - `/Hello/Greet` — Returns "Hello, Guest!" (default value)

- ex8 — Attribute routing with tours
  - Demonstrates attribute routing with a `ToursController` for exploring world cities.
  - Route pattern: `/goto/{city}`
  - **Routing Examples:**
    - `/goto` — Lists all available cities
    - `/goto/nyc` — Returns "New York City"
    - `/goto/paris` — Returns "Paris"
    - `/goto/london` — Returns "London"
    - `/goto/tokyo` — Returns "Tokyo"
    - `/goto/dubai` — Returns "Dubai"
    - `/goto/sydney` — Returns "Sydney"
    - `/goto/bangkok` — Returns "Bangkok"
    - `/goto/barcelona` — Returns "Barcelona"
    - `/goto/lasvegas` — Returns "Las Vegas"
    - `/goto/rome` — Returns "Rome"
    - `/goto/amsterdam` — Returns "Amsterdam"
    - `/goto/singapur` — Returns "Singapore"
    - `/goto/istanbul` — Returns "Istanbul"
    - `/goto/buenosaires` — Returns "Buenos Aires"
    - `/goto/moscow` — Returns "Moscow"
    - `/goto/mumbai` — Returns "Mumbai"
    - `/goto/berlin` — Returns "Berlin"
  - **Invalid Routes:**
    - `/goto/invalidcity` — Returns 404 error with list of available cities

- ex9 — POCO (Plain Old CLR Object) Controller
  - Demonstrates POCO controller pattern without inheriting from Controller or ControllerBase.
  - Uses attribute routing with a simple `HomeController`.
  - **Routing Examples:**
    - `/home` — Returns "Welcome to the Home page of ex9 - POCO Controller Demo"
    - `/home/today` — Returns current date and time (e.g., "Current Date and Time: Sunday, November 03, 2025 12:00:00")
    - `/home/http/123` — Returns "The ID number is: 123"
    - `/home/http/456` — Returns "The ID number is: 456"
  - **Invalid Routes:**
    - `/home/invalid` — Returns 404 error with list of valid routes

- ex10 — Razor Variables Exercise
  - Demonstrates the use of variables, loops, and conditional logic in Razor views.
  - Includes simple variables, while loops, foreach loops with lists, and ternary operators.
  - **Sections:**
    - Simple Variables — Display string, integer, and double variables from both model properties and local Razor variables.
    - While Loop — Demonstrates counting from 1 to 5 using a while loop.
    - ForEach Loop with Strings — Displays a list of fruits using foreach loop with the Fruits list from the model.
    - ForEach Loop with Integers — Shows a table of numbers with calculated values (doubled and squared).
    - Conditional Logic — Uses ternary operators to calculate grade based on score and pluralize text.
    - ForEach with Index — Displays fruits with their index positions in a numbered list.
  - **Route Examples:**
    - `/` or `/Index` — Displays the Razor variables exercise page with all examples

- ex11 — Razor View Access to Models
  - Demonstrates accessing model properties in Razor views.
  - Showcases binding between PageModel and Razor views using the @Model directive.
  - **Sections:**
    - Model Properties — Display simple properties from the model (Title, Current Date/Time, Message).
    - Items List — Render a list of items from a model collection in an unordered list.
    - Numbers with Calculations — Display numbers in a table with calculated values (doubled and squared).
  - **Route Examples:**
    - `/` or `/Index` — Displays the model access demonstration page with all model-bound content

- ex12 — View Engine, ViewData and ViewBag
  - Demonstrates the use of ViewData dictionary and ViewBag dynamic object for passing data from page models to views.
  - Showcases employee listing with structured data using ViewData.
  - **Sections:**
    - Home Page — Displays ViewData and ViewBag values demonstrating both access methods.
    - Employees Page — Lists employees with details (Name, Designation, Company, Location) and uses ViewData for page metadata.
  - **Route Examples:**
    - `/` or `/Index` — Home page displaying ViewData and ViewBag demonstration
    - `/employees` — Employees directory with employee listing and ViewData metadata

## How to run (any project)

First, navigate to the project folder:

```powershell
cd ex5-routing1
```

Then run the application:

```powershell
dotnet run
```

Or use watch mode for auto-reload on file changes:

```powershell
dotnet watch run
```

Open the printed URL in your browser.
