using Microsoft.ReportingServices.Diagnostics.Internal;
using Sales_Management_System.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace POS_System.ViewModel
{
    public class ReportGetData : VMBase
    {
        //VMUCVoidReport rep = new VMUCVoidReport();
        //// static string ConnectionString = $"Data Source= OYSLANS; Initial Catalog = SalesManagementWPF; TrustServerCertificate = True; Integrated Security = True";
        //static string ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ToString();

        //public static void GetVoidData(DataTable DataTable)
        //{
        //    SqlConnection Connection = new SqlConnection(ConnectionString);

        //    try
        //    {
        //        //Connection = new SqlConnection(ConnectionString);
        //        Connection.Open();
        //        SqlCommand command = new SqlCommand("select * from tblCPurches", Connection);
        //        SqlDataReader reader = command.ExecuteReader();
        //        DataTable.Load(reader);
        //        Connection.Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message + "Database connection failed...", "Sql Connection", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }

        //}

        //public static void GetVoidData1(DataTable DataTable)
        //{
        //    SqlConnection Connection = new SqlConnection(ConnectionString);

        //    try
        //    {
        //        //Connection = new SqlConnection(ConnectionString);
        //        Connection.Open();
        //        SqlCommand command = new SqlCommand("select * from tblCPurches where Date ='" + rep.Find + "'", Connection);
        //        SqlDataReader reader = command.ExecuteReader();
        //        DataTable.Load(reader);
        //        Connection.Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message + "Database connection failed...", "Sql Connection", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }

        //}


    }
}
