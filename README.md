Shopping Cart System – Part 2

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
