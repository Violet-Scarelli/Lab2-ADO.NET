using System;
using System.Collections.Generic;
using System.Text;

using MySql.Data.MySqlClient;
using System.Data;
using MMABooksBusinessClasses;

namespace MMABooksDBClasses
{
    public static class ProductDB
    {
        public static Product GetProduct(string productCode)
        {
			MySqlConnection connection = MMABooksDB.GetConnection();
			string selectStatement
				= "SELECT ProductCode, Description, UnitPrice, OnHandQuantity "
				+ "FROM Products "
				+ "WHERE ProductCode = @ProductCode";
			MySqlCommand selectCommand =
				new MySqlCommand(selectStatement, connection);
			selectCommand.Parameters.AddWithValue("@ProductCode", productCode);

			try
			{
				connection.Open();
				MySqlDataReader prodReader =
					selectCommand.ExecuteReader(CommandBehavior.SingleRow);
				if (prodReader.Read())
				{
					Product product = new Product();
					product.ProductCode = prodReader["@ProductCode"].ToString();
					product.Description = prodReader["Name"].ToString();
					product.UnitPrice = Convert.ToDecimal(prodReader["unitPrice"]);
					product.OnHandQuantity = (int)prodReader["City"];
					return product;
				}
				else
				{
					return null;
				}
			}
			catch (MySqlException ex)
			{
				throw ex;
			}
			finally
			{
				connection.Close();
			}
		}
		public static List<Product> GetProductList()
		{
			MySqlConnection connection = MMABooksDB.GetConnection();
			string selectStatement
				= "SELECT * "
				+ "FROM Products ";
			MySqlCommand selectCommand =
				new MySqlCommand(selectStatement, connection);
			try
			{
				connection.Open();
				MySqlDataReader prodReader =
					selectCommand.ExecuteReader();
				if (prodReader.HasRows)
				{
					List<Product> products = new List<Product>();
					while(prodReader.Read())
					{
						Product product = new Product();
						product.ProductCode = prodReader["ProductCode"].ToString();
						product.Description = prodReader["Description"].ToString();
						product.UnitPrice = Convert.ToDecimal(prodReader["UnitPrice"]);
						product.OnHandQuantity = (int)prodReader["OnHandQuantity"];
						products.Add(product);
					}
					return products;
				}
			}
			catch(MySqlException ex)
			{
				throw ex;
			}
			finally
			{
				connection.Close();
			}
			return null;
		}
		public static string AddProduct(Product product)
		{
			MySqlConnection connection = MMABooksDB.GetConnection();
			string addStatement =
				"INSERT Products " +
				"(ProductCode, Description, UnitPrice, OnHandQuantity) " +
				"VALUES (@ProductCode, @Description, @UnitPrice, @OnHandQuantity)";
			MySqlCommand insertCommand =
				new MySqlCommand(addStatement, connection);
			insertCommand.Parameters.AddWithValue(
				"@ProductCode", product.ProductCode);
			insertCommand.Parameters.AddWithValue(
				"@Description", product.Description);
			insertCommand.Parameters.AddWithValue(
				"@UnitPrice", product.UnitPrice);
			insertCommand.Parameters.AddWithValue(
				"@OnHandQuantity", product.OnHandQuantity);
			try
			{
				connection.Open();
				insertCommand.ExecuteNonQuery();
				// MySQL specific code for getting last pk value
				string selectStatement =
					"SELECT LAST_INSERT_ID()";
				MySqlCommand selectCommand =
					new MySqlCommand(selectStatement, connection);
				string productCode = Convert.ToString(selectCommand.ExecuteScalar());
				return productCode;
			}
			catch (MySqlException ex)
			{
				throw ex;
			}
			finally
			{
				connection.Close();
			}
		}
		public static bool DeleteProduct(Product product)
		{
			// get a connection to the database
			MySqlConnection connection = MMABooksDB.GetConnection();
			string deleteStatement =
				"DELETE FROM Products " +
				"WHERE ProductCode = @ProductCode " +
				"AND Description = @Description " +
				"AND UnitPrice = @UnitPrice " +
				"AND OnHandQuantity = @OnHandQuantity ";
			// set up the command object
			MySqlCommand deleteCommand =
				new MySqlCommand(deleteStatement, connection);
			deleteCommand.Parameters.AddWithValue(
				"@ProductCode", product.ProductCode);
			deleteCommand.Parameters.AddWithValue(
				"@Description", product.Description);
			deleteCommand.Parameters.AddWithValue(
				"@UnitPrice", product.UnitPrice);
			deleteCommand.Parameters.AddWithValue(
				"@OnHandQuantity", product.OnHandQuantity);
			try
			{
				// open the connection
				// execute the command
				// if the number of records returned = 1, return true otherwise return false
				connection.Open();
				deleteCommand.ExecuteNonQuery();
				string selectStatement =
					"SELECT LAST_INSERT_ID()";
				MySqlCommand selectCommand =
					new MySqlCommand(selectStatement, connection);
				if (selectCommand.ExecuteReader().RecordsAffected == 1)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			catch (MySqlException ex)
			{
				// throw the exception
				throw ex;
			}
			finally
			{
				// close the connection
				connection.Close();
			}
		}

		public static bool UpdateProduct(Product oldProduct, Product newProduct)
		{
			// create a connection
			MySqlConnection connection = MMABooksDB.GetConnection();
			string updateStatement =
				"UPDATE Products SET " +
				"ProductCode = @NewProductCode, " +
				"Description = @NewDescription, " +
				"UnitPrice = @NewUnitPrice, " +
				"OnHandQuantity = @NewOnHandQuantity, " +
				"WHERE ProductCode = @OldProductCode " +
				"AND Description = @OldDescription " +
				"AND UnitPrice = @OldUnitPrice " +
				"AND OnHandQuantity = @OldOnHandQuantity ";
			// setup the command object
			MySqlCommand updateCommand =
				new MySqlCommand(updateStatement, connection);
			updateCommand.Parameters.AddWithValue(
				"@NewProductCode", oldProduct.ProductCode);
			updateCommand.Parameters.AddWithValue(
				"@NewDescription", oldProduct.Description);
			updateCommand.Parameters.AddWithValue(
				"@NewUnitPrice", oldProduct.UnitPrice);
			updateCommand.Parameters.AddWithValue(
				"@NewOnHandQuantity", oldProduct.OnHandQuantity);
			updateCommand.Parameters.AddWithValue(
				"@OldProductCode", newProduct.ProductCode);
			updateCommand.Parameters.AddWithValue(
				"@OldDescription", newProduct.Description);
			updateCommand.Parameters.AddWithValue(
				"@OldUnitPrice", newProduct.UnitPrice);
			updateCommand.Parameters.AddWithValue(
				"@OldOnHandQuantity", newProduct.OnHandQuantity);
			try
			{
				// open the connection
				// execute the command
				// if the number of records returned = 1, return true otherwise return false
				connection.Open();
				updateCommand.ExecuteNonQuery();
				string selectStatement =
					"SELECT LAST_INSERT_ID()";
				MySqlCommand selectCommand =
					new MySqlCommand(selectStatement, connection);
				int numRows = Convert.ToInt32(selectCommand.ExecuteReader());
				if (numRows == 1)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			catch (MySqlException ex)
			{
				// throw the exception
				throw ex;
			}
			finally
			{
				// close the connection
				connection.Close();
			}
		}
    }
}
