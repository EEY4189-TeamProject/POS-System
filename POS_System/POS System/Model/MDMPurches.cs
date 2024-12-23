using Sales_Management_System.ViewModel;
using SalesSystem_05._11._2022.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Management_System.Model
{
    public class MDMPurches:VMBase
    {
        

        private int _productId;

        public int ProductId
        {
            get { return _productId; }
            set { _productId = value; OnPropertyChanged(); }
        }

        private int _billId;

        public int BillId
        {
            get { return _billId; }
            set { _billId = value; OnPropertyChanged(); }
        }



        private MDProduct product;
        public MDProduct Product
        {
            get { return product; }
            set { product = value; OnPropertyChanged(); }
        }


        private int _purches_Id;

        public int PurchesId
        {
            get { return _purches_Id; }
            set { _purches_Id = value; OnPropertyChanged(); }
        }


        //private int _cPurchesId;

        //public int CPurchesId
        //{
        //    get { return _cPurchesId; }
        //    set { _cPurchesId = value; OnPropertyChanged(); }
        //}



        private int _purchesQuantity;

        public int PurchesQuantity
        {
            get { return _purchesQuantity; }
            set { _purchesQuantity = value; OnPropertyChanged();}
        }


        private MDSupplier supplier;

        public MDSupplier Supplier
        {
            get { return supplier; }
            set { supplier = value; OnPropertyChanged(); }
        }


        private double _total;

        public double Total
        {
            get { return _total; }
            set { _total = value; OnPropertyChanged();}
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



        //public MDProduct ProductId;
        //public MDProduct ProductName;
        //public MDProduct ProductPrice;
        //public MDProduct ProductQuantity;

        //private int _productID;

        //public int ProductID
        //{
        //    get { return _productID; }
        //    set { _productID = value; OnPropertyChanged(); }
        //}

        //private string _productName;

        //public string ProductName
        //{
        //    get { return _productName; }
        //    set { _productName = value; OnPropertyChanged(); }
        //}

        //private double _productPrice;

        //public double ProductPrice
        //{
        //    get { return _productPrice; }
        //    set { _productPrice = value; OnPropertyChanged(); }
        //}


    }
}
