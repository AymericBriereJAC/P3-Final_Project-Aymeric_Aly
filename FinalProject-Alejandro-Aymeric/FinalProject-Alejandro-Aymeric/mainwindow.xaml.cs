using FinalProject_Alejandro_Aymeric.Items;
using System;
using System.Collections.Generic;
using System.IO;
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
        private List<Product> products = new List<Product>();
        private List<Product> cart = new List<Product>();
        private List<int> BillAmounts = new List<int>() { 5, 10, 20, 50, 100 };
        public MainWindow()
        {
            InitializeComponent();

            AddProducts("items.txt", products);

            //Set the Cart listview source to the cart array
            lvCartItems.ItemsSource = cart;
            lvItems.ItemsSource = products;
        }
        private void AddProducts(string file, List<Product> toAdd)
        {
            try
            {
                if (File.Exists(file))
                {
                    string line;

                    using (StreamReader reader = new StreamReader(file))
                    {
                        while((line = reader.ReadLine()) != null)
                        {
                            string[] itemOptions = line.Split(',');
                            toAdd.Add(new Product(itemOptions[0], Convert.ToDecimal(itemOptions[1]), Convert.ToInt32(itemOptions[2])));
                        }
                    }
                }
                else throw new ArgumentException("An error occured while fetching the available items");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "An error occured", MessageBoxButton.OK, MessageBoxImage.Error); //an error occured, show the appropriate error message
            }

            lvItems.Items.Refresh();
        }

        private void AddCart_Click(object sender, RoutedEventArgs e)
        {
            if (lvItems.SelectedIndex == -1) MessageBox.Show($"Please select an item to add to the cart", "An error occured", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                cart.Add(products[lvItems.SelectedIndex]);
                products[lvItems.SelectedIndex].Quantity -= 1;
                lvCartItems.Items.Refresh();
                lvItems.Items.Refresh();
            }
        }

        private void payCash_Click(object sender, RoutedEventArgs e)
        {
            decimal total = GetTotal(cart);

            if (total <= 0) MessageBox.Show($"You need to have at least one item in your cart in order to pass the checkout", "An error occured", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                // Show the ReceiptWindow
                ReceiptWindow receiptWindow = new ReceiptWindow(products, cart, "Cash");
                receiptWindow.Show();
            }
        }

        private void payDebit_Click(object sender, RoutedEventArgs e)
        {
            decimal total = GetTotal(cart);

            if (total < 5) MessageBox.Show($"You need to have at least 5$ worth of items to pay with a debit card", "An error occured", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (total <= 0) MessageBox.Show($"You need to have at least one item in your cart in order to pass the checkout", "An error occured", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                ReceiptWindow receiptWindow = new ReceiptWindow(products, cart, "Debit Card");
                receiptWindow.Show();
            }
        }

        public decimal GetTotal(List<Product> toAddd)
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

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void lvCartItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(lvCartItems.SelectedIndex == -1) MessageBox.Show($"Please select an item to remove from your cart", "An error occured", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                cart[lvCartItems.SelectedIndex].Quantity += 1;
                cart.RemoveAt(lvCartItems.SelectedIndex);
                lvCartItems.Items.Refresh();
                lvItems.Items.Refresh();
            }
        }
    }
}