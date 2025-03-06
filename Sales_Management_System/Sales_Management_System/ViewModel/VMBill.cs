using Sales_Management_System.Model;
using Sales_Management_System.View;
using Sales_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Sales_Management_System.ViewModel
{
    public class VMBill:VMBase
    {
        private MDMPurches purches;

        public MDMPurches Purches
        {
            get { return purches; }
            set { purches = value; OnPropertyChanged(); }
        }

        private ObservableCollection<MDMPurches> purchesList;

        public ObservableCollection<MDMPurches> PurchesList
        {
            get { return purchesList; }
            set { purchesList = value;OnPropertyChanged(); }
        }

        private double finaltotal;

        public double Finaltotal
        {
            get { return finaltotal; }
            set { finaltotal = value; OnPropertyChanged(); }
        }

        private double payment;

        public double Payment
        {
            get { return payment; }
            set { payment = value; OnPropertyChanged(); }
        }

        private double balance;

        public double Balance
        {
            get { return balance; }
            set { balance = value; OnPropertyChanged(); }
        }

        public DateTime DT { get; set; } = DateTime.Now;

        public VMBill(ObservableCollection<MDMPurches> PurchesList, MDMPurches Purches,double Finaltotal,double Payment,double Balance)
        {
            this.Finaltotal = Finaltotal;
            this.Payment = Payment;
            this.Balance = Balance;

            this.purchesList = PurchesList;
            purches = new MDMPurches
            {
                PurchesId= Purches.ProductId,
                ProductId= Purches.ProductId,
                ProductName= Purches.ProductName,
                ProductPrice= Purches.ProductPrice,
                Total= Purches.Total
            };

        }


        public ICommand cmdClose { get { return new RelayCommand(Close); } }

        public static Action close;
        void Close(object param)
        {
            close.Invoke();
        }

    }
}
