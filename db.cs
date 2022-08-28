using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Shop
{
    class db
    {
        public static String connstr = "server=localhost; database=shop; uid=root; pwd=\"\";";
        public static SqlConnection con = new SqlConnection(connstr);


        public static void openconnection ()
        {
            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Database Connection Failed");
                Console.WriteLine(e);
            }
        }
    }
}
