using System.ComponentModel;

List<Product> products = new List<Product>();

Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("-------------------------------");
Console.WriteLine("   Add Products to your List");
Console.WriteLine("-------------------------------");
Console.ResetColor();

while (true)
{
    Console.Write("Add Category: ");
    string category = Console.ReadLine();
    if (category.ToLower().Trim() == "q")
    {
        break;
    }
    if (string.IsNullOrEmpty(category))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Category cannot be null or empty.");
        Console.ResetColor();
        continue;
    }
    Console.Write("Add Product: ");
    string name = Console.ReadLine();
    if (name.ToLower().Trim() == "q")
    {
        break;
    }
    if (string.IsNullOrEmpty(name))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Product name cannot be null or empty.");
        Console.ResetColor();
        continue;
    }
    double price = 0;
    string priceInput;
    while (true)
    {
        Console.Write("Add Price: ");
        priceInput = Console.ReadLine();
        if (priceInput.ToLower().Trim() == "q")
        {
            break;
        }
        if (double.TryParse(priceInput, out price) && price > 0)
        {
            break;
        }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid price. Please enter a valid number.");
        Console.ResetColor();
    }
    products.Add(new Product(category, name, price));

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\nProduct added!");
    Console.ResetColor();
    Console.WriteLine("\nPress 'q' if you want to finish, or press Enter to add another product.");
    string continueInput = Console.ReadLine().ToLower().Trim();
    if (continueInput == "q")
    {
        break;
    }
}

void ProductSorter()
{
    ProductSorter sorter = new ProductSorter();
    List<Product> sortedProducts = sorter.SortProducts(products);

    Console.WriteLine("\n------------------------------------------");
    Console.ForegroundColor= ConsoleColor.Green;
    Console.WriteLine("\n   Your chosen products sorted by Price");
    Console.ResetColor();
    Console.WriteLine("\n------------------------------------------");
    Console.WriteLine($"{"Category".PadRight(18)}{"Product".PadRight(18)}Price");
    Console.WriteLine("------------------------------------------");

    foreach (Product product in sortedProducts)
    {
        Console.WriteLine(product.Category.PadRight(18) + "" + product.Name.PadRight(18) + "" + product.Price);
    }
    double sumOfAllPrices = products.Sum(x => x.Price);
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine($"\n   Your total price is: {sumOfAllPrices:F2}\n");
    Console.ResetColor();
}

ProductSorter();



Console.WriteLine("Would you like to add more Products? y/n");
string userInput = Console.ReadLine().ToLower().Trim();

if (userInput == "y")
{
    AddProducts();
}
else if (userInput == "q" || userInput == "n")
{
    EndApplication();
}
else
{
    Console.WriteLine("Invalid input. Please enter 'y' to add more products or 'n' to exit.");
}

static void EndApplication()
{
    Console.WriteLine("Application is ending.");
    Environment.Exit(0);
}

void AddProducts()
{
    List<Product> addProducts = new List<Product>();
    while (true)
    {
        Console.Write("Add Category: ");
        string category = Console.ReadLine();
        if (category.ToLower().Trim() == "q")
        {
            break;
        }
        if (string.IsNullOrEmpty(category))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Category cannot be null or empty.");
            Console.ResetColor();
            continue;
        }
        Console.Write("Add Product: ");
        string name = Console.ReadLine();
        if (name.ToLower().Trim() == "q")
        {
            break;
        }
        if (string.IsNullOrEmpty(name))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Product name cannot be null or empty.");
            Console.ResetColor();
            continue;
        }
        double price = 0;
        string priceInput;
        while (true)
        {
            Console.Write("Add Price: ");
            priceInput = Console.ReadLine();
            if (priceInput.ToLower().Trim() == "q")
            {
                break;
            }
            if (double.TryParse(priceInput, out price) && price > 0)
            {
                break;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid price. Please enter a valid number.");
            Console.ResetColor();
        }
        
        addProducts.Add(new Product(category, name, price));

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nProduct added!");
        Console.ResetColor();
        Console.WriteLine("\nPress 'q' if you want to finish, or press Enter to add another product.");
        string continueInput = Console.ReadLine().ToLower().Trim();
        if (continueInput == "q")
        {
            break;
        }
    }
    products.AddRange(addProducts);
}

ProductSorter();

class Product
{
    public Product(string category, string name, double price)
    {
        Category = category;
        Name = name;
        Price = price;
    }

    public string Category { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }

}

class ProductSorter
{
    public List<Product> SortProducts(List<Product> products)
    {
        return products.OrderBy(p => p.Price).ToList();
    }
}


