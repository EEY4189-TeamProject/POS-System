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

using System.Windows.Input;

namespace POS_System.ViewModel
{
    public class VMUCVoidReport : VMBase
    {
        public VMUCVoidReport()
        {

        }
        private DateTime _find;

        public DateTime Find
        {
            get { return _find; }
            set { _find = value; OnPropertyChanged(); }
        }



        // public ICommand cmdSearch { get { return new RelayCommand(Search); } }

        private ObservableCollection<MDCPurches> _cPurches;

        public ObservableCollection<MDCPurches> CPurches
        {
            get { return _cPurches; }
            set { _cPurches = value; OnPropertyChanged(); }
        }



        public void Search(object param)
        {
            try
            {



                Find = DateTime.Parse(param.ToString());
                CPurches = new ObservableCollection<MDCPurches>();
                SQLConnection.SqlConnection();
                string searchQuery = $"select * from tblCPurches where Date ='" + Find.ToString("yyyy-MM-dd") + "'";
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

                CPurches = new ObservableCollection<MDCPurches>();
                SQLConnection.SqlConnection();
                //string searchQuery = $"select * from tblCPurches where Date ='" + Find + "'";

                string searchQuery = $"SELECT * FROM tblCPurches WHERE Date BETWEEN '" + StartDate + "' AND '" + EndDate + "' ";

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

