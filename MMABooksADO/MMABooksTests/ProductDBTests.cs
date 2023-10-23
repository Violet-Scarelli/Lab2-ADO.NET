using MMABooksBusinessClasses;
using MMABooksDBClasses;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMABooksTests
{
    public class ProductDBTests
    {
        [Test]
        public void TestGetProducts()
        {
            List<Product> products = ProductDB.GetProductList();
            Assert.AreEqual(16, products.Count);
        }

        [Test]
        public void TestCreateProduct() 
        {
            Product p = new Product();
            p.ProductCode = "ABCDE";
            p.Description = "A Test Product";
            p.UnitPrice = 10;
            p.OnHandQuantity = 1;
			string added = ProductDB.AddProduct(p);
            Assert.AreEqual(added, "ABCDE");
            bool deleted = ProductDB.DeleteProduct(p);
            Assert.IsTrue(deleted);
        }
    }
}
