using FinalProject_Alejandro_Aymeric.Items;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Text;

namespace FinalProject_Alejandro_Aymeric.VendingMachineOperation
{
    /*
     * OOP Pilliar Encapsulation: Cart class should be static because it make no sense to
     * have multiple cart. We will have multiple class of product, but only 1 cart per user
     */
    internal static class Cart
    {
        private static List<Product> _cart = new List<Product>();

        public static decimal Total
        {
            get
            {
                // Calculate the total cost of the items in the cart
                decimal totalCost = 0;
                foreach (Product item in _cart)
                {
                    totalCost += item.Price;
                }

                return totalCost;
            }
        }

        public static List<Product> CartContent { get { return _cart; } set { _cart = value; } }

        public static int GetItemQuantity(string productName)
        {
            int counter = 0;

            foreach (Product item in _cart)
                if (item.Name == productName)
                    counter++;

            return counter;
        }

        public static bool ValidateBalance(decimal balance)
        {
            //verify that the user has the fund to pay his cart

            return Total <= balance;
        }

        public static string GenerateReceipt(string paymentMethod, decimal choosenBill = -1)
        {
            string receiptText = "Thank you for your purchase!\n\n";

            receiptText += "Items:\n";
            int currentItemQuantity = 0;

            foreach (Product item in CartContent)
            {
                currentItemQuantity = Cart.GetItemQuantity(item.Name);

                if (currentItemQuantity > 0)
                    receiptText += $"{item.Name} x{currentItemQuantity} @ ${item.Price:F2} each = ${item.Price * currentItemQuantity:F2}\n";
            }

            receiptText += $"\nTotal: ${Cart.Total:F2}\n";
            receiptText += $"Payment Method: {paymentMethod}\n";

            if (paymentMethod == "Cash") receiptText += $"Your change is ${choosenBill - Cart.Total}";

            return receiptText;
        }
    }
}
