using Sales_Management_System.ViewModel;
using SalesSystem_05._11._2022.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Management_System.Model
{
    public class MDProduct : VMBase
    {
        private int _productId;

        public int ProductId
        {
            get { return _productId; }
            set 
            {
                _productId = value;
                OnPropertyChanged(); 
            }
        }

        //private MDSupplier _supplier;

        //public MDSupplier Supplier
        //{
        //    get { return _supplier; }
        //    set { _supplier = value; OnPropertyChanged(); }
        //}

        private MDStock _stock;

        public MDStock Stock
        {
            get { return _stock; }
            set { _stock = value; OnPropertyChanged(); }
        }


        private int supplierId;

        public int SupplierId
        {
            get { return supplierId; }
            set { supplierId = value; OnPropertyChanged(); }
        }

        private string suppliername;

        public string SupplierName
        {
            get { return suppliername; }
            set { suppliername = value; OnPropertyChanged(); }
        }

        private string _productName;

        public string ProductName
        {
            get { return _productName; }
            set
            {
                _productName = value;
                OnPropertyChanged();
            }
        }
    

        private double _productPrice;

        public double ProductPrice
        {
            get { return _productPrice; }
            set
            {
                _productPrice = value;
                OnPropertyChanged();
            }
        }

        private int _producyQuantity;

        public int ProductQuantity
        {
            get { return _producyQuantity; }
            set
            {
                _producyQuantity = value;
                OnPropertyChanged();
            }
        }


        //private int _stockId;

        //public int StockId
        //{
        //    get { return _stockId; }
        //    set { _stockId = value; OnPropertyChanged(); }
        //}

       


    }
}
