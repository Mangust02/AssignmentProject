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
using System.Data.SqlClient;
using System.Data;

namespace AssignmentProject
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        SqlConnection conn;
        public LoginPage()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\pos\ass\AssignmentProject\PosAssignment.mdf;Integrated Security=True");
            
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            String username = usr.Text;
            String password = pass.Password;

            if(string.IsNullOrEmpty(username))
            {
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
            conn.Open();
            String query = "SELECT * FROM Admin where AdminID = " + username + "and Password='" + password + "'" ;
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (reader[3].ToString() == "Admin")
                {
                    AdminPage admin = new AdminPage();
                    admin.Show();
                    this.Close();
                } 
                else if(reader[3].ToString() == "Employee")
                {
                    EmployeePage employee = new EmployeePage();
                    employee.Show();
                    this.Close();
                }
            } 
            
            else
            {
                MessageBox.Show("Username or Password incorrect");
            }
            conn.Close();
        }
    }
}
