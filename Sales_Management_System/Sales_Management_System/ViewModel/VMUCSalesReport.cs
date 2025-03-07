using Microsoft.Reporting.WinForms;
using Sales_Management_System.Model;
using Sales_Management_System.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sales_Management_System.ViewModel
{
    public class VMUCSalesReport : VMBase
    {
        public VMUCSalesReport()
        {

        }
        private DateTime _find;

        public DateTime Find
        {
            get { return _find; }
            set { _find = value; OnPropertyChanged(); }
        }


        private ObservableCollection<MDMPurches> _mPurches;

        public ObservableCollection<MDMPurches> MPurches
        {
            get { return _mPurches; }
            set { _mPurches = value; OnPropertyChanged(); }
        }

        public void Search(object param)
        {
            try
            {
                Find = DateTime.Parse(param.ToString());
                MPurches = new ObservableCollection<MDMPurches>();
                SQLConnection.SqlConnection();
                string searchQuery = $"select * from tblMPurches where Date ='" + Find.ToString("yyyy-MM-dd") + "'";
                SqlCommand Command = new SqlCommand(searchQuery, SQLConnection.getConnection());
                var reader = Command.ExecuteReader();
                reader.Close();
                SQLConnection.close_Connection();
            }
            catch
            {
                MessageBox.Show("Please select a date", "Report", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }


        //Month end..
        private DateTime startDate;

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; OnPropertyChanged(); }
        }

        private DateTime endDate;

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; OnPropertyChanged(); }
        }

        public void monthEndSearch(object param, object param1)
        {
            try
            {

                StartDate = DateTime.Parse(param.ToString());
                EndDate = DateTime.Parse(param1.ToString());

                MPurches = new ObservableCollection<MDMPurches>();
                SQLConnection.SqlConnection();
                //string searchQuery = $"select * from tblCPurches where Date ='" + Find + "'";

                string searchQuery = $"SELECT * FROM tblMPurches WHERE Date BETWEEN '" + StartDate + "' AND '" + EndDate + "' ";

                SqlCommand Command = new SqlCommand(searchQuery, SQLConnection.getConnection());
                var reader = Command.ExecuteReader();
                reader.Close();
                SQLConnection.close_Connection();

            }
            catch
            {
                MessageBox.Show("Please select a date", "Report", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }

    }
}
