# E-Commerce Management System

A simple e-commerce management system built with ASP.NET Core MVC and Entity Framework.

## Features
- **Category Management**: View and manage product categories.
- **Product Management**: List products with details and images.
- **Order Management**: Track customer orders and order items.
- **Customer Management**: Store and manage customer details.

## Tech Stack
- **Backend**: ASP.NET Core MVC, Entity Framework Core
- **Frontend**: Razor Views, Bootstrap
- **Database**: SQL Server

## Database Schema
- **Category** → Contains multiple products *(One-to-Many)*
- **Customer** → Places multiple orders *(One-to-Many)*
- **Order** → Contains multiple order items linked to products *(Many-to-Many)*

## Controllers
- `CategoryController`: Displays categories (ViewData, ViewBag)
- `ProductController`: Lists products (ViewModel)
- `OrderController`: Manages orders with customer details (ViewModel)

## Setup
1. Clone the repository:  
   ```sh
   git clone https://github.com/your-username/repository-name.git
   ```
2. Update the database connection string in `appsettings.json`.
3. Run the migration and seed data:  
   ```sh
   dotnet ef database update
   ```
4. Start the application:  
   ```sh
   dotnet run
   
