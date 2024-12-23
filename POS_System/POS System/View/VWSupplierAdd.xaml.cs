using SalesSystem_05._11._2022.ViewModel;
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

namespace SalesSystem_05._11._2022.View
{
    /// <summary>
    /// Interaction logic for VWSupplierAdd.xaml
    /// </summary>
    public partial class VWSupplierAdd : Window
    {
        public VWSupplierAdd()
        {
            InitializeComponent();
            this.DataContext = new VMSupplierAdd();

            VMSupplierAdd.supplierExit = new Action(this.Close);
        }
    }
}
