using POS_System.View;
using POS_System.ViewModel;
using Sales_Management_System.View;
using SalesSystem_05._11._2022.Model;
using SalesSystem_05._11._2022.View;
using SalesSystem_05._11._2022.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Sales_Management_System.ViewModel
{
    internal class VMDashboard :VMBase
    {
        private UserControl _control = new UserControl();

        public UserControl Control
        {
            get { return _control; }
            set
            {
                _control = value;
                OnPropertyChanged();
            }
        }

        private MDUser _user;

        public MDUser Userr
        {
            get { return _user; }
            set { _user = value; OnPropertyChanged(); }
        }

        public VMDashboard(MDUser User)
        {
            Userr = new MDUser();
            Userr.UserName = User.UserName;
           
            sales();
        }

        public ICommand cmdUCProduct { get { return new RelayCommand(Product); } }

        public ICommand cmdUCPurches { get { return new RelayCommand(Purches); } }

        public ICommand cmdUCStock { get { return new RelayCommand(Stock); } }

        public ICommand cmdBack { get { return new RelayCommand(Back); } }

        //public ICommand cmdUCProductView { get { return new RelayCommand(ProductView); } }

        //public ICommand cmdUCStockView { get { return new RelayCommand(StockView); } }

        public ICommand cmdSales { get { return new RelayCommand(SalesView); } }

        public ICommand cmdCPur { get { return new RelayCommand(CPurView); } }
        public ICommand cmdSupplier { get { return new RelayCommand(Supplier); } }

        public ICommand cmdUser { get { return new RelayCommand(User); } }

       public ICommand cmdSalesReport { get { return new RelayCommand(SalesReport); } }

        public ICommand cmdVoidReport { get { return new RelayCommand(VoidReport); } }

        void User(object param)
        {
            VMLogin user = new VMLogin();
            Control.Content = new UCUser();
            Control.DataContext = user;

        }
        void Supplier(object param)
        {
            VMSupplier supplier = new VMSupplier();
            Control.Content = new UCSupplier();
            Control.DataContext = supplier;
        }
      
        public ICommand cmdback { get { return new RelayCommand(Exit); } }
        public static Action back;

        void Exit(object param)
        {
            back.Invoke();
        }


       // public static Action back;

        void Back(object param)
        {
            // back.Invoke();
            //MainWindow main = new MainWindow();
            //main.DataContext = new VMMainwindow();
            //back.Invoke();
            //main.ShowDialog();

            if (MessageBox.Show("Do you want to Logout ?", "Logout", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)

            {
                VWLogin log = new VWLogin();
                log.DataContext = new VMLogin();
                back.Invoke();
                log.ShowDialog();
            }

        }

        void Product(object param)
        {
            VMProduct product = new VMProduct();
            Control.Content = new UCProduct();
            Control.DataContext = product;
        }

        void Purches(object param)
        {
            

            VMPurches purches = new VMPurches();
            Control.Content = new UCPurches();
            Control.DataContext = purches;
        }

        void sales()
        {
            
            VMPurches purches = new VMPurches();
            Control.Content = new UCPurches();
            Control.DataContext = purches;
        }


        void Stock(object param)
        {
            VMStock stock = new VMStock();
            Control.Content = new UCStock();
            Control.DataContext = stock;
        }

        //void ProductView(object param)
        //{
        //    VMProductView productView = new VMProductView();
        //    Control.Content = new UCProductView();
        //    Control.DataContext = productView;
        //}

        //void StockView(object param)
        //{
        //    VMStockView stockView = new VMStockView();
        //    Control.Content = new UCStockView();
        //    Control.DataContext = stockView;
        //}

        void SalesView(object param)
        {
            VMSalesView sale = new VMSalesView();
            Control.Content = new UCSalesView();
            Control.DataContext = sale;
        }

        void CPurView(object param)
        {
            //VMPurchesCancelled can = new VMPurchesCancelled();
            //Control.Content = new UCPurchesCancelled();
            //Control.DataContext = can;
        }

        void SalesReport(object param)
        {
            VMUCSalesReport SReport = new VMUCSalesReport();
            Control.Content = new UCSalesReport();
            Control.DataContext = SReport;
        }

        void VoidReport(object param)
        {
            VMUCVoidReport VReport = new VMUCVoidReport();
            Control.Content = new UCVoidReport();
            Control.DataContext = VReport;
        }
    }
}
