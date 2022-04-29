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
        public void setConnection()
        {
         conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\pos\ass\AssignmentProject\PosAssignment.mdf;Integrated Security=True");
        }
    }
}
