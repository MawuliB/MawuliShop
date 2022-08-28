using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace Shop
{
    public partial class History : Form
    {
        public History()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\BADASSOU MAWULI\Documents\shopdb.mdf;Integrated Security=True;Connect Timeout=30");

        private void fetchDataHistory()
        {
            Con.Open();
            string query = "select * from HistoryTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var data = new DataSet();
            sda.Fill(data);
            SPPtable.DataSource = data.Tables[0];
            Con.Close();
        }

        private void fetchDataAllSales()
        {
            Con.Open();
            string query = "select * from AllSalesTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var data = new DataSet();
            sda.Fill(data);
            AStable.DataSource = data.Tables[0];
            Con.Close();
        }

        private void History_Load(object sender, EventArgs e)
        {
            fetchDataHistory();
            fetchDataAllSales();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void fetchDataSpecificText()
        {
            Con.Open();
            string query = "select * from HistoryTable where AttName like '" + "%" + searchH.Text + "%" + "'" + "or" + " date like '" + "%" + searchH.Text + "%" + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var data = new DataSet();
            sda.Fill(data);
            SPPtable.DataSource = data.Tables[0];
            Con.Close();
        }

        private void fetchDataSpecificText2()
        {
            Con.Open();
            string query = "select * from AllSalesTable where Date like '" + "%" + searchA.Text + "%" + "'" + "or" + " Name like '" + "%" + searchA.Text + "%" + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var data = new DataSet();
            sda.Fill(data);
            AStable.DataSource = data.Tables[0];
            Con.Close();
        }

        private void description_TextChanged(object sender, EventArgs e)
        {
            fetchDataSpecificText();
        }

        private void searchA_TextChanged(object sender, EventArgs e)
        {
            fetchDataSpecificText2();
        }

        private void refreshH_Click(object sender, EventArgs e)
        {
            fetchDataHistory();
            searchH.Text = "";
        }

        private void refreshA_Click(object sender, EventArgs e)
        {
            fetchDataAllSales();
            searchA.Text = "";
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Forms f = new Forms();
            f.Show();
            await Task.Delay(500);
            this.Hide();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            Category c = new Category();
            c.Show();
            await Task.Delay(500);
            this.Hide();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            Attendants a = new Attendants();
            a.Show();
            await Task.Delay(500);
            this.Hide();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void History_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LOGIN lg = new LOGIN();
            lg.Show();
            this.Hide();
        }
    }
}
