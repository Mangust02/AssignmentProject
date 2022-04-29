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
            Connect.conn.Open();
            String add_query = "INSERT INTO Admin(AdminID, AdminUsername,Qualification,Password) VALUES("+employee_ID.Text+", '"+employee_Name.Text+"','"+ employee_Qualification+"','"+employee_Password.Text+"')";
            SqlCommand cmd = new SqlCommand(add_query,Connect.conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Saved");


        }
    }
}
