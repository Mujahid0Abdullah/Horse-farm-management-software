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
    public partial class ogrencilerPage : Form
    {
        public ogrencilerPage()
        {
            InitializeComponent();
            Displayog();
            GethocaId();
         
        }
        //SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Program.path + @"\" + Program.databasename + ";Integrated Security = True; Connect Timeout = 30");
        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "AtBahcesi0.1.mdf;Integrated Security=True");
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-3HFSHQI;Initial Catalog=AtCiftligi;Integrated Security=True");
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AtBahcesi0._1.Properties.Settings.AtCiftligiConnectionString"].ConnectionString);

        private void Displayog()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select * from ogrenciTbl", con);
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
            tlfnTb.Text = "";
            hocaTb.Text = "";
           
            dateTimePicker1.Value = DateTime.Today;
            dtp_ilk.Value= DateTime.Today;
            dtp_son.Value = DateTime.Today;
            GenCB.SelectedIndex = -1;
            hocaCb.SelectedIndex = -1;
            derssaatiCb.SelectedIndex = -1;
            derssayisiCb.SelectedIndex = -1;





            key = 0;
        }
        private void ogrnLbl_Click(object sender, EventArgs e)
        {

        }
        private void GethocaId()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Id from hocaTbl", con);
            SqlDataReader rder;
            rder = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));



            dt.Load(rder);

            hocaCb.ValueMember = "Id";
            hocaCb.DataSource = dt;
            con.Close();

        }
        private void GetAntrAd()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from hocaTbl where Id=" + hocaCb.SelectedValue.ToString() + "", con);
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                hocaTb.Text = dr["Ad"].ToString();
            }


            con.Close();

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


        SeyislerPage y;
        private void SysLbl_Click(object sender, EventArgs e)
        {
            if (y == null || y.IsDisposed)
            { y = new SeyislerPage(); y.Show(); }
            else { y.Visible = true; if (y.Created) { y.Activate(); } }
            this.Hide();
        }
        private void SysImg_Click(object sender, EventArgs e)
        {
            if (y == null || y.IsDisposed)
            { y = new SeyislerPage(); y.Show(); }
            else { y.Visible = true; if (y.Created) { y.Activate(); } }
            this.Hide();
        }


        AntrenoruPage a;
        private void label10_Click(object sender, EventArgs e)
        {
            if (a == null || a.IsDisposed)
            { a = new AntrenoruPage(); a.Show(); }
            else { a.Visible = true; if (a.Created) { a.Activate(); } }
            this.Hide();
        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (a == null || a.IsDisposed)
            { a = new AntrenoruPage(); a.Show(); }
            else { a.Visible = true; if (a.Created) { a.Activate(); } }
            this.Hide();
        }




        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }



        Login l;
        private void label12_Click(object sender, EventArgs e)
        {
            if (l == null || l.IsDisposed)
            { l = new Login(); l.Show(); }
            else { l.Visible = true; if (l.Created) { l.Activate(); } }
            this.Hide();
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (l == null || l.IsDisposed)
            { l = new Login(); l.Show(); }
            else { l.Visible = true; if (l.Created) { l.Activate(); } }
            this.Hide();
        }




        private void ekleBtn_Click(object sender, EventArgs e)
        {
            if (AdTb.Text == "" || SydTb.Text == "" || tlfnTb.Text == "" || hocaTb.Text == "" || dateTimePicker1.Value.Date == DateTime.Today || dtp_son.Value.Date == DateTime.Today || GenCB.SelectedIndex == -1 || derssaatiCb.SelectedIndex == -1 || derssayisiCb.SelectedIndex == -1)
            {
                MessageBox.Show("eksi bilgiler var ");
            }
           
            else
            {
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into ogrenciTbl ( Ad,Soyad,cinsiyet,KursSaati,telefon,hoca,DogumTarihi,KayitTarihi,DersSayisi,KayıtBiti)values(@Ad,@syd,@cn,@krs,@tfn,@h,@dt,@kt,@ds,@Kb)", con);
                    cmd.Parameters.AddWithValue("@Ad", AdTb.Text);
                    cmd.Parameters.AddWithValue("@syd", SydTb.Text);
                    cmd.Parameters.AddWithValue("@dt", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@krs", derssaatiCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@tfn", tlfnTb.Text);

                    cmd.Parameters.AddWithValue("@h", hocaTb.Text);
                    cmd.Parameters.AddWithValue("@kt", dtp_ilk.Value.Date);
                    cmd.Parameters.AddWithValue("@ds", derssayisiCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@cn", GenCB.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@kb", dtp_son.Value.Date);

                   


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Öğrenci  eklendi");

                    con.Close();
                    Displayog();
                    Clear();



                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void ogrencilerPage_Load(object sender, EventArgs e)
        {
            if (Login.HocaGiris == true)
            {
              
                SysImg.Visible = false;
                SysLbl.Visible = false;
                atlbl.Visible = false;
                AtImg.Visible = false;
                antrimg.Visible = false;
                antrLbl.Visible = false;
                hocaLbl.Visible = false;
                hocaImg.Visible = false;
                atlistImg.Visible = true;
                aTlistLbl.Visible = true;

            }
            else
            {
                atlistImg.Visible = false;
                aTlistLbl.Visible = false;
            }

            if (Login.yoneticibtnGoster == true)
            {
                yntLbl.Visible = true;
                 yntImg.Visible = true;
            }
            else
            {

                yntLbl.Visible = false;
                yntImg.Visible = false;
            }
           
        }

        


        Atpage f;
        private void atlbl_Click(object sender, EventArgs e)
        {
            if (f == null || f.IsDisposed)
            { f = new Atpage(); f.Show(); }
            else { f.Visible = true; if (f.Created) { f.Activate(); } }
            this.Hide();
        }

        private void AtImg_Click(object sender, EventArgs e)
        {
            if (f == null || f.IsDisposed)
            { f = new Atpage(); f.Show(); }
            else { f.Visible = true; if (f.Created) { f.Activate(); } }
            this.Hide();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (AdTb.Text == "" || SydTb.Text == "" || tlfnTb.Text == "" || hocaTb.Text == "" || dateTimePicker1.Value.Date == DateTime.Today || dtp_son.Value.Date == DateTime.Today || GenCB.SelectedIndex == -1 || derssaatiCb.SelectedIndex == -1 || derssayisiCb.SelectedIndex == -1)
            {
                MessageBox.Show("eksi bilgiler var ");
            }
            else if (key == 0)
            {
                MessageBox.Show("bir Öğrenci seçin ");
            }
            else
            {
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("update ogrenciTbl set Ad=@Ad,Soyad=@syd,DogumTarihi=@dt,KursSaati=@krs,telefon=@tfn,hoca=@h,KayitTarihi=@kt,DersSayisi=@ds,cinsiyet=@cn,KayıtBiti=@Kb where Id=@key", con);
                    cmd.Parameters.AddWithValue("@Ad", AdTb.Text);
                    cmd.Parameters.AddWithValue("@syd", SydTb.Text);
                    cmd.Parameters.AddWithValue("@dt", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@krs", derssaatiCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@tfn", tlfnTb.Text);
                    cmd.Parameters.AddWithValue("@h", hocaTb.Text);
                    cmd.Parameters.AddWithValue("@kt", dtp_ilk.Value.Date);
                    cmd.Parameters.AddWithValue("@ds", derssayisiCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@cn", GenCB.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@kb", dtp_son.Value.Date);

                    cmd.Parameters.AddWithValue("@key", key);


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Öğrenci  güncelledi");

                    con.Close();
                    Displayog();
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
                MessageBox.Show("Bir Öğrenci Seçin");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from ogrenciTbl where Id=@DKey", con);
                    cmd.Parameters.AddWithValue("@DKey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Öğrenci Silindi");

                    con.Close();
                    Displayog();
                    Clear();


                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AdTb.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            SydTb.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            GenCB.SelectedItem = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            derssaatiCb.SelectedItem = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            tlfnTb.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            hocaTb.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
         
             dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
             dtp_ilk.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            derssayisiCb.SelectedIndex = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[9].Value) - 1;

            dtp_son.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();

                    
          
            if (AdTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());//key=  SelectedRows[0].Cells[0].Value =ilk sütun

            }
            KalangunTb.Text = Program.cost(dtp_son.Value.Date, dtp_ilk.Value.Date, (Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[9].Value) - 1)).ToString();
            textBox1.Text =Program.y.ToString();
        }

        private void hocaTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void hocaCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetAntrAd();
        }

        private void dtp_son_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void hocaCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void KalangunTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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
        AtlarListesi gr;
        private void aTlistLbl_Click(object sender, EventArgs e)
        {
            if (gr == null || gr.IsDisposed)
            { gr = new AtlarListesi(); gr.ShowDialog(); }
            else { gr.Visible = true; if (gr.Created) { gr.Activate(); } }
            this.Hide();
        }

        private void atlistImg_Click(object sender, EventArgs e)
        {
            if (gr == null || gr.IsDisposed)
            { gr = new AtlarListesi(); gr.ShowDialog(); }
            else { gr.Visible = true; if (gr.Created) { gr.Activate(); } }
            this.Hide();
        }
    }
}
