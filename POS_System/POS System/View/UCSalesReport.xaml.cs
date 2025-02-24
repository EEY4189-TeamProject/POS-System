﻿using Microsoft.Reporting.WinForms;
using POS_System.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POS_System.View
{
    /// <summary>
    /// Interaction logic for UCSalesReport.xaml
    /// </summary>
    public partial class UCSalesReport : UserControl
    {
        static string ConnectionString = @"Data Source=OYSLANS\OYSSQLSERVER;Initial Catalog=SalesManagementWPF;user id=sa;password=Manager@23; TrustServerCertificate=True; Integrated Security = True";



        SqlConnection Connection;
        private LocalReport _Report;
        DataTable DataTable;
        ReportDataSource ReportData;
        static VMUCSalesReport day;
        public UCSalesReport()
        {
            InitializeComponent();

            DataTable = new DataTable();
            day = new VMUCSalesReport();
            day.Find = DateTime.Now;
            GetSalesData(DataTable);

            string _path = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())));

            string ContentStart = _path + @"\Reports\SalesReport.rdlc";

            ReportViewer.LocalReport.DataSources.Clear();

            ReportData = new ReportDataSource
            {
                Name = "POSDatasetSales",
                Value = DataTable
            };

            ReportViewer.LocalReport.DataSources.Add(ReportData);

            ReportViewer.LocalReport.ReportPath = ContentStart;

            ReportViewer.SetDisplayMode(DisplayMode.Normal);

            ReportViewer.RefreshReport();
            ReportViewer.Refresh();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataTable = new DataTable();

            GetSalesData(DataTable);

            string _path = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())));

            string ContentStart = _path + @"\Reports\SalesReport.rdlc";

            ReportViewer.LocalReport.DataSources.Clear();

            ReportData = new ReportDataSource
            {
                Name = "POSDatasetSales",
                Value = DataTable
            };

            ReportViewer.LocalReport.DataSources.Add(ReportData);

            ReportViewer.LocalReport.ReportPath = ContentStart;

            ReportViewer.SetDisplayMode(DisplayMode.Normal);

            ReportViewer.RefreshReport();
            ReportViewer.Refresh();
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {

   

            DataTable = new DataTable();
            day.Search(Find);
            //day.Search(Find);
            GetSalesData1(DataTable);
            string _path = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())));
            string ContentStart = _path + @"\Reports\SalesReport.rdlc";

            ReportViewer.LocalReport.DataSources.Clear();

            ReportData = new ReportDataSource
            {
                Name = "POSDatasetSales",
                Value = DataTable
            };

            ReportViewer.LocalReport.DataSources.Add(ReportData);

            ReportViewer.LocalReport.ReportPath = ContentStart;

            ReportViewer.SetDisplayMode(DisplayMode.Normal);

            ReportViewer.RefreshReport();
            ReportViewer.Refresh();

            if(DataTable.Rows.Count==0)
            {
                MessageBox.Show("Data not Found", "Report", MessageBoxButton.OK, MessageBoxImage.Error);
            }



        }

        //VMUCVoidReport rep = new VMUCVoidReport();
        //static string ConnectionString = ConnectionStrings["connectionString"].ToString();

        public static void GetSalesData(DataTable DataTable)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);

            try
            {
                //Connection = new SqlConnection(ConnectionString);
                Connection.Open();
                SqlCommand command = new SqlCommand("select ProductName,ProductPrice,PurchesQuantity,Total,Date from tblMPurches", Connection);
                SqlDataReader reader = command.ExecuteReader();
                DataTable.Load(reader);
                Connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Database connection failed...", "Sql Connection", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        public static void GetSalesData1(DataTable DataTable)
        {

            SqlConnection Connection = new SqlConnection(ConnectionString);

            try
            {
                //Connection = new SqlConnection(ConnectionString);
                Connection.Open();
                SqlCommand command = new SqlCommand("select ProductName,ProductPrice,PurchesQuantity,Total,Date from tblMPurches where Date ='" + day.Find.ToString("yyyy-MM-dd") + "'", Connection);
                SqlDataReader reader = command.ExecuteReader();
                DataTable.Load(reader);
                Connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Database connection failed...", "Sql Connection", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Button_Click_Load(object sender, RoutedEventArgs e)
        {
            DataTable = new DataTable();

            GetSalesData(DataTable);

            string _path = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())));

            string ContentStart = _path + @"\Reports\SalesReport.rdlc";

            ReportViewer.LocalReport.DataSources.Clear();

            ReportData = new ReportDataSource
            {
                Name = "POSDatasetSales",
                Value = DataTable
            };

            ReportViewer.LocalReport.DataSources.Add(ReportData);

            ReportViewer.LocalReport.ReportPath = ContentStart;

            ReportViewer.SetDisplayMode(DisplayMode.Normal);

            ReportViewer.RefreshReport();
            ReportViewer.Refresh();
        }




        //month end

        public static void GetVoidData2(DataTable DataTable)
        {

            SqlConnection Connection = new SqlConnection(ConnectionString);

            try
            {
                //Connection = new SqlConnection(ConnectionString);
                Connection.Open();
                SqlCommand command = new SqlCommand("select ProductName,ProductPrice,PurchesQuantity,Total,Date from tblMPurches WHERE Date BETWEEN '" + day.StartDate.ToString("yyyy-MM-dd") + "' AND '" + day.EndDate.ToString("yyyy-MM-dd") + "' ", Connection);
                SqlDataReader reader = command.ExecuteReader();
                DataTable.Load(reader);
                Connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Database connection failed...", "Sql Connection", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Button_Click_Month_Search(object sender, RoutedEventArgs e)
        {
           
            DataTable = new DataTable();
            day.monthEndSearch(StartDate, EndDate);


            GetVoidData2(DataTable);
            string _path = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())));
            string ContentStart = _path + @"\Reports\SalesReport.rdlc";

            ReportViewer.LocalReport.DataSources.Clear();

            ReportData = new ReportDataSource
            {
                Name = "POSDatasetSales",
                Value = DataTable
            };

            ReportViewer.LocalReport.DataSources.Add(ReportData);

            ReportViewer.LocalReport.ReportPath = ContentStart;

            ReportViewer.SetDisplayMode(DisplayMode.Normal);

            ReportViewer.RefreshReport();
            ReportViewer.Refresh();

            if (DataTable.Rows.Count == 0)
            {
                MessageBox.Show("Data not Found", "Report", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }



    }
}

