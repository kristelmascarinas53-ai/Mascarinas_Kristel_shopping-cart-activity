using System;

class Product
{
    public int Id;
    public string Name;
    public string Category;
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
    static void PrintCentered(string text)
    {
        int screenWidth = Console.WindowWidth;
        int textLength = text.Length;

        int spaces = (screenWidth - textLength) / 2;
        if (spaces < 0) spaces = 0;

        Console.WriteLine(); 
        Console.WriteLine(new string(' ', spaces) + text);
        Console.WriteLine();
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
static void ViewCart(CartItem[] cart, int cartCount)
{
    Console.WriteLine("\n=== YOUR CART ===");

    if (cartCount == 0)
    {
        Console.WriteLine("Cart is empty.");
        return;
    }

    for (int i = 0; i < cartCount; i++)
    {
        Console.WriteLine($"{cart[i].Product.Id}. {cart[i].Product.Name} x{cart[i].Quantity}");
    }
}
     static void RemoveItem(CartItem[] cart, ref int cartCount)
 {
     Console.Write("Enter Product ID to remove: ");

     if (!int.TryParse(Console.ReadLine(), out int id))
     {
         PrintCentered("Invalid input.");
         return;
     }

     for (int i = 0; i < cartCount; i++)
     {
         if (cart[i].Product.Id == id)
         {
             for (int j = i; j < cartCount - 1; j++)
             {
                 cart[j] = cart[j + 1];
             }

             cartCount--;
             PrintCentered("Item removed.");
             return;
         }
     }

     PrintCentered("Item not found.");
 }

 static void UpdateQuantity(CartItem[] cart, int cartCount)
 {
     Console.Write("Enter Product ID to update: ");

     if (!int.TryParse(Console.ReadLine(), out int id))
     {
         PrintCentered("Invalid input.");
         return;
     }

     for (int i = 0; i < cartCount; i++)
     {
         if (cart[i].Product.Id == id)
         {
             Console.Write("Enter new quantity: ");

             if (!int.TryParse(Console.ReadLine(), out int newQty) || newQty <= 0)
             {
                 PrintCentered("Invalid quantity.");
                 return;
             }

             cart[i].Quantity = newQty;
             cart[i].Subtotal = cart[i].Product.GetItemTotal(newQty);

             PrintCentered("Quantity updated.");
             return;
         }
     }

     PrintCentered("Item not found.");
 }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.BackgroundColor = ConsoleColor.White;
        Console.Clear(); 
        
        Product[] products = new Product[]
        {
           new Product { Id = 1, Name = "Laptop", Category="Electronics", Price = 1500, RemainingStock = 5 },
           new Product { Id = 2, Name = "Mouse", Category="Electronics", Price = 500, RemainingStock = 10 },
           new Product { Id = 3, Name = "Keyboard", Category="Electronics", Price = 1500, RemainingStock = 7 },
           new Product { Id = 4, Name = "Lapis", Category="School", Price = 200, RemainingStock = 23 },
           new Product { Id = 5, Name = "Tissue", Category="Household", Price = 10, RemainingStock = 34 }
        };

        CartItem[] cart = new CartItem[10];
        int cartCount = 0;

        bool continueShopping = true;
        int receiptCounter = 1;
        string[] orderHistory = new string[20];
int historyCount = 0;

        while (continueShopping)
        {
PrintCentered("============================================== STORE MENU ==============================================");

            foreach (var product in products)
            {
                product.DisplayProduct();
            }

           Console.WriteLine("S. Search Product");
           Console.WriteLine("C. Filter by Category");

           Console.Write("\nEnter product number / option: ");
           string input = Console.ReadLine();
           
if (input.ToUpper() == "S")
{
    Console.Write("Enter product name to search: ");
    string keyword = Console.ReadLine().ToLower();

    bool found = false;

    foreach (var p in products)
    {
        if (p.Name.ToLower().Contains(keyword))
        {
            Console.WriteLine($"{p.Id}. {p.Name} - ₱{p.Price} - Stock: {p.RemainingStock}");
            found = true;
        }
    }

    if (!found)
        Console.WriteLine("No product found.");

    continue;
}


if (input.ToUpper() == "C")
{
    Console.WriteLine("1. Food");
    Console.WriteLine("2. Electronics");
    Console.WriteLine("3. Clothing");

    string cat = Console.ReadLine();

    foreach (var p in products)
    {
        if ((cat == "1" && p.Category == "Food") ||
            (cat == "2" && p.Category == "Electronics") ||
            (cat == "3" && p.Category == "Clothing"))
        {
            Console.WriteLine($"{p.Id}. {p.Name}");
        }
    }

    continue;
}

if (!int.TryParse(input, out int productChoice))
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

           string choice;

do
{
    Console.Write("Do you want to add more items? (Y/N): ");
    choice = Console.ReadLine().Trim().ToUpper();

    if (choice != "Y" && choice != "N")
    {
        PrintCentered("Invalid input. Please enter Y or N only.");
    }

} while (choice != "Y" && choice != "N");

            if (choice != "Y")
            {
                continueShopping = false;
            }
        }

        double grandTotal = 0;

PrintCentered("================================ RECEIPT ==============================================");

string receiptNo = receiptCounter.ToString("D4");
string dateNow = DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt");

PrintCentered($"Receipt No: {receiptNo}");
PrintCentered($"Date: {dateNow}");
        
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

double payment;
while (true)
{
    Console.Write("\nEnter payment amount: ");

    if (!double.TryParse(Console.ReadLine(), out payment))
    {
        PrintCentered("Invalid input. Please enter a number.");
        continue;
    }

    if (payment < finalTotal)
    {
        PrintCentered("Insufficient payment. Please enter a valid amount.");
        continue;
    }

    break;
}

double change = payment - finalTotal;

PrintCentered($"Payment: ₱{payment}");
PrintCentered($"Change: ₱{change}");
        
        if (historyCount < orderHistory.Length)
{
    orderHistory[historyCount] = $"Receipt #{receiptNo} - Final Total: ₱{finalTotal}";
    historyCount++;
}

receiptCounter++;
        
        PrintCentered($"Grand Total: ₱{grandTotal}");
        PrintCentered($"Discount: ₱{discount}");
        PrintCentered($"Final Total: ₱{finalTotal}");
       
double change = payment - finalTotal;

PrintCentered($"Payment: ₱{payment}");
PrintCentered($"Change: ₱{change}");

        PrintCentered("============================================== UPDATED STOCK =========================================== ");
        PrintCentered("LOW STOCK ALERT:");

foreach (var p in products)
{
    if (p.RemainingStock <= 5)
    {
        PrintCentered($"{p.Name} has only {p.RemainingStock} left.");
    }
}
        foreach (var product in products)
        {
            PrintCentered($"{product.Name}: {product.RemainingStock}");
        }
PrintCentered("============== ORDER HISTORY ==============");

for (int i = 0; i < historyCount; i++)
{
    PrintCentered(orderHistory[i]);
}
        PrintCentered("Thank you for shopping!");
    }
    
}
