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
    public partial class Form3 : Form
    {
        SqlConnection connect;
        SqlDataAdapter d1, d2, d3, d4;
        DataSet ds1, ds2, ds3, ds4;

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillDataSet();
        }

        BindingSource b1, b2, b3, b4;
        public Form3()
        {
            InitializeComponent();
            connect = new SqlConnection(@"Data Source=DESKTOP-RM0NF38;Initial Catalog=APOTHIKI_4293;Integrated Security=True");
            connect.Open();
            d1 = new SqlDataAdapter("Select * from APOTHIKI", connect);
            DataTable dt1 = new DataTable();
            d1.Fill(dt1);
            comboBox1.DataSource = dt1;
            comboBox1.DisplayMember = "EIDOS";
        }
        public void fillDataSet()
        {
            d2 = new SqlDataAdapter("Select EPONYMIA,HMER_PARAGELIAS, K_PAR, EIDOS, KATHGORIA, TIMH_POLHSHS, FPA, POSOTHTA "
                                    +
                "FROM PELATHS inner join PARAGELIA inner join PROIONTA_PARAGELIAS " +

                "on PARAGELIA.KOD_PAR = PROIONTA_PARAGELIAS.K_PAR inner join APOTHIKI on PROIONTA_PARAGELIAS.K_E = APOTHIKI.KE  " +

                "on PELATHS.KOD_PELATH = PARAGELIA.K_PEL WHERE EIDOS= '" + comboBox1.Text.ToString() + "'", connect);

            ds2 = new DataSet();
            b2 = new BindingSource();
            d2.Fill(ds2);
            DataTable dt = new DataTable();
            dataGridView1.DataSource = ds2.Tables[0].DefaultView;
            double sum = 0;
            double total = 0;
            double fpaCalc = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {

                double timh = Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                double posothta = Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value);
                double fpa = Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value) / 100;

                fpaCalc += timh * posothta * fpa;
                sum += timh * posothta;
                total = sum + fpaCalc;
            }
            label3.Text = total.ToString("F2");
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            fillDataSet();
        }
    }
}
