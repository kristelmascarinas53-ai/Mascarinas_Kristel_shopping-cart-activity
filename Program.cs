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

        // ✅ SET GLOBAL STYLE
        Console.ForegroundColor = ConsoleColor.Green;
        Console.BackgroundColor = ConsoleColor.White;
        Console.Clear(); // apply background

        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Laptop", Price = 1500, RemainingStock = 5 },
            new Product { Id = 2, Name = "Mouse", Price = 500, RemainingStock = 10 },
            new Product { Id = 3, Name = "Keyboard", Price = 1500, RemainingStock = 7 },
            new Product { Id = 4, Name = "Lapis", Price = 200, RemainingStock = 23 },
            new Product { Id = 5, Name = "Tissue", Price = 10, RemainingStock = 34 }
        };

        CartItem[] cart = new CartItem[10];
        int cartCount = 0;

        bool continueShopping = true;

        while (continueShopping)
        {
            PrintCentered("============================================== STORE MENU ==============================================");

            foreach (var product in products)
            {
                product.DisplayProduct();
            }

            Console.Write("\nEnter product number: ");
            if (!int.TryParse(Console.ReadLine(), out int productChoice))
            {
                PrintCentered("Invalid input. Please enter a number.");
                continue;
            }

            if (productChoice < 1 || productChoice > products.Length)
            {
                PrintCentered("Invalid product number.");
                continue;
            }

            Product selectedProduct = products[productChoice - 1];

            if (selectedProduct.RemainingStock == 0)
            {
                PrintCentered("Product is out of stock.");
                continue;
            }

            Console.Write("Enter quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
            {
                PrintCentered("Invalid quantity.");
                continue;
            }

            if (!selectedProduct.HasEnoughStock(quantity))
            {
                PrintCentered("Not enough stock available.");
                continue;
            }

            bool found = false;
            for (int i = 0; i < cartCount; i++)
            {
                if (cart[i].Product.Id == selectedProduct.Id)
                {
                    cart[i].Quantity += quantity;
                    cart[i].Subtotal = cart[i].Product.GetItemTotal(cart[i].Quantity);
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                if (cartCount >= cart.Length)
                {
                    PrintCentered("Cart is full.");
                    continue;
                }

                cart[cartCount] = new CartItem
                {
                    Product = selectedProduct,
                    Quantity = quantity,
                    Subtotal = selectedProduct.GetItemTotal(quantity)
                };
                cartCount++;
            }

            selectedProduct.DeductStock(quantity);

            PrintCentered("Item added to cart!");

            if (AreAllProductsOutOfStock(products))
            {
                PrintCentered("All products are out of stock. Proceeding to receipt...");
                break;
            }

            Console.Write("Do you want to add more items? (Y/N): ");
            string choice = Console.ReadLine().Trim().ToUpper();

            if (choice != "Y")
            {
                continueShopping = false;
            }
        }

        double grandTotal = 0;

        PrintCentered("============================================== RECEIPT ==============================================");
        for (int i = 0; i < cartCount; i++)
        {
            PrintCentered($"{cart[i].Product.Name} x{cart[i].Quantity} = ₱{cart[i].Subtotal}");
            grandTotal += cart[i].Subtotal;
        }

        double discount = 0;
        if (grandTotal >= 5000)
        {
            discount = grandTotal * 0.10;
        }

        double finalTotal = grandTotal - discount;

        PrintCentered($"Grand Total: ₱{grandTotal}");
        PrintCentered($"Discount: ₱{discount}");
        PrintCentered($"Final Total: ₱{finalTotal}");

        PrintCentered("============================================== UPDATED STOCK =========================================== ");
        foreach (var product in products)
        {
            PrintCentered($"{product.Name}: {product.RemainingStock}");
        }

        PrintCentered("Thank you for shopping!");
    }
    
}