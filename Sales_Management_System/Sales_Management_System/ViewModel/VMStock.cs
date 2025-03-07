using Sales_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Input;
using System.Windows;
using Sales_Management_System.View;
using System.Collections.ObjectModel;

namespace Sales_Management_System.ViewModel
{
    public class VMStock : VMBase
    {
        public VMStock(MDStock Stock)
        {

            {
                Stock = new();
                //Stock.StockId = Stock.StockId;
                Stock.ProductId = Stock.ProductId;
                Stock.ProductName = Stock.ProductName;
                Stock.ProductPrice = Stock.ProductPrice;
                Stock.ProductQuantity = Stock.ProductQuantity;




            }
        }

        private MDProduct product;

        public MDProduct Product
        {
            get { return product; }
            set { product = value; OnPropertyChanged(); }
        }


        private ObservableCollection<MDStock> stock;

        public ObservableCollection<MDStock> Stock
        {
            get { return stock; }
            set { stock = value; OnPropertyChanged(); }
        }

        public VMStock()
        {
            StockView();
            StockRefresh += On_ProductReferesh;
        }

        void StockView()
        {
            Stock = new ObservableCollection<MDStock>();
            SQLConnection.DBConnection();
            SQLConnection.SqlConnection();

            var searchQuery = $"select * from tblStock order by ProductId asc";
            var Command = new SqlCommand(searchQuery, SQLConnection.getConnection());
            var reader = Command.ExecuteReader();
            while (reader.Read())
            {
                Stock.Add(new MDStock
                {
                    //StockId = (int)reader.GetValue(0),
                    ProductId = (int)reader.GetValue(0),
                    ProductName = (reader.GetValue(1).ToString()),
                    ProductPrice = Convert.ToDouble(reader.GetValue(2)),
                    ProductQuantity = (int)reader.GetValue(3)
                });
            }
            SQLConnection.close_Connection();
        }

        //Search query....

        //  public ICommand cmdStockSearch { get { return new RelayCommand(StockSearch); } }

        private string _find;

        public string Find
        {
            get { return _find; }
            set { _find = value; OnPropertyChanged(); AutoStockSearch(); }
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

        void AutoStockSearch()
        {
            try
            {


                switch (Field)
                {
                    //case "Stock ID":
                    //    Column = "StockId";
                    //    break;

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

                Stock = new ObservableCollection<MDStock>();
                SQLConnection.SqlConnection();
                string searchQuery = $"select * from  tblStock where {Column} Like '%" + Find + "%'";
                SqlCommand Command = new SqlCommand(searchQuery, SQLConnection.getConnection());
                var reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    Stock.Add(new MDStock
                    {
                        //StockId = (int)reader.GetValue(0),
                        ProductId = (int)reader.GetValue(0),
                        ProductName = (reader.GetValue(1).ToString()),
                        ProductPrice = Convert.ToDouble(reader.GetValue(2)),
                        ProductQuantity = (int)reader.GetValue(3)
                    }); ;
                }
                SQLConnection.close_Connection();

            }
            catch
            {
                MessageBox.Show("Invalid Inputs...");
            }
        }


        public ICommand cmdSearch { get { return new RelayCommand(Search); } }

        void Search(object param)
        {
            try
            {


                switch (Field)
                {
                    //case "Stock ID":
                    //    Column = "StockId";
                    //    break;

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

                Stock = new ObservableCollection<MDStock>();
                SQLConnection.SqlConnection();
                string searchQuery = $"select * from  tblStock where {Column} = '" + Find + "'";
                SqlCommand Command = new SqlCommand(searchQuery, SQLConnection.getConnection());
                var reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    Stock.Add(new MDStock
                    {
                        //StockId = (int)reader.GetValue(0),
                        ProductId = (int)reader.GetValue(0),
                        ProductName = (reader.GetValue(1).ToString()),
                        ProductPrice = Convert.ToDouble(reader.GetValue(2)),
                        ProductQuantity = (int)reader.GetValue(3)
                    }); ;
                }
                SQLConnection.close_Connection();
                if (Stock.Count == 0)
                {
                    MessageBox.Show("Data not found", " Search", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Please select an option for search...", "Search", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }


        //reset query....

        public ICommand cmdStockReset { get { return new RelayCommand(StockReset); } }

        void StockReset(object param)
        {
            StockView();
        }

        //Delete query...

        public ICommand cmdStockDelete { get { return new RelayCommand(StockDelete); } }

        //   public object DialogResult { get; private set; }

        void StockDelete(object param)
        {
            MDStock stock = param as MDStock;

            try
            {

                if (MessageBox.Show("Do you want to delete", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    SQLConnection.SqlConnection();
                    string deleteQuery = $"delete from tblStock where ProductId = {stock.ProductId}";
                    SqlCommand Command = new SqlCommand(deleteQuery, SQLConnection.getConnection());
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.DeleteCommand = new SqlCommand(deleteQuery, SQLConnection.getConnection());
                    adapter.DeleteCommand.ExecuteReader();
                    adapter.Dispose();
                    Command.Dispose();
                    SQLConnection.close_Connection();
                    StockRefresh();

                    MessageBox.Show("Product deleted sucessfully");
                }
            }
            catch
            {
                MessageBox.Show("Can't delete\n It was Stored in Purches", "Delete", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        // Stock update....


        public ICommand cmdSUpdate { get { return new RelayCommand(SUpdate); } }

        void SUpdate(object param)
        {
            MDStock mStock = (MDStock)param;
            VWStockUpdate stock = new VWStockUpdate();
            stock.DataContext = new VMStockUpdate(mStock);
            stock.ShowDialog();


        }



        //Auto Refresh....

        public static Action StockRefresh;


        public void On_ProductReferesh()
        {
            StockView();
        }
    }
}
