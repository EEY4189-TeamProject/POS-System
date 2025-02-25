using Sales_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;

using Sales_Management_System.View;
using SalesSystem_05._11._2022.Model;

namespace Sales_Management_System.ViewModel
{
    public class VMPurches : VMBase
    {
        private ObservableCollection<MDStock> stock;

        public ObservableCollection<MDStock> Stock
        {
            get { return stock; }
            set { stock = value; OnPropertyChanged(); }
        }
        public VMPurches()
        {
            ProductView();
            PurchesList = new();

            Purches = new MDMPurches();
            Purches.Product = new MDProduct();
            Purches.PurchesId = SQLConnection.ISData("tblMPurches") ? int.Parse(SQLConnection.CheckTableData("tblMPurches", "PurchesId", "PurchesId")) + 1 : 1;
            Purches.BillId = SQLConnection.ISData("tblBill") ? int.Parse(SQLConnection.CheckTableData("tblBill", "BillId", "BillId")) + 1 : 1;

            // CPurches = new MDCPurches();
            CPurches.Product = new MDProduct();
            CPurches.CPurchesId = SQLConnection.ISData("tblCPurches") ? int.Parse(SQLConnection.CheckTableData("tblCPurches", "CPurchesId", "CPurchesId")) + 1 : 1;
        }

        void ProductView()
        {
            //Product = new MDProduct();
            ProductList = new ObservableCollection<MDProduct>();
            SQLConnection.DBConnection();
            SQLConnection.SqlConnection();
            //Purches = new MDMPurches();
            var searchQuery = $"select * from tblProduct ";
            var Command = new SqlCommand(searchQuery, SQLConnection.getConnection());
            var reader = Command.ExecuteReader();
            while (reader.Read())
            {
                ProductList.Add(new MDProduct
                {
                    ProductId = (int)reader.GetValue(0),
                    ProductName = (reader.GetValue(1).ToString()),
                    //Supplier = new MDSupplier
                    //{
                    //    SupplierName = (SQLConnection.SpaficDataISINTable("tblSupplier", "SupplierName", "SupplierId", reader.GetValue(2).ToString())),
                    //},
                    SupplierName = (SQLConnection.SpaficDataISINTable("tblSupplier", "SupplierName", "SupplierId", reader.GetValue(2).ToString())),
                    //Supplier = { Supplier.SupplierName(reader.GetValue(2).ToString()) },
                    ProductPrice = Convert.ToDouble(reader.GetValue(3)),
                    ProductQuantity = (int)reader.GetValue(4)
                });
            }
            SQLConnection.close_Connection();
        }



        // Search query...

        //    public ICommand cmdStockToPurSearch { get { return new RelayCommand(StockToPurSearch); } }

        private string _find;

        public string Find
        {
            get { return _find; }
            set { _find = value; OnPropertyChanged(); StockToPurSearch(); }
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


        void StockToPurSearch()
        {
            try
            {
                switch (Field)
                {
                    case "Product Name":
                        Column = "ProductName";
                        break;
                    case "Product Price":
                        Column = "ProductPrice";
                        break;
                }

                ProductList = new ObservableCollection<MDProduct>();
                SQLConnection.SqlConnection();
                string searchQuery = $"select * from  tblProduct where {Column} Like '%" + Find + "%'";
                SqlCommand Command = new SqlCommand(searchQuery, SQLConnection.getConnection());
                var reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    ProductList.Add(new MDProduct
                    {
                        ProductId = (int)reader.GetValue(0),
                        ProductName = (reader.GetValue(1).ToString()),
                        //SupplierId= (int)reader.GetValue(2),
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
            catch
            {
                MessageBox.Show("Please select an option for search", "Product ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public ICommand cmdSearch { get { return new RelayCommand(Search); } }

        void Search(object param)
        {
            try
            {
                switch (Field)
                {
                    case "Product Name":
                        Column = "ProductName";
                        break;
                    case "Product Price":
                        Column = "ProductPrice";
                        break;
                }

                ProductList = new ObservableCollection<MDProduct>();
                SQLConnection.SqlConnection();
                string searchQuery = $"select * from  tblProduct where {Column} ='" + Find + "'";
                SqlCommand Command = new SqlCommand(searchQuery, SQLConnection.getConnection());
                var reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    ProductList.Add(new MDProduct
                    {
                        ProductId = (int)reader.GetValue(0),
                        ProductName = (reader.GetValue(1).ToString()),
                        SupplierName = (SQLConnection.SpaficDataISINTable("tblSupplier", "SupplierName", "SupplierId", reader.GetValue(2).ToString())),
                        ProductPrice = Convert.ToDouble(reader.GetValue(3)),
                        ProductQuantity = (int)reader.GetValue(4),
                    });
                }
                SQLConnection.close_Connection();
                if (ProductList.Count == 0)
                {
                    MessageBox.Show("Data not found", " Search", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Please select an option for search", "Product ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        public DateTime DT { get; set; } = DateTime.Now;

        public ICommand cmdPurchesAdd { get { return new RelayCommand(PurchesAdd); } }

        void PurchesAdd(object param)
        {
            try
            {
                {
                    var Product = (MDProduct)param;
                    int Quantity = int.Parse(SQLConnection.GetValue("tblStock", "ProductQuantity", "ProductId", Product.ProductId.ToString()));
                    //SQLConnection.SpaficDataISINTable("tblStock", "ProductName", "ProductId")
                    // if (SalesList.Any(salse => salse.Quantity < Quantity) || SalesList.Count == 0)
                    if (PurchesList.Any(Qty => Qty.PurchesQuantity < Quantity) || PurchesList.Count == 0)
                    {
                        if (!PurchesList.Any(purchase => purchase.Product == Product))
                        {
                            MDMPurches pur = new MDMPurches()
                            {
                                ProductId = Product.ProductId,
                                Product = Product,
                                PurchesQuantity = 1,
                                Total = Product.ProductPrice * 1,
                                Date = DateTime.Now,

                            };

                            PurchesList.Add(pur);
                            //pur.PurchesId = PurchesList.Count == null ? 1 : PurchesList.Count;
                        }
                        else
                        {
                            foreach (var item in PurchesList)
                            {
                                if (item.Product == Product)
                                {
                                    item.PurchesQuantity++;
                                    item.Total = Product.ProductPrice * item.PurchesQuantity;
                                }
                            };
                        }
                    }
                    else
                    {
                        MessageBox.Show("Product Qty isn't stock", " ", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    Finaltotal = PurchesList.Sum(p => p.Total);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Product isn't stock ");
            }
        }



        public ICommand cmdPurReset { get { return new RelayCommand(Reset); } }
        void Reset(object param)
        {
            ProductView();
        }

        //Purches List remove..
        public ICommand cmdPurchesRemove { get { return new RelayCommand(PurchesRemove); } }

        void PurchesRemove(object param)
        {
            var Product = (MDMPurches)param;
            PurchesList.Remove(Product);
            Finaltotal = PurchesList.Sum(p => p.Total);
            Payment = new();
        }


        public ICommand cmdDecrement { get { return new RelayCommand(Decrement); } }

        void Decrement(object param)
        {
            var purches = (MDMPurches)param;
            if (purches != null)
            {
                if (purches.PurchesQuantity > 1)
                {
                    purches.PurchesQuantity--;
                    purches.Total = purches.Product.ProductPrice * purches.PurchesQuantity;
                    Finaltotal = PurchesList.Sum(p => p.Total);
                }
                else
                {
                    if (MessageBox.Show("Do you want to cancel this Item", "Cancel", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        PurchesList.Remove(purches);
                        Finaltotal = PurchesList.Sum(p => p.Total);
                    }
                }
            }

        }

        public ICommand cmdIncrement { get { return new RelayCommand(Increment); } }

        void Increment(object param)
        {
            var purches = (MDMPurches)param;
            if (purches != null)
            {
                purches.PurchesQuantity++;
                purches.Total = purches.Product.ProductPrice * purches.PurchesQuantity;
                Finaltotal = PurchesList.Sum(p => p.Total);

            }
        }

        private MDStock _stock;

        public MDStock StockDatas
        {
            get { return _stock; }
            set { _stock = value; OnPropertyChanged(); }
        }


        public ICommand cmdBalance { get { return new RelayCommand(balance); } }

        void balance(object param)
        {
            if (paymentValidation())
            {
                //Balance = new();
                foreach (var Item in PurchesList)
                {
                    Balance = Payment - Finaltotal;

                    SQLConnection.SqlConnection();
                    string query = $"insert into tblMPurches values('" + Purches.PurchesId + "','" + Item.Product.ProductId + "','" + Item.Product.ProductName + "','" + Item.Product.ProductPrice + "','" + Item.PurchesQuantity + "','" + Item.Total + "','" + Item.Date.ToString("yyyy-MM-dd HH:mm:ss") + "'  )";
                    SqlCommand Command = new SqlCommand(query, SQLConnection.getConnection());
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.InsertCommand = new SqlCommand(query, SQLConnection.getConnection());
                    adapter.InsertCommand.ExecuteNonQuery();
                    adapter.Dispose();
                    Command.Dispose();
                    SQLConnection.close_Connection();

                    SQLConnection.SqlConnection();
                    string query1 = $"insert into tblBill values('" + Purches.BillId + "','" + Item.Product.ProductId + "','" + Item.Product.ProductName + "','" + Item.Product.ProductPrice + "','" + Item.PurchesQuantity + "','" + Item.Total + "','" + Finaltotal + "','" + Payment + "','" + Balance + "','" + Item.Date.ToString("yyyy-MM-dd HH:mm:ss") + "'  )";
                    SqlCommand Command1 = new SqlCommand(query1, SQLConnection.getConnection());
                    SqlDataAdapter adapter1 = new SqlDataAdapter();
                    adapter1.InsertCommand = new SqlCommand(query1, SQLConnection.getConnection());
                    adapter1.InsertCommand.ExecuteNonQuery();
                    adapter1.Dispose();
                    Command1.Dispose();
                    SQLConnection.close_Connection();


                    // int ProductQuantity = int.Parse(SQLConnection.GetValue("tblStock", "ProductQuantity", "ProductId", Item.Product.ProductId.ToString()));
                    int ProductQuantity = int.Parse(SQLConnection.GetValue("tblStock", "ProductQuantity", "ProductId", Item.Product.ProductId.ToString())) - Item.PurchesQuantity;

                    SQLConnection.SqlConnection();
                    string Query = $"Update  tblStock set ProductQuantity ='" + ProductQuantity + "'  where ProductId = '" + Item.Product.ProductId + "'";
                    SqlCommand command = new SqlCommand(Query, SQLConnection.getConnection());
                    SqlDataAdapter Adapter = new SqlDataAdapter();
                    Adapter.UpdateCommand = new SqlCommand(Query, SQLConnection.getConnection());
                    Adapter.UpdateCommand.ExecuteNonQuery();
                    Adapter.Dispose();
                    command.Dispose();
                    SQLConnection.close_Connection();

                }
                //MessageBox.Show("Purchesed successfully....\nDo you want bill..?", " ", MessageBoxButton.OK, MessageBoxImage.Information);
                if (MessageBox.Show("Purchesed successfully\nDo you want bill ? ", " ", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    //  PurchesList = new();
                    VWBill bill = new VWBill();
                    bill.DataContext = new VMBill(PurchesList, Purches, Finaltotal, Payment, Balance);
                    bill.ShowDialog();
                }
                PurchesList = new();
                Payment = new();
                Balance = new();
                Finaltotal = new();
                PurchesList = new ObservableCollection<MDMPurches>();

            }
            // PurchesList = new ObservableCollection<MDMPurches>();
            //  Balance = new();
            //Finaltotal = new();
            //PurchesList = new ObservableCollection<MDMPurches>();
        }


        public ICommand cmdVoid { get { return new RelayCommand(VoidPurches); } }

        void VoidPurches(object param)
        {
            foreach (var Item in PurchesList)
            {
                SQLConnection.SqlConnection();
                string query = $"insert into tblCPurches values('" + CPurches.CPurchesId + "','" + Item.Product.ProductId + "','" + Item.Product.ProductName + "','" + Item.Product.ProductPrice + "','" + Item.PurchesQuantity + "','" + Item.Total + "','" + Item.Date.ToString("yyyy-MM-dd HH:mm:ss") + "'  )";
                SqlCommand Command = new SqlCommand(query, SQLConnection.getConnection());
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.InsertCommand = new SqlCommand(query, SQLConnection.getConnection());
                adapter.InsertCommand.ExecuteNonQuery();
                adapter.Dispose();
                Command.Dispose();
            }
            Finaltotal = new();
            PurchesList = new ObservableCollection<MDMPurches>();
            Payment = new();
            Balance = new();
        }

        private double _payment;

        public double Payment
        {
            get { return _payment; }
            set { _payment = value; OnPropertyChanged(); }
        }

        private double _finalTotal;

        public double Finaltotal
        {
            get { return _finalTotal; }
            set { _finalTotal = value; OnPropertyChanged(); }
        }

        private double _balance;
        public double Balance
        {
            get { return _balance; }
            set { _balance = value; OnPropertyChanged(); }
        }


        private ObservableCollection<MDStock> _stocklist;
        public ObservableCollection<MDStock> StockList
        {
            get { return _stocklist; }
            set { _stocklist = value; OnPropertyChanged(); }
        }


        private ObservableCollection<MDMPurches> _purcheslist;
        public ObservableCollection<MDMPurches> PurchesList
        {
            get { return _purcheslist; }
            set { _purcheslist = value; OnPropertyChanged(); }
        }


        private ObservableCollection<MDProduct> _productlist;
        public ObservableCollection<MDProduct> ProductList
        {
            get { return _productlist; }
            set { _productlist = value; OnPropertyChanged(); }
        }

        private MDMPurches _purches = new MDMPurches();
        public MDMPurches Purches
        {
            get { return _purches; }
            set { _purches = value; OnPropertyChanged(); }
        }

        private MDCPurches _cPurches = new MDCPurches();
        private object? removeSubjectCommand;

        public MDCPurches CPurches
        {
            get { return _cPurches; }
            set { _cPurches = value; OnPropertyChanged(); }
        }


        // Validations....
        public bool paymentValidation()
        {
            bool Result = false;
            bool payment = PayValidation(Payment, Finaltotal);
            if (payment)
            {
                Result = true;
            }
            return Result;
        }

        public static bool PayValidation(double payment, double total)
        {
            if (total == 0)
            {
                MessageBox.Show("No sales for this payment", "Payment ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (payment == 0 || payment < 0)
            {
                MessageBox.Show("Invalid Payment...\nPayment can't be zero OR less than zero", "Payment ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (payment < total)
            {
                MessageBox.Show("Payment will be more than total price", "Payment", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {

                return true;
            }
            return false;
        }
    }
}


