using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RetailInventory.Data;
using RetailInventory.Models;

// Read configuration from appsettings.json
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var connectionString = configuration.GetConnectionString("DefaultConnection");

var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
optionsBuilder.UseSqlServer(connectionString);

using var context = new AppDbContext(optionsBuilder.Options);

// Lab 5: Retrieve All Products
var products = await context.Products.ToListAsync();
Console.WriteLine("All Products:");
foreach (var p in products)
    Console.WriteLine($"{p.Name} - ₹{p.Price}");

// Lab 5: Find by ID
var product = await context.Products.FindAsync(1);
Console.WriteLine($"\nFound: {product?.Name}");

// Lab 5: FirstOrDefault with Condition
var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);
Console.WriteLine($"Expensive: {expensive?.Name}");