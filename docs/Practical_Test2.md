<div class="document-header">

# Enterprise Application Development (2601-PRG2224)
## Practical Test Documentation - Part 2

**Student Name:** Muhammad Awais Ghaffar  
**Student ID:** 22116024  
**Date:** November 19, 2025

</div>

---

<div class="section">

## Table of Contents
1. [Project Overview](#project-overview)
2. [Exercise 10 - Razor Variables and Loops](#exercise-10---razor-variables-and-loops)
3. [Exercise 11 - Razor Model Access](#exercise-11---razor-model-access)
4. [Appendix](#appendix)

</div>

---

<div class="section">

## Exercise 10 - Razor Variables and Loops


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
- Sets up middleware pipeline for HTTPS redirection, routing, and authorization
- Maps static assets from wwwroot folder
- Maps Razor Pages to handle page requests
- Configures exception handling for production environments

---

### Index.cshtml.cs - PageModel

```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ex10.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    // Properties for Razor variables demonstration
    public string WelcomeMessage { get; } = "Welcome to ex10 - Razor Variables Exercise";
    public int NumberValue { get; } = 42;
    public List<string> Fruits { get; } = new() { "Apple", "Banana", "Cherry", "Date", "Elderberry" };
    public List<int> Numbers { get; } = new() { 10, 20, 30, 40, 50 };

    public void OnGet()
    {

    }
}
```
---

### Index.cshtml - Section 1: Simple Variables

```html
@page
@model IndexModel
@{
    ViewData["Title"] = "Razor Variables Exercise";
}

<div class="container mt-5">
    <h1>@Model.WelcomeMessage</h1>
    <p class="text-muted">This page demonstrates the use of variables, while loops, and foreach loops in Razor views.</p>

    <hr />

    <!-- Section 1: Simple Variables -->
    <section class="mb-5">
        <h2>1. Simple Variables</h2>
        <div class="card">
            <div class="card-body">
                <p><strong>Welcome Message:</strong> @Model.WelcomeMessage</p>
                <p><strong>Number Value:</strong> @Model.NumberValue</p>
                
                <!-- Local Razor variable -->
                @{
                    string greeting = "Hello from Razor!";
                    int age = 25;
                    double price = 19.99;
                }
                <p><strong>Local Variable:</strong> @greeting</p>
                <p><strong>Age:</strong> @age years old</p>
                <p><strong>Price:</strong> $@price.ToString("F2")</p>
            </div>
        </div>
    </section>
```

---

### Index.cshtml - Section 2: While Loop

```html
    <!-- Section 2: While Loop Example -->
    <section class="mb-5">
        <h2>2. While Loop Example</h2>
        <div class="card">
            <div class="card-body">
                <p><strong>Counting from 1 to 5 using while loop:</strong></p>
                <ul>
                    @{
                        int counter = 1;
                        while (counter <= 5)
                        {
                            <li>Count: @counter</li>
                            counter++;
                        }
                    }
                </ul>
            </div>
        </div>
    </section>
```
---

### Index.cshtml - Section 3: ForEach with Strings

```html
    <!-- Section 3: ForEach Loop with String List -->
    <section class="mb-5">
        <h2>3. ForEach Loop - Fruits List</h2>
        <div class="card">
            <div class="card-body">
                <p><strong>List of fruits from Model:</strong></p>
                <ul class="list-group">
                    @foreach (var fruit in Model.Fruits)
                    {
                        <li class="list-group-item">🍎 @fruit</li>
                    }
                </ul>
            </div>
        </div>
    </section>
```

---

### Index.cshtml - Section 4: ForEach with Calculations

```html
    <!-- Section 4: ForEach Loop with Numbers -->
    <section class="mb-5">
        <h2>4. ForEach Loop - Numbers List</h2>
        <div class="card">
            <div class="card-body">
                <p><strong>List of numbers with calculations:</strong></p>
                <table class="table table-striped">
                    <thead>
                        <tr>
                            <th>Original</th>
                            <th>Doubled</th>
                            <th>Squared</th>
                        </tr>
                    </thead>
                    <tbody>
                        @foreach (var num in Model.Numbers)
                        {
                            <tr>
                                <td>@num</td>
                                <td>@(num * 2)</td>
                                <td>@(num * num)</td>
                            </tr>
                        }
                    </tbody>
                </table>
            </div>
        </div>
    </section>
```

---

### Index.cshtml - Section 5: Conditional Logic

```html
    <!-- Section 5: Conditional Logic with Variables -->
    <section class="mb-5">
        <h2>5. Conditional Logic with Variables</h2>
        <div class="card">
            <div class="card-body">
                @{
                    int score = 85;
                    string grade = score >= 90 ? "A" : score >= 80 ? "B" : score >= 70 ? "C" : "F";
                }
                <p><strong>Score:</strong> @score</p>
                <p><strong>Grade:</strong> <span class="badge bg-success">@grade</span></p>
                
                @{
                    int itemCount = 3;
                }
                <p><strong>Items in cart:</strong> @itemCount (@(itemCount == 1 ? "item" : "items"))</p>
            </div>
        </div>
    </section>
```


---

### Index.cshtml - Section 6: ForEach with Index

```html
    <!-- Section 6: Advanced ForEach with Index -->
    <section class="mb-5">
        <h2>6. ForEach Loop with Index</h2>
        <div class="card">
            <div class="card-body">
                <p><strong>Fruits with index numbers:</strong></p>
                <ol>
                    @foreach (var fruit in Model.Fruits)
                    {
                        var index = Model.Fruits.IndexOf(fruit) + 1;
                        <li>@index. @fruit</li>
                    }
                </ol>
            </div>
        </div>
    </section>

</div>
```
---

### Project Output - Exercise 10

**Expected Route:** `https://localhost:[port]/`

<div class="output-placeholder">

*[Screenshot would show a page titled "Welcome to ex10 - Razor Variables Exercise" with 6 sections:
1. Simple Variables section displaying welcome message, number value, and local variables
2. While Loop section showing counts from 1 to 5
3. ForEach Loop showing fruits list with emoji icons
4. ForEach Loop showing numbers table with doubled and squared calculations
5. Conditional Logic showing score/grade and item count
6. Advanced ForEach showing indexed fruit list]*

</div>

---

### Project Structure - ex10

```
ex10/
├── Program.cs
├── appsettings.json
├── appsettings.Development.json
├── ex10.csproj
├── Pages/
│   ├── Index.cshtml
│   ├── Index.cshtml.cs
│   ├── Privacy.cshtml
│   ├── Privacy.cshtml.cs
│   ├── Error.cshtml
│   ├── Error.cshtml.cs
│   ├── _ViewImports.cshtml
│   ├── _ViewStart.cshtml
│   └── Shared/
│       ├── _Layout.cshtml
│       ├── _Layout.cshtml.css
│       └── _ValidationScriptsPartial.cshtml
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

## Exercise 11 - Razor Model Access

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

---

### Index.cshtml.cs - PageModel with Properties

```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ex11.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    // Model properties
    public string Title { get; set; } = "Home.Index";
    public DateTime CurrentDate { get; set; }
    public List<string> Items { get; set; } = new();
    public List<int> Numbers { get; set; } = new();
    public string Message { get; set; } = "";

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        CurrentDate = DateTime.Now;
        Items = new List<string> { "Wednesday, 5 Aug 2020", "Wednesday, 5 Aug 2020" };
        Numbers = new List<int> { 1, 2, 3, 4, 5 };
        Message = "Welcome to Razor Model Access Demo";
    }
}
```


---

### Index.cshtml - Main View

```html
@page
@model IndexModel
@{
    ViewData["Title"] = "Razor Model Access";
}

<div class="container mt-5">
    <h1>@Model.Title</h1>
    <hr />
    
    <div class="row mt-4">
        <div class="col-md-8">
            <!-- Display Simple Model Properties -->
            <h3>Model Properties</h3>
            <p><strong>Title:</strong> @Model.Title</p>
            <p><strong>Current Date/Time:</strong> @Model.CurrentDate.ToString("dddd, d MMM yyyy")</p>
            <p><strong>Message:</strong> @Model.Message</p>
            
            <hr />
            
            <!-- Display List of Items -->
            <h3>Items List</h3>
            <ul class="list-group">
                @foreach (var item in Model.Items)
                {
                    <li class="list-group-item">@item</li>
                }
            </ul>
            
            <hr />
            
            <!-- Display Numbers with Calculations -->
            <h3>Numbers with Calculations</h3>
            <table class="table table-striped">
                <thead>
                    <tr>
                        <th>Number</th>
                        <th>Doubled</th>
                        <th>Squared</th>
                    </tr>
                </thead>
                <tbody>
                    @foreach (var num in Model.Numbers)
                    {
                        <tr>
                            <td>@num</td>
                            <td>@(num * 2)</td>
                            <td>@(num * num)</td>
                        </tr>
                    }
                </tbody>
            </table>
        </div>
    </div>
</div>
```

---

### Project Output - Exercise 11

**Expected Route:** `https://localhost:[port]/`

<div class="output-placeholder">

*[Screenshot would show a page titled "Home.Index" with three sections:
1. Model Properties section showing Title, Current Date/Time (formatted as "Tuesday, 19 Nov 2025"), and Welcome message
2. Items List section showing two date entries in a Bootstrap list group
3. Numbers with Calculations table showing numbers 1-5 with their doubled and squared values]*

</div>

---

### Project Structure - ex11

```
ex11/
├── Program.cs
├── appsettings.json
├── appsettings.Development.json
├── ex11.csproj
├── Pages/
│   ├── Index.cshtml
│   ├── Index.cshtml.cs
│   ├── Privacy.cshtml
│   ├── Privacy.cshtml.cs
│   ├── Error.cshtml
│   ├── Error.cshtml.cs
│   ├── _ViewImports.cshtml
│   ├── _ViewStart.cshtml
│   └── Shared/
│       ├── _Layout.cshtml
│       ├── _Layout.cshtml.css
│       └── _ValidationScriptsPartial.cshtml
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

---


### Technologies Used
- .NET 9.0
- ASP.NET Core Razor Pages
- Bootstrap 5
- jQuery
- C# 12

---

<div class="document-footer">

**End of Documentation**

Muhammad Awais Ghaffar - Student ID: 22116024  
Enterprise Application Development (2601-PRG2224)

</div>
