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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection connect = new SqlConnection("Data Source=ATES\\SQLEXPRESS;Initial Catalog=TEST;Integrated Security=True");
        public string number;

        void gelenkutusu()
        {
            SqlDataAdapter da= new SqlDataAdapter("select *from TBLMESAJ WHERE ALICI="+number,connect);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }
        void gidenkutusu()
        {
            SqlDataAdapter da1 = new SqlDataAdapter("select *from TBLMESAJ WHERE GONDEREN=" + number, connect);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            lblNumbr.Text = number;
            gidenkutusu();
            gelenkutusu();
            connect.Open();
            SqlCommand kmt = new SqlCommand("select AD,SOYAD FROM TBLKISILER WHERE NUMARA=" + number, connect);
            SqlDataReader dr=kmt.ExecuteReader();
            while (dr.Read())
            {
                lblName.Text = dr[0]+" " + dr[1];
            }
            connect.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand kmt = new SqlCommand("insert into TBLMESAJ (GONDEREN,ALICI,BASLIK,ICERIK) VALUES(@P1,@P2,@P3@P4)", connect);
            kmt.Parameters.AddWithValue("@P1", number);
            kmt.Parameters.AddWithValue("@P2", maskedTextBox1.Text);
            kmt.Parameters.AddWithValue("@P3", txtTıttle.Text);
            kmt.Parameters.AddWithValue("@P4", richTextBox1.Text);
            kmt.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("YOUR MESSAGE HAS BEEN DELIVERED SUCCESFULLY");
            gidenkutusu();
        }
    }
}
