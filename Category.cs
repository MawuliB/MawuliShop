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
    public partial class Category : Form
    {
        public Category()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            Attendants att = new Attendants();
            att.Show();
            await Task.Delay(500);
            this.Hide();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Forms pd = new Forms();
            pd.Show();
            await Task.Delay(500);
            this.Hide();
        }

            SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\BADASSOU MAWULI\Documents\shopdb.mdf;Integrated Security=True;Connect Timeout=30");
        private void cataddbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (catname.Text == "" || description.Text == "")
                {
                    MessageBox.Show("Can't Add !\t\n Missing Info");
                }
                else
                {
                    Con.Open();
                    String query = "insert into CatTable (CatName, Description) values ('" + catname.Text + "','" + description.Text + "')";
                    SqlCommand command = new SqlCommand(query, Con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Category Added Successfully");
                    Con.Close();
                    catid.Text = "";
                    catname.Text = "";
                    description.Text = "";
                    fetchCat();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Con.Close();
            }
        }
        private void fetchCat()
        {
            Con.Open();
            string query = "select * from CatTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var data = new DataSet();
            sda.Fill(data);
            catList.DataSource = data.Tables[0];
            Con.Close();
        }
        private void Category_Load(object sender, EventArgs e)
        {
            fetchCat();
        }

        private void catList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            catid.Text = catList.SelectedRows[0].Cells[0].Value.ToString();
            catname.Text = catList.SelectedRows[0].Cells[1].Value.ToString();
            description.Text = catList.SelectedRows[0].Cells[2].Value.ToString();

        }

        private void catdelbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (catid.Text == "")
                {
                    MessageBox.Show("Product Not Selected \nPlease select the product to delete");
                }
                else
                {
                    Con.Open();
                    String query = "delete from CatTable where CatID=" + catid.Text + "";
                    SqlCommand command = new SqlCommand(query, Con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Category Deleted Successfully");
                    Con.Close();
                    catid.Text = "";
                    catname.Text = "";
                    description.Text = "";
                    fetchCat();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Con.Close();
            }
        }

        private void cateditbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (catid.Text == "")
                {
                    MessageBox.Show("Category Not Selected \nPlease select the category to edit");
                }
                else
                {
                    Con.Open();
                    String query = "update CatTable set CatName='" + catname.Text + "', Description='" + description.Text + "'where CatID=" + catid.Text + ";";
                    SqlCommand command = new SqlCommand(query, Con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Category Edited Successfully");
                    Con.Close();
                    catid.Text = "";
                    catname.Text = "";
                    description.Text = "";
                    fetchCat();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Con.Close();
            }
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            History h = new History();
            h.Show();
            await Task.Delay(500);
            this.Hide();
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void Category_MouseDown(object sender, MouseEventArgs e)
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
