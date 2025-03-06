using Sales_Management_System.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Management_System.Model
{
    public class MDUser:VMBase
    {
        private int userId;

        public int UserId
        {
            get { return userId; }
            set { userId = value;OnPropertyChanged(); }
        }

        

        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; OnPropertyChanged(); 
            
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged(); }
        }

        private string isActive;

        public string IsActive
        {
            get { return isActive; }
            set { isActive = value; OnPropertyChanged(); }
        }

    }
}
