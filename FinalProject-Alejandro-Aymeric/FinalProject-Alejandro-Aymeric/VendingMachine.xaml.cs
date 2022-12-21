using FinalProject_Alejandro_Aymeric.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinalProject_Alejandro_Aymeric
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<ProductData> products = new List<ProductData>();
        private List<ProductData> cart = new List<ProductData>();
        private List<int> BillAmounts = new List<int>() { 5, 10, 20, 50, 100 };
        public MainWindow()
        {
            InitializeComponent();

            products.Add(CreateProduct("Apple.txt"));
            products.Add(CreateProduct("Cereal.txt"));
            products.Add(CreateProduct("Cheese.txt"));
            products.Add(CreateProduct("Chives.txt"));
            products.Add(CreateProduct("Juice.txt"));
            products.Add(CreateProduct("Milk.txt"));
            products.Add(CreateProduct("Pear.txt"));
            products.Add(CreateProduct("WheyProtein.txt"));
        }
        private ProductData CreateProduct(string file)
        {
            try
            {
                return new ProductData(file);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "An error occured", MessageBoxButton.OK, MessageBoxImage.Error); //an error occured, show the appropriate error message
                return null;
            }
        }

        private void addCart_Click(object sender, RoutedEventArgs e)
        {
            if (lbItems.SelectedIndex == -1) MessageBox.Show($"Please select an item to add to the cart", "An error occured", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                cart.Add(products[lbItems.SelectedIndex]);
                products[lbItems.SelectedIndex].Quantity -= 1;
            }
        }

        private void lbCart_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void lbCart_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void lbItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (products[lbItems.SelectedIndex].Quantity <= 0) MessageBox.Show($"No {lbItems.SelectedItem} left", "An error occured", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void payCash_Click(object sender, RoutedEventArgs e)
        {
            // Show the ReceiptWindow
            ReceiptWindow receiptWindow = new ReceiptWindow(cart, "Cash");
            receiptWindow.Show();
        }

        private void payDebit_Click(object sender, RoutedEventArgs e)
        {
            decimal total = GetTotal(cart);

            if (total < 5) MessageBox.Show($"You need to have at least 5$ worth of items to pay with a debit card", "An error occured", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                ReceiptWindow receiptWindow = new ReceiptWindow(cart, "Debit Card");
                receiptWindow.Show();
            }
        }

        public decimal GetTotal(List<ProductData> toAddd)
        {
            decimal total = 0;

            for (int i = 0; i < toAddd.Count; i++)
            {
                total += toAddd[i].Price;
            }

            return total;
        }
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}