using FinalProject_Alejandro_Aymeric.Items;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FinalProject_Alejandro_Aymeric
{
    /// <summary>
    /// Interaction logic for ReceiptWindow.xaml
    /// </summary>
    public partial class ReceiptWindow : Window
    {
        public ReceiptWindow(List<ProductData> cart, string paymentMethod)
        {
            InitializeComponent();

            // Calculate the total cost of the items in the cart
            decimal totalCost = 0;
            foreach (ProductData item in cart)
            {
                totalCost += item.Price * item.Quantity;
            }

            // Set the receipt text
            string receiptText = "Thank you for your purchase!\n\n";
            receiptText += "Items:\n";
            foreach (ProductData item in cart)
            {
                receiptText += $"{item.Name} x{item.Quantity} @ ${item.Price:F2} each = ${item.Price * item.Quantity:F2}\n";
            }
            receiptText += $"\nTotal: ${totalCost:F2}\n";
            receiptText += $"Payment Method: {paymentMethod}\n";

            tbReceipt.Text = receiptText;
        }
        private MainWindow GetMainWindow()
        {
            foreach (Window window in Application.Current.Windows)  //loop through all the window the app created
            {
                if (window.GetType() == typeof(MainWindow)) //if the window is the main window, cast it and return it
                {
                    return (window as MainWindow);
                }
            }

            return null;   //the window was not found, return null
        }
    }
}
