using Sales_Management_System.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Management_System.Model
{
    public class MDCPurches:VMBase
    {
        private int _productId;

        public int ProductId
        {
            get { return _productId; }
            set { _productId = value; OnPropertyChanged(); }
        }




        private MDProduct product;
        public MDProduct Product
        {
            get { return product; }
            set { product = value; OnPropertyChanged(); }
        }


        private int _cPurchesId;

        public int CPurchesId
        {
            get { return _cPurchesId; }
            set { _cPurchesId = value; OnPropertyChanged(); }
        }



        private int _purchesQuantity;

        public int PurchesQuantity
        {
            get { return _purchesQuantity; }
            set { _purchesQuantity = value; OnPropertyChanged(); }
        }


        private double _total;

        public double Total
        {
            get { return _total; }
            set { _total = value; OnPropertyChanged(); }
        }

        private DateTime date;


        public DateTime Date
        {
            get { return date; }
            set { date = value; OnPropertyChanged(); }
        }


        private string _name;

        public string ProductName
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }

        private double _price;

        public double ProductPrice
        {
            get { return _price; }
            set { _price = value; OnPropertyChanged(); }
        }

    }
}
