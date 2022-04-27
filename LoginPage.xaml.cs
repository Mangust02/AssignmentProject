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

namespace AssignmentProject
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            String username = usr.Text;
            String password = pass.Password;

            if(string.IsNullOrEmpty(username))
            {
               // MessageBox.Show("Username and Password are required");
               error1.Visibility = Visibility.Visible;
                error1.Content = "*Username is required";
            }else if (string.IsNullOrEmpty(password)){ 
                error2.Visibility = Visibility.Visible;
                error2.Content = "*Password is required";
            }
            else
            {
                error1.Visibility = Visibility.Hidden;
                error2.Visibility= Visibility.Hidden;
            }
        }
    }
}
