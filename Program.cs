using System;

class Product
{
    public int Id;
    public string Name;
    public double Price;
    public int RemainingStock;

    public void DisplayProduct()
    {
        Console.ForegroundColor = ConsoleColor.Green;

        string text = $"{Id}. {Name} - ₱{Price} (Stock: {RemainingStock})";

        int screenWidth = Console.WindowWidth;
        int spaces = (screenWidth - text.Length) / 2;
        if (spaces < 0) spaces = 0;

        Console.WriteLine(new string(' ', spaces) + text);
    }

    public double GetItemTotal(int quantity)
    {
        return Price * quantity;
    }

    public bool HasEnoughStock(int quantity)
    {
        return quantity <= RemainingStock;
    }

    public void DeductStock(int quantity)
    {
        RemainingStock -= quantity;
    }
}

class CartItem
{
    public Product Product;
    public int Quantity;
    public double Subtotal;
}
class Program
{
    // ✅ Centered + spaced printing
    static void PrintCentered(string text)
    {
        int screenWidth = Console.WindowWidth;
        int textLength = text.Length;

        int spaces = (screenWidth - textLength) / 2;
        if (spaces < 0) spaces = 0;

        Console.WriteLine(); // space above
        Console.WriteLine(new string(' ', spaces) + text);
        Console.WriteLine(); // space below
    }

    static bool AreAllProductsOutOfStock(Product[] products)
    {
        foreach (var product in products)
        {
            if (product.RemainingStock > 0)
            {
                return false;
            }
        }
        return true;
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;


