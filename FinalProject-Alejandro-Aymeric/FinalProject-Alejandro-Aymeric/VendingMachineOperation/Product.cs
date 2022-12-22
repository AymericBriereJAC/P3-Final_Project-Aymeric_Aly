using System;
using System.IO;
using System.Web;

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
            ImagePath = imagePath_;
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

        public string ImagePath
        {
            get { return _imagePath; }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Image path cannot be blank");

                _imagePath = value;
            }
        }
    }
}
