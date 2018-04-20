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

namespace QuanLyThuVien
{
    public partial class quanly : Form
    {
        public quanly()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
            Form1 fr1 = new Form1();
            fr1.ShowDialog();
        }

        private void quanly_Load(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["QLTV"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString); try
            {
                conn.Open();
                string ID = Luu.luu;
                string sql = "select * from quanly where ID='" + ID + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                if (dta.Read() == true)
                {

                    lbTen1.Text=dta["ten"].ToString();
                    lbTen2.Text = dta["ten"].ToString();
                    lbChucVu.Text= "Quản lý";
                    lbEmail.Text= dta["email"].ToString();
                    lbGioiTinh.Text=dta["gioitinh"].ToString();
                    lbNgaysinh.Text = dta["ngaysinh"].ToString();
                    lbSDT.Text = dta["sdt"].ToString();
                    
                }
                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi!!!");
            }
        }


    }
}
