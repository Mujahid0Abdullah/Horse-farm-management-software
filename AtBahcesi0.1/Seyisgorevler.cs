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
using System.Configuration;

namespace AtBahcesi0._1
{
    public partial class Seyisgorevler : Form
    {
        public Seyisgorevler()
        {
            InitializeComponent();
            GetSysId();
            Displaygorev();
        }
        //SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Program.path + @"\" + Program.databasename + ";Integrated Security = True; Connect Timeout = 30");
        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "AtBahcesi0.1.mdf;Integrated Security=True");
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-3HFSHQI;Initial Catalog=AtCiftligi;Integrated Security=True");
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AtBahcesi0._1.Properties.Settings.AtCiftligiConnectionString"].ConnectionString);

        private void Displaygorev()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select * from SeyisGorevTbl", con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);

            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            con.Close();

        }
        private void GetSysId()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Id from SeyisTbl", con);
            SqlDataReader rder;
            rder = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));



            dt.Load(rder);

            SysCb.ValueMember = "Id";
            SysCb.DataSource = dt;
            con.Close();

        }
        private void GetSysAd()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from SeyisTbl where Id=" + SysCb.SelectedValue.ToString() + "", con);
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                AdTb.Text = dr["Ad"].ToString();
            }


            con.Close();

        }
        private void GetSysEmail()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from SeyisTbl where Id=" + SysCb.SelectedValue.ToString() + "", con);
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                emlTb.Text = dr["Email"].ToString();
            }


            con.Close();

        }
        private void Clear()
        {
            grvTb.Text = "";
            AdTb.Text = "";
            emlTb.Text = "";
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Now;


            SysCb.SelectedIndex = -1;
        }
        private void Seyisgorevler_Load(object sender, EventArgs e)
        {

        }

        private void SysCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetSysEmail();
            GetSysAd();
        }

        private void ekleBtn_Click(object sender, EventArgs e)
        {
            if (AdTb.Text == "" || emlTb.Text == "" || grvTb.Text == "" )
            {
                MessageBox.Show("eksi bilgiler var ");
            }

            else
            {
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into SeyisGorevTbl (gorev,SeyisAd,email,tarih,saat,SeyisId )values(@grv,@ad,@eml,@t,@s,@sid)", con);
                    cmd.Parameters.AddWithValue("@grv", grvTb.Text);
                    cmd.Parameters.AddWithValue("@ad",  AdTb.Text);
                    cmd.Parameters.AddWithValue("@t",   dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@s",   dateTimePicker2.Value);
                    cmd.Parameters.AddWithValue("@eml", emlTb.Text);

                    cmd.Parameters.AddWithValue("@sid", SysCb.SelectedValue.ToString());
                   




                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Görev  eklendi");

                    con.Close();
                    Displaygorev();
                    Clear();



                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int key = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            grvTb.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            AdTb.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
             emlTb.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            dateTimePicker2.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            SysCb.SelectedValue = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
          



            if (AdTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());//key=  SelectedRows[0].Cells[0].Value =ilk sütun

            }
        }

        private void pictureLogoBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void silBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Bir Görev Seçin");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from SeyisGorevTbl where Id=@DKey", con);
                    cmd.Parameters.AddWithValue("@DKey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Görev Silindi");

                    con.Close();
                    Displaygorev();
                    Clear();


                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ogrnLbl_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
