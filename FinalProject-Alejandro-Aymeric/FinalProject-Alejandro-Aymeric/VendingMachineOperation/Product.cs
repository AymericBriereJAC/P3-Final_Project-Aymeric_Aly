using System;
using System.ComponentModel;
using System.IO;
using System.Web;
using System.Windows.Media.Imaging;

namespace FinalProject_Alejandro_Aymeric.Items
{
    /*
     * This class deals with all operations related with products such as 
     *  keeping product name,price quantity and the path to its related image
     *  Check if an intem is in inventory etc...
     */
    public class Product
    {
        protected string _name = "";
        protected decimal _price = 2;
        protected int _quantity = 5;
        protected string _imagePath = "";

        /// <summary>
        /// Create a Product object
        /// </summary>
        /// <param name="name_">Name of the Product</param>
        /// <param name="price_">Price of the Product</param>
        /// <param name="quantity_">Quantity of the Product</param>
        /// <param name="imagePath_">Path of the image realted to the product</param>
        public Product(string name_, decimal price_, int quantity_,string imagePath_)
        {
            Name = name_;
            Price = price_;
            Quantity = quantity_;
            _imagePath = imagePath_;
        }

        /// <summary>
        /// Get the name of the product
        /// </summary>
        public string Name 
        { 
            get { return _name; } 
            protected set 
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Name cannot be blank");

                _name = value;
            }
        }

        /// <summary>
        /// Get the price of the product
        /// </summary>
        public decimal Price 
        { 
            get { return _price; }
            protected set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Price needs to be more than 0");

                _price = value;
            }
        }

        /// <summary>
        /// Get and set the product quantity
        /// </summary>
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Quantity need to be positive");

                _quantity = value;
            }
        }

        /// <summary>
        /// Get the product image
        /// </summary>
        public BitmapImage ImagePath
        {
            get 
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(_imagePath, UriKind.Relative);
                bitmapImage.EndInit();

                return bitmapImage;
            }
        }

        /// <summary>
        /// Check if the product is in inventory
        /// </summary>
        /// <returns>true or false</returns>
        /// <exception cref="ArgumentNullException">IF the product is null</exception>
        public bool CheckInventory()
        {
            bool isEmpty = false;

            if (this == null) throw new ArgumentNullException();

            if(this.Quantity <= 0)
            {
                isEmpty = true;    
            }
            return isEmpty;
        }
    }
}
