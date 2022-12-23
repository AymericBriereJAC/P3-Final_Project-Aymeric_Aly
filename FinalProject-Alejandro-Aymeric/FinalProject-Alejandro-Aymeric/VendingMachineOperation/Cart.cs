using FinalProject_Alejandro_Aymeric.Items;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Text;

namespace FinalProject_Alejandro_Aymeric.VendingMachineOperation
{
    /* This class take care of all operations related to the shopping cart such as:
     * keeping track of the elements in the cart, get the total of the cart, 
     * validate that the user has enough money to pay, generate a receipt
     * 
     * OOP Pilliar Encapsulation: Cart class should be static because it make no sense to
     * have multiple cart. We will have multiple class of product, but only 1 cart per user
     */
    public static class Cart
    {
        private static List<Product> _cart = new List<Product>();   //list of the products in the cart
        public static decimal QUARTER = 0.25M, NICKEL = 0.05M, DIME = 0.10M, FIVEBILL = 5, TENBILL = 10,
                                TWENTYBILL = 20, FIFTYBILL = 50, HUNDREDBILL = 100, TOONIE =2, 
                                LOONIE = 1, PENNY = 0.01M;

        /// <summary>
        /// Get the total of the cart
        /// </summary>
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

        /// <summary>
        /// Get and set the content of the cart
        /// </summary>
        public static List<Product> CartContent { get { return _cart; } set { _cart = value; } }

        /// <summary>
        /// Get the quantity of a certian product in the cart
        /// </summary>
        /// <param name="productName">The name of the item to count</param>
        /// <returns></returns>
        public static int GetItemQuantity(string productName)
        {
            int counter = 0;

            foreach (Product item in _cart)
                if (item.Name == productName)
                    counter++;

            return counter;
        }

        /// <summary>
        /// Validate that the user has the required balance to pay his cart
        /// </summary>
        /// <param name="balance">money the user has</param>
        /// <returns></returns>
        public static bool ValidateBalance(decimal balance)
        {
            //verify that the user has the fund to pay his cart

            return Total <= balance;
        }

        /// <summary>
        /// Generate a receipt for the user
        /// </summary>
        /// <param name="toGenerate">The avaialable products that could be in the cart</param>
        /// <param name="paymentMethod">How the user will pay (Cash or Debit)</param>
        /// <param name="choosenBill">If the user paid with cash the bill he used (optional)</param>
        /// <returns></returns>
        public static string GenerateReceipt(string paymentMethod, decimal choosenBill = -1)
        {
            List<Product> printed = new List<Product>();

            string receiptText = "Thank you for your purchase!\n\n";

            receiptText += "Items:\n";
            int currentItemQuantity = 0;

            foreach (Product item in CartContent)
            {
                currentItemQuantity = Cart.GetItemQuantity(item.Name);

                if (currentItemQuantity > 0 && !printed.Contains(item))
                {
                    receiptText += $"{item.Name} x{currentItemQuantity} @ ${item.Price:F2} each = ${item.Price * currentItemQuantity:F2}\n";
                    printed.Add(item);
                }
            }

            receiptText += $"\nTotal: ${Cart.Total:F2}\n";
            receiptText += $"Payment Method: {paymentMethod}\n";

            if (paymentMethod == "Cash")
            {
                receiptText += "------------------------------------------\n";
                decimal change = choosenBill - Cart.Total;
                // Calculate the number of each bill and coin to give as change
                int numHundredBills = (int)(change / HUNDREDBILL);
                change -= numHundredBills * HUNDREDBILL;
                int numFiftyBills = (int)(change / FIFTYBILL);
                change -= numFiftyBills * FIFTYBILL;
                int numTwentyBills = (int)(change / TWENTYBILL);
                change -= numTwentyBills * TWENTYBILL;
                int numTenBills = (int)(change / TENBILL);
                change -= numTenBills * TENBILL;
                int numFiveBills = (int)(change / FIVEBILL);
                change -= numFiveBills * FIVEBILL;

                int numToonies = (int)(change / TOONIE);
                change -= numToonies * TOONIE;
                int numLoonies = (int)(change / LOONIE);
                change -= numLoonies * LOONIE;
                int numQuarters = (int)(change / QUARTER);
                change -= numQuarters * QUARTER;
                int numDimes = (int)(change / DIME);
                change -= numDimes * DIME;
                int numNickels = (int)(change / NICKEL);
                change -= numNickels * NICKEL;
                int numPennies = (int)(change / PENNY);

                // Add the change breakdown to the receipt
                receiptText += $"Cash received: ${choosenBill}\n";
                receiptText += $"Your change is ${change}:\n";
                receiptText += "Breakdown :\n";
                if (numHundredBills > 0) receiptText += $"{numHundredBills} x ${HUNDREDBILL:C}\n";
                if (numFiftyBills > 0) receiptText += $"{numFiftyBills} x ${FIFTYBILL:C}\n";
                if (numTwentyBills > 0) receiptText += $"{numTwentyBills} x ${TWENTYBILL:C}\n";
                if (numTenBills > 0) receiptText += $"{numTenBills} x ${TENBILL:C}\n";
                if (numFiveBills > 0) receiptText += $"{numFiveBills} x ${FIVEBILL:C}\n";
                if (numToonies > 0) receiptText += $"{numToonies} x ${TOONIE:C}\n";
                if (numLoonies > 0) receiptText += $"{numLoonies} x ${LOONIE:C}\n";
                if (numQuarters > 0) receiptText += $"{numQuarters} x ${QUARTER:C}\n";
                if (numDimes > 0) receiptText += $"{numDimes} x ${DIME:C}\n";
                if (numNickels > 0) receiptText += $"{numNickels} x ${NICKEL:C}\n";
                if (numPennies > 0) receiptText += $"{numPennies} x ${PENNY:C}\n";
            }

            return receiptText;
        }

        /// <summary>
        /// Clear the cart and update the given product list inventory
        /// </summary>
        /// <param name="toUpdate">Product list with the inventory to update</param>
        /// <param name="restockItems">Wheter or not to add back to pro</param>
        public static void ClearCart(List<Product> toUpdate, bool restockItems = true)
        {
            if (restockItems)
            {
                bool cartItemFound = false;

                for (int i = 0; i < CartContent.Count; i++)
                {
                    for (int y = 0; y < toUpdate.Count; y++)
                    {
                        cartItemFound = false;

                        if (CartContent[i] == toUpdate[y]) //the matching product was found, update the quantity
                        {
                            toUpdate[y].Quantity += 1;
                            cartItemFound = true;
                            break;
                        }
                    }

                    if (!cartItemFound)
                    {
                        //the product was not in the product list(was out of stock) add it back in stock
                        CartContent[i].Quantity += 1;
                        toUpdate.Add(Cart.CartContent[i]);
                    }
                }
            }

            CartContent.Clear();
        }
    }
}