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

namespace Mesaj_Sistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection connect = new SqlConnection("Data Source=ATES\\SQLEXPRESS;Initial Catalog=TEST;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand kmt= new SqlCommand("select *from TBLKISILER WHERE NUMARA=@P1 AND SIFRE=@P2",connect);
            kmt.Parameters.AddWithValue("@P1", maskedTextBox1.Text);
            kmt.Parameters.AddWithValue("@P2",txtPssword.Text);
            SqlDataReader dr=kmt.ExecuteReader();
            if (dr.Read())
            {
                Form2 frm=new Form2();
                frm.number = maskedTextBox1.Text;
                frm.Show();
            }
            else
            {
                MessageBox.Show("PASSWORD OR NUMBER IS INCORRECT");
            }
            connect.Close();
        }
    }
}
