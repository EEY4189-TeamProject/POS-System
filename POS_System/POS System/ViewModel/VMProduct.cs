using Sales_Management_System.Model;
using Sales_Management_System.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Data.SqlClient;
using System.Windows;
using System.Collections.ObjectModel;
using SalesSystem_05._11._2022.Model;

namespace Sales_Management_System.ViewModel
{
    internal class VMProduct : VMBase
    {
        public ICommand cmdAddProduct { get { return new RelayCommand(AddProduct); } }

        void AddProduct(object param)
        {
            VWProductAdd productAdd = new VWProductAdd();
            productAdd.DataContext = new VMProductAdd();
            productAdd.ShowDialog();
        }

        private ObservableCollection<MDProduct> product;

        public ObservableCollection<MDProduct> Product
        {
            get { return product; }
            set { product = value; OnPropertyChanged(); }
        }
        public VMProduct()
        {
            ProductView();
            ProductRefresh += On_ProductReferesh;
        }

        void ProductView()
        {
            Product = new ObservableCollection<MDProduct>();
            SQLConnection.DBConnection();
            SQLConnection.SqlConnection();

            //var searchQuery = $"select p.ProductId,p.ProductName, s.SupplierName,p.ProductPrice,p.ProductQuantity from tblProduct p join tblSupplier s on s.SupplierId= p.SupplierId order by ProductId asc";
            var searchQuery = $"select * from tblProduct order by ProductId asc";
            var Command = new SqlCommand(searchQuery, SQLConnection.getConnection());
            var reader = Command.ExecuteReader();
            while (reader.Read())
            {
                product.Add(new MDProduct
                {
                    ProductId = (int)reader.GetValue(0),
                    ProductName = (reader.GetValue(1).ToString()),
                    //Supplier = new MDSupplier
                    //{
                    //    SupplierName = (SQLConnection.SpaficDataISINTable("tblSupplier", "SupplierName", "SupplierId", reader.GetValue(2).ToString())),
                    //},
                    SupplierName = (SQLConnection.SpaficDataISINTable("tblSupplier", "SupplierName", "SupplierId", reader.GetValue(2).ToString())),
                    ProductPrice = Convert.ToDouble(reader.GetValue(3)),
                    ProductQuantity = (int)reader.GetValue(4),

                });
            }
            SQLConnection.close_Connection();
        }



        //Search query....

        //public ICommand cmdProductSearch { get { return new RelayCommand(ProductSearch); } }

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




        //reset query....

        void AutoProductSearch()
        {
            try
            {
                switch (Field)
                {
                    case "Product ID":
                        Column = "ProductId";
                        break;

                    case "Product Name":
                        Column = "ProductName";
                        break;
                    case "Product Price":
                        Column = "ProductPrice";
                        break;
                }
                //$"select * from  tblProduct where {Column} Like '%" + Find + "%'"
                // Product = new();
                Product = new ObservableCollection<MDProduct>();
                SQLConnection.SqlConnection();
                // string searchQuery = $"select p.ProductId,p.ProductName, s.SupplierName,p.ProductPrice,p.ProductQuantity from tblProduct p join tblSupplier s on s.SupplierId= p.SupplierId where {Column} Like '%" + Find + "%'";
                string searchQuery = $"select * from  tblProduct where {Column} Like '%" + Find + "%'";
                SqlCommand Command = new SqlCommand(searchQuery, SQLConnection.getConnection());
                var reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    Product.Add(new MDProduct
                    {
                        ProductId = (int)reader.GetValue(0),
                        ProductName = (reader.GetValue(1).ToString()),
                        //Supplier = new MDSupplier
                        //{
                        //    SupplierName = (SQLConnection.SpaficDataISINTable("tblSupplier", "SupplierName", "SupplierId", reader.GetValue(2).ToString())),
                        //},
                        SupplierName = (SQLConnection.SpaficDataISINTable("tblSupplier", "SupplierName", "SupplierId", reader.GetValue(2).ToString())),
                        ProductPrice = Convert.ToDouble(reader.GetValue(3)),
                        ProductQuantity = (int)reader.GetValue(4),

                    });
                }
                SQLConnection.close_Connection();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("Please select an option for search...", "Product Search", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public ICommand cmdSearch { get { return new RelayCommand(Search); } }

        void Search(object param)
        {
            try
            {
                switch (Field)
                {
                    case "Product ID":
                        Column = "ProductId";
                        break;

                    case "Product Name":
                        Column = "ProductName";
                        break;
                    case "Product Price":
                        Column = "ProductPrice";
                        break;
                }
                Product = new ObservableCollection<MDProduct>();
                SQLConnection.SqlConnection();
                string searchQuery = $"select * from  tblProduct where  {Column} ='" + Find + "'";
                SqlCommand Command = new SqlCommand(searchQuery, SQLConnection.getConnection());
                var reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    Product.Add(new MDProduct
                    {
                        ProductId = (int)reader.GetValue(0),
                        ProductName = (reader.GetValue(1).ToString()),
                        SupplierName = (SQLConnection.SpaficDataISINTable("tblSupplier", "SupplierName", "SupplierId", reader.GetValue(2).ToString())),
                        ProductPrice = Convert.ToDouble(reader.GetValue(3)),
                        ProductQuantity = (int)reader.GetValue(4),

                    });
                }
                SQLConnection.close_Connection();
                if(Product.Count==0)
                {
                    MessageBox.Show("Data not found", " Search", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            catch (Exception ex)
            {             
                MessageBox.Show(ex.Message+"Please select an option for search...", "Search", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
                     

    public ICommand cmdProductreset { get { return new RelayCommand(ProductRest); } }

        void ProductRest(object param)
        {
            ProductView();
        }




        //Delete query...
        public ICommand cmdProductDelete { get { return new RelayCommand(ProductDelete); } }

        //public object DialogResult { get; private set; }

        void ProductDelete(object param)
        {
            MDProduct product = param as MDProduct;

            try
            {
                if (MessageBox.Show("Do you want to delete...", "Delete", MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    SQLConnection.SqlConnection();
                    string DeleteQuery = $"delete from tblStock where ProductId = {product.ProductId}";
                    SqlCommand command = new SqlCommand(DeleteQuery, SQLConnection.getConnection());
                    SqlDataAdapter Adapter = new SqlDataAdapter();
                    Adapter.DeleteCommand = new SqlCommand(DeleteQuery, SQLConnection.getConnection());
                    Adapter.DeleteCommand.ExecuteReader();
                    Adapter.Dispose();
                    command.Dispose();
                    SQLConnection.close_Connection();


                    SQLConnection.SqlConnection();
                    string deleteQuery = $"delete from tblProduct where ProductId = {product.ProductId}";
                    SqlCommand Command = new SqlCommand(deleteQuery, SQLConnection.getConnection());
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.DeleteCommand = new SqlCommand(deleteQuery, SQLConnection.getConnection());
                    adapter.DeleteCommand.ExecuteReader();
                    adapter.Dispose();
                    Command.Dispose();
                    SQLConnection.close_Connection();
                    ProductRefresh();                 

                    MessageBox.Show("Product deleted sucessfully ", "Delete", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message+"Can't delete \n This product already sales ", "Delete", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //Update query....
        public ICommand cmdUpdate { get { return new RelayCommand(ProductUpdate); } }

        void ProductUpdate(object param)
        {
            MDProduct mProduct = (MDProduct)param;
            VWProductAdd ProductAdd = new VWProductAdd();
            ProductAdd.DataContext = new VMProductAdd(mProduct);
            ProductAdd.ShowDialog();

        }


        //Auto Refresh....

        public static Action ProductRefresh;

        public void On_ProductReferesh()
        {
            ProductView();
        }
    }
}
