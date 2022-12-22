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
    }
}
