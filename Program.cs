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
    static double ShowSemiReceipt(CartItem[] cart, int cartCount)
    {
        double total = 0;

        PrintCentered("========== ORDER SUMMARY ==========");

        for (int i = 0; i < cartCount; i++)
        {
            PrintCentered($"{cart[i].Product.Name} x{cart[i].Quantity} = ₱{cart[i].Subtotal}");
            total += cart[i].Subtotal;
        }

        double discount = total >= 5000 ? total * 0.10 : 0;
        double finalTotal = total - discount;

        PrintCentered($"Grand Total: ₱{total}");
        PrintCentered($"Discount: ₱{discount}");
        PrintCentered($"Final Total: ₱{finalTotal}");

        return finalTotal;
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
           new Product { Id = 5, Name = "ballpen", Category="School", Price = 200, RemainingStock = 20 },
           new Product { Id = 6, Name = "plate", Category="Household", Price = 250, RemainingStock = 15 },
           new Product { Id = 7, Name = "Tissue", Category="Household", Price = 10, RemainingStock = 34 }
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
            Console.WriteLine("M. Cart Menu");

            Console.Write("\nEnter product number / option: ");
            string input = Console.ReadLine();

            if (input.ToUpper() == "M")
            {
                bool inCartMenu = true;

                while (inCartMenu)
                {
                    Console.WriteLine("1. View Cart");
                    Console.WriteLine("2. Remove Item");
                    Console.WriteLine("3. Update Quantity");
                    Console.WriteLine("4. Clear Cart");
                    Console.WriteLine("5. Checkout");
                    Console.WriteLine("6. Back");

                    bool isCartEmpty = cartCount == 0;

                    Console.Write("Choice: ");
                    string cartChoice = Console.ReadLine();

                    if (cartChoice == "1")
                    {
                        ViewCart(cart, cartCount);
                    }
                    else if (cartChoice == "2")
                    {
                        if (cartCount == 0)
                        {
                            PrintCentered("Cart is empty. Nothing to remove.");
                        }
                        else
                        {
                            RemoveItem(cart, ref cartCount);
                        }
                    }
                    else if (cartChoice == "3")
                    {
                        if (cartCount == 0)
                        {
                            PrintCentered("Cart is empty. Nothing to update.");
                        }
                        else
                        {
                            UpdateQuantity(cart, cartCount);
                        }
                    }
                    else if (cartChoice == "4")
                    {
                        if (cartCount == 0)
                        {
                            PrintCentered("Cart is already empty.");
                        }
                        else
                        {
                            cartCount = 0;
                            PrintCentered("Cart cleared.");
                        }
                    }
                    else if (cartChoice == "5")
                    {
                        if (cartCount == 0)
                        {
                            PrintCentered("Cart is empty. Cannot checkout.");
                        }
                        else
                        {
                            double total = 0;

                            PrintCentered("=========== RECEIPT ===========");

                            for (int i = 0; i < cartCount; i++)
                            {
                                PrintCentered($"{cart[i].Product.Name} x{cart[i].Quantity} = ₱{cart[i].Subtotal}");
                                total += cart[i].Subtotal;
                            }

                            double discountLocal = total >= 5000 ? total * 0.10 : 0;
                            double finalLocal = total - discountLocal;

                            PrintCentered($"Grand Total: ₱{total}");
                            PrintCentered($"Discount: ₱{discountLocal}");
                            PrintCentered($"Final Total: ₱{finalLocal}");

                            double paymentLocal;

                            while (true)
                            {
                                Console.Write("Enter payment: ");

                                if (!double.TryParse(Console.ReadLine(), out paymentLocal))
                                {
                                    PrintCentered("Invalid input.");
                                    continue;
                                }

                                if (paymentLocal < finalLocal)
                                {
                                    PrintCentered("Insufficient payment.");
                                    continue;
                                }

                                break;
                            }

                            PrintCentered($"Change: ₱{paymentLocal - finalLocal}");

                            cartCount = 0;

                            PrintCentered("Checkout successful!");
                        }
                    }
                    else if (cartChoice == "6")
                    {
                        inCartMenu = false;
                    }
                    else
                    {
                        PrintCentered("Invalid choice.");
                    }
                }

                continue;
            }

            if (input.ToUpper() == "S")
            {
                Console.Write("Enter product name to search: ");
                string keyword = Console.ReadLine().ToLower();

                bool searchFound = false;

                foreach (var p in products)
                {
                    if (p.Name.ToLower().Contains(keyword))
                    {
                        Console.WriteLine($"{p.Id}. {p.Name} - ₱{p.Price} - Stock: {p.RemainingStock}");
                        searchFound = true;
                    }
                }

                if (!searchFound)
                    Console.WriteLine("No product found.");

                continue;
            }


            if (input.ToUpper() == "C")
            {
                bool inCategory = true;

                while (inCategory)
                {
                    Console.WriteLine("\n=== CATEGORY MENU ===");
                    Console.WriteLine("1. Electronics");
                    Console.WriteLine("2. School");
                    Console.WriteLine("3. Household");
                    Console.WriteLine("4. Back to Main Menu");

                    Console.Write("Choose category: ");
                    string cat = Console.ReadLine();

                    string selectedCategory = "";

                    if (cat == "1") selectedCategory = "Electronics";
                    else if (cat == "2") selectedCategory = "School";
                    else if (cat == "3") selectedCategory = "Household";
                    else if (cat == "4") break;
                    else
                    {
                        PrintCentered("Invalid category.");
                        continue;
                    }

                    Console.WriteLine($"\n=== {selectedCategory.ToUpper()} PRODUCTS ===");

                    bool found = false;

                    foreach (var p in products)
                    {
                        if (p.Category == selectedCategory)
                        {
                            Console.WriteLine($"{p.Id}. {p.Name} - ₱{p.Price} - Stock: {p.RemainingStock}");
                            found = true;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine("No products found.");
                        continue;
                    }

                    // ================= NEW ACTION MENU =================
                    Console.WriteLine("\nOptions:");
                    Console.WriteLine("A. Add to Cart");
                    Console.WriteLine("C. Choose Another Category");
                    Console.WriteLine("M. Main Menu");

                    Console.Write("Select option: ");
                    string action = Console.ReadLine().ToUpper();

                    if (action == "A")
                    {
                        Console.Write("Enter Product ID: ");
                        int id = int.Parse(Console.ReadLine());

                        Console.Write("Quantity: ");
                        int qty = int.Parse(Console.ReadLine());

                        Product selected = products[id - 1];

                        if (!selected.HasEnoughStock(qty))
                        {
                            PrintCentered("Not enough stock.");
                            continue;
                        }

                        bool exists = false;

                        for (int i = 0; i < cartCount; i++)
                        {
                            if (cart[i].Product.Id == id)
                            {
                                cart[i].Quantity += qty;
                                cart[i].Subtotal = cart[i].Product.GetItemTotal(cart[i].Quantity);
                                exists = true;
                            }
                        }

                        if (!exists)
                        {
                            cart[cartCount] = new CartItem
                            {
                                Product = selected,
                                Quantity = qty,
                                Subtotal = selected.GetItemTotal(qty)
                            };
                            cartCount++;
                        }

                        selected.DeductStock(qty);
                        PrintCentered("Added to cart!");
                    }
                    else if (action == "C")
                    {
                        continue; 
                    }
                    else if (action == "M")
                    {
                        break;
                    }
                    else
                    {
                        PrintCentered("Invalid option.");
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

            bool itemExists = false;

            for (int i = 0; i < cartCount; i++)
            {
                if (cart[i].Product.Id == selectedProduct.Id)
                {
                    cart[i].Quantity += quantity;
                    cart[i].Subtotal = cart[i].Product.GetItemTotal(cart[i].Quantity);
                    itemExists = true;
                    break;
                }
            }

            if (!itemExists)
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

                double finalTotalSemi = ShowSemiReceipt(cart, cartCount);

                double paymentSemi;

                while (true)
                {
                    Console.Write("Enter payment amount: ");

                    if (!double.TryParse(Console.ReadLine(), out paymentSemi))
                    {
                        PrintCentered("Invalid input.");
                        continue;
                    }

                    if (paymentSemi < finalTotalSemi)
                    {
                        PrintCentered("Insufficient payment.");
                        continue;
                    }

                    break;
                }

                double changeSemi = paymentSemi - finalTotalSemi;

                PrintCentered("========== OFFICIAL RECEIPT ==========");

                string receiptNo = receiptCounter.ToString("D4");
                string dateNow = DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt");

                PrintCentered($"Receipt No: {receiptNo}");
                PrintCentered($"Date: {dateNow}");

                double receiptTotal = 0;

                for (int i = 0; i < cartCount; i++)
                {
                    PrintCentered($"{cart[i].Product.Name} x{cart[i].Quantity} = ₱{cart[i].Subtotal}");
                    receiptTotal += cart[i].Subtotal;
                }

                double discount = receiptTotal >= 5000 ? receiptTotal * 0.10 : 0;
                double finalTotal = receiptTotal - discount;

                PrintCentered($"Grand Total: ₱{receiptTotal}");
                PrintCentered($"Discount: ₱{discount}");
                PrintCentered($"Final Total: ₱{finalTotal}");

                PrintCentered($"Payment: ₱{paymentSemi}");
                PrintCentered($"Change: ₱{changeSemi}");

                receiptCounter++;
                cartCount = 0;

                PrintCentered("THANK YOU FOR SHOPPING!");
            }
        }

            double grandTotal = 0;

          
        }

    }
