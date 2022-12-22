using System;
using System.IO;
using System.Web;
using System.Windows.Media.Imaging;

namespace FinalProject_Alejandro_Aymeric.Items
{
    public class Product
    {
        protected string _name = "";
        protected decimal _price = 2;
        protected int _quantity = 5;
        protected string _imagePath = "";
        public Product(string name_, decimal price_, int quantity_,string imagePath_)
        {
            Name = name_;
            Price = price_;
            Quantity = quantity_;
            _imagePath = imagePath_;
        }

        public string Name 
        { 
            get { return _name; } 
            protected set 
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Name cannot be blank");

                _name = value;
            }
        }

        public decimal Price 
        { 
            get { return _price; }
            protected set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Price needs to be more than 0");

                _price = value;
            }
        }

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Quantity need to be positive");

                _quantity = value;
            }
        }

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

        public bool CheckInventory(Product prod)
        {
            bool isEmpty = false;

            if (prod == null) throw new ArgumentNullException();

            if(prod.Quantity <= 0)
            {
                isEmpty = true;    
            }
            return isEmpty;
        }
    }
}
