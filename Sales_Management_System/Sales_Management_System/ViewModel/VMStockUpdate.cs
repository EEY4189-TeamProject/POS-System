using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Input;
using System.Windows;
using Sales_Management_System.Model;
using POS_System.ViewModel;

namespace Sales_Management_System.ViewModel
{
    public class VMStockUpdate : VMBase
    {
        public ICommand cmdStockUpdate { get { return new RelayCommand(StockUpdate); } }

        void StockUpdate(object param)
        {


            if (Validation())
            {

                SQLConnection.SqlConnection();
                string Query1 = $"Update  tblStock set ProductQuantity ='" + Stock.ProductQuantity + "' where ProductId = '" + Stock.ProductId + "'";
                SqlCommand command1 = new SqlCommand(Query1, SQLConnection.getConnection());
                SqlDataAdapter Adapter1 = new SqlDataAdapter();
                Adapter1.UpdateCommand = new SqlCommand(Query1, SQLConnection.getConnection());
                Adapter1.UpdateCommand.ExecuteNonQuery();
                Adapter1.Dispose();
                command1.Dispose();
                SQLConnection.close_Connection();

                VMStock.StockRefresh();
                ExitUpdateStock.Invoke();
                MessageBox.Show("Stock sucessfully Updated", "Stock", MessageBoxButton.OK, MessageBoxImage.Information);
                ExitUpdateStock.Invoke();
            }



        }


        public bool Validation()
        {
            bool Result = false;
            bool stock = VMValidation.StockValidation(Stock.ProductQuantity);

            if (stock)
            {
                Result = true;
            }
            return Result;
        }



        private MDStock _stock;

        public MDStock Stock
        {
            get { return _stock; }
            set { _stock = value; OnPropertyChanged(); }
        }


        public VMStockUpdate(MDStock stock)
        {
            Stock = new();
            Stock.ProductId = stock.ProductId;
            Stock.ProductName = stock.ProductName;
            Stock.ProductQuantity = stock.ProductQuantity;
        }


        // stock Update cancel....

        public ICommand cmdSCancel { get { return new RelayCommand(UpdateStockCancel); } }

        public static Action ExitUpdateStock;

        void UpdateStockCancel(object param)
        {
            if (MessageBox.Show("Do you want to Cancel ?", "Cancel", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)

            {
                ExitUpdateStock.Invoke();
            }

        }

        public VMStockUpdate()
        {

        }

    }
}
