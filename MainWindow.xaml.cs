using Microsoft.EntityFrameworkCore;
using System;

using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;


namespace ISP_Lab18
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UsersDbContext usersDb;
        private User selectedUser;

        public MainWindow()
        {
            InitializeComponent();
            usersDb = new UsersDbContext();
            usersDb.Users.Load();
            selectedUser = new User();
            Binding listBinding = new Binding()
            {
                Source = usersDb.Users.Local.ToBindingList()
            };
            BindingOperations.SetBinding(usersList, ListView.ItemsSourceProperty, listBinding);
            Bind(selectedUser);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (selectedUser.Id == 0)
            {
                usersDb.Users.Add(selectedUser);
                usersDb.SaveChanges();
            } else
            {
                usersDb.Users.Update(selectedUser);
                usersDb.SaveChanges();
            }
            selectedUser = new User();
            Bind(selectedUser);

        }

        private void Selection_Item(object sender, RoutedEventArgs e)
        {
            selectedUser = usersDb.Users.Skip(usersList.SelectedIndex).First();
            Bind(selectedUser);

        }
        private void Bind(User sourse)
        {
            Binding bindingFirstName = new Binding("FirstName")
            {
                Source = sourse,
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            BindingOperations.SetBinding(firstName, TextBox.TextProperty, bindingFirstName);

            Binding bindingLastName = new Binding("LastName")
            {
                Source = sourse,
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            BindingOperations.SetBinding(lastName, TextBox.TextProperty, bindingLastName);

            Binding bindingMiddleName = new Binding("MiddleName")
            {
                Source = sourse,
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            BindingOperations.SetBinding(middleName, TextBox.TextProperty, bindingMiddleName);


            Binding bindingBdate = new Binding("Bdate")
            {
                Source = sourse,
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            BindingOperations.SetBinding(calendar, Calendar.SelectedDateProperty, bindingBdate);
            calendar.DisplayDate = sourse.Bdate;

            Binding maleGenderBinding = new Binding("Gender")
            {
                Source = sourse,
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                Converter = new GenderConverter(),
                ConverterParameter = Gender.Male
            };
            BindingOperations.SetBinding(male, RadioButton.IsCheckedProperty, maleGenderBinding);

            Binding femaleGenderBinding = new Binding("Gender")
            {
                Source = sourse,
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                Converter = new GenderConverter(),
                ConverterParameter = Gender.Female
            };
            BindingOperations.SetBinding(female, RadioButton.IsCheckedProperty, femaleGenderBinding);
          
            Binding catsBinding = new Binding("Cats")
            {
                Source = sourse,
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            BindingOperations.SetBinding(cats, CheckBox.IsCheckedProperty, catsBinding);

            Binding bindingPhone = new Binding("Phone")
            {
                Source = sourse,
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            BindingOperations.SetBinding(phone, TextBox.TextProperty, bindingPhone);

        }

        
    }
}
