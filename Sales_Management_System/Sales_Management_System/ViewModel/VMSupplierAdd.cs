using Sales_Management_System.ViewModel;
using Sales_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using POS_System.ViewModel;

namespace Sales_Management_System.ViewModel
{
    public class VMSupplierAdd :VMBase
    {
        public ICommand cmdSupplierExit { get { return new RelayCommand(SupplierExit); } }

        public static Action supplierExit;
        void SupplierExit(object param)
        {
            if (MessageBox.Show("Do you want to Cancel ?", "Cancel", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)

            {
                supplierExit.Invoke();

            }
        }

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


        public ICommand cmdSupplierAdd { get { return new RelayCommand(SupplierAdd); } }
        void SupplierAdd(object param)
        {
            try
            {
                switch (btnAdd)
                {
                    case "Add":
                      if(Validation())
                        {

                            SQLConnection.SqlConnection();
                            string query1 = $"insert into tblSupplier values('" + Supplier.SupplierId + "' ,'" + Supplier.SupplierName + "','" + Supplier.PhoneNumber + "' ,'" + Supplier.SupplierAddress + "' )";
                            SqlCommand Command = new SqlCommand(query1, SQLConnection.getConnection());
                            SqlDataAdapter adapter = new SqlDataAdapter();
                            adapter.InsertCommand = new SqlCommand(query1, SQLConnection.getConnection());
                            adapter.InsertCommand.ExecuteNonQuery();
                            adapter.Dispose();
                            Command.Dispose();

                            SQLConnection.close_Connection();
                            VMSupplier.SupplierRefresh();
                            supplierExit.Invoke();
                            MessageBox.Show("Supplier sucessfully added", "Supplier", MessageBoxButton.OK, MessageBoxImage.Information);
                            supplierExit.Invoke();
                        }

                        break;

                    case "Update":
                        if(UpdateValidation())
                        {
                            SQLConnection.SqlConnection();
                            string Query1 = $"Update  tblSupplier set SupplierName ='" + Supplier.SupplierName + "' ,PhoneNumber='" + Supplier.PhoneNumber + "',SupplierAddress='" + Supplier.SupplierAddress + "' where SupplierId = '" + Supplier.SupplierId + "'";
                            SqlCommand command = new SqlCommand(Query1, SQLConnection.getConnection());
                            SqlDataAdapter Adapter = new SqlDataAdapter();
                            Adapter.UpdateCommand = new SqlCommand(Query1, SQLConnection.getConnection());
                            Adapter.UpdateCommand.ExecuteNonQuery();
                            Adapter.Dispose();
                            command.Dispose();
                            SQLConnection.close_Connection();
                            VMSupplier.SupplierRefresh();
                            supplierExit.Invoke();
                            MessageBox.Show("Supplier sucessfully Updated", "Supplier", MessageBoxButton.OK, MessageBoxImage.Information);
                            supplierExit.Invoke();

                        }
                        break;
                }
               
            }
            catch(Exception ex)
            {
                MessageBox.Show("Can not add supplier", "Supplier", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private MDSupplier supplier;

        public MDSupplier Supplier
        {
            get { return supplier; }
            set { supplier = value; OnPropertyChanged(); }
        }

        public void IsSupplier()
        {
            Supplier = new();
            Supplier.SupplierId = SQLConnection.ISData("tblSupplier") ? int.Parse(SQLConnection.CheckTableData("tblSupplier", "SupplierId", "SupplierId")) + 1 : 1;
        }

        public VMSupplierAdd(MDSupplier supplier = null)
        {
            if (supplier == null)
            {
                IsSupplier();
                btnAdd = "Add";
                btnCancel = "Cancel";
            }
            else
            {
                Supplier = new();
                Supplier.SupplierId = supplier.SupplierId;
                Supplier.SupplierName = supplier.SupplierName;
                Supplier.PhoneNumber = supplier.PhoneNumber;
                Supplier.SupplierAddress = supplier.SupplierAddress;
                btnAdd = "Update";
                btnCancel = "Cancel";
            }
        }

        public bool Validation()
        {
            bool Result = false;

            bool product = VMValidation.SupplierValidation(Supplier.SupplierName, Supplier.PhoneNumber, Supplier.SupplierAddress);

            if (product)
            {
                Result = true;
            }
            return Result;

        }
        public bool UpdateValidation()
        {
            bool Result = false;

            bool product = VMValidation.SupplierUpdateValidation(Supplier.SupplierName, Supplier.PhoneNumber, Supplier.SupplierAddress);

            if (product)
            {
                Result = true;
            }
            return Result;

        }
        
    }
}
