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
    /// Interaction logic for SelectBill.xaml
    /// </summary>
    public partial class SelectBill : Window
    {
        private List<decimal> Bills = new List<decimal>() { 5, 10, 20, 50, 100 };
        private decimal _choosenBill;

        public SelectBill()
        {
            InitializeComponent();

            lbBills.ItemsSource = Bills;
            lblTotal.Content = $"Your total is: {Cart.Total}$";
        }

        private void btnPay_Click(object sender, RoutedEventArgs e)
        {
            if (lbBills.SelectedIndex == -1) MessageBox.Show($"Please select bill to pay with", "An error occured", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (!Cart.ValidateBalance(Bills[lbBills.SelectedIndex])) MessageBox.Show($"You don't have enough to pay your cart", "An error occured", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                _choosenBill = Bills[lbBills.SelectedIndex];
                Close();
            }
        }
        public decimal ChoosenBill { get { return _choosenBill; } }
    }
}
