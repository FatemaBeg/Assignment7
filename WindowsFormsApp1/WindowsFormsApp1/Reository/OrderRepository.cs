using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp1.Reository
{

    public class OrderRepository
    {

        public bool AddOrder(string name, string quantity, int totalprice)
        {
            bool isAdded = false;
            try
            {
                string connectionString = @"Server=FATEMA-PC\SQLEXPRESS; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                string commandString = @"INSERT INTO Orders (ItemsName, Quantity,TotalPrice) Values ('" + name + "', '" + quantity + "', '" + totalprice + "')";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
                sqlConnection.Open();

                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    isAdded = true;
                }
                sqlConnection.Close();

            }
            catch (Exception)
            {

            }

            return isAdded;

        }
        public bool ItemIsNameExists(string name)
        {
            bool exists = false;
            try
            {
                string connectionString = @"Server=FATEMA-PC\SQLEXPRESS; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                string commandString = @"SELECT * FROM Orders WHERE ItemsName='" + name + "'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
                sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    exists = true;
                }

                sqlConnection.Close();

            }
            catch (Exception)
            {

            }

            return exists;
        }
        public bool UpdateOrder(string name, string quantity, int  totalprice, int id)
        {
            
            try
            {
                string connectionString = @"Server=FATEMA-PC\SQLEXPRESS; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);


                string commandString = @"UPDATE Orders SET ItemsName =  '" + name + "' ,  Quantity =  '" + quantity + "',TotalPrice="+totalprice+" WHERE Id = " + id + "";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
                sqlConnection.Open();
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    return true;
                }

                sqlConnection.Close();
            }
            catch (Exception)
            {

            }

            return false;
        }

        public bool DeleteOrder(int id)
        {
            try
            {

                string connectionString = @"Server=FATEMA-PC\SQLEXPRESS; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                string commandString = @"DELETE FROM Orders WHERE Id = " + id + "";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
                sqlConnection.Open();
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    return true;
                }
                sqlConnection.Close();
            }
            catch (Exception)
            {

            }
            return false;
        }
        public DataTable SearchOrder(string name)
        {

            string connectionString = @"Server=FATEMA-PC\SQLEXPRESS; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string commandString = @"SELECT * FROM Orders  WHERE itemsName='" + name + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();

            return dataTable;
        }
        public DataTable Display()
        {

            string connectionString = @"Server=FATEMA-PC\SQLEXPRESS; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string commandString = @"SELECT * FROM Orders";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;

        }
    }
}
