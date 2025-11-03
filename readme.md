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
