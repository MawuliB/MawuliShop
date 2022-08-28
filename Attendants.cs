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
    public partial class Attendants : Form
    {
        public Attendants()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Forms pd = new Forms();
            pd.Show();
            await Task.Delay(500);
            this.Hide();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            Category ct = new Category();
            ct.Show();
            await Task.Delay(500);
            this.Hide();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\BADASSOU MAWULI\Documents\shopdb.mdf;Integrated Security=True;Connect Timeout=30");
        private void attaddbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (attname.Text == "" || dob.Text == "" || number.Text == "" || password.Text == "")
                {
                    MessageBox.Show("Can't Add !\t\n Missing Info");
                }
                else
                {
                    Con.Open();
                    String query = "insert into AttTable (AttName, Age, Number, Password) values ('" + attname.Text + "'," + dob.Text + "," + number.Text + ",'" + password.Text + "')";
                    SqlCommand command = new SqlCommand(query, Con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Attendant Added Successfully");
                    Con.Close();
                    attid.Text = "";
                    attname.Text = "";
                    dob.Text = "";
                    number.Text = "";
                    password.Text = "";
                    fetchData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Con.Close();
            }
        }
        private void fetchData()
        {
            Con.Open();
            string query = "select * from AttTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var data = new DataSet();
            sda.Fill(data);
            attList.DataSource = data.Tables[0];
            Con.Close();
        }

        private void Attendants_Load(object sender, EventArgs e)
        {
            fetchData();
        }

        private void attList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            attid.Text = attList.SelectedRows[0].Cells[0].Value.ToString();
            attname.Text = attList.SelectedRows[0].Cells[1].Value.ToString();
            dob.Text = attList.SelectedRows[0].Cells[2].Value.ToString();
            number.Text = attList.SelectedRows[0].Cells[3].Value.ToString();
            password.Text = attList.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void atteditbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (attid.Text == "")
                {
                    MessageBox.Show("Attendant Not Selected \nPlease select the attendant to edit");
                }
                else
                {
                    Con.Open();
                    String query = "update AttTable set AttName='" +attname.Text + "', Age=" + dob.Text + ", Number=" + number.Text + ", Password='" + password.Text + "'where AttID=" + attid.Text + ";";
                    SqlCommand command = new SqlCommand(query, Con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Attendant Edited Successfully");
                    Con.Close();
                    attid.Text = "";
                    attname.Text = "";
                    dob.Text = "";
                    number.Text = "";
                    password.Text = "";
                    fetchData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Con.Close();
            }
        }

        private void attdelbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (attid.Text == "")
                {
                    MessageBox.Show("Attendant Not Selected \nPlease select the Attendant to delete");
                }
                else
                {
                    Con.Open();
                    String query = "delete from AttTable where AttID=" + attid.Text + "";
                    SqlCommand command = new SqlCommand(query, Con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Attendant Deleted Successfully");
                    Con.Close();
                    attid.Text = "";
                    attname.Text = "";
                    dob.Text = "";
                    number.Text = "";
                    password.Text = "";
                    fetchData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Con.Close();
            }
        }

        private void attid_TextChanged(object sender, EventArgs e)
        {

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

        private void label8_MouseDown(object sender, MouseEventArgs e)
        {

        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void Attendants_MouseDown(object sender, MouseEventArgs e)
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
