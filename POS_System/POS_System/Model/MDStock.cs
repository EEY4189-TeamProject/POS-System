using Sales_Management_System.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Management_System.Model
{
    public class MDStock:VMBase
    {
        //public MDProduct ProductId;
        //public MDProduct ProductName;
        //public MDProduct ProductPrice;
        //public MDProduct ProductQuantity;


        private int _stockId;

        public int StockId
        {
            get { return _stockId; }
            set { _stockId = value; OnPropertyChanged(); }
        }

        //private MDProduct product;

        //public MDProduct Product
        //{
        //    get { return product; }
        //    set { product = value; OnPropertyChanged(); }
        //}


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


    }
}
