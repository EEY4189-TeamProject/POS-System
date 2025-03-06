using Sales_Management_System.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sales_Management_System.View
{
    public partial class VWLogin : Window
    {
            public VWLogin()
            {
                InitializeComponent();
                this.DataContext = new VMLogin();

                VMLogin.logout = new Action(this.Close);
            }

            private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
            {
                if (sender is PasswordBox passwordBox)
                {
                    if (this.DataContext is VMLogin viewModel)
                    {
                        viewModel.Password = passwordBox.Password;
                    }
                }
            }
        }
    }
