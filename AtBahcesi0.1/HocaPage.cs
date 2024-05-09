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
    public partial class Hocapage : Form
    {
        public Hocapage()
        {
            InitializeComponent(); DisplayHoca();
        }
        //SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Program.path + @"\" + Program.databasename + ";Integrated Security = True; Connect Timeout = 30");
        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "AtBahcesi0.1.mdf;Integrated Security=True");
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-3HFSHQI;Initial Catalog=AtCiftligi;Integrated Security=True");
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AtBahcesi0._1.Properties.Settings.AtCiftligiConnectionString"].ConnectionString);


        private void DisplayHoca()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select * from HocaTbl", con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);

            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            con.Close();

        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
        int key = 0;
        private void Clear()
        {

            AdTb.Text = "";
            SydTb.Text = "";
            denTb.Text = "";
            EmlTb.Text = "";
            PTb.Text = "";
           
            GenCB.SelectedIndex = -1;
            TecCb.SelectedIndex = -1;




            key = 0;
        }
        private void ekleBtn_Click(object sender, EventArgs e)
        {
            if (AdTb.Text == "" || SydTb.Text == "" || EmlTb.Text == "" || PTb.Text == "" ||  GenCB.SelectedIndex == -1 ||TecCb.SelectedIndex == -1)
            {
                MessageBox.Show("eksi bilgiler var ");
            }
            else
            {
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into HocaTbl(Ad,Soyad,DogumTarihi,tecrübeyillari,diploma,Email,password,cinsiyet)values(@Ad,@syd,@dt,@tec,@den,@eml,@p,@cn)", con);
                    cmd.Parameters.AddWithValue("@Ad", AdTb.Text);
                    cmd.Parameters.AddWithValue("@syd", SydTb.Text);
                    cmd.Parameters.AddWithValue("@dt", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@tec", TecCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@den", denTb.Text);
                    cmd.Parameters.AddWithValue("@eml", EmlTb.Text);
                    cmd.Parameters.AddWithValue("@p", PTb.Text);
                    cmd.Parameters.AddWithValue("@cn", GenCB.SelectedItem.ToString());
                   


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Hoca" +
                        " eklenmiş");

                    con.Close();
                    DisplayHoca();
                    Clear();



                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (AdTb.Text == "" || SydTb.Text == "" || EmlTb.Text == "" || PTb.Text == "" ||  GenCB.SelectedIndex == -1 || TecCb.SelectedIndex == -1)
            {
                MessageBox.Show("eksi bilgiler var ");
            }
            else if (key == 0)
            {
                MessageBox.Show("bir Hoca seçin ");
            }
            else
            {
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("update HocaTbl set Ad=@Ad,Soyad=@syd,DogumTarihi=@dt,tecrübeyillari=@tec,Diploma=@den,Email=@eml,password=@p,cinsiyet=@cn where Id=@key", con);
                    cmd.Parameters.AddWithValue("@Ad", AdTb.Text);
                    cmd.Parameters.AddWithValue("@syd", SydTb.Text);
                    cmd.Parameters.AddWithValue("@dt", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@tec", TecCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@den", denTb.Text);
                    cmd.Parameters.AddWithValue("@eml", EmlTb.Text);
                    cmd.Parameters.AddWithValue("@p", PTb.Text);
                    cmd.Parameters.AddWithValue("@cn", GenCB.SelectedItem.ToString());
             
                    cmd.Parameters.AddWithValue("@key", key);


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Hoca  güncelledi");

                    con.Close();
                    DisplayHoca();
                    Clear();



                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void silBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Bir Hoca Seçin");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from HocaTbl where Id=@DKey", con);
                    cmd.Parameters.AddWithValue("@DKey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Seçilen Hoca Silindi");

                    con.Close();
                    DisplayHoca();
                    Clear();


                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        AntrenoruPage a;
        private void label11_Click(object sender, EventArgs e)
        {
            if (a == null || a.IsDisposed)
            { a = new AntrenoruPage(); a.Show(); }
            else { a.Visible = true; if (a.Created) { a.Activate(); } }
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (a == null || a.IsDisposed)
            { a = new AntrenoruPage(); a.Show(); }
            else { a.Visible = true; if (a.Created) { a.Activate(); } }
            this.Hide();
        }
        SeyislerPage f;
        private void SysLbl_Click(object sender, EventArgs e)
        {
            if (f == null || f.IsDisposed)
            { f = new SeyislerPage(); f.Show(); }
            else { f.Visible = true; if (f.Created) { f.Activate(); } }
            this.Hide();
        }

        private void SysImg_Click(object sender, EventArgs e)
        {
            if (f == null || f.IsDisposed)
            { f = new SeyislerPage(); f.Show(); }
            else { f.Visible = true; if (f.Created) { f.Activate(); } }
            this.Hide();
        }
        yoneticiPage y;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (y == null || y.IsDisposed)
            { y = new yoneticiPage(); y.Show(); }
            else { y.Visible = true; if (y.Created) { y.Activate(); } }
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            if (y == null || y.IsDisposed)
            { y = new yoneticiPage(); y.Show(); }
            else { y.Visible = true; if (y.Created) { y.Activate(); } }
            this.Hide();
        }

        private void Hocapage_Load(object sender, EventArgs e)
        {
            
            label13.Visible = false;
            pictureBox1.Visible = false;
            if (Login.yoneticibtnGoster == true)
            {
                pictureBox1.Visible = true;
                label13.Enabled = true; label13.Visible = true;
            }
        }
        Atpage ap;
        private void label8_Click(object sender, EventArgs e)
        {
            if (ap == null || ap.IsDisposed)
            { ap = new Atpage(); ap.Show(); }
            else { ap.Visible = true; if (ap.Created) { ap.Activate(); } }
            this.Hide();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (ap == null || ap.IsDisposed)
            { ap = new Atpage(); ap.Show(); }
            else { ap.Visible = true; if (ap.Created) { ap.Activate(); } }
            this.Hide();

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
    }
}
