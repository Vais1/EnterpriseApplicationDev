<div class="document-header">

# Enterprise Application Development (2601-PRG2224)
## Practical Test Documentation

**Student Name:** Muhammad Awais Ghaffar  
**Student ID:** 22116024  
**Date:** November 5, 2025

</div>

---

<div class="section">

## Table of Contents
1. [Project Overview](#project-overview)
2. [Exercise 4 - Static Files Demo](#exercise-4---static-files-demo)
3. [Exercise 5 - Basic MVC Routing](#exercise-5---basic-mvc-routing)
4. [Appendix](#appendix)

</div>

---

<div class="section">

## Project Overview

This documentation covers two ASP.NET Core projects demonstrating fundamental web application concepts:

- **ex4**: Static file serving with Razor Pages
- **ex5-routing1**: MVC routing with controllers and views

Both projects are built using .NET 9.0 and showcase different architectural patterns in ASP.NET Core.

</div>

---

<div class="section">

## Exercise 4 - Static Files Demo

### Project Description
A Razor Pages application demonstrating static file serving capabilities in ASP.NET Core. The project displays an image served from the `wwwroot` folder with a custom background color.

### Key Concepts
- Static file middleware
- Razor Pages architecture
- wwwroot folder structure
- Static assets management

---

### Program.cs Configuration

```csharp
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
```

**What this code does:**
- Configures the web application builder with Razor Pages services
- Sets up middleware pipeline for HTTPS redirection and routing
- Maps static assets from wwwroot folder (images, CSS, JavaScript)
- Maps Razor Pages to handle page requests
- Configures exception handling for production environments

---

### Index.cshtml - Main Page

```html
@page
@model IndexModel
@{
    ViewData["Title"] = "File Server Demo";
}

<div class="text-center">
    <h1 class="display-4">file server demo</h1>
    <br />
    <img src="~/img/mountain.png" asp-append-version="true" alt="Mountain" style="max-width: 90%; height: auto;" />
</div>
```

**What this code does:**
- Defines a Razor Page with `@page` directive
- Sets the page title in ViewData dictionary
- Displays a centered heading
- Renders an image from the wwwroot/img folder
- Uses `asp-append-version` for cache busting
- Applies responsive styling to the image

---

### Custom Styling (site.css)

```css
body {
  margin-bottom: 60px;
  /* Solid background color for the page */
  background-color: #fff7e6; /* light warm peach */
}
```

**What this code does:**
- Sets a bottom margin for the body element
- Applies a light peach background color to create visual appeal
- Ensures consistent spacing throughout the application

---

### Project Output - Exercise 4

**Expected Route:** `https://localhost:[port]/`

<div class="output-placeholder">

*[Insert screenshot of the static file demo page showing "file server demo" heading and mountain image with peach background]*

</div>

---

### Project Structure - ex4

```
ex4/
├── Program.cs
├── appsettings.json
├── appsettings.Development.json
├── ex4.csproj
├── Pages/
│   ├── Index.cshtml
│   ├── Index.cshtml.cs
│   ├── Privacy.cshtml
│   ├── Error.cshtml
│   ├── _ViewImports.cshtml
│   ├── _ViewStart.cshtml
│   └── Shared/
│       └── _Layout.cshtml
├── wwwroot/
│   ├── css/
│   │   └── site.css
│   ├── js/
│   │   └── site.js
│   ├── img/
│   │   └── mountain.png
│   └── lib/
│       ├── bootstrap/
│       ├── jquery/
│       └── jquery-validation/
└── Properties/
    └── launchSettings.json
```

</div>

---

<div class="section">

## Exercise 5 - Basic MVC Routing

### Project Description
An MVC (Model-View-Controller) application demonstrating conventional and attribute-based routing in ASP.NET Core. The project includes two controllers with multiple actions and views.

### Key Concepts
- MVC architectural pattern
- Conventional routing
- Attribute routing
- Controller actions
- View rendering
- Route parameters

---

### Program.cs Configuration

```csharp
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

// Handle 404 and other status codes
app.UseStatusCodePagesWithRedirects("/Error");

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
```

**What this code does:**
- Registers MVC services with `AddControllersWithViews()`
- Configures the request pipeline with routing and authorization middleware
- Sets up conventional routing with default pattern `{controller=Home}/{action=Index}/{id?}`
- Default route points to HomeController's Index action
- Optional `id` parameter allows routes like `/Controller/Action/123`
- Configures status code page redirects for error handling

---

### HomeController.cs - Conventional Routing

```csharp
using Microsoft.AspNetCore.Mvc;

namespace ex5_routing1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
```

**What this code does:**
- Defines a controller class inheriting from `Controller` base class
- Implements two action methods: `Index` and `About`
- Uses conventional routing (no route attributes)
- Returns corresponding views for each action
- Routes accessible at `/Home/Index` and `/Home/About`

---

### Home/Index.cshtml View

```html
@{
    ViewData["Title"] = "Home Page";
}

<div class="text-center">
    <h1 class="display-4">Welcome to the Home Page</h1>
    <p>This is the home page handled by HomeController.</p>
    <a href="/Home/About" class="btn btn-primary">About</a>
    <a href="/shop/Products" class="btn btn-secondary">Products</a>
</div>
```

**What this code does:**
- Sets the page title using ViewData
- Displays a welcome message
- Provides navigation links to About and Products pages
- Uses Bootstrap classes for styling

---

### Home/About.cshtml View

```html
@{
    ViewData["Title"] = "About";
}

<h1>About Us</h1>
<p>This page is handled by HomeController's About action.</p>
<a href="/Home" class="btn btn-primary">Back to Home</a>
```

**What this code does:**
- Displays information about the application
- Provides a navigation link back to the home page
- Demonstrates simple view rendering

---

### Project Output - Exercise 5 (Home Pages)

**Route: `/Home/Index` or `/`**

<div class="output-placeholder">

*[Insert screenshot of Home Index page showing "Welcome to the Home Page" with About and Products buttons]*

</div>

**Route: `/Home/About`**

<div class="output-placeholder">

*[Insert screenshot of About page showing "About Us" heading with back to home button]*

</div>

---

### ProductsController.cs - Attribute Routing

```csharp
using Microsoft.AspNetCore.Mvc;

namespace ex5_routing1.Controllers
{
    [Route("shop/[controller]")]
    public class ProductsController : Controller
    {
        [Route("")]
        [Route("list")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("item/{id}")]
        public IActionResult Details(int id)
        {
            ViewBag.ProductId = id;
            return View();
        }
    }
}
```

**What this code does:**
- Uses attribute routing with `[Route("shop/[controller]")]` at controller level
- `[controller]` token is replaced with "Products" (controller name without "Controller" suffix)
- Base route becomes `/shop/products`
- Index action has two routes: `/shop/products` and `/shop/products/list`
- Details action accepts an `id` parameter from the route: `/shop/products/item/{id}`
- Passes the `id` value to the view using ViewBag
- Demonstrates flexible routing with multiple route patterns

---

### Products/Index.cshtml View

```html
@{
    ViewData["Title"] = "Products";
}

<h1>Our Products</h1>
<p>This page is handled by ProductsController.</p>
<ul>
    <li><a href="/shop/Products/item/1">Product 1</a></li>
    <li><a href="/shop/Products/item/2">Product 2</a></li>
</ul>
<a href="/Home" class="btn btn-primary">Back to Home</a>
```

**What this code does:**
- Displays a list of products with links
- Each link includes a product ID in the route
- Provides navigation back to the home page
- Demonstrates route parameter usage in links

---

### Products/Details.cshtml View

```html
@{
    ViewData["Title"] = "Product Details";
}

<h1>Product Details</h1>
<p>Product ID: @ViewBag.ProductId</p>
<p>This page is handled by ProductsController's Details action.</p>
<a href="/shop/Products" class="btn btn-primary">Back to Products</a>
```

**What this code does:**
- Displays details for a specific product
- Retrieves and displays the product ID from ViewBag
- Shows how route parameters are passed from controller to view
- Provides navigation back to the products list

---

### Project Output - Exercise 5 (Products Pages)

**Route: `/shop/products` or `/shop/products/list`**

<div class="output-placeholder">

*[Insert screenshot of Products Index page showing "Our Products" with product links]*

</div>

**Route: `/shop/products/item/1`**

<div class="output-placeholder">

*[Insert screenshot of Product Details page showing "Product ID: 1"]*

</div>

**Route: `/shop/products/item/5`**

<div class="output-placeholder">

*[Insert screenshot of Product Details page showing "Product ID: 5"]*

</div>

---

### Routing Summary - Exercise 5

| Route Pattern | Controller | Action | Description |
|--------------|------------|--------|-------------|
| `/` or `/Home/Index` | HomeController | Index | Home page (conventional routing) |
| `/Home/About` | HomeController | About | About page (conventional routing) |
| `/shop/products` | ProductsController | Index | Products list (attribute routing) |
| `/shop/products/list` | ProductsController | Index | Products list alternate route |
| `/shop/products/item/{id}` | ProductsController | Details | Product details with ID parameter |

---

### Project Structure - ex5-routing1

```
ex5-routing1/
├── Program.cs
├── appsettings.json
├── appsettings.Development.json
├── ex5-routing1.csproj
├── ex5-routing1.sln
├── Controllers/
│   ├── HomeController.cs
│   └── ProductsController.cs
├── Views/
│   ├── _ViewImports.cshtml
│   ├── _ViewStart.cshtml
│   ├── Home/
│   │   ├── Index.cshtml
│   │   └── About.cshtml
│   ├── Products/
│   │   ├── Index.cshtml
│   │   └── Details.cshtml
│   └── Shared/
│       └── _Layout.cshtml
├── Pages/
│   └── Error.cshtml
├── wwwroot/
│   ├── css/
│   │   └── site.css
│   ├── js/
│   │   └── site.js
│   └── lib/
│       ├── bootstrap/
│       ├── jquery/
│       └── jquery-validation/
└── Properties/
    └── launchSettings.json
```

</div>

---

<div class="section">

## Appendix

### How to Run the Projects

#### Exercise 4
```powershell
cd ex4
dotnet run
```

#### Exercise 5
```powershell
cd ex5-routing1
dotnet run
```

#### Using Watch Mode (Auto-reload on changes)
```powershell
dotnet watch run
```

### Key Differences Between ex4 and ex5

| Feature | ex4 (Razor Pages) | ex5 (MVC) |
|---------|-------------------|-----------|
| Architecture | Page-based | Controller-based |
| Routing | Page-based routing | Conventional + Attribute routing |
| File Organization | Pages folder | Controllers + Views folders |
| Use Case | Simple page-focused apps | Complex apps with separation of concerns |
| Code-behind | .cshtml.cs files | Controller classes |

### Technologies Used
- .NET 9.0
- ASP.NET Core
- Razor Pages (ex4)
- MVC Pattern (ex5)
- Bootstrap 5
- jQuery

### Learning Outcomes
1. Understanding static file serving in ASP.NET Core
2. Implementing Razor Pages architecture
3. Working with MVC controllers and views
4. Configuring conventional routing patterns
5. Applying attribute-based routing
6. Passing data between controllers and views
7. Managing route parameters

</div>

---

<div class="document-footer">

**End of Documentation**

Muhammad Awais Ghaffar - Student ID: 22116024  
Enterprise Application Development (2601-PRG2224)

</div>
