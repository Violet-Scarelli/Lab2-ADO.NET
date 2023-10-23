using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using MMABooksBusinessClasses;
using MMABooksDBClasses;
using MySql.Data.MySqlClient;

namespace MMABooksTests
{
    public class CustomerDBTests
    {

        [Test]
        public void TestGetCustomer()
        {
            Customer c = CustomerDB.GetCustomer(1);
            Assert.AreEqual(1, c.CustomerID);
        }

        [Test]
        public void TestCreateDeleteCustomer() 
        {
            //Bundled these two together for now because I was having an issue where the "create" test would create endless copies of Mickey Mouse
			Customer c = new Customer();
			c.Name = "Mickey Mouse";
			c.Address = "101 Main Street";
			c.City = "Orlando";
			c.State = "FL";
			c.ZipCode = "10101";

			int customerID = CustomerDB.AddCustomer(c);
			c = CustomerDB.GetCustomer(customerID);
			Assert.AreEqual("Mickey Mouse", c.Name);

            CustomerDB.DeleteCustomer(c);
            Assert.IsNull(CustomerDB.GetCustomer(customerID));
		}

        [Test]
        public void TestUpdateCustomer()
        {
            Customer c = new Customer();
			c.Name = "Mickey Mouse";
			c.Address = "101 Main Street";
			c.City = "Orlando";
			c.State = "FL";
			c.ZipCode = "10101";
			int customerID = CustomerDB.AddCustomer(c);
			c = CustomerDB.GetCustomer(customerID);
			Assert.AreEqual("Mickey Mouse", c.Name);

			Customer n = new Customer();
			n.Name = "Minnie Mouse";
			n.Address = "202 Side Street";
			n.City = "Anaheim";
			n.State = "CA";
			n.ZipCode = "92802";

			bool updated = CustomerDB.UpdateCustomer(c, n);
			TestContext.WriteLine(n.ToString());
			Assert.IsTrue(updated);

		}
    }
}
