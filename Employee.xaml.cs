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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace AssignmentProject
{
    /// <summary>
    /// Interaction logic for Employee.xaml
    /// </summary>
    public partial class Employee : Page
    {
        public Employee()
        {
            InitializeComponent();
            Connect connect = new Connect();
            connect.setConnection();
        }

        private void employee_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string AdminID = employee_ID.Text;
                string AdminUsername = employee_Name.Text;
                string Role = employee_Role.Text;
                string Password = employee_Password.Text;

                if (string.IsNullOrEmpty(AdminID) || string.IsNullOrEmpty(AdminUsername) || string.IsNullOrEmpty(Role) ||  string.IsNullOrEmpty(Password)) 
                {
                    MessageBox.Show("Please, fill in all the required fields");
                }
                else
                {
                    Connect.conn.Open();
                    String ie_query = "INSERT INTO Admin(AdminID, AdminUsername, Role, Password) VALUES('" + employee_ID.Text + "', '" + employee_Name.Text + "', '" + employee_Role.Text + "', '" + employee_Password.Text + "') ";
                    SqlCommand ee_cmd = new SqlCommand(ie_query, Connect.conn);
                    ee_cmd.ExecuteNonQuery();
                    MessageBox.Show("The record has been successfully Inserted");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("" + ex);
            }
            finally
            {
                Connect.conn.Close();
            }


        }


        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Connect.conn.Open();
                String de_query = "DELETE FROM Admin WHERE AdminId=" + employee_ID.Text;
                SqlCommand de_cmd = new SqlCommand(de_query, Connect.conn);
                de_cmd.ExecuteNonQuery();
                MessageBox.Show("The record has been successfully Deleted");
               // clear();
               // loadData();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("" + ex);
            }
            finally
            {
                Connect.conn.Close();
            }
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Connect.conn.Open();
                String ue_query = "UPDATE Admin SET AdminUsername= '" + employee_Name.Text + "', Role= '" + employee_Role.Text + "', Password= '" + employee_Password.Text + "' WHERE AdminId=" + employee_ID.Text;
                SqlCommand ue_cmd = new SqlCommand(ue_query, Connect.conn);
                ue_cmd.ExecuteNonQuery();
                MessageBox.Show("The record has been successfully Updated");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("" + ex);
            }
            finally
            {
                Connect.conn.Close();
            }
        }
    }
}
