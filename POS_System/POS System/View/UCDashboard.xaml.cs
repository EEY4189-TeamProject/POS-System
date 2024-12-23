using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Threading;
using Sales_Management_System.ViewModel;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;
using POS_System.ViewModel;

namespace Sales_Management_System.View
{
    /// <summary>
    /// Interaction logic for UCDashboard.xaml
    /// </summary>
    public partial class UCDashboard : Window
    {
        SqlConnection Connection;
        private LocalReport _Report;
        DataTable DataTable;
        ReportDataSource ReportData;
        public UCDashboard()
        {
            InitializeComponent();
            //this.DataContext = new VMDashboard();
            DataTable = new DataTable();
            VMDashboard.back = new Action(this.Close);


            StartClock();

        }

        private void StartClock()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += tickevent;
            timer.Start();
        }

        private void tickevent(object sender, EventArgs e)
        {
            datelbl.Text = DateTime.Now.ToString(@"dd.MM.yyyy  hh:mm:ss   tt");
        }



 
    }
}
