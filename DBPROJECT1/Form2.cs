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
namespace DBPROJECT1
{
    public partial class Form2 : Form
    {
        SqlConnection connect;
        SqlDataAdapter d1, d2, d3, d4;
        DataSet ds1, ds2, ds3, ds4;
        BindingSource b1, b2, b3, b4;
        public Form2()
        {
            InitializeComponent();
            connect = new SqlConnection(@"Data Source=DESKTOP-RM0NF38;Initial Catalog=APOTHIKI_4293;Integrated Security=True");
            connect.Open();
            d1 = new SqlDataAdapter("Select * from PELATHS", connect);
            DataTable dt1 = new DataTable();
            comboBox1.DataSource = dt1;
            comboBox1.DisplayMember = "EPONYMIA";
             
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
