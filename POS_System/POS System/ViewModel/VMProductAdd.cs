using Sales_Management_System.Model;
using SalesSystem_05._11._2022.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Sales_Management_System.ViewModel
{
    public class VMProductAdd : VMBase
    {
        public ICommand cmdProductExit { get { return new RelayCommand(ProductExit); } }

        public static Action productExit;
        void ProductExit(object param)
        {
            if (MessageBox.Show("Do you want to Cancel ?", "Cancel", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)

            {
                productExit.Invoke();

            }
        }



        // Product add or save....
        public ICommand cmdProductAdd { get { return new RelayCommand(productAdd); } }
        void productAdd(object param)
        {
            try
            {

                switch (btnAdd)
                {
                    case "Add":
                        if (Validation())

                        {
                            if (!VMValidation.Combovalidation(SelectedSupplier.SupplierName))
                            {
                                MessageBox.Show("Please select supplier", " Product", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }

                            SelectedSupplier.SupplierId = int.Parse(SQLConnection.GetValue("tblSupplier", "SupplierId", "SupplierName", SelectedSupplier.SupplierName));

                            SQLConnection.SqlConnection();
                            string query = $"insert into tblProduct values('" + Product.ProductId + "' ,'" + Product.ProductName + "','" + SelectedSupplier.SupplierId + "','" + Product.ProductPrice + "' ,'" + Product.ProductQuantity + "' )";
                            SqlCommand Command = new SqlCommand(query, SQLConnection.getConnection());
                            SqlDataAdapter adapter = new SqlDataAdapter();
                            adapter.InsertCommand = new SqlCommand(query, SQLConnection.getConnection());
                            adapter.InsertCommand.ExecuteNonQuery();
                            adapter.Dispose();
                            Command.Dispose();

                            SQLConnection.close_Connection();


                            SQLConnection.SqlConnection();

                            string query1 = $"insert into tblStock values('" + Product.ProductId + "' ,'" + Product.ProductName + "','" + Product.ProductPrice + "' ,'" + Product.ProductQuantity + "' )";
                            SqlCommand Command1 = new SqlCommand(query1, SQLConnection.getConnection());
                            SqlDataAdapter adapter1 = new SqlDataAdapter();
                            adapter1.InsertCommand = new SqlCommand(query1, SQLConnection.getConnection());
                            adapter1.InsertCommand.ExecuteNonQuery();
                            adapter1.Dispose();
                            Command1.Dispose();
                            SQLConnection.close_Connection();
                            VMProduct.ProductRefresh();
                            productExit.Invoke();
                            MessageBox.Show("Product sucessfully added", "Product", MessageBoxButton.OK, MessageBoxImage.Information);
                            productExit.Invoke();

                        }

                        break;

                    case "Update":
                        if (UpdateValidation())
                        {
                            if (!VMValidation.Combovalidation(SelectedSupplier.SupplierName))
                            {
                                MessageBox.Show("Please select supplier", " Product", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                            SelectedSupplier.SupplierId = int.Parse(SQLConnection.GetValue("tblSupplier", "SupplierId", "SupplierName", SelectedSupplier.SupplierName));

                            SQLConnection.SqlConnection();
                            string Query = $"Update  tblProduct set ProductName ='" + Product.ProductName + "' ,ProductPrice ='" + Product.ProductPrice + "',SupplierId ='" + selectedSupplier.SupplierId + "',ProductQuantity='" + Product.ProductQuantity + "' where ProductId = '" + Product.ProductId + "'";
                            SqlCommand command = new SqlCommand(Query, SQLConnection.getConnection());
                            SqlDataAdapter Adapter = new SqlDataAdapter();
                            Adapter.UpdateCommand = new SqlCommand(Query, SQLConnection.getConnection());
                            Adapter.UpdateCommand.ExecuteNonQuery();
                            Adapter.Dispose();
                            command.Dispose();
                            SQLConnection.close_Connection();



                            SQLConnection.SqlConnection();
                            string Query1 = $"Update  tblStock set ProductName ='" + Product.ProductName + "' ,ProductPrice ='" + Product.ProductPrice + "',ProductQuantity='" + Product.ProductQuantity + "' where ProductId = '" + Product.ProductId + "'";
                            SqlCommand command1 = new SqlCommand(Query1, SQLConnection.getConnection());
                            SqlDataAdapter Adapter1 = new SqlDataAdapter();
                            Adapter1.UpdateCommand = new SqlCommand(Query1, SQLConnection.getConnection());
                            Adapter1.UpdateCommand.ExecuteNonQuery();
                            Adapter1.Dispose();
                            command1.Dispose();
                            SQLConnection.close_Connection();

                            VMProduct.ProductRefresh();
                            productExit.Invoke();
                            MessageBox.Show("Product sucessfully Updated", "Product", MessageBoxButton.OK, MessageBoxImage.Information);
                            productExit.Invoke();

                        }
                        break;
                }

            }
            catch
            {
                MessageBox.Show("Invalid Inputs", "Product", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        //public bool Validation()

        public bool Validation()
        {
            bool Result = false;

            bool product = VMValidation.ProductValidation(Product.ProductName, Product.ProductPrice, Product.ProductQuantity);
            //string name = SelectedSupplier.SupplierName;


            if (product)
            {
                Result = true;
            }
            return Result;

        }

        static bool validate(string name)
        {
            if (name == null)
            {
                return false;
            }
            return true;
        }


        public bool UpdateValidation()
        {
            bool Result = false;

            bool product = VMValidation.ProductUpdateValidation(Product.ProductName, Product.ProductPrice, Product.ProductQuantity);

            if (product)
            {
                Result = true;
            }
            return Result;

        }


        private MDProduct _product;

        public MDProduct Product
        {
            get { return _product; }
            set { _product = value; OnPropertyChanged(); }
        }

        private MDStock _stock;

        public MDStock Stock
        {
            get { return _stock; }
            set { _stock = value; OnPropertyChanged(); }
        }



        // Product add.... and Update.....

        private string _btnAdd;

        public string btnAdd
        {
            get { return _btnAdd; }
            set { _btnAdd = value; OnPropertyChanged(); }
        }

        private string _btnCancel;

        public string btnCancel
        {
            get { return _btnCancel; }
            set { _btnCancel = value; OnPropertyChanged(); }
        }


        public void IsProduct()
        {
            Product = new();
            Product.ProductId = SQLConnection.ISData("tblProduct") ? int.Parse(SQLConnection.CheckTableData("tblProduct", "ProductId", "ProductId")) + 1 : 1;
        }

        public VMProductAdd(MDProduct product = null)
        {
            FnGetData();
            if (product == null)
            {
                //QtyEnable = true;
                IsProduct();
                btnAdd = "Add";
                btnCancel = "Cancel";
            }
            else
            {//listla temparary aa save pannini
                QtyEnable = "Hidden";
                Product = new();
                //Product = product;
                Product.ProductId = product.ProductId;
                Product.ProductName = product.ProductName;
                //SelectedSupplier = SupplierCollection.FirstOrDefault(d => d.SupplierId == product.Supplier.SupplierId);
                SelectedSupplier.SupplierName = product.SupplierName;
                Product.ProductPrice = product.ProductPrice;
                Product.ProductQuantity = product.ProductQuantity;
                btnAdd = "Update";
                btnCancel = "Cancel";
            }
        }


        private string _qtyEnable;

        public string QtyEnable
        {
            get { return _qtyEnable; ; }
            set { _qtyEnable = value; OnPropertyChanged(); }
        }





        // SupplierAdd....

        private MDSupplier selectedSupplier = new MDSupplier();

        public MDSupplier SelectedSupplier
        {
            get { return selectedSupplier; }
            set { selectedSupplier = value; OnPropertyChanged(); }
        }

        private ObservableCollection<MDSupplier> supplierCollection;

        public ObservableCollection<MDSupplier> SupplierCollection
        {
            get { return supplierCollection; }
            set { supplierCollection = value; }
        }




        public void FnGetData()
        {
            SupplierCollection = new ObservableCollection<MDSupplier>();
            SQLConnection.DBConnection();
            SQLConnection.SqlConnection();

            var searchQuery = $"select * from tblSupplier";

            var Command = new SqlCommand(searchQuery, SQLConnection.getConnection());
            var reader = Command.ExecuteReader();
            while (reader.Read())
            {
                SupplierCollection.Add(new MDSupplier
                {
                    SupplierId = (int)reader.GetValue(0),
                    SupplierName = (reader.GetValue(1).ToString()),
                    PhoneNumber = (reader.GetValue(2).ToString()),
                    SupplierAddress = (reader.GetValue(3).ToString())
                });
            }
            SQLConnection.close_Connection();
        }


    }
}
