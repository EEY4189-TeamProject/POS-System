using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;

namespace Sales_Management_System.ViewModel
{
    public class SQLConnection
    {
        static SqlConnection Connection;

        static string ConnectionString = @"Data Source=KETHUSHA;Initial Catalog=SalesManagementWPF; TrustServerCertificate=False; Integrated Security = True";


        public static bool DBConnection()
        {
            try
            {
                Connection = new SqlConnection(ConnectionString);
                Connection.Open();
                //MessageBox.Show("Database connected successfully...");
                Connection.Close();
                return true;
            }
            catch
            {
                MessageBox.Show("Database connection failed...", "Sql Connection", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        public static void SqlConnection()
        {
            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                {
                    Connection = new SqlConnection(ConnectionString);
                    Connection.Open();
                }
            }
            catch
            {
                MessageBox.Show("Can't Connect DataBase", "Sql Connection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static void close_Connection()
        {
            if (Connection.State == System.Data.ConnectionState.Open)
            { Connection.Close(); }
        }

        public static SqlConnection getConnection()
        {
            return Connection;
        }

        public static bool ISData(string table)
        {
            DBConnection();
            int value = 0;
            Connection.Open();
            bool Retrunit = false;
            var SerchQuary = $"select count(*) from {table};";
            var Command = new SqlCommand(SerchQuary, Connection);
            var reader = Command.ExecuteReader();

            while (reader.Read())
            {
                value = int.Parse(reader.GetValue(0).ToString());
                if (value != 0 && value != null)
                {
                    Retrunit = true;
                }

            }
            Connection.Close();

            return Retrunit;

        }

        public static string SpaficDataISINTable(string table, string Name, string IDColumnname)
        {
            DBConnection();
            string datavalue = "";
            Connection.Open();
            bool Retrunit = false;
            var SerchQuary = $"select {table}.{Name} from {table};";
            var Command = new SqlCommand(SerchQuary, Connection);
            var reader = Command.ExecuteReader();
            while (reader.Read())
            {

                datavalue = reader.GetValue(0).ToString();
            }
            Connection.Close();

            return datavalue;
        }

        public static string SpaficDataISINTable(string table, string Name, string IDColumnname, string IDvalue)
        {
            DBConnection();
            string datavalue = "";
            Connection.Open();
            bool Retrunit = false;
            var SerchQuary = $"select {table}.{Name} from {table} where {IDColumnname} ={IDvalue}";
            var Command = new SqlCommand(SerchQuary, Connection);
            var reader = Command.ExecuteReader();
            while (reader.Read())
            {

                datavalue = reader.GetValue(0).ToString();
            }
            Connection.Close();

            return datavalue;

        }
        public static bool IsData(string table_name, string Column_name, string Check_value)
        {

            bool value = false;
            try
            {

                SqlConnection();
                string Query = $"select * from {table_name} where {Column_name} = " + " '" + Check_value + "'  ";
                var command = new SqlCommand(Query, Connection);
                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    value = true;
                }
                dataReader.Close();
                command.Dispose();
                close_Connection();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                value = false;
            }
            return value;

        }

        public static string CheckTableData(string table, string Name, string IDColumn)
        {
            DBConnection();
            string datavalue = "";
            Connection.Open();
            bool ReturnUnit = false;
            var SearchQuery = $"select {table}.{Name} from {table};";
            var Command = new SqlCommand(SearchQuery, Connection);
            var Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                datavalue = Reader.GetValue(0).ToString();
            }
            Connection.Close();
            return datavalue;
        }


        //Get value......
        static public string GetValue(string table, string getColumn, string Column, string value)
        {

            //SqlCommand Command;
            //SqlDataReader dataReader;

            string Value = "";
            try
            {
                Connection.Open();
                var query = $"select {table}.{getColumn} from {table} where {Column} = '" + value + "'";
                var Command = new SqlCommand(query, Connection);
                var dataReader = Command.ExecuteReader();


                while (dataReader.Read())
                {
                    value = dataReader.GetValue(0).ToString();
                }

                dataReader.Close();
                Command.Dispose();
                Connection.Close();

                return value;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return value;
            }
        }



        // Same product name check validation....
        static public bool IsProduct(string getvalue, string table_name, string column_name, string Check_value)
        {
            SqlCommand Command;
            SqlDataReader dataReader;
            SqlDataAdapter adapter = new SqlDataAdapter();
            bool value = false;
            try
            {
                //ConnectionString();
                Connection.Open();
                string query = $"select {getvalue} from {table_name} where {column_name} = " + "'" + Check_value + "'";
                Command = new SqlCommand(query, Connection);
                dataReader = Command.ExecuteReader();

                while (dataReader.Read())
                {
                    value = true;
                }
                dataReader.Close();
                Command.Dispose();

                Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                value = false;
            }
            return value;
        }

    }
}

