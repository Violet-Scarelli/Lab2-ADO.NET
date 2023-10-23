using System;
using System.Collections.Generic;
using System.Text;

namespace MMABooksBusinessClasses
{
    public class Product
    {
        public Product() { }

        public Product(string description, int quantity, string code, decimal price)
        {
            Description = description;
            OnHandQuantity = quantity;
            ProductCode = code;
            UnitPrice = price;
        }

        public string Description { get; set; }
        public int OnHandQuantity { get; set; }
        public string ProductCode { get; set; }
        public decimal UnitPrice { get; set; }

		public override string ToString()
		{
			return Description + ", " + OnHandQuantity + ", " + ProductCode + ", " + UnitPrice;
		}
	}
}
