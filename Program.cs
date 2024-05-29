using System.ComponentModel;

List<Product> products = new List<Product>();

Console.WriteLine("Add product");

while (true)
{
    Console.Write("Add Category: ");
    string category = Console.ReadLine();
    if (category.ToLower().Trim() == "q")
    {
        break;
    }
    Console.Write("Add Product: ");
    string name = Console.ReadLine();
    if (name.ToLower().Trim() == "q")
    {
        break;
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
        if (double.TryParse(priceInput, out price))
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

ProductSorter sorter = new ProductSorter();
List<Product> sortedProducts = sorter.SortProducts(products);

Console.WriteLine("\n------------------------------------------");
Console.WriteLine("\nYour chosen products in Alphabetical order");
Console.WriteLine("\n------------------------------------------");
Console.WriteLine($"{"Category".PadRight(18)}{"Product".PadRight(18)}Price");
Console.WriteLine("------------------------------------------");

foreach (Product product in sortedProducts)
{
    Console.WriteLine(product.Category.PadRight(18) + "" + product.Name.PadRight(18) + "" + product.Price);
}

double sumOfAllPrices = products.Sum(x => x.Price);
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("\nYour total price is: " + sumOfAllPrices);
Console.ResetColor();


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
        return products.OrderBy(p => p.Name).ToList();
    }
}