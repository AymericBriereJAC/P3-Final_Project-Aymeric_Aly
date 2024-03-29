﻿using FinalProject_Alejandro_Aymeric.Items;
using FinalProject_Alejandro_Aymeric.VendingMachineOperation;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
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
        protected string receiptText;

        public ReceiptWindow( string paymentMethod, decimal choosenBill = -1)
        {
            InitializeComponent();

            //generate the receipt and show it to the user
            receiptText = Cart.GenerateReceipt(paymentMethod, choosenBill);
            tbReceipt.Text = receiptText;
        }

        /// <summary>
        /// The user accepted the receipt accepted the receipt,
        /// close the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// The user want to export his receipt. Export it to the wanted file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            string saveLocation = "";
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text File | *.txt"; // | All Files | *.*";
                saveFileDialog.AddExtension = false;
                saveFileDialog.DefaultExt = "";
                if (saveFileDialog.ShowDialog() == true)
                    saveLocation = saveFileDialog.FileName; //had a trouble where i got double extension (.html.html) it is an easy way i found to fix it

                File.WriteAllText(saveLocation, receiptText);

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "An error occured", MessageBoxButton.OK, MessageBoxImage.Error); //an error occured, show the appropriate error message
            }
        }
    }
}
