using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using MMABooksBusinessClasses;

namespace MMABooksTests
{
    [TestFixture]
    public class CustomerTests
    {
        [Test]
        public void TestCustomerConstructor()
        {
            Customer customer = new Customer();
            Assert.IsNotNull(customer);
			Assert.AreEqual(0, customer.CustomerID);
			Assert.AreEqual(null, customer.Name);
            Assert.AreEqual(null, customer.Address);
            Assert.AreEqual(null, customer.City);
            Assert.AreEqual(null, customer.State);
            Assert.AreEqual(null, customer.ZipCode);

			int newCustomerID = 123;
			string newName = "Bob";
            string newAddress = "123 Test St";
            string newCity = "Testburg";
            string newState = "Lorem Ipsum";
            string newZipCode = "12345";
            Customer newCustomer = new Customer(newCustomerID, newName, newAddress, newCity, newState, newZipCode);
			Assert.IsNotNull(newCustomer);
			Assert.AreEqual(newCustomerID, newCustomer.CustomerID);
			Assert.AreEqual(newName, newCustomer.Name);
			Assert.AreEqual(newAddress, newCustomer.Address);
			Assert.AreEqual(newCity, newCustomer.City);
			Assert.AreEqual(newState, newCustomer.State);
			Assert.AreEqual(newZipCode, newCustomer.ZipCode);
		}
        [Test]
        public void TestCustomerSetter()
        {
            Customer customer = new Customer(123, "Bob", "123 Test St", "Testburg", "Lorem Ipsum", "12345");
			int newCustomerID = 456;
			string newName = "Alice";
			string newAddress = "123 Newer St";
			string newCity = "Blanksville";
			string newState = "Dolorsit";
			string newZipCode = "78901";
            customer.CustomerID = newCustomerID;
            customer.Name = newName;
            customer.Address = newAddress;
            customer.City = newCity;
            customer.State = newState;
            customer.ZipCode = newZipCode;
			Assert.AreEqual(newCustomerID, customer.CustomerID);
			Assert.AreEqual(newName, customer.Name);
			Assert.AreEqual(newAddress, customer.Address);
			Assert.AreEqual(newCity, customer.City);
			Assert.AreEqual(newState, customer.State);
			Assert.AreEqual(newZipCode, customer.ZipCode);
			newCustomerID = 555;
			newName = "Charlie";
			newAddress = "555 Old St";
			newCity = "Slate Town";
			newState = "Amet";
			newZipCode = "67875";
			customer.CustomerID = newCustomerID;
			customer.Name = newName;
			customer.Address = newAddress;
			customer.City = newCity;
			customer.State = newState;
			customer.ZipCode = newZipCode;
			Assert.AreEqual(newCustomerID, customer.CustomerID);
			Assert.AreEqual(newName, customer.Name);
			Assert.AreEqual(newAddress, customer.Address);
			Assert.AreEqual(newCity, customer.City);
			Assert.AreEqual(newState, customer.State);
			Assert.AreEqual(newZipCode, customer.ZipCode);
		}
    }
}
