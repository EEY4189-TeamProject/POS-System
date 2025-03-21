﻿using Sales_Management_System.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using Sales_Management_System.Model;

namespace Sales_Management_System.ViewModel
{
    public class VMLogin : VMBase
    {
        public ICommand cmdMainmenu { get { return new RelayCommand(Mainmenu); } }

        public VMLogin()
        {
            FnGetData();

        }
        void Mainmenu(object param)
        {
            var password = param as PasswordBox;
            if (string.IsNullOrWhiteSpace(SelectedUser.UserName))
            {
                MessageBox.Show("Enter valid Username ", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Enter valid Password ", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!(SelectedUser.Password == Password))
            {
                MessageBox.Show("Incorrect Password ", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                UCDashboard dashboard = new UCDashboard();
                dashboard.DataContext = new VMDashboard(SelectedUser);
                logout.Invoke();
                dashboard.ShowDialog();
            }
        }

        public void FnGetData()
        {
            UserCollection = new ObservableCollection<MDUser>();
            SQLConnection.DBConnection();
            SQLConnection.SqlConnection();

            var searchQuery = $"select * from tblUser where IsActive = 'Active'";

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
        //Auto Refresh...

        public ICommand Logout { get { return new RelayCommand(exit); } }

        public static Action logout;

        void exit(object param)
        {
            if (MessageBox.Show("Do you want to Exit.?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                logout.Invoke();
            }
        }


        private MDUser selectedUser = new MDUser();

        public MDUser SelectedUser
        {
            get { return selectedUser; }
            set { selectedUser = value; OnPropertyChanged(); }
        }


        private ObservableCollection<MDUser> userCollection;

        public ObservableCollection<MDUser> UserCollection
        {
            get { return userCollection; }
            set { userCollection = value; OnPropertyChanged(); }
        }



        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged(); }
        }
    }
}

