using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;

namespace AtBahcesi0._1
{

    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
       
        public static Boolean yoneticibtnGoster = false;
        public static Boolean antrGiris = false;
        public static Boolean HocaGiris = false;
        public static string sayisEmail;
        public static string hocaEmail;

        //SqlConnection con =new  SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename="+Program.path+@"\"+Program.databasename+";Integrated Security = True; Connect Timeout = 30");
        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "AtBahcesi0.1.mdf;Integrated Security=True");
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-3HFSHQI;Initial Catalog=AtCiftligi;Integrated Security=True");
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AtBahcesi0._1.Properties.Settings.AtCiftligiConnectionString"].ConnectionString);

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
           
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwordTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LgnCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SifrePage sp = new SifrePage();
            sp.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {


            Application.Exit();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (LgnCB.SelectedIndex == 0)
            {
                if (emailTb.Text=="admin" && passwordTb.Text == "12345")
                {
                    yoneticiPage yp = new yoneticiPage();
                    yp.Show();
                    yoneticibtnGoster = true;
                    this.Hide();
                }
                else { 
                con.Open();
                SqlCommand cm = new SqlCommand("Select * from yoneticiTbl where Email='" + emailTb.Text + "'and password='" + passwordTb.Text + "'", con);
                SqlDataReader dr;
                dr = cm.ExecuteReader();
                if (dr.Read())
                {
                   Atpage fm = new Atpage();

                    fm.Show();
                    this.Hide();


                }
                else { MessageBox.Show(" email yada şifre yanlış girdiniz", "Hata"); }

                con.Close();
                DataTable dt = new DataTable();
                }
            }
            else if (LgnCB.SelectedIndex == 1)
            {
                con.Open();
                SqlCommand cm = new SqlCommand("Select * from HocaTbl where Email='" + emailTb.Text + "'and password='" + passwordTb.Text + "'", con);
                SqlDataReader dr;
                dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    hocaEmail = emailTb.Text;
                     HocaGiris = true;
                    AtlarListesi fm = new AtlarListesi();

                    fm.Show();
                    this.Hide();
                }
                else { MessageBox.Show(" email yada şifre yanlış girdiniz", "Hata"); }

                con.Close();
                DataTable dt = new DataTable();
            }
            else if (LgnCB.SelectedIndex == 2)
            {
            con.Open();
            SqlCommand cm = new SqlCommand("Select * from SeyisTbl where Email='" + emailTb.Text + "'and password='" + passwordTb.Text + "'", con);
            SqlDataReader dr;
            dr = cm.ExecuteReader();
            if (dr.Read())
            {
                    sayisEmail = emailTb.Text;
                AtlarListesi fm = new AtlarListesi();

                fm.Show();
                this.Hide();
            }
            else { MessageBox.Show(" email yada şifre yanlış girdiniz", "Hata"); }

            con.Close();
            DataTable dt = new DataTable();
            }
            else if (LgnCB.SelectedIndex == 3)
            {
                con.Open();
                SqlCommand cm = new SqlCommand("Select * from AntrTbl where Email='" + emailTb.Text + "'and password='" + passwordTb.Text + "'", con);
                SqlDataReader dr;
                dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    antrGiris = true;
                    Atpage fm = new Atpage();

                    fm.Show();
                    this.Hide();
                }
                else { MessageBox.Show(" email yada şifre yanlış girdiniz", "Hata"); }

                con.Close();
                DataTable dt = new DataTable();
            }
            else
            {
                MessageBox.Show(" Kullanıcı tipi seçin");
            }
        }
    }
}
