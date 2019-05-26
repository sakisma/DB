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
using System.IO;
namespace DBPROJECT1
{
    public partial class Form1 : Form
    {
        SqlConnection conn;
        SqlDataAdapter da1, da2, da3, da4;
        DataSet ds1, ds2, ds3, ds4;
        BindingSource b1, b2, b3, b4;
        SqlCommandBuilder cmdbl;
        SqlCommand command,command1;

        private void SaveToolStripButton1_Click(object sender, EventArgs e)
        {
            cmdbl = new SqlCommandBuilder(da2);
            da2.Update(ds2, "Paragelia_table");
            MessageBox.Show("Information Updated");
        }

        private void BindingNavigator1_RefreshItems(object sender, EventArgs e)
        {
            refreshImage();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            String openPath;
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openPath = openFileDialog1.InitialDirectory +
                    openFileDialog1.FileName;
                textBox12.Text = openPath;
                pictureBox1.Image = Image.FromFile(openPath);
                command = new SqlCommand("update PELATHS set FOTO = '" + openPath + "' where KOD_PELATH=" + textBox1.Text + ";", conn);
                command.ExecuteNonQuery();
            }
        }


        private void Button4_Click(object sender, EventArgs e)
        {
            String path;
            if(openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog2.InitialDirectory + openFileDialog2.FileName;
                textBox28.Text = path;
                pictureBox2.Image = Image.FromFile(path);
                command1 = new SqlCommand("UPDATE APOTHIKI set PHOTO = '" + path + "' where KE= " + textBox19.Text + ";", conn);
                command1.ExecuteNonQuery();
            }
        }

        private void BindingNavigator3_RefreshItems(object sender, EventArgs e)
        {
            refreshImage2();
        }

        private void SaveToolStripButton2_Click_1(object sender, EventArgs e)
        {
            cmdbl = new SqlCommandBuilder(da3);
            da3.Update(ds3, "Apothiki_table");
            MessageBox.Show("Information Updated");
        }

        private void TabControl1_Click(object sender, EventArgs e)
        {
            refreshImage2();
        }

        private void TabPage1_Click(object sender, EventArgs e)
        {

        }

        private void SaveToolStripButton3_Click(object sender, EventArgs e)
        {
            cmdbl = new SqlCommandBuilder(da4);
            da4.Update(ds4, "PROIONTA_PARAGELIAS_TABLE");
            MessageBox.Show("Information Updated");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
        }

        private void SaveToolStripButton_Click(object sender, EventArgs e)
        {
            cmdbl = new SqlCommandBuilder(da1);
            da1.Update(ds1,"Pelaths_Table");
            MessageBox.Show("Information Updated");
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }

        public void fillDataPelaths()
        {
            da1 = new SqlDataAdapter("Select * from PELATHS", conn);
            ds1 = new DataSet();
            da1.Fill(ds1, "Pelaths_Table");
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
        }

        public void fillDataParagelia()
        {
            da2 = new SqlDataAdapter("Select * from PARAGELIA", conn);
            ds2 = new DataSet();
            da2.Fill(ds2, "Paragelia_table");
            b2 = new BindingSource();
            b2.DataSource = ds2.Tables[0].DefaultView;
            textBox14.DataBindings.Add(new Binding("Text", b2, "KOD_PAR", true));
            textBox15.DataBindings.Add(new Binding("Text", b2, "HMER_PARAGELIAS", true));
            textBox16.DataBindings.Add(new Binding("Text", b2, "K_PEL", true));
            textBox17.DataBindings.Add(new Binding("Text", b2, "TROPOS_PLHROMHS", true));
            textBox18.DataBindings.Add(new Binding("Text", b2, "TOPOS_PARADOSHS", true));
            bindingNavigator2.BindingSource = b2;
        }

        public void fillDataApothiki()
        {
            da3 = new SqlDataAdapter("Select * from APOTHIKI", conn);
            ds3 = new DataSet();
            da3.Fill(ds3, "Apothiki_table");
            b3 = new BindingSource();
            b3.DataSource = ds3.Tables[0].DefaultView;
            textBox19.DataBindings.Add(new Binding("Text", b3, "KE", true));
            textBox20.DataBindings.Add(new Binding("Text", b3, "EIDOS", true));
            textBox21.DataBindings.Add(new Binding("Text", b3, "KATHGORIA", true));
            textBox22.DataBindings.Add(new Binding("Text", b3, "APOTHEMA", true));
            textBox23.DataBindings.Add(new Binding("Text", b3, "TIMH_POLHSHS", true));
            textBox24.DataBindings.Add(new Binding("Text", b3, "FPA", true));
            textBox28.DataBindings.Add(new Binding("Text", b3, "PHOTO", true));
            bindingNavigator3.BindingSource = b3;
        }

        public void fillDataProiontaParagelias()
        {
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

        private void Form1_Load(object sender, EventArgs e)
        {
            fillDataPelaths();
            fillDataParagelia();
            fillDataApothiki();
            fillDataProiontaParagelias();
            refreshImage();
        }

        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=DESKTOP-RM0NF38;Initial Catalog=APOTHIKI_4293;Integrated Security=True");
            conn.Open();
        }


        public void refreshImage()
        {
            String photoPath = textBox12.Text.Trim();
            if(photoPath != null && File.Exists(photoPath))
            {
                pictureBox1.Image = Image.FromFile(photoPath);
            }
            else
            {
                pictureBox1.Image = Image.FromFile("C:/Users/sakis/Pictures/Null.jpg");
            }
        }


        public void refreshImage2()
        {
            String photoPath2 = textBox28.Text.Trim();
            if (photoPath2 != null && File.Exists(photoPath2))
            {
                pictureBox2.Image = Image.FromFile(photoPath2);
            }
            else
            {
                pictureBox2.Image = Image.FromFile("C:/Users/sakis/Pictures/Null.jpg");
            }
        }

        private void Label16_Click(object sender, EventArgs e)
        {

        }
    }
}
