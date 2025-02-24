using Sales_Management_System.ViewModel;
using SalesSystem_05._11._2022.Model;
using SalesSystem_05._11._2022.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SalesSystem_05._11._2022.ViewModel
{
    internal class VMSupplier:VMBase
    {
        public ICommand cmdAddSupplier { get { return new RelayCommand(AddSupplier); } }

        void AddSupplier(object param)
        {
            VWSupplierAdd productAdd = new VWSupplierAdd();
            productAdd.DataContext = new VMSupplierAdd();
            productAdd.ShowDialog();
        }


        private ObservableCollection<MDSupplier> supplier;

        public ObservableCollection<MDSupplier> Supplier
        {
            get { return supplier; }
            set { supplier = value; OnPropertyChanged(); }
        }

        public VMSupplier()
        {
            SupplierView();
            SupplierRefresh += On_SupplierReferesh;
        }

        void SupplierView()
        {
            Supplier = new ObservableCollection<MDSupplier>();
            SQLConnection.DBConnection();
            SQLConnection.SqlConnection();

            var searchQuery = $"select * from tblSupplier order by SupplierId asc";
            var Command = new SqlCommand(searchQuery, SQLConnection.getConnection());
            var reader = Command.ExecuteReader();
            while (reader.Read())
            {
                Supplier.Add(new MDSupplier
                {
                    SupplierId = (int)reader.GetValue(0),
                    SupplierName = (reader.GetValue(1).ToString()),
                    PhoneNumber = reader.GetValue(2).ToString(),
                    SupplierAddress = (reader.GetValue(3).ToString()),
                });
            }
            SQLConnection.close_Connection();
        }


        //Delete query...
        public ICommand cmdSupplierDelete { get { return new RelayCommand(SupplierDelete); } }

        //public object DialogResult { get; private set; }

        void SupplierDelete(object param)
        {
            MDSupplier supplier = param as MDSupplier;

            try
            {

                if (MessageBox.Show("Do you want to delete", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    SQLConnection.SqlConnection();
                    string deleteQuery = $"delete from tblSupplier where SupplierId = {supplier.SupplierId}";
                    SqlCommand Command = new SqlCommand(deleteQuery, SQLConnection.getConnection());
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.DeleteCommand = new SqlCommand(deleteQuery, SQLConnection.getConnection());
                    adapter.DeleteCommand.ExecuteReader();
                    adapter.Dispose();
                    Command.Dispose();
                    SQLConnection.close_Connection();
                    SupplierRefresh();
                    MessageBox.Show("Product deleted sucessfully");
                }
            }
            catch
            {
                MessageBox.Show("Can't delete\n Supplier in Active", "Delete", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //Update query...

        public ICommand cmdUpdate { get { return new RelayCommand(SupplierUpdate); } }

        void SupplierUpdate(object param)
        {
            MDSupplier supplier = (MDSupplier)param;
            VWSupplierAdd SupplierAdd = new VWSupplierAdd();
            SupplierAdd.DataContext = new VMSupplierAdd(supplier);
            SupplierAdd.ShowDialog();
        }

        public static Action SupplierRefresh;


        public void On_SupplierReferesh()
        {
            SupplierView();
        }


        //Auto search..
        private string _find;

        public string Find
        {
            get { return _find; }
            set { _find = value; OnPropertyChanged(); AutoProductSearch(); }
        }


        private string _field;

        public string Field
        {
            get { return _field; }
            set { _field = value; OnPropertyChanged(); }
        }


        private string _column;

        public string Column
        {
            get { return _column; }
            set { _column = value; OnPropertyChanged(); }
        }


        private string _listView;

        public string ListView
        {
            get { return _listView; }
            set { _listView = value; OnPropertyChanged(); }
        }


        void AutoProductSearch()
        {
            try
            {
                switch (Field)
                {
                    case "Supplier ID":
                        Column = "SupplierId";
                        break;

                    case "Supplier Name":
                        Column = "SupplierName";
                        break;
        
                        break;
                    case "Address":
                        Column = "SupplierAddress";
                        break;
                }

                // Product = new();
                Supplier = new ObservableCollection<MDSupplier>();
                SQLConnection.SqlConnection();
                string searchQuery = $"select * from tblSupplier where {Column} Like '%" + Find + "%'";
                SqlCommand Command = new SqlCommand(searchQuery, SQLConnection.getConnection());
                var reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    Supplier.Add(new MDSupplier
                    {
                        SupplierId = (int)reader.GetValue(0),
                        SupplierName = (reader.GetValue(1).ToString()),
                        PhoneNumber = reader.GetValue(2).ToString(),
                        SupplierAddress = reader.GetValue(3).ToString()
                    });
                }
                SQLConnection.close_Connection();

            }
            catch
            {
                MessageBox.Show("Please select an option for search", "Supplier", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public ICommand cmdSearch { get { return new RelayCommand(Search); } }

        void Search (object param)
        {
            try
            {
                switch (Field)
                {
                    case "Supplier ID":
                        Column = "SupplierId";
                        break;

                    case "Supplier Name":
                        Column = "SupplierName";
                        break;

                        break;
                    case "Address":
                        Column = "SupplierAddress";
                        break;
                }

                // Product = new();
                Supplier = new ObservableCollection<MDSupplier>();
                SQLConnection.SqlConnection();
                string searchQuery = $"select * from tblSupplier where {Column}='"+Find+"'";
                SqlCommand Command = new SqlCommand(searchQuery, SQLConnection.getConnection());
                var reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    Supplier.Add(new MDSupplier
                    {
                        SupplierId = (int)reader.GetValue(0),
                        SupplierName = (reader.GetValue(1).ToString()),
                        PhoneNumber = reader.GetValue(2).ToString(),
                        SupplierAddress = reader.GetValue(3).ToString()
                    });
                }
                SQLConnection.close_Connection();
                if(Supplier.Count==0)
                {
                    MessageBox.Show("Data not found", " Search", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

            }
            catch
            {
                MessageBox.Show("Please select an option for search", "Supplier", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public ICommand cmdSupplierReset { get { return new RelayCommand(SupplierReset); } }
        void SupplierReset(object param)
        {
            SupplierView();
        }
    }
}
