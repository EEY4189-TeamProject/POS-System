using Sales_Management_System.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace POS_System.ViewModel
{
    public class VMValidation : VMBase
    {
        public static bool ProductValidation(string PName, double price, int Qty)
        {
            if (string.IsNullOrEmpty(PName) || string.IsNullOrWhiteSpace(PName))
            {
                MessageBox.Show("Product cant be null", "Product", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!Regex.IsMatch(PName, @"^[a-zA-Z\s]*$"))
            {
                MessageBox.Show("Invalid product name", "Product", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (SQLConnection.IsProduct("ProductName", "tblProduct", "ProductName", PName))
            {
                MessageBox.Show("This product in already in Product list ", "Product", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (price < 0)
            {
                MessageBox.Show("Product price must be Positive value", "Product", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (price == 0)
            {
                MessageBox.Show("Product price can't be  zero " + "0" + " or Null value", "Product", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (Qty < 0)
            {
                MessageBox.Show("Quantity must be Positive value", "Product", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (Qty == 0)
            {
                MessageBox.Show("Quantity can't be  zero " + "0" + "or NULL value", "Product ", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }


            return true;
        }
        public static bool Combovalidation(string name)
        {
            if (name == null)
            {
                return false;
            }
            return true;
        }


        public static bool StockValidation(int ProductQty)
        {
            if (ProductQty < 0)
            {
                MessageBox.Show("Product quantity must be Positive value", "Stock", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (ProductQty == 0)
            {
                MessageBox.Show("Product quantity can't be  zero " + "0" + " or NULL value", "Stock", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        public static bool ProductUpdateValidation(string PName, double price, int Qty)
        {
            if (string.IsNullOrEmpty(PName) || string.IsNullOrWhiteSpace(PName))
            {
                MessageBox.Show("Product cant be null", "Product", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!Regex.IsMatch(PName, @"^[a-zA-Z\s]*$"))
            {
                MessageBox.Show("Invalid product name", "Product", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (price < 0)
            {
                MessageBox.Show("Product price must be Positive value", "Product", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (price == 0)
            {
                MessageBox.Show("Product price can't be  zero " + "0" + " or Null value", "Product", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        public static bool SupplierValidation(string name, string number, string address)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Supplier cant be null", "Supplier", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!Regex.IsMatch(name, @"^[a-zA-Z\s]*$"))
            {
                MessageBox.Show("Invalid supplier...\nPlease enter correct name", "Supplier", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (string.IsNullOrEmpty(number) || (!Regex.IsMatch(number, @"^(0?|[0])?[0-9]{9}$")))
            {
                MessageBox.Show("Invalid Phone number\nplease enter valid Number", "Supplier", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (SQLConnection.IsProduct("PhoneNumber", "tblSupplier", "PhoneNumber", number))
            {
                MessageBox.Show("This Number is already in use ", "Supplier", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (string.IsNullOrEmpty(address) || string.IsNullOrWhiteSpace(address) || (!Regex.IsMatch(name, @"^[a-zA-Z\s]*$")))
            {
                MessageBox.Show("Invalid address \nEnter valid Address", "Supplier", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }



        public static bool SupplierUpdateValidation(string name, string number, string address)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Supplier cant be null", "Supplier", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!Regex.IsMatch(name, @"^[a-zA-Z\s]*$"))
            {
                MessageBox.Show("Invalid supplier\nPlease enter correct name", "Supplier", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (string.IsNullOrEmpty(number) || (!Regex.IsMatch(number, @"^(0?|[0])?[0-9]{9}$")))
            {
                MessageBox.Show("Invalid Phone number\nplease enter valid Number", "Supplier", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (SQLConnection.IsProduct("PhoneNumber", "tblSupplier", "PhoneNumber", number))
            {
                MessageBox.Show("This Number is already in use ", "Supplier", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (string.IsNullOrEmpty(address) || string.IsNullOrWhiteSpace(address) || (!Regex.IsMatch(name, @"^[a-zA-Z\s]*$")))
            {
                MessageBox.Show("Invalid address \nEnter valid Address", "Supplier", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }


        public static bool LoginValidation(string name, string password)
        {
            if (!(SQLConnection.IsProduct("UserName", "tblUser", "UserName", name)))
            {
                MessageBox.Show("Invalid Username ", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!(SQLConnection.IsProduct("Password", "tblUser", "Password", name)))
            {
                MessageBox.Show("Invalid Username ", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }


        public static bool UserAddValidation(string name, string password)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Invalid Username ", "User", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Invalid Password ", "User", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (SQLConnection.IsProduct("UserName", "tblUser", "UserName", name))
            {
                MessageBox.Show("This Username is already in use ", "User", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        public static bool UserUpdateValidation(string name, string password)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Invalid Username ", "User", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Invalid Password ", "User", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

    }
}

