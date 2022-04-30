using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AssignmentProject
{
    class Connect
    {
        public static SqlConnection conn;
        public static String str;
        public void setConnection()
        {
            String fullpath = System.IO.Path.GetFullPath("PosAssignment.mdf");
            String path = fullpath.Substring(0, fullpath.IndexOf("bin"));
            str = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + "PosAssignment.mdf;Integrated Security=True";
            conn = new SqlConnection(str);
            conn.ConnectionString = str;
        }
    }
}
