using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace AtBahcesi0._1
{
    public partial class yoneticiPage : Form
    {
        public yoneticiPage()
        {
            InitializeComponent();
            Displayyonetici();
        }
        //SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Program.path + @"\" + Program.databasename + ";Integrated Security = True; Connect Timeout = 30");
       // SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "AtBahcesi0.1.mdf;Integrated Security=True");
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-3HFSHQI;Initial Catalog=AtCiftligi;Integrated Security=True");
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AtBahcesi0._1.Properties.Settings.AtCiftligiConnectionString"].ConnectionString);
        private void Displayyonetici()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select * from yoneticiTbl", con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);

            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            con.Close();

        }
        int key = 0;
        private void Clear()
        {

            AdTb.Text = "";
            SydTb.Text = "";
            denTb.Text = "";
            EmlTb.Text = "";
            PTb.Text = "";

            MTB.Text = "";
            GenCB.SelectedIndex = -1;
            zmnCb.SelectedIndex = -1;





            key = 0;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void yoneticiPage_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AdTb.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            SydTb.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            MTB.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            denTb.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            EmlTb.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            PTb.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            GenCB.SelectedItem = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();

            zmnCb.SelectedItem = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
            if (AdTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());//key= resepId SelectedRows[0].Cells[0].Value =ilk sütun

            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void ekleBtn_Click(object sender, EventArgs e)
        {
            if (AdTb.Text == "" || SydTb.Text == "" || MTB.Text == "" || EmlTb.Text == "" || PTb.Text == "" || GenCB.SelectedIndex == -1 || zmnCb.SelectedIndex == -1)
            {
                MessageBox.Show("eksi bilgiler var ");
            }
            else
            {
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into yoneticiTbl(Ad,Soyad,DogumTarihi,maas,DeplomaDeneyim,Email,password,cinsiyet,CalismaZamani)values(@Ad,@syd,@dt,@mas,@den,@eml,@p,@cn,@zmn)", con);
                    cmd.Parameters.AddWithValue("@Ad", AdTb.Text);
                    cmd.Parameters.AddWithValue("@syd", SydTb.Text);
                    cmd.Parameters.AddWithValue("@dt", dateTimePicker1.Value.Date);

                    cmd.Parameters.AddWithValue("@mas", MTB.Text);
                    cmd.Parameters.AddWithValue("@den", denTb.Text);
                    cmd.Parameters.AddWithValue("@eml", EmlTb.Text);
                    cmd.Parameters.AddWithValue("@p", PTb.Text);
                    cmd.Parameters.AddWithValue("@cn", GenCB.SelectedItem.ToString());

                    cmd.Parameters.AddWithValue("@zmn", zmnCb.SelectedItem.ToString());


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("yonetici eklenmiş");

                    con.Close();
                    Displayyonetici();
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
            if (AdTb.Text == "" || SydTb.Text == "" || MTB.Text == "" || EmlTb.Text == "" || PTb.Text == "" || GenCB.SelectedIndex == -1 || zmnCb.SelectedIndex == -1)
            {
                MessageBox.Show("eksi bilgiler var ");
            }
            else if (key == 0)
            {
                MessageBox.Show("bir yönetici seçin ");
            }
            else
            {
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("update SeyisTbl set Ad=@Ad,Soyad=@syd,DogumTarihi=@dt,maas=@mas,DeplomaDeneyim=@den,Email=@eml,password=@p,cinsiyet=@cn,CalismaZamani=@zmn where Id=@key", con);
                    cmd.Parameters.AddWithValue("@Ad", AdTb.Text);
                    cmd.Parameters.AddWithValue("@syd", SydTb.Text);
                    cmd.Parameters.AddWithValue("@dt", dateTimePicker1.Value.Date);

                    cmd.Parameters.AddWithValue("@mas", MTB.Text);
                    cmd.Parameters.AddWithValue("@den", denTb.Text);
                    cmd.Parameters.AddWithValue("@eml", EmlTb.Text);
                    cmd.Parameters.AddWithValue("@p", PTb.Text);
                    cmd.Parameters.AddWithValue("@cn", GenCB.SelectedItem.ToString());

                    cmd.Parameters.AddWithValue("@zmn", zmnCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@key", key);


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("yonetici eklenmiş");

                    con.Close();
                    Displayyonetici();

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
                MessageBox.Show("Bir seyis Seçin");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from yoneticiTbl where Id=@DKey", con);
                    cmd.Parameters.AddWithValue("@DKey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("yönetici Silindi");

                    con.Close();
                    Displayyonetici();

                    Clear();


                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        Atpage f;
        private void label8_Click(object sender, EventArgs e)
        {

            if (f == null || f.IsDisposed)
            { f = new Atpage(); f.Show(); }
            else { f.Visible = true; if (f.Created) { f.Activate(); } }
            this.Hide();

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (f == null || f.IsDisposed)
            { f = new Atpage(); f.Show(); }
            else { f.Visible = true; if (f.Created) { f.Activate(); } }
            this.Hide();
        }

        SeyislerPage y;
        private void label10_Click(object sender, EventArgs e)
        {
            if (y == null || y.IsDisposed)
            { y = new SeyislerPage(); y.Show(); }
            else { y.Visible = true; if (y.Created) { y.Activate(); } }
            this.Hide();
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (y == null || y.IsDisposed)
            { y = new SeyislerPage(); y.Show(); }
            else { y.Visible = true; if (y.Created) { y.Activate(); } }
            this.Hide();
        }

        
        ogrencilerPage op;
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (op == null || op.IsDisposed)
            { op = new ogrencilerPage(); op.Show(); }
            else { op.Visible = true; if (op.Created) { op.Activate(); } }
            this.Hide();
        }
        private void label2_Click(object sender, EventArgs e)
        {
            if (op == null || op.IsDisposed)
            { op = new ogrencilerPage(); op.Show(); }
            else { op.Visible = true; if (op.Created) { op.Activate(); } }
            this.Hide();
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

        private void hocaLbl_Click(object sender, EventArgs e)
        {
            if (h == null || h.IsDisposed)
            { h = new Hocapage(); h.Show(); }
            else { h.Visible = true; if (h.Created) { h.Activate(); } }
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            DialogResult sonuc;
            sonuc = MessageBox.Show("Çıkmak istediğinizden emin misiniz?", "uyarı!", MessageBoxButtons.OKCancel);
            if (sonuc == DialogResult.OK)
            {
                //Login lgn = new Login();
                //lgn.Show();
                //this.Hide();
                Application.Restart();


            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            DialogResult sonuc;
            sonuc = MessageBox.Show("Çıkmak istediğinizden emin misiniz?", "uyarı!", MessageBoxButtons.OKCancel);
            if (sonuc == DialogResult.OK)
            {
                //Login lgn = new Login();
                //lgn.Show();
                //this.Hide();
                Application.Restart();


            }
        }
        Hocapage h;
        private void hocaImg_Click(object sender, EventArgs e)
        {
            if (h == null || h.IsDisposed)
            { h = new Hocapage(); h.Show(); }
            else { h.Visible = true; if (h.Created) { h.Activate(); } }
            this.Hide();
        }
    }
}


     

        

   
