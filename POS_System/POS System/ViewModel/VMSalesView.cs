using Sales_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Sales_Management_System.ViewModel
{
    public class VMSalesView : VMBase
    {



        private ObservableCollection<MDMPurches> purches;

        public ObservableCollection<MDMPurches> Purches
        {
            get { return purches; }
            set { purches = value; OnPropertyChanged(); }
        }

        public VMSalesView()
        {
            SalesView();
            SalesRefresh += On_ProductReferesh;
        }


        void SalesView()
        {
            Purches = new ObservableCollection<MDMPurches>();
            SQLConnection.DBConnection();
            SQLConnection.SqlConnection();

            var searchQuery = $"select * from tblMPurches order by PurchesId asc  ";
            var Command = new SqlCommand(searchQuery, SQLConnection.getConnection());
            var reader = Command.ExecuteReader();
            while (reader.Read())
            {
                Purches.Add(new MDMPurches
                {
                    PurchesId = (int)reader.GetValue(0),
                    ProductId = int.Parse(reader.GetValue(1).ToString()),
                    ProductName = (reader.GetValue(2).ToString()),
                    ProductPrice = Convert.ToDouble(reader.GetValue(3).ToString()),
                    PurchesQuantity = int.Parse(reader.GetValue(4).ToString()),
                    Total = Convert.ToDouble(reader.GetValue(5).ToString()),
                    Date = (DateTime)reader.GetValue(6)
                });
            }
            SQLConnection.close_Connection();
        }

        //Sales delete...

        public ICommand cmdSaleDelete { get { return new RelayCommand(SalesDelete); } }

        void SalesDelete(object param)
        {


            try
            {
                MDMPurches pur = param as MDMPurches;
                if (MessageBox.Show("Do you want to delete", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    SQLConnection.SqlConnection();
                    string deleteQuery = $"delete from tblMPurches where PurchesId = {pur.PurchesId}";
                    SqlCommand Command = new SqlCommand(deleteQuery, SQLConnection.getConnection());
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.DeleteCommand = new SqlCommand(deleteQuery, SQLConnection.getConnection());
                    adapter.DeleteCommand.ExecuteReader();
                    adapter.Dispose();
                    Command.Dispose();
                    SQLConnection.close_Connection();
                    SalesRefresh();
                    MessageBox.Show("Sales deleted sucessfully...");
                }
            }
            catch
            {
                MessageBox.Show("Can't delete", "Delete", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static Action SalesRefresh;


        public void On_ProductReferesh()
        {
            SalesView();
        }


        //search query...

        private string _find;

        public string Find
        {
            get { return _find; }
            set { _find = value; OnPropertyChanged(); AutoSalesSearch(); }
        }


        private string _field;

        public string Field
        {
            get { return _field; }
            set { _field = value; OnPropertyChanged(); 
            
                if(Field == "Date")
                {
                    TextBox = "Collapsed";
                    DatePicker = "Visible";
                }
                else
                {
                    TextBox = "Visible";
                    DatePicker = "Collapsed";
                }
            }
            
        }


        private string _column;

        public string Column
        {
            get { return _column; }
            set { _column = value; OnPropertyChanged(); }
        }


        private string textBox;

        public string TextBox
        {
            get { return textBox; }
            set { textBox = value; OnPropertyChanged(); }
        }

        private string datePicker ="Collapsed";

        public string DatePicker
        {
            get { return datePicker ; }
            set { datePicker = value;OnPropertyChanged(); }
        }


        void AutoSalesSearch()
        {
            try
            {

                switch (Field)
                {
                    case "Purches Id":
                        Column = "PurchesId";
                        break;
                    case "Product Name":
                        Column = "ProductName";
                        break;
                    case "Product Price":
                        Column = "ProductPrice";
                        break;
                    case "Date":
                        Column = "Date";
                        break;

                }


                Purches = new ObservableCollection<MDMPurches>();
                SQLConnection.SqlConnection();
                string searchQuery = $"select * from tblMPurches where {Column} Like '%" + Find + "%'";
                SqlCommand Command = new SqlCommand(searchQuery, SQLConnection.getConnection());
                var reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    Purches.Add(new MDMPurches
                    {
                        PurchesId = (int)reader.GetValue(0),
                        ProductId = int.Parse(reader.GetValue(1).ToString()),
                        ProductName = (reader.GetValue(2).ToString()),
                        ProductPrice = Convert.ToDouble(reader.GetValue(3).ToString()),
                        PurchesQuantity = int.Parse(reader.GetValue(4).ToString()),
                        Total = Convert.ToDouble(reader.GetValue(5).ToString()),
                        Date = (DateTime)reader.GetValue(6)
                    });
                }
                SQLConnection.close_Connection();
            }
            catch
            {
                MessageBox.Show("Please select an option for search", "Search", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        //Search....

        public ICommand cmdSaleSearch { get { return new RelayCommand(SalesSearch); } }

        void SalesSearch(object param)
        {

            try
            {
                bool IsDateColumn = false;
                switch (Field)
                {

                    case "Purches Id":
                        Column = "PurchesId";
                        break;

                    case "Product Name":
                        Column = "ProductName";
                        break;

                    case "Product Price":
                        Column = "ProductPrice";
                        break;

                    case "Date":
                        Column = "Date";
                        IsDateColumn = true;
                        break;

                }

                //if (!SQLConnection.IsData("tblMPurches", Column, Find))
                //{


                    Purches = new ObservableCollection<MDMPurches>();
                var v = IsDateColumn ? String.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(Find)) : Find;

                     SQLConnection.SqlConnection();
                    string searchQuery = $"select * from tblMPurches where {Column} ='" + v + "'";
                    SqlCommand Command = new SqlCommand(searchQuery, SQLConnection.getConnection());
                    var reader = Command.ExecuteReader();

                    while (reader.Read())
                    {
                        Purches.Add(new MDMPurches
                        {
                            PurchesId = (int)reader.GetValue(0),
                            ProductId = int.Parse(reader.GetValue(1).ToString()),
                            ProductName = (reader.GetValue(2).ToString()),
                            ProductPrice = Convert.ToDouble(reader.GetValue(3).ToString()),
                            PurchesQuantity = int.Parse(reader.GetValue(4).ToString()),
                            Total = Convert.ToDouble(reader.GetValue(5).ToString()),
                            Date = (DateTime)reader.GetValue(6)
                        });
                    }

                    SQLConnection.close_Connection();
                    if(Purches.Count==0)
                    {
                        MessageBox.Show("Data not found", " Search", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                //}
                //else
                //{
                //    MessageBox.Show("Data not found", " Search", MessageBoxButton.OK, MessageBoxImage.Error);

                //}
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message+"Please select an option for search", " Search", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        public ICommand cmdSalesReset { get { return new RelayCommand(SalesReset); } }
        void SalesReset(object param)
        {
            SalesView();
        }
    }
}
