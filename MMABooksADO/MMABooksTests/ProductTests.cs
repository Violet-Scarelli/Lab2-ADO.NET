using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using MMABooksBusinessClasses;

namespace MMABooksTests
{
    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void TestProductConstructor()
        {
            Product product1 = new Product();
            Assert.IsNotNull(product1);
            Assert.AreEqual(null, product1.ProductCode);
            Assert.AreEqual(null, product1.Description);

            string newCode = "ABCDE";
            string newDescription = "A Test Product";
            int newQuantity = 1;
            decimal newUnitPrice = 10;
            Product product2 = new Product(newDescription, newQuantity, newCode, newUnitPrice);
            Assert.IsNotNull(product2);
            Assert.AreEqual(newCode, product2.ProductCode);
            Assert.AreEqual(newDescription, product2.Description);
            Assert.AreEqual(newQuantity, product2.OnHandQuantity);
            Assert.AreEqual(newUnitPrice, product2.UnitPrice);
        }

        [Test]
        public void TestProductSetters()
        {
            Product product1 = new Product("A Test Product", 1, "ABCDE", 10);
			string newCode = "FGHIJ";
			string newDescription = "Another Test Product";
			int newQuantity = 2;
			decimal newUnitPrice = 20;
            product1.UnitPrice = newUnitPrice;
            product1.ProductCode = newCode;
            product1.Description = newDescription;
            product1.OnHandQuantity = newQuantity;
            Assert.AreEqual(newCode, product1.ProductCode);
			Assert.AreEqual(newDescription, product1.Description);
			Assert.AreEqual(newQuantity, product1.OnHandQuantity);
			Assert.AreEqual(newUnitPrice, product1.UnitPrice);
			newCode = "KLMNO";
			newDescription = "Yet Another Test Product";
			newQuantity = 3;
			newUnitPrice = 30;
			product1.UnitPrice = newUnitPrice;
			product1.ProductCode = newCode;
			product1.Description = newDescription;
			product1.OnHandQuantity = newQuantity;
			Assert.AreEqual(newCode, product1.ProductCode);
			Assert.AreEqual(newDescription, product1.Description);
			Assert.AreEqual(newQuantity, product1.OnHandQuantity);
			Assert.AreEqual(newUnitPrice, product1.UnitPrice);
		}

        [Test]
        public void TestProductGetters()
        {
            //empty test
        }
        [Test]
        public void TestProductToString()
        {
			Product product1 = new Product("A Test Product", 1, "ABCDE", 10);
            Assert.IsTrue(product1.ToString().Contains("A Test Product"));
			Assert.IsTrue(product1.ToString().Contains("1"));
            Assert.IsTrue(product1.ToString().Contains("ABCDE"));
			Assert.IsTrue(product1.ToString().Contains("10"));
		}

    }
}
