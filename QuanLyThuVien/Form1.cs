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
using System.Data;
namespace QuanLyThuVien
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["QLTV"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString); try
            {
                conn.Open();
                string ID = textBox2.Text.Trim();
                string PASS = textBox1.Text.Trim();
                string sql = "select * from dangnhap where ID='" + ID + "'and PASS='"+PASS+"'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                if (dta.Read() == true)
                {

                    if(string.Compare(dta["quantri"].ToString(),"1")==0) 
                    {
                        this.Hide();
                        Luu.luu = ID;
                        quanly ql = new quanly();
                        ql.ShowDialog();
                        
                    }
                    else
                    {
                        this.Hide();
                        Luu.luu = ID;
                        nhanVien nv = new nhanVien();
                        nv.ShowDialog();
                    }
                }
               // conn.Close();
            }
            catch(Exception)
            {
                MessageBox.Show("Lỗi kết nối!!!");
            }
        }


    }
}
