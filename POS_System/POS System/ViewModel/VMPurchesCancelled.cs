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
    public class VMPurchesCancelled:VMBase
    {
        private ObservableCollection<MDCPurches> _cPurches;

        public ObservableCollection<MDCPurches> CPurches
        {
            get { return _cPurches; }
            set { _cPurches = value; OnPropertyChanged(); }
        }

        public VMPurchesCancelled()
        {
            CPurView();
            CPurRefresh += On_ProductReferesh;
        }

        void CPurView()
        {
            CPurches = new ObservableCollection<MDCPurches>();
            SQLConnection.DBConnection();
            SQLConnection.SqlConnection();

            var searchQuery = $"select * from tblCPurches order by CPurchesId asc  ";
            var Command = new SqlCommand(searchQuery, SQLConnection.getConnection());
            var reader = Command.ExecuteReader();
            while (reader.Read())
            {
                CPurches.Add(new MDCPurches
                {
                    CPurchesId = (int)reader.GetValue(0),
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


        public ICommand cmdCPurDel { get { return new RelayCommand(CPurDel); } }

        void CPurDel(object param)
        {
            try
            {
                MDCPurches pur = param as MDCPurches;
                if (MessageBox.Show("Do you want to delete", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    SQLConnection.SqlConnection();
                    string deleteQuery = $"delete from tblCPurches where CPurchesId = {pur.CPurchesId}";
                    SqlCommand Command = new SqlCommand(deleteQuery, SQLConnection.getConnection());
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.DeleteCommand = new SqlCommand(deleteQuery, SQLConnection.getConnection());
                    adapter.DeleteCommand.ExecuteReader();
                    adapter.Dispose();
                    Command.Dispose();
                    SQLConnection.close_Connection();
                    CPurRefresh();
                    MessageBox.Show(" deleted sucessfully");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message +"Can't delete", "Delete", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        public static Action CPurRefresh;


        public void On_ProductReferesh()
        {
            CPurView();
        }

        //search query...

        private string _find;

        public string Find
        {
            get { return _find; }
            set { _find = value; OnPropertyChanged(); AutoCSalesSearch(); }
        }


        private string _field;

        public string Field
        {
            get { return _field; }
            set { _field = value; OnPropertyChanged(); 
            
               
                    if (Field == "Date")
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

        private string datePicker="Collapsed";

        public string DatePicker
        {
            get { return datePicker; }
            set { datePicker= value; OnPropertyChanged(); }
        }


        void AutoCSalesSearch()
        {
            try
            {

                switch (Field)
                {
                    case "Purches Id":
                        Column = "CPurchesId";
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


                CPurches = new ObservableCollection<MDCPurches>();

                //  var v = IsDateColumn ? String.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(Find)) : Find;

                SQLConnection.SqlConnection();
                string searchQuery = $"select * from tblCPurches where {Column} Like '%" + Find + "%'";
                SqlCommand Command = new SqlCommand(searchQuery, SQLConnection.getConnection());
                var reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    CPurches.Add(new MDCPurches
                    {
                        CPurchesId = (int)reader.GetValue(0),
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

        public ICommand cmdSearch { get { return new RelayCommand(Search); } }

        void Search(object param)
        {
            try
            {
                bool IsdateColumn = false;


                switch (Field)
                {
                    case "Purches Id":
                        Column = "CPurchesId";
                        break;
                    case "Product Name":
                        Column = "ProductName";
                        break;
                    case "Product Price":
                        Column = "ProductPrice";
                        break;
                    case "Date":
                        Column = "Date";
                        IsdateColumn = true;
                        break;

                }


                CPurches = new ObservableCollection<MDCPurches>();
                var v = IsdateColumn ? String.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(Find)) : Find;

                SQLConnection.SqlConnection();
                string searchQuery = $"select * from tblCPurches where {Column} ='" + v + "'";
                SqlCommand Command = new SqlCommand(searchQuery, SQLConnection.getConnection());
                var reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    CPurches.Add(new MDCPurches
                    {
                        CPurchesId = (int)reader.GetValue(0),
                        ProductId = int.Parse(reader.GetValue(1).ToString()),
                        ProductName = (reader.GetValue(2).ToString()),
                        ProductPrice = Convert.ToDouble(reader.GetValue(3).ToString()),
                        PurchesQuantity = int.Parse(reader.GetValue(4).ToString()),
                        Total = Convert.ToDouble(reader.GetValue(5).ToString()),
                        Date = (DateTime)reader.GetValue(6)
                    });
                }
                SQLConnection.close_Connection();
                if(CPurches.Count==0)
                {
                    MessageBox.Show("Data not found", " Search", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Please select an option for search", "Search", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public ICommand cmdCPurReset { get { return new RelayCommand(CPurReset); } }

        void CPurReset(object param)
        {
            CPurView();
        }
    }
}

