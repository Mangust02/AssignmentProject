using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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
using Microsoft.Win32;

namespace AssignmentProject
{
     class NameofFile
    {
        public static string changedFileName;
    }
    /// <summary>
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class Products : Page
    {
        public Products()
        {
            InitializeComponent();
        }

        private void imageLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == true)
                {
                    pathTextBox.Text = dialog.FileName;
                    imageForSeller.Source = new BitmapImage(new Uri(pathTextBox.Text, UriKind.Absolute));

                    string source = pathTextBox.Text;
                    FileInfo fileInfo = new FileInfo(source);

                    Random random = new Random();
                    NameofFile.changedFileName = "img_name_" + random.Next(1000, 5000) + "." + System.IO.Path.GetExtension(pathTextBox.Text);

                    string path = System.IO.Path.GetFullPath("img/Products/");
                    string folder_path = path.Substring(0, path.IndexOf("bin"));

                    string destination = folder_path + @"Images\Products\" + NameofFile.changedFileName;
                    fileInfo.CopyTo(destination);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void insertToDb_Click(object sender, RoutedEventArgs e)
        {
            String fullpath = System.IO.Path.GetFullPath("PosAssignment.mdf");
            String path = fullpath.Substring(0, fullpath.IndexOf("bin"));
            Connect.str = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + "PosAssignment.mdf;Integrated Security=True";
            Connect.conn = new SqlConnection(Connect.str);
            Connect.conn.ConnectionString = Connect.str;
            Connect.conn.Open();
                    String add_query = "INSERT INTO product_table(name, author, price, quantity, image) VALUES('" + product_Name.Text + "', '" + product_Author.Text + "','" + product_Price.Text + "','" + product_Quantity.Text + "', '/images/Products/" + NameofFile.changedFileName + "')";
                    SqlCommand cmd = new SqlCommand(add_query, Connect.conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Saved");

        }
    }
}
