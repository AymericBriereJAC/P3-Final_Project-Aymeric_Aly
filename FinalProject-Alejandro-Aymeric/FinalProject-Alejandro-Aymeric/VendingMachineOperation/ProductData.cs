using System;
using System.IO;

namespace FinalProject_Alejandro_Aymeric.Items
{
    public class ProductData
    {
        protected string _name = "";
        protected decimal _price = 2;
        protected int _quantity = 5;
        public ProductData(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(fileName))
                    {
                        string line = reader.ReadToEnd();   //the file is supposed to only have 1 line

                        string[] values = line.Split(',');

                        _name = values[0];
                        _price = Convert.ToDecimal(values[1]);
                        _quantity = Convert.ToInt32(values[2]);
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else throw new Exception("the file doesnot exist");
        }

        public string Name { get { return _name; } }

        public decimal Price { get { return _price; } }

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Quantity need to be positive");

                _quantity = value;
            }
        }
    }
}
