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
using System.Net.Mail;
using System.Configuration;

namespace AtBahcesi0._1
{
    public partial class SifrePage : Form
    {
        public SifrePage()
        {
            InitializeComponent();
        }
       
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AtBahcesi0._1.Properties.Settings.AtCiftligiConnectionString"].ConnectionString);

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (LgnCB.SelectedIndex == 2)
            {
                Boolean D = false;
                string r = "";
                con.Open();
                SqlCommand cm = new SqlCommand("Select * from SeyisTbl where Email='" + emailTb.Text + "'and Ad='" + adTb.Text + "'", con);
                SqlDataReader dr;
                dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    MailMessage mesaj = new MailMessage();
                    SmtpClient istemci = new SmtpClient();
                    istemci.Credentials = new System.Net.NetworkCredential("qqwweeqweft@outlook.sa", "password");
                    istemci.Port = 587;
                    istemci.Host = "smtp.office365.com";
                    istemci.EnableSsl = true;
                    mesaj.To.Add(emailTb.Text);
                    mesaj.Subject = "YENİ ŞİFRE";
                    mesaj.From = new MailAddress("qqwweeqweft@outlook.sa");
                    Random rnd = new Random();
                    String rndsifre = rnd.Next(100000000).ToString();
                    mesaj.Body = "yeni şifreniz: " + rndsifre;
                    r = rndsifre;
                    try
                    {
                        istemci.Send(mesaj);


                        MessageBox.Show(emailTb.Text + "'e yeni şifre gönderildi", "connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        D = true;



                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                    }
                }
                else { MessageBox.Show(" email yada şifre yanlış girdiniz", "Hata"); }


                con.Close();
                if (D) {
                    con.Open();
                SqlCommand cmd = new SqlCommand("update SeyisTbl set password=@p where Email=@eml", con);
                cmd.Parameters.AddWithValue("@p", r);

                cmd.Parameters.AddWithValue("@eml", emailTb.Text);
                cmd.ExecuteNonQuery();
                    con.Close();
                }
                DataTable dt = new DataTable();
            }else if (LgnCB.SelectedIndex == 0)
            {
                Boolean D = false;
                string r = "";
                con.Open();
                SqlCommand cm = new SqlCommand("Select * from yoneticiTbl where Email='" + emailTb.Text + "'and Ad='" + adTb.Text + "'", con);
                SqlDataReader dr;
                dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    MailMessage mesaj = new MailMessage();
                    SmtpClient istemci = new SmtpClient();
                    istemci.Credentials = new System.Net.NetworkCredential("qqwweeqweft@outlook.sa", "password");
                    istemci.Port = 587;
                    istemci.Host = "smtp.office365.com";
                    istemci.EnableSsl = true;
                    mesaj.To.Add(emailTb.Text);
                    mesaj.Subject = "YENİ ŞİFRE";
                    mesaj.From = new MailAddress("qqwweeqweft@outlook.sa");
                    Random rnd = new Random();
                    String rndsifre = rnd.Next(100000000).ToString();
                    mesaj.Body = "yeni şifreniz: " + rndsifre;
                    r = rndsifre;
                    try
                    {
                        istemci.Send(mesaj);


                        MessageBox.Show(emailTb.Text + "'e yeni şifre gönderildi", "connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        D = true;



                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                    }
                }
                else { MessageBox.Show(" email yada şifre yanlış girdiniz", "Hata"); }


                con.Close();
                if (D)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update yoneticiTbl set password=@p where Email=@eml", con);
                    cmd.Parameters.AddWithValue("@p", r);

                    cmd.Parameters.AddWithValue("@eml", emailTb.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                DataTable dt = new DataTable();
            }
            else if (LgnCB.SelectedIndex == 1)
            {
                Boolean D = false;
                string r = "";
                con.Open();
                SqlCommand cm = new SqlCommand("Select * from HocaTbl where Email='" + emailTb.Text + "'and Ad='" + adTb.Text + "'", con);
                SqlDataReader dr;
                dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    MailMessage mesaj = new MailMessage();
                    SmtpClient istemci = new SmtpClient();
                    istemci.Credentials = new System.Net.NetworkCredential("qqwweeqweft@outlook.sa", "password");
                    istemci.Port = 587;
                    istemci.Host = "smtp.office365.com";
                    istemci.EnableSsl = true;
                    mesaj.To.Add(emailTb.Text);
                    mesaj.Subject = "YENİ ŞİFRE";
                    mesaj.From = new MailAddress("qqwweeqweft@outlook.sa");
                    Random rnd = new Random();
                    String rndsifre = rnd.Next(100000000).ToString();
                    mesaj.Body = "yeni şifreniz: " + rndsifre;
                    r = rndsifre;
                    try
                    {
                        istemci.Send(mesaj);


                        MessageBox.Show(emailTb.Text + "'e yeni şifre gönderildi", "connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        D = true;



                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                    }
                }
                else { MessageBox.Show(" email yada şifre yanlış girdiniz", "Hata"); }


                con.Close();
                if (D)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update HocaTbl set password=@p where Email=@eml", con);
                    cmd.Parameters.AddWithValue("@p", r);

                    cmd.Parameters.AddWithValue("@eml", emailTb.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                DataTable dt = new DataTable();
            }
            else if (LgnCB.SelectedIndex == 3)
            {
                Boolean D = false;
                string r = "";
                con.Open();
                SqlCommand cm = new SqlCommand("Select * from AntrTbl where Email='" + emailTb.Text + "'and Ad='" + adTb.Text + "'", con);
                SqlDataReader dr;
                dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    MailMessage mesaj = new MailMessage();
                    SmtpClient istemci = new SmtpClient();
                    istemci.Credentials = new System.Net.NetworkCredential("qqwweeqweft@outlook.sa", "password");
                    istemci.Port = 587;
                    istemci.Host = "smtp.office365.com";
                    istemci.EnableSsl = true;
                    mesaj.To.Add(emailTb.Text);
                    mesaj.Subject = "YENİ ŞİFRE";
                    mesaj.From = new MailAddress("qqwweeqweft@outlook.sa");
                    Random rnd = new Random();
                    String rndsifre = rnd.Next(100000000).ToString();
                    mesaj.Body = "yeni şifreniz: " + rndsifre;
                    r = rndsifre;
                    try
                    {
                        istemci.Send(mesaj);


                        MessageBox.Show(emailTb.Text + "'e yeni şifre gönderildi", "connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        D = true;



                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                    }
                }
                else { MessageBox.Show(" email yada şifre yanlış girdiniz", "Hata"); }


                con.Close();
                if (D)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update AntrTbl set password=@p where Email=@eml", con);
                    cmd.Parameters.AddWithValue("@p", r);

                    cmd.Parameters.AddWithValue("@eml", emailTb.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                DataTable dt = new DataTable();
            }
            else
            {
                MessageBox.Show(" Kullanıcı tipi seçin");
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            Login lg = new Login();
            lg.Show();
        }

        private void emailTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void LgnCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SifrePage_Load(object sender, EventArgs e)
        {

        }
    }
}
