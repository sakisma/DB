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
    public partial class Form1 : Form
    {
        SqlConnection conn;
        SqlDataAdapter da1, da2, da3, da4;
        DataSet ds1, ds2, ds3, ds4;

        private void Button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }

        BindingSource b1, b2, b3, b4;


        private void Form1_Load(object sender, EventArgs e)
        {
            da1 = new SqlDataAdapter("Select * from PELATHS", conn);
            ds1 = new DataSet();
            da1.Fill(ds1,"Pelaths_Table");
            b1 = new BindingSource();
            b1.DataSource = ds1.Tables[0].DefaultView;
            textBox1.DataBindings.Add(new Binding("Text", b1, "KOD_PELATH", true));
            textBox2.DataBindings.Add(new Binding("Text", b1, "EPONYMIA", true));
            textBox3.DataBindings.Add(new Binding("Text", b1, "EPITHETO", true));
            textBox4.DataBindings.Add(new Binding("Text", b1, "ONOMA", true));
            textBox5.DataBindings.Add(new Binding("Text", b1, "HM_GENHSHS", true));
            textBox6.DataBindings.Add(new Binding("Text", b1, "HLIKIA", true));
            textBox7.DataBindings.Add(new Binding("Text", b1, "AFM", true));
            textBox8.DataBindings.Add(new Binding("Text", b1, "DOY", true));
            textBox9.DataBindings.Add(new Binding("Text", b1, "DIEYTHINSI", true));
            textBox10.DataBindings.Add(new Binding("Text", b1, "POLH", true));
            textBox11.DataBindings.Add(new Binding("Text", b1, "THL", true));
            textBox12.DataBindings.Add(new Binding("Text", b1, "FOTO", true));
            textBox13.DataBindings.Add(new Binding("Text", b1, "SXOLIA", true));
            bindingNavigator1.BindingSource = b1;


            da2 = new SqlDataAdapter("Select * from PARAGELIA", conn);
            ds2 = new DataSet();
            da2.Fill(ds2,"Paragelia_table");
            b2 = new BindingSource();
            b2.DataSource = ds2.Tables[0].DefaultView;
            textBox14.DataBindings.Add(new Binding("Text", b2, "KOD_PAR", true));
            textBox15.DataBindings.Add(new Binding("Text", b2, "HMER_PARAGELIAS", true));
            textBox16.DataBindings.Add(new Binding("Text", b2, "K_PEL", true));
            textBox17.DataBindings.Add(new Binding("Text", b2, "TROPOS_PLHROMHS", true));
            textBox18.DataBindings.Add(new Binding("Text", b2, "TOPOS_PARADOSHS", true));
            bindingNavigator2.BindingSource = b2;


            da3 = new SqlDataAdapter("Select * from APOTHIKI", conn);
            ds3 = new DataSet();
            b3 = new BindingSource();
            da3.Fill(ds3, "Apothiki_table");
            b3.DataSource = ds3.Tables[0].DefaultView;
            textBox19.DataBindings.Add(new Binding("Text", b3, "KE", true));
            textBox20.DataBindings.Add(new Binding("Text", b3, "EIDOS", true));
            textBox21.DataBindings.Add(new Binding("Text", b3, "KATHGORIA", true));
            textBox22.DataBindings.Add(new Binding("Text", b3, "APOTHEMA", true));
            textBox23.DataBindings.Add(new Binding("Text", b3, "TIMH_POLHSHS", true));
            textBox24.DataBindings.Add(new Binding("Text", b3, "FPA", true));
            bindingNavigator3.BindingSource = b3;

            da4 = new SqlDataAdapter("Select * from PROIONTA_PARAGELIAS", conn);
            ds4 = new DataSet();
            da4.Fill(ds4, "PROIONTA_PARAGELIAS_TABLE");
            b4 = new BindingSource();
            b4.DataSource = ds4.Tables[0].DefaultView;
            textBox25.DataBindings.Add(new Binding("Text", b4, "K_PAR", true));
            textBox26.DataBindings.Add(new Binding("Text", b4, "K_E", true));
            textBox27.DataBindings.Add(new Binding("Text", b4, "POSOTHTA", true));
            bindingNavigator4.BindingSource = b4;
        }



        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=DESKTOP-RM0NF38;Initial Catalog=APOTHIKI_4293;Integrated Security=True");
            conn.Open();
        }

        private void Label16_Click(object sender, EventArgs e)
        {

        }
    }
}
