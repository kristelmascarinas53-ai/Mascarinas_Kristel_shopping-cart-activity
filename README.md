#**Shopping Cart System – Part 2**#

 Overview
This project is an enhanced version of a console-based Shopping Cart System built using C#. It allows users to browse products, add items to cart, manage cart contents, and complete purchases with proper validation and receipt generation.

Features Added (Part 2)

Cart Management System
Users can manage their cart before checkout:
- View cart items
- Remove items from cart
- Update item quantity
- Clear cart
- Proceed to checkout

Product Search
Users can search products by name for easier navigation in the product list.

Product Categories
Products are grouped into categories:
- Electronics
- School
- Household

Users can filter products based on category.

Checkout & Payment Validation
- Ensures payment is numeric
- Prevents insufficient payment
- Calculates change automatically

Receipt Generation
Each transaction includes:
- Receipt number
- Date and time
- Purchased items
- Grand total
- Discount (if applicable)
- Final total
- Payment
- Change

Low Stock Alert
After checkout, the system displays products with low stock (≤ 5 items remaining).

Order History
Stores completed transactions during runtime and allows users to view past orders.

Input Validation
All inputs such as menu choices, quantities, and payment are validated to prevent program crashes.

#**AI Usage In This Project**#

I used different AI tools such as ChatGPT, Gemini AI, and Claude AI as a collaborative coding assistant throughout the development of my shopping cart system. These AI tools were used to help me design, debug, and improve different parts of my program including product management, cart system, checkout process, stock handling, and order history tracking.

AI was not used to fully generate the program, but rather as a guide to help me understand logic errors, fix bugs, and improve the overall structure and flow of my console application.

Why AI Was Used

I used AI mainly to help solve logical and runtime issues that I encountered while developing the system. My program involves multiple interconnected parts such as product listing, cart management, category filtering, search functionality, checkout processing, receipt generation, and order history.

Some of the issues I faced included:
- Cart loop not behaving correctly when reaching limits
- Stock not updating properly after adding items to cart
- Incorrect subtotal and total calculations during checkout
- Program flow stopping or repeating unexpectedly
- Order history not saving correctly after checkout
- Difficulty in organizing menu navigation between different features

AI helped me understand these problems and guided me in fixing them step-by-step.

AI Assistance in Debugging and Logic Fixes

AI was used to analyze and correct errors in my program logic, especially in the following areas:

1. Cart and Loop Management
I had issues where the cart system would not stop properly or would allow incorrect behavior when adding items.

Example prompts:
- "how do I properly control a while loop for menu system"
- "why is my cart array allowing errors when full"

2. Stock Management System
I struggled with updating stock correctly after each purchase and preventing over-purchasing.

Example prompts:
- "how to reduce product stock after adding to cart"
- "how to check stock before allowing purchase"
- "why is my stock not updating correctly after checkout"

3. Cart Structure and Item Updates
I had difficulty preventing duplicate items and updating quantity properly.

Example prompts:
- "how to prevent duplicate items in cart array"
- "how to update quantity instead of adding duplicate product"
- "how to recalculate subtotal after quantity change"

4. Checkout and Receipt Generation
I needed guidance in properly structuring checkout flow and generating receipts.

Example prompts:
- "where should I place receipt generation in console program flow"
- "how to compute total, discount, and change"
- "how to make sure checkout runs before clearing cart"

5. Program Flow and Menu Navigation
I also struggled with menu transitions and program repetition issues.

Example prompts:
- "why does my console program keep repeating menu after action"
- "how to properly structure nested menus in c#"
- "how to return to main menu without breaking program flow"

6. Input Validation and Error Handling
AI helped me improve user input handling to avoid crashes and invalid entries.

Example prompts:
- "how to use tryparse in c# to avoid input errors"
- "how to validate user input in console application"
- "how to prevent program crash from invalid input"

#**Improvements After Using AI**#

After using AI assistance, I was able to significantly improve my program in the following areas:

- Fixed logical errors in cart and checkout flow
- Improved stock validation and ensured accurate updates after purchase
- Corrected subtotal and total computation logic
- Fixed order history saving issue by storing data before clearing the cart
- Improved menu navigation and program flow structure
- Added proper input validation to prevent runtime errors
- Organized the system into clearer functional sections (product, cart, checkout, history)

Overall, the system became more stable, functional, and easier to use after applying AI-assisted debugging and improvements.

#**Summary of changes**#

This update improves the original Shopping Cart System by expanding it into a more complete and interactive console-based shopping application. The system now includes full cart management, improved user interaction, and additional requirements aligned with Part 2 of the activity.

The program is designed to simulate a real-world shopping experience where users can browse products, manage their cart, apply checkout rules, and view transaction history.

 Major Improvements

1. Product Management System
The product system was improved to support:
- Product listing with ID, name, price, category, and stock
- Stock tracking and deduction after purchase
- Low stock monitoring after transactions

 2. Cart Management System
A complete cart management feature was implemented, allowing users to:
- Add products to cart
- View cart items with quantity and subtotal
- Update item quantity
- Remove specific items
- Clear the entire cart before checkout

This ensures users have full control over their selected items before confirming purchase.

3. Product Search and Category Filtering
The system includes improved navigation features:
- Product search by name (case-insensitive)
- Category filtering (Electronics, School, Household)
- Better product browsing experience before adding items to cart

 4. Checkout and Payment System
A full checkout system was implemented that includes:
- Computation of total amount
- Discount logic (applied when conditions are met)
- Payment validation to ensure sufficient amount
- Automatic computation of change
- Prevention of invalid or incomplete transactions

5. Receipt Generation
After successful checkout, the system generates an official receipt containing:
- Receipt number
- Date and time of transaction
- List of purchased items with quantity and subtotal
- Grand total, discount, final total
- Payment and change information

This simulates a real-world point-of-sale receipt system.

 6. Order History System
An order history feature was added to store completed transactions during runtime.

- Stores receipt summaries after checkout
- Allows users to view past orders while the program is running
- Helps track previous purchases before program restart

 7. Low Stock Alert Feature
After checkout, the system checks product inventory and:
- Displays products with low stock (≤ 5 items remaining)
- Notifies the user to help simulate inventory awareness

8. Input Validation and Error Handling
To improve system stability, multiple input validations were added:
- Prevents invalid numeric inputs using TryParse
- Validates menu selections
- Ensures correct Y/N responses
- Prevents crashes caused by invalid user input

 9. Program Structure and Flow Improvements
The overall program flow was improved using:
- Proper loop control for menus
- Separation of concerns between product, cart, and checkout logic
- Better navigation between main menu, cart menu, and checkout process
- Prevention of premature program termination

Overall Result

With these improvements, the system now functions as a more complete shopping cart application that supports product browsing, cart management, checkout processing, receipt generation, and order tracking. The program is more stable, user-friendly, and structured using proper C# programming concepts such as arrays, classes, loops, and conditional statements.
