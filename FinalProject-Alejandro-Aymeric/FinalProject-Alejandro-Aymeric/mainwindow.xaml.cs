using FinalProject_Alejandro_Aymeric.Items;
using FinalProject_Alejandro_Aymeric.VendingMachineOperation;
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

        public MainWindow()
        {
            InitializeComponent();

            AddProducts("items.txt", products);

            //Set the Cart listview source to the cart array
            lvCartItems.ItemsSource = Cart.CartContent;
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
                            toAdd.Add(new Product(itemOptions[0], Convert.ToDecimal(itemOptions[1]), Convert.ToInt32(itemOptions[2]), itemOptions[3]));
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
            else if (products[lvItems.SelectedIndex].Quantity <= 0) MessageBox.Show($"No {products[lvItems.SelectedIndex].Name} left!", "An error occured", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                Cart.CartContent.Add(products[lvItems.SelectedIndex]);
                products[lvItems.SelectedIndex].Quantity -= 1;
                lvCartItems.Items.Refresh();
                lvItems.Items.Refresh();
            }
        }

        private void payCash_Click(object sender, RoutedEventArgs e)
        {

            if (Cart.Total <= 0) MessageBox.Show($"You need to have at least one item in your cart in order to pass the checkout", "An error occured", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                SelectBill bill = new SelectBill();
                bill.ShowDialog();

                // Show the ReceiptWindow
                ReceiptWindow receiptWindow = new ReceiptWindow(products, "Cash", bill.ChoosenBill);
                receiptWindow.Show();
            }
        }

        private void payDebit_Click(object sender, RoutedEventArgs e)
        {
            if (Cart.Total < 5) MessageBox.Show($"You need to have at least 5$ worth of items to pay with a debit card", "An error occured", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (Cart.Total <= 0) MessageBox.Show($"You need to have at least one item in your cart in order to pass the checkout", "An error occured", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                ReceiptWindow receiptWindow = new ReceiptWindow(products, "Debit Card");
                receiptWindow.ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(lvCartItems.SelectedIndex == -1) MessageBox.Show($"Please select an item to remove from your cart", "An error occured", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                Cart.CartContent[lvCartItems.SelectedIndex].Quantity += 1;
                Cart.CartContent.RemoveAt(lvCartItems.SelectedIndex);
                lvCartItems.Items.Refresh();
                lvItems.Items.Refresh();
            }
        }

        
    }
}