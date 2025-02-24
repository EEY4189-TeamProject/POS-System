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
    /// <summary>
    /// Interaction logic for VWProductAdd.xaml
    /// </summary>
    public partial class VWProductAdd : Window
    {
        public VWProductAdd()
        {
            InitializeComponent();
            this.DataContext = new VMProductAdd();

            VMProductAdd.productExit = new Action(this.Close);

        }
    }
}
