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
    public partial class AntrenoruPage : Form
    {
        public AntrenoruPage()
        {
            InitializeComponent();
            Displayantenoru();
        }
        //SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Acer\source\repos\AtBahcesi0.1\AtBahcesi0.1\AtBahcesi0.1.mdf;Integrated Security = True; Connect Timeout = 30");
        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "AtBahcesi0.1.mdf;Integrated Security=True");
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AtBahcesi0._1.Properties.Settings.AtCiftligiConnectionString"].ConnectionString);

        private void Displayantenoru()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select * from AntrTbl", con);
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
            GrvTb.Text = "";
            MTB.Text = "";
            GenCB.SelectedIndex = -1;
            zmnCb.SelectedIndex = -1;
            TecCb.SelectedIndex = -1;




            key = 0;
        }
        private void AntrenoruPage_Load(object sender, EventArgs e)
        {
            //if (Login.antrGiris == true)
            //{
            //    ogrnLbl.Visible = false;
            //    ogrnImg.Visible = false;
            //    SysImg.Visible = false;
            //    SysLbl.Visible = false;


            //}
            label13.Visible = false;
            pictureBox1.Visible = false;
            if (Login.yoneticibtnGoster == true)
            {
                pictureBox1.Visible = true;
                label13.Visible = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AdTb.Text            = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            SydTb.Text           = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            TecCb.SelectedIndex  = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[4].Value) - 1;

            MTB.Text             = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            denTb.Text           = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            EmlTb.Text           = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            PTb.Text             = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            GenCB.SelectedItem   = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
            GrvTb.Text           = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
            zmnCb.SelectedItem   = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
            if (AdTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());//key= resepId SelectedRows[0].Cells[0].Value =ilk sütun

            }
        }

        private void ekleBtn_Click(object sender, EventArgs e)
        {
            if (AdTb.Text == "" || SydTb.Text == "" || MTB.Text == "" || EmlTb.Text == "" || PTb.Text == "" || GrvTb.Text == "" || GenCB.SelectedIndex == -1 || zmnCb.SelectedIndex == -1 || TecCb.SelectedIndex == -1)
            {
                MessageBox.Show("eksi bilgiler var ");
            }
            else
            {
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into AntrTbl(Ad,Soyad,DogumTarihi,tecrubeYillari,maas,DeplomaDeneyim,Email,password,cinsiyet,gorev,CalismaZamani)values(@Ad,@syd,@dt,@tec,@mas,@den,@eml,@p,@cn,@grv,@zmn)", con);
                    cmd.Parameters.AddWithValue("@Ad", AdTb.Text);
                    cmd.Parameters.AddWithValue("@syd", SydTb.Text);
                    cmd.Parameters.AddWithValue("@dt", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@tec", TecCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@mas", MTB.Text);
                    cmd.Parameters.AddWithValue("@den", denTb.Text);
                    cmd.Parameters.AddWithValue("@eml", EmlTb.Text);
                    cmd.Parameters.AddWithValue("@p", PTb.Text);
                    cmd.Parameters.AddWithValue("@cn", GenCB.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@grv", GrvTb.Text);
                    cmd.Parameters.AddWithValue("@zmn", zmnCb.SelectedItem.ToString());


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Antrenörü eklenmiş");

                    con.Close();
                    Displayantenoru();
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
            if (AdTb.Text == "" || SydTb.Text == "" || MTB.Text == "" || EmlTb.Text == "" || PTb.Text == "" || GrvTb.Text == "" || GenCB.SelectedIndex == -1 || zmnCb.SelectedIndex == -1 || TecCb.SelectedIndex == -1)
            {
                MessageBox.Show("eksi bilgiler var ");
            }
            else if (key == 0)
            {
                MessageBox.Show("bir Antrenörü seçin ");
            }
            else
            {
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("update AntrTbl set Ad=@Ad,Soyad=@syd,DogumTarihi=@dt,tecrubeYillari=@tec,maas=@mas,DeplomaDeneyim=@den,Email=@eml,password=@p,cinsiyet=@cn,gorev=@grv,CalismaZamani=@zmn where Id=@key", con);
                    cmd.Parameters.AddWithValue("@Ad", AdTb.Text);
                    cmd.Parameters.AddWithValue("@syd", SydTb.Text);
                    cmd.Parameters.AddWithValue("@dt", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@tec", TecCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@mas", MTB.Text);
                    cmd.Parameters.AddWithValue("@den", denTb.Text);
                    cmd.Parameters.AddWithValue("@eml", EmlTb.Text);
                    cmd.Parameters.AddWithValue("@p", PTb.Text);
                    cmd.Parameters.AddWithValue("@cn", GenCB.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@grv", GrvTb.Text);
                    cmd.Parameters.AddWithValue("@zmn", zmnCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@key", key);


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Antrenörü  güncelledi");

                    con.Close();
                    Displayantenoru();
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
                MessageBox.Show("Bir Antrenörü Seçin");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from AntrTbl where Id=@DKey", con);
                    cmd.Parameters.AddWithValue("@DKey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Antrenörü Silindi");

                    con.Close();
                    Displayantenoru();
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

        private void label11_Click(object sender, EventArgs e)
        {

        }
        ogrencilerPage op;
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (op == null || op.IsDisposed)
            { op = new ogrencilerPage(); op.Show(); }
            else { op.Visible = true; if (op.Created) { op.Activate(); } }
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (op == null || op.IsDisposed)
            { op = new ogrencilerPage(); op.Show(); }
            else { op.Visible = true; if (op.Created) { op.Activate(); } }
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
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
        private void label11_Click_1(object sender, EventArgs e)
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

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        Login l;
        private void label12_Click(object sender, EventArgs e)
        {
            if (l == null || l.IsDisposed)
            { l = new Login(); l.Show(); }
            else { l.Visible = true; if (l.Created) { l.Activate(); } }
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        yoneticiPage o;
        private void label13_Click(object sender, EventArgs e)
        {
            if (o == null || o.IsDisposed)
            { o = new yoneticiPage(); o.Show(); }
            else { o.Visible = true; if (o.Created) { o.Activate(); } }
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (o == null || o.IsDisposed)
            { o = new yoneticiPage(); o.Show(); }
            else { o.Visible = true; if (o.Created) { o.Activate(); } }
            this.Hide();
        }
        Hocapage h;
        private void hocaLbl_Click(object sender, EventArgs e)
        {
            if (h == null || h.IsDisposed)
            { h = new Hocapage(); h.Show(); }
            else { h.Visible = true; if (h.Created) { h.Activate(); } }
            this.Hide();
        }

        private void hocaImg_Click(object sender, EventArgs e)
        {
            if (h == null || h.IsDisposed)
            { h = new Hocapage(); h.Show(); }
            else { h.Visible = true; if (h.Created) { h.Activate(); } }
            this.Hide();
        }
    }
}
