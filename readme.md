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

## How to run (any project)

From the project folder:

```powershell
dotnet run
```

Open the printed URL in your browser.
