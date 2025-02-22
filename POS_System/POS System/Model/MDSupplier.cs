using Sales_Management_System.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem_05._11._2022.Model
{
    public class MDSupplier:VMBase
    {
        private int _supplierId;

        public int SupplierId
        {
            get { return _supplierId; }
            set { _supplierId = value; OnPropertyChanged(); }
        }


        private string _supplierName;

        public string SupplierName
        {
            get { return _supplierName; }
            set { _supplierName = value; OnPropertyChanged(); }
        }


        private string _phoneNumber;

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; OnPropertyChanged(); }
        }

        private string _sAddress;

        public string SupplierAddress
        {
            get { return _sAddress; }
            set { _sAddress = value; OnPropertyChanged(); }
        }

    }
}
