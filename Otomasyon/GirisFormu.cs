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

namespace Otomasyon
{
    public partial class GirisFormu : Form
    {
        public GirisFormu()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                string user = textBox1.Text;
                string password = textBox2.Text;

                string connectionString = "Data Source=DESKTOP-QFAN9MA\\SQLEXPRESS;Initial Catalog=girisform;Integrated Security=True;Encrypt=False";
                string query = "SELECT * FROM Kullanici_bilgileri WHERE kullanici_adi = @user AND sifre = @password";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand com = new SqlCommand(query, con))
                    {
                        com.Parameters.AddWithValue("@user", user);
                        com.Parameters.AddWithValue("@password", password);

                        con.Open();
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                MessageBox.Show("Tebrikler Giriş Başarılı");
                            GirisAnaform frm = new GirisAnaform();
                            frm.Show();
                            this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Kullanıcı adı veya Şifre hatalı");
                            }
                        }
                    }
                }
            }

        }
    }

