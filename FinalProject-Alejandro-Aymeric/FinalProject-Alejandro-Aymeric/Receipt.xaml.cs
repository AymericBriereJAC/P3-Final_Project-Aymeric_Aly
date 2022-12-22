using FinalProject_Alejandro_Aymeric.Items;
using FinalProject_Alejandro_Aymeric.VendingMachineOperation;
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
        public ReceiptWindow(List<Product> products, string paymentMethod, decimal choosenBill = -1)
        {
            InitializeComponent();

            // Set the receipt text
            string receiptText = "Thank you for your purchase!\n\n";    //converting to stringbuilder would be more efficient
            receiptText += "Items:\n";
            int currentItemQuantity = 0;
            foreach (Product item in products)
            {
                currentItemQuantity = Cart.GetItemQuantity(item.Name);

                if(currentItemQuantity > 0)
                    receiptText += $"{item.Name} x{currentItemQuantity} @ ${item.Price:F2} each = ${item.Price * currentItemQuantity:F2}\n";
            }
            receiptText += $"\nTotal: ${Cart.Total:F2}\n";
            receiptText += $"Payment Method: {paymentMethod}\n";
            if (paymentMethod == "Cash") receiptText += $"Your change is ${choosenBill - Cart.Total}";

            tbReceipt.Text = receiptText;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
