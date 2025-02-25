using Sales_Management_System.ViewModel; // Importing ViewModel namespace  
using SalesSystem_05._11._2022.Model; // Importing Model namespace  
using SalesSystem_05._11._2022.View; // Importing View namespace  
using System; // Importing system base classes  
using System.Collections.Generic; // Importing collection classes  
using System.Collections.ObjectModel; // Importing observable collection  
using System.Data.SqlClient; // Importing SQL client for database connection  
using System.Linq; // Importing LINQ for data manipulation  
using System.Text; // Importing text utilities  
using System.Threading.Tasks; // Importing threading and task management  
using System.Windows; // Importing Windows UI functionalities  
using System.Windows.Input; // Importing command interface  

namespace SalesSystem_05._11._2022.ViewModel
{
    internal class VMSupplier : VMBase
    {
        // ICommand for adding a new supplier  
        public ICommand cmdAddSupplier { get { return new RelayCommand(AddSupplier); } }

        // Method to add supplier, opens a new form  
        void AddSupplier(object param)
        {
            VWSupplierAdd productAdd = new VWSupplierAdd(); // Creating instance of Supplier Add form  
            productAdd.DataContext = new VMSupplierAdd(); // Setting data context  
            productAdd.ShowDialog(); // Displaying form  
        }

        // ObservableCollection to store supplier data  
        private ObservableCollection<MDSupplier> supplier;

        // Property for binding supplier list  
        public ObservableCollection<MDSupplier> Supplier
        {
            get { return supplier; }
            set { supplier = value; OnPropertyChanged(); } // Notify UI on data change  
        }

        // Constructor  
        public VMSupplier()
        {
            SupplierView(); // Fetch supplier details  
            SupplierRefresh += On_SupplierReferesh; // Subscribe to refresh event  
        }

        // Method to fetch suppliers from database  
        void SupplierView()
        {
            Supplier = new ObservableCollection<MDSupplier>(); // Initialize supplier collection  
            SQLConnection.DBConnection(); // Open DB connection  
            SQLConnection.SqlConnection(); // Connect to SQL server  

            var searchQuery = $"SELECT * FROM tblSupplier ORDER BY SupplierId ASC"; // SQL query to fetch suppliers  
            var Command = new SqlCommand(searchQuery, SQLConnection.getConnection()); // Execute SQL command  
            var reader = Command.ExecuteReader(); // Read data  

            while (reader.Read()) // Loop through fetched data  
            {
                Supplier.Add(new MDSupplier
                {
                    SupplierId = (int)reader.GetValue(0), // Read Supplier ID  
                    SupplierName = (reader.GetValue(1).ToString()), // Read Name  
                    PhoneNumber = reader.GetValue(2).ToString(), // Read Phone  
                    SupplierAddress = (reader.GetValue(3).ToString()), // Read Address  
                });
            }
            SQLConnection.close_Connection(); // Close DB connection  
        }

        // ICommand for deleting a supplier  
        public ICommand cmdSupplierDelete { get { return new RelayCommand(SupplierDelete); } }

        // Method to delete supplier  
        void SupplierDelete(object param)
        {
            MDSupplier supplier = param as MDSupplier;

            try
            {
                if (MessageBox.Show("Do you want to delete", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    SQLConnection.SqlConnection(); // Connect to SQL server  
                    string deleteQuery = $"DELETE FROM tblSupplier WHERE SupplierId = {supplier.SupplierId}"; // Delete query  
                    SqlCommand Command = new SqlCommand(deleteQuery, SQLConnection.getConnection());
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.DeleteCommand = new SqlCommand(deleteQuery, SQLConnection.getConnection());
                    adapter.DeleteCommand.ExecuteReader(); // Execute delete command  
                    adapter.Dispose();
                    Command.Dispose();
                    SQLConnection.close_Connection(); // Close DB connection  
                    SupplierRefresh(); // Refresh supplier list  
                    MessageBox.Show("Product deleted successfully"); // Show success message  
                }
            }
            catch
            {
                MessageBox.Show("Can't delete\n Supplier in Active", "Delete", MessageBoxButton.OK, MessageBoxImage.Error); // Show error message  
            }
        }

        // ICommand for updating supplier  
        public ICommand cmdUpdate { get { return new RelayCommand(SupplierUpdate); } }

        // Method to update supplier  
        void SupplierUpdate(object param)
        {
            MDSupplier supplier = (MDSupplier)param; // Get selected supplier  
            VWSupplierAdd SupplierAdd = new VWSupplierAdd(); // Open update form  
            SupplierAdd.DataContext = new VMSupplierAdd(supplier); // Bind data to form  
            SupplierAdd.ShowDialog(); // Show update dialog  
        }

        public static Action SupplierRefresh; // Event for refreshing supplier list  

        // Event handler for refreshing supplier list  
        public void On_SupplierReferesh()
        {
            SupplierView(); // Reload supplier data  
        }

        // Auto search feature  
        private string _find;
        public string Find
        {
            get { return _find; }
            set { _find = value; OnPropertyChanged(); AutoProductSearch(); } // Trigger search on value change  
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

        // Auto search method  
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
                    case "Address":
                        Column = "SupplierAddress";
                        break;
                }

                Supplier = new ObservableCollection<MDSupplier>(); // Reset supplier list  
                SQLConnection.SqlConnection(); // Connect to SQL server  
                string searchQuery = $"SELECT * FROM tblSupplier WHERE {Column} LIKE '%" + Find + "%'"; // Search query  
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
                SQLConnection.close_Connection(); // Close DB connection  

            }
            catch
            {
                MessageBox.Show("Please select an option for search", "Supplier", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public ICommand cmdSearch { get { return new RelayCommand(Search); } }

        void Search(object param)
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
                    case "Address":
                        Column = "SupplierAddress";
                        break;
                }

                Supplier = new ObservableCollection<MDSupplier>();
                SQLConnection.SqlConnection();
                string searchQuery = $"SELECT * FROM tblSupplier WHERE {Column}='" + Find + "'";
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
    }
}
