using Sales_Management_System.ViewModel;
using SalesSystem_05._11._2022.Model;
using SalesSystem_05._11._2022.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SalesSystem_05._11._2022.ViewModel
{
    public class VMUser : VMBase
    {
        public ICommand cmdAddUser { get { return new RelayCommand(AddUser); } }

        void AddUser(object param)
        {
            VWUserAdd user = new VWUserAdd();
            user.DataContext = new VMUserAdd();
            user.ShowDialog();
        }

        public VMUser()
        {
            UserView();
            UserRefresh += On_UserReferesh;
        }


        public void UserView()
        {
            UserCollection = new ObservableCollection<MDUser>();
            SQLConnection.DBConnection();
            SQLConnection.SqlConnection();

            var searchQuery = $"select * from tblUser ";

            var Command = new SqlCommand(searchQuery, SQLConnection.getConnection());
            var reader = Command.ExecuteReader();
            while (reader.Read())
            {
                UserCollection.Add(new MDUser
                {
                    UserId = (int)reader.GetValue(0),
                    UserName = (reader.GetValue(1).ToString()),
                    Password = (reader.GetValue(2).ToString()),
                    IsActive = (reader.GetValue(3).ToString())
                });
            }
            SQLConnection.close_Connection();
        }


        private string _find;

        public string Find
        {
            get { return _find; }
            set { _find = value; OnPropertyChanged(); AutoUserSearch(); }
        }


        private string _field;

        public string Field
        {
            get { return _field; }
            set { _field = value; OnPropertyChanged(); }
        }


        private string _column;

        public string Column
        {
            get { return _column; }
            set { _column = value; OnPropertyChanged(); }
        }


        private string _listView;

        public string ListView
        {
            get { return _listView; }
            set { _listView = value; OnPropertyChanged(); }
        }

        void AutoUserSearch()
        {
            try
            {
                switch (Field)
                {
                    case "User ID":
                        Column = "UserId";
                        break;

                    case "User Name":
                        Column = "UserName";
                        break;

                    case "Status":
                        Column = "IsActive";
                        break;

                }


                UserCollection = new ObservableCollection<MDUser>();
                SQLConnection.SqlConnection();
                string searchQuery = $"select * from tblUser where {Column} Like '%" + Find + "%'";
                SqlCommand Command = new SqlCommand(searchQuery, SQLConnection.getConnection());
                var reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    UserCollection.Add(new MDUser
                    {
                        UserId = (int)reader.GetValue(0),
                        UserName = (reader.GetValue(1).ToString()),
                        Password = (reader.GetValue(2).ToString()),
                        IsActive = (reader.GetValue(3).ToString())
                    });
                }
                SQLConnection.close_Connection();
            }
            catch
            {
                MessageBox.Show("Please select an option for search", "User ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        public ICommand cmdSearch { get { return new RelayCommand(Search); } }

        void Search(object param)
        {
            try
            {
                switch (Field)
                {
                    case "User ID":
                        Column = "UserId";
                        break;

                    case "User Name":
                        Column = "UserName";
                        break;

                    case "Status":
                        Column = "IsActive";
                        break;

                }


                UserCollection = new ObservableCollection<MDUser>();
                SQLConnection.SqlConnection();
                string searchQuery = $"select * from tblUser where {Column} = '" + Find + "'";
                SqlCommand Command = new SqlCommand(searchQuery, SQLConnection.getConnection());
                var reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    UserCollection.Add(new MDUser
                    {
                        UserId = (int)reader.GetValue(0),
                        UserName = (reader.GetValue(1).ToString()),
                        Password = (reader.GetValue(2).ToString()),
                        IsActive = (reader.GetValue(3).ToString())
                    });
                }
                SQLConnection.close_Connection();
                if(UserCollection.Count==0)
                {
                    MessageBox.Show("Data not found", " Search", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Please select an option for search", "User ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        public ICommand cmdActive { get { return new RelayCommand(Active); } }

        void Active(object param)
        {
            UserCollection = new ObservableCollection<MDUser>();
            SQLConnection.DBConnection();
            SQLConnection.SqlConnection();

            var searchQuery = $"select * from tblUser where IsActive='Active' ";

            var Command = new SqlCommand(searchQuery, SQLConnection.getConnection());
            var reader = Command.ExecuteReader();
            while (reader.Read())
            {
                UserCollection.Add(new MDUser
                {
                    UserId = (int)reader.GetValue(0),
                    UserName = (reader.GetValue(1).ToString()),
                    Password = (reader.GetValue(2).ToString()),
                    IsActive = (reader.GetValue(3).ToString())
                });
            }
            SQLConnection.close_Connection();
        }

        public ICommand cmdLeave { get { return new RelayCommand(Leave); } }

        void Leave(object param)
        {
            UserCollection = new ObservableCollection<MDUser>();
            SQLConnection.DBConnection();
            SQLConnection.SqlConnection();

            var searchQuery = $"select * from tblUser where IsActive='DeActive' ";

            var Command = new SqlCommand(searchQuery, SQLConnection.getConnection());
            var reader = Command.ExecuteReader();
            while (reader.Read())
            {
                UserCollection.Add(new MDUser
                {
                    UserId = (int)reader.GetValue(0),
                    UserName = (reader.GetValue(1).ToString()),
                    Password = (reader.GetValue(2).ToString()),
                    IsActive = (reader.GetValue(3).ToString())
                });
            }
            SQLConnection.close_Connection();
        }

        //User reset

        public ICommand cmdUserReset { get { return new RelayCommand(UserRest); } }

        void UserRest(object param)
        {

            UserView();    
        }


        //Delete query...
        public ICommand cmdUserDelete { get { return new RelayCommand(UserDelete); } }

        //public object DialogResult { get; private set; }

        void UserDelete(object param)
        {
            MDUser user = param as MDUser;

            try
            {

                if (MessageBox.Show("Do you want to delete", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {    
                    SQLConnection.SqlConnection();
                    string deleteQuery = $"delete from tblUser where UserId = {user.UserId}";
                    //string deleteQuery = $"delete from tblUser where IsActive = DeActive";

                    SqlCommand Command = new SqlCommand(deleteQuery, SQLConnection.getConnection());
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.DeleteCommand = new SqlCommand(deleteQuery, SQLConnection.getConnection());
                    adapter.DeleteCommand.ExecuteReader();
                    adapter.Dispose();
                    Command.Dispose();
                    SQLConnection.close_Connection();
                    UserRefresh();
                    MessageBox.Show("User deleted sucessfully", "Delete", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            catch
            {
                MessageBox.Show("Can't delete\n User in Active", "Delete", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        //Update query....
        public ICommand cmdUpdate { get { return new RelayCommand(UserUpdate); } }

        void UserUpdate(object param)
        {
            MDUser use = (MDUser)param;
            VWUserAdd user = new VWUserAdd();
            user.DataContext = new VMUserAdd(use);
            user.ShowDialog();
        }


        private ObservableCollection<MDUser> userCollection;

        public ObservableCollection<MDUser> UserCollection
        {
            get { return userCollection; }
            set { userCollection = value; OnPropertyChanged(); }
        }


        public static Action UserRefresh;
        public void On_UserReferesh()
        {
            UserView();
        }
    }
}
