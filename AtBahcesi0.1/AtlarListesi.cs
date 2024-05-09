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
    public partial class AtlarListesi : Form
    {
        public AtlarListesi()
        {
            InitializeComponent();
            if (Login.HocaGiris == false)
            {
                Displaygorev();

            }
            else
            {
                Displayogrenci();
            }
            DisplayAt();
        }
        //SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Program.path + @"\" + Program.databasename + ";Integrated Security = True; Connect Timeout = 30");
        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "AtBahcesi0.1.mdf;Integrated Security=True");
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-3HFSHQI;Initial Catalog=AtCiftligi;Integrated Security=True");
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AtBahcesi0._1.Properties.Settings.AtCiftligiConnectionString"].ConnectionString);

        private void DisplayAt()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select * from At ", con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);

            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            con.Close();

        }
        private void Displaygorev()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select * from SeyisGorevTbl where email='"+Login.sayisEmail+"' ", con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);

            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];

            con.Close();

        }
        string hocaName;
        private void GetAntrAd()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from HocaTbl where Email='" + Login.hocaEmail + "'", con);
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                hocaName = dr["Ad"].ToString();
            }


            con.Close();

        }
        private void Displayogrenci()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select * from ogrenciTbl where hoca='" + hocaName + "' ", con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);

            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];

            con.Close();

        }
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        Login l;
        private void label12_Click(object sender, EventArgs e)
        {
            
            DialogResult sonuc;
            sonuc = MessageBox.Show("Çıkmak istediğinizden emin misiniz?", "uyarı!", MessageBoxButtons.OKCancel);
            if (sonuc == DialogResult.OK)
            {
                if (l == null || l.IsDisposed)
                { l = new Login(); l.Show(); }
                else { l.Visible = true; if (l.Created) { l.Activate(); } }
                this.Close();
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            DialogResult sonuc;
            sonuc = MessageBox.Show("Çıkmak istediğinizden emin misiniz?", "uyarı!", MessageBoxButtons.OKCancel);
            if (sonuc == DialogResult.OK)
            {
                if (l == null || l.IsDisposed)
                { l = new Login(); l.Show(); }
                else { l.Visible = true; if (l.Created) { l.Activate(); } }
                this.Close();
            }
        }

        private void AtlarListesi_Load(object sender, EventArgs e)
        {
           

            if (Login.HocaGiris == true)
            {
                ogrnLbl.Visible = true;
                ogrnImg.Visible = true;
                label1.Text = "Öğrencilerim";
            }
            else
            {
            ogrnLbl.Visible = false;
            ogrnImg.Visible = false;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();


        }
        ogrencilerPage op;
        private void ogrnLbl_Click(object sender, EventArgs e)
        {
            if (op == null || op.IsDisposed)
            { op = new ogrencilerPage(); op.Show(); }
            else { op.Visible = true; if (op.Created) { op.Activate(); } }
            this.Hide();
        }

        private void ogrnImg_Click(object sender, EventArgs e)
        {
            if (op == null || op.IsDisposed)
            { op = new ogrencilerPage(); op.Show(); }
            else { op.Visible = true; if (op.Created) { op.Activate(); } }
            this.Hide();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
