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
        public void TestCreateDeleteProduct() 
        {
            Product p = new Product();
            p.ProductCode = "ABCDE";
            p.Description = "A Test Product";
            p.UnitPrice = 10;
            p.OnHandQuantity = 1;

            string productCode = ProductDB.AddProduct(p);
            p = ProductDB.GetProduct(productCode);
            Assert.AreEqual("ABCDE", p.ProductCode);

            ProductDB.DeleteProduct(p);
            Assert.IsNull(ProductDB.GetProduct(productCode));
        }
    }
}
