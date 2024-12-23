using Sales_Management_System.ViewModel;
using SalesSystem_05._11._2022.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SalesSystem_05._11._2022.ViewModel
{
    public class VMUserAdd : VMBase
    {
        public VMUserAdd(MDUser user = null)
        {
            if (user == null)
            {
                //QtyEnable = true;
                IsUser();
                btnAdd = "Add";
                btnCancel = "Cancel";
            }
            else
            {
                //QtyEnable = false;
                User = new();
                User.UserId = user.UserId;
                User.UserName = user.UserName;
                User.Password = user.Password;
                User.IsActive = user.IsActive;
                btnAdd = "Update";
                btnCancel = "Cancel";
            }
        }



        public ICommand cmdUserSave { get { return new RelayCommand(UserSave); } }

        void UserSave(object param)
        {
            try
            {

            
            switch (btnAdd)
            {

                case "Add":
                    if (Validation())
                    {
                        if (!VMValidation.Combovalidation(User.IsActive))
                        {
                            MessageBox.Show("Please select user status", " User", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }


                        SQLConnection.SqlConnection();
                        string query = $"insert into tblUser values('" + User.UserId + "' ,'" + User.UserName + "','" + User.Password + "' ,'" + User.IsActive + "' )";
                        SqlCommand Command = new SqlCommand(query, SQLConnection.getConnection());
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.InsertCommand = new SqlCommand(query, SQLConnection.getConnection());
                        adapter.InsertCommand.ExecuteNonQuery();
                        adapter.Dispose();
                        Command.Dispose();
                        SQLConnection.close_Connection();
                        VMUser.UserRefresh();
                        userExit.Invoke();
                        MessageBox.Show("User sucessfully added", "User", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    break;

                case "Update":

                    if (UpdateValidation())
                    {
                        if (!VMValidation.Combovalidation(User.IsActive))
                        {
                            MessageBox.Show("Please select user status", " User", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        SQLConnection.SqlConnection();
                        string Query = $"Update  tblUser set UserName ='" + User.UserName + "' ,Password ='" + User.Password + "',IsActive='" + User.IsActive + "' where UserId = '" + User.UserId + "'";
                        SqlCommand command = new SqlCommand(Query, SQLConnection.getConnection());
                        SqlDataAdapter Adapter = new SqlDataAdapter();
                        Adapter.UpdateCommand = new SqlCommand(Query, SQLConnection.getConnection());
                        Adapter.UpdateCommand.ExecuteNonQuery();
                        Adapter.Dispose();
                        command.Dispose();
                        SQLConnection.close_Connection();
                        VMUser.UserRefresh();
                        userExit.Invoke();
                        MessageBox.Show("User sucessfully Updated", "User", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    break;
            }
            }
            catch
            {
                MessageBox.Show("Invalid inputs", " User", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private MDUser user;

        public MDUser User
        {
            get { return user; }
            set { user = value; OnPropertyChanged(); }
        }
        public void IsUser()
        {
            User = new();
            User.UserId = SQLConnection.ISData("tblUser") ? int.Parse(SQLConnection.CheckTableData("tblUser", "UserId", "UserId")) + 1 : 1;
        }

        private string _btnAdd;

        public string btnAdd
        {
            get { return _btnAdd; }
            set { _btnAdd = value; OnPropertyChanged(); }
        }

        private string _btnCancel;

        public string btnCancel
        {
            get { return _btnCancel; }
            set { _btnCancel = value; OnPropertyChanged(); }
        }


        public ICommand cmdUserExit { get { return new RelayCommand(UserExit); } }

        public static Action userExit;
        void UserExit(object param)
        {
            if (MessageBox.Show("Do you want to Cancel ?", "Cancel", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                userExit.Invoke();
            }


        }


        public bool Validation()
        {
            bool Result = false;

            bool product = VMValidation.UserAddValidation(User.UserName, User.Password);

            if (product)
            {
                Result = true;
            }
            return Result;
        }

        public bool UpdateValidation()
        {
            bool Result = false;

            bool product = VMValidation.UserUpdateValidation(User.UserName, User.Password);

            if (product)
            {
                Result = true;
            }
            return Result;
        }
    }
}
