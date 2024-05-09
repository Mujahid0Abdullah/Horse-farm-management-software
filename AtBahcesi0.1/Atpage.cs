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
    public partial class Atpage : Form
    {
        public Atpage()
        {
            InitializeComponent();
            DisplayAt();
            GetSysId();
            GetantrId();
        }
        //SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Program.path + @"\" + Program.databasename + ";Integrated Security = True; Connect Timeout = 30");
        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "AtBahcesi0.1.mdf;Integrated Security=True");
       // SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-3HFSHQI;Initial Catalog=AtCiftligi;Integrated Security=True");
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AtBahcesi0._1.Properties.Settings.AtCiftligiConnectionString"].ConnectionString);

        private void DisplayAt()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select * from At", con);
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

        private void GetantrId()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Id from AntrTbl", con);
            SqlDataReader rder;
            rder = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));



            dt.Load(rder);

            AntrCb.ValueMember = "Id";
            AntrCb.DataSource = dt;
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
                SysTb.Text = dr["Ad"].ToString();
            }


            con.Close();

        }
        private void GetAntrAd()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from AntrTbl where Id=" + AntrCb.SelectedValue.ToString() + "", con);
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                antTb.Text = dr["Ad"].ToString();
            }


            con.Close();

        }
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void Atpage_Load(object sender, EventArgs e)
        {
            if (Login.antrGiris == true)
            {
                ogrnLbl.Visible = false;
                ogrnImg.Visible = false;
                antrImg.Visible = false;
                antrLbl.Visible = false;
                hocaImg.Visible = false;
                hocaLbl.Visible = false;

            }

            label13.Enabled = false;
            label13.Visible = false;
            pictureBox2.Visible = false;
            if (Login.yoneticibtnGoster == true)
            {
                pictureBox2.Visible = true;
                label13.Enabled = true;label13.Visible = true;
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (a == null || a.IsDisposed)
            { a = new AntrenoruPage(); a.Show(); }
            else { a.Visible = true; if (a.Created) { a.Activate(); } }
            this.Hide();
        }

       int key = 0;

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Bir At Seçin");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from At where Id=@DKey", con);
                    cmd.Parameters.AddWithValue("@DKey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("At Silindi");

                    con.Close();
                    DisplayAt();
                    Clear();


                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
       
        private void Clear()
        {
            
            AdTb.Text = "";
            irkTB.Text = "";
            shbTb.Text = "";
            SysTb.Text = "";
            OrjnTb.Text = "";
            antTb.Text = "";
            
            atGenCB.SelectedIndex = -1;
            yasCb.SelectedIndex = -1;
         


            key = 0;
        }
        private void ekleBtn_Click(object sender, EventArgs e)
        {
            if (AdTb.Text == "" || irkTB.Text == ""  || shbTb.Text == "" || SysTb.Text == "" || antTb.Text == "" || atGenCB.SelectedIndex == -1 || ahirCb.SelectedIndex == -1)
            {
                MessageBox.Show("eksi bilgiler var ");
            }
            else
            {
                try
                {
                   
                        con.Open();
                        SqlCommand cmd = new SqlCommand("insert into At(ad,irk,cinsiyet,sahibi,seyis,yas,antrenoru,orijin,dogumTarihi,ahirNo)values(@Ad,@irk,@cn,@shb,@sys,@yas,@ant,@orjn,@date,@ahir)", con);
                        cmd.Parameters.AddWithValue("@Ad", AdTb.Text);
                        cmd.Parameters.AddWithValue("@irk", irkTB.Text);
                        cmd.Parameters.AddWithValue("@cn", atGenCB.SelectedItem.ToString());                      
                        cmd.Parameters.AddWithValue("@shb", shbTb.Text);
                        cmd.Parameters.AddWithValue("@sys", SysTb.Text);
                        cmd.Parameters.AddWithValue("@yas", yasCb.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@ant", antTb.Text);
                        cmd.Parameters.AddWithValue("@orjn", OrjnTb.Text);
                        cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value.Date);
                         cmd.Parameters.AddWithValue("@ahir", ahirCb.SelectedItem.ToString());

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("At eklenmiş");

                        con.Close();
                        DisplayAt();
                        Clear();
                         AdTb.Focus();

                   

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (AdTb.Text == "" || irkTB.Text == "" || shbTb.Text == "" || SysTb.Text == "" || antTb.Text == "" || atGenCB.SelectedIndex == -1 || ahirCb.SelectedIndex == -1)
            {
                MessageBox.Show("eksi bilgiler var ");
            }
            else if (key == 0)
            {
                MessageBox.Show("bir At seçin ");
            }
            else
            {
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("update At set ad=@Ad,irk=@irk,cinsiyet=@cn,sahibi=@shb,seyis=@sys,yas=@yas,antrenoru=@ant,orijin=@orjn,dogumTarihi=@date,ahirNo=@ahir where Id=@key", con);
                    cmd.Parameters.AddWithValue("@Ad", AdTb.Text);
                    cmd.Parameters.AddWithValue("@irk", irkTB.Text);
                    cmd.Parameters.AddWithValue("@cn", atGenCB.SelectedItem.ToString());

                    cmd.Parameters.AddWithValue("@shb", shbTb.Text);
                    cmd.Parameters.AddWithValue("@sys", SysTb.Text);
                    cmd.Parameters.AddWithValue("@yas", yasCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@ant", antTb.Text);
                    cmd.Parameters.AddWithValue("@orjn", OrjnTb.Text);
                    cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@ahir", ahirCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@key", key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("At güncelledi");

                    con.Close();
                    DisplayAt();
                    Clear();



                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            //AdTb.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            //irkTB.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            //if (dataGridView1.SelectedRows[0].Cells[3].Value.ToString() == "Erkek")
            //{
            //    atGenCB.SelectedIndex = 0;
            //}
            //else
            //{
            //    atGenCB.SelectedIndex = 1;
            //}
            ////atGenCB.SelectedItem = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            //shbTb.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            //SysTb.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            //yasCb.SelectedItem = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            //antTb.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            //OrjnTb.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            //dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
            //ahirCb.SelectedItem = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();

            //if (AdTb.Text == "")
            //{
            //    key = 0;
            //}
            //else
            //{
            //    key = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());//key= resepId SelectedRows[0].Cells[0].Value =ilk sütun

            //}
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AdTb.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            irkTB.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            if (dataGridView1.SelectedRows[0].Cells[3].Value.ToString() == "Erkek")
            {
                atGenCB.SelectedIndex = 0;
            }
            else
            {
                atGenCB.SelectedIndex = 1;
            }
            //atGenCB.SelectedItem = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            shbTb.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            SysTb.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            yasCb.SelectedItem = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            antTb.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            OrjnTb.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
            ahirCb.SelectedItem = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();

            if (AdTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());//key= resepId SelectedRows[0].Cells[0].Value =ilk sütun

            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            DialogResult sonuc;
            sonuc = MessageBox.Show("Çıkmak istediğinizden emin misiniz?","uyarı!",MessageBoxButtons.OKCancel);
            if(sonuc== DialogResult.OK)
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
                Login lgn = new Login();
                lgn.Show();
                this.Hide();
                
               

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {
            AtlarListesi atlst = new AtlarListesi();
            atlst.Show();
            this.Hide();

        }

       
        SeyislerPage f;
        private void label10_Click(object sender, EventArgs e)
        {
            if (f == null || f.IsDisposed)
            { f = new SeyislerPage(); f.Show(); }
            else { f.Visible = true; if (f.Created) { f.Activate(); } }
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            if (f == null || f.IsDisposed)
            { f = new SeyislerPage(); f.Show(); }
            else { f.Visible = true; if (f.Created) { f.Activate(); } }
            this.Hide(); 

        }
        yoneticiPage y;
        private void label13_Click_1(object sender, EventArgs e)
        {
            if (y == null || y.IsDisposed)
            { y = new yoneticiPage(); y.Show(); }
            else { y.Visible = true; if (y.Created) { y.Activate(); } }
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (y == null || y.IsDisposed)
            { y = new yoneticiPage(); y.Show(); }
            else { y.Visible = true; if (y.Created) { y.Activate(); } }
            this.Hide();
        }
        ogrencilerPage op;
        private void label2_Click_1(object sender, EventArgs e)
        {
            if (op == null || op.IsDisposed)
            { op = new ogrencilerPage(); op.Show(); }
            else { op.Visible = true; if (op.Created) { op.Activate(); } }
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SysCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetSysAd();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void AntrCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetAntrAd();
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

        private void OrjnTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void SysTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void antTb_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
