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
            d1.Fill(dt1);
            comboBox1.DataSource = dt1;
            comboBox1.DisplayMember = "EPONYMIA";
             
        }

        public void fillDataSet()
        {
            d2 = new SqlDataAdapter("Select EPONYMIA, AFM, EIDOS, KATHGORIA, TIMH_POLHSHS, FPA, POSOTHTA " 
                                    +
                "FROM PELATHS inner join PARAGELIA inner join PROIONTA_PARAGELIAS " +
                                    
                "on PARAGELIA.KOD_PAR = PROIONTA_PARAGELIAS.K_PAR inner join APOTHIKI on PROIONTA_PARAGELIAS.K_E = APOTHIKI.KE  " +
                                    
                "on PELATHS.KOD_PELATH = PARAGELIA.K_PEL WHERE EPONYMIA= '" + comboBox1.Text.ToString()+ "'", connect);
            
            ds2 = new DataSet();
            b2 = new BindingSource();
            d2.Fill(ds2);
            DataTable dt = new DataTable();
            dataGridView1.DataSource = ds2.Tables[0].DefaultView;
            float sum = 0;
            for(int i=0; i < dataGridView1.RowCount; i++)
            {
                sum += Convert.ToSingle(dataGridView1.Rows[i].Cells[4].Value)+ 
                       Convert.ToSingle(dataGridView1.Rows[i].Cells[4].Value)*
                       (Convert.ToSingle(dataGridView1.Rows[i].Cells[6].Value)*
                       Convert.ToSingle(dataGridView1.Rows[i].Cells[5].Value));
                
            }
            label4.Text = sum.ToString();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillDataSet();
            //SAVVA GAMIESAI
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            fillDataSet();
        }
    }
}
