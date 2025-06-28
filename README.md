# InventoryManagerDemo API

This is a simple RESTful API for managing a product inventory system, built with **ASP.NET Core**, **Entity Framework Core**, and **MySQL**.

## Features

- View all products  
- Add a new product  
- Update existing product data  
- Each product includes:
  - `Name`
  - `Description`
  - `Price`
  - `Quantity`
- Data persisted using EF Core with Pomelo MySQL provider  
- Unit tests implemented using **NUnit** and **EF Core InMemory** provider

## Requirements

- [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) or newer  
- MySQL Server (8.0+)  
- Visual Studio 2022 / VS Code / Rider / any modern IDE  

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/yourusername/InventoryManagerDemo.git
cd InventoryManagerDemo
```

### 2. Configure your MySQL connection string

Edit `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;port=3306;database=InventoryDb;user=root;password=your_password"
  }
}
```

### 3. Apply EF Core migrations

```bash
dotnet ef database update
```

### 4. Run the API

```bash
dotnet run
```
The API will be available at:

```
https://localhost:5001/api/product
```

## Running Unit Tests

Navigate to the test project folder (e.g., `InventoryManagerDemo.Tests`) and run:

```bash
dotnet test
```

Tests are run using the **EF Core InMemory** provider for fast and isolated execution.

## Task Feedback

Please fill this section after completing each task:

**Q: Was it easy to complete the task using AI?**  
A: Yes, AI provided very clear code snippets and explanations.

**Q: How long did the task take you to complete?**  
A: About 1 hour, mostly spent debugging connection settings with MySQL.

**Q: Was the code ready to run after generation? What did you have to change to make it usable?**  
A: The generated code worked mostly as-is, but I had to configure the connection string and add missing EF migrations.

**Q: Which challenges did you face during completion of the task?**  
A: Understanding controller routing and EF Core migration flow.

**Q: Which specific prompts did you learn as good practice to complete the task?**  
A: “How to set up unit tests for ASP.NET Core API with EF Core and InMemory database” helped a lot.
