using Sales_Management_System.Model;
using Sales_Management_System.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem_05._11._2022.Model
{
    internal class MBill:VMBase
    {
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

        private MDMPurches purches;

        public MDMPurches Purches
        {
            get { return purches; }
            set { purches = value; OnPropertyChanged(); }
        }

        //private int _productId;

        //public int ProductId
        //{
        //    get { return _productId; }
        //    set { _productId = value; }
        //}

        //private int _purches_Id;

        //public int PurchesId
        //{
        //    get { return _purches_Id; }
        //    set { _purches_Id = value; OnPropertyChanged(); }
        //}

        //private double _finalTotal;

        //public double FinalTotal
        //{
        //    get { return _finalTotal; }
        //    set { _finalTotal = value; OnPropertyChanged(); }
        //}

        //private int _purchesQuantity;

        //public int PurchesQuantity
        //{
        //    get { return _purchesQuantity; }
        //    set { _purchesQuantity = value; OnPropertyChanged(); }
        //}


        //private double _total;

        //public double Total
        //{
        //    get { return _total; }
        //    set { _total = value; OnPropertyChanged(); }
        //}

        //private DateTime dateTime;


        //public DateTime DateTime
        //{
        //    get { return dateTime; }
        //    set { dateTime = value; OnPropertyChanged(); }
        //}

    }
}
