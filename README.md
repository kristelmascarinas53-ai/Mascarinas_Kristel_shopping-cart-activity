**Shopping Cart System – Part 2**

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

**AI Usage In This Project**

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

**Improvements After Using AI**

After using AI assistance, I was able to significantly improve my program in the following areas:

- Fixed logical errors in cart and checkout flow
- Improved stock validation and ensured accurate updates after purchase
- Corrected subtotal and total computation logic
- Fixed order history saving issue by storing data before clearing the cart
- Improved menu navigation and program flow structure
- Added proper input validation to prevent runtime errors
- Organized the system into clearer functional sections (product, cart, checkout, history)

Overall, the system became more stable, functional, and easier to use after applying AI-assisted debugging and improvements.
