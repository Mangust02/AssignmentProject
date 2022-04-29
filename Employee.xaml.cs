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
                Connect.conn.Open();
                String query = "SELECT * FROM Admin WHERE AdminID=" + employee_ID.Text;
                SqlCommand q_cmd = new SqlCommand(query, Connect.conn);
                SqlDataReader dr = q_cmd.ExecuteReader();

                if (dr.Read())
                {
                    MessageBox.Show("EmployeeID already exists");
                }
                else
                {
                    String add_query = "INSERT INTO Admin(AdminID, AdminUsername,Qualification,Password,Role) VALUES(" + employee_ID.Text + ", '" + employee_Name.Text + "','" + employee_Qualification.Text + "','" + employee_Password.Text + "')";
                    SqlCommand cmd = new SqlCommand(add_query, Connect.conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Saved");
                }

            }catch (SqlException ex)
            {
                MessageBox.Show(""+ex);
            }
            finally
            {
                Connect.conn.Close();
            }
            

        }
    }
}
