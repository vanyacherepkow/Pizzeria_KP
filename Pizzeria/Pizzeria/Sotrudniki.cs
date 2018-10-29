using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Pizzeria
{
    public partial class Sotrudniki : Form
    {
        Podkl_Bazi _PB = new Podkl_Bazi();
        Vivod _Viv = new Vivod();
        Procedures _Proc = new Procedures();
        public Sotrudniki()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Menu Form = new Main_Menu();
            Form.Show();
        }
        public void Sotrudnikik_load()
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            _Viv.vivod_sotrudnik_obj();
            dataGridView1.DataSource = Program.VivodSotrobj;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            if (Program.AdminAccess == 1)
            {
                dataGridView1.Columns[4].Visible = true;
                dataGridView1.Columns[5].Visible = true;
                dataGridView1.Columns[6].Visible = true;
                dataGridView1.Columns[7].Visible = true;
                dataGridView1.Columns[8].Visible = true;
                dataGridView1.Columns[9].Visible = true;
                dataGridView1.Columns[10].Visible = true;
                dataGridView1.Columns[11].Visible = true;
                dataGridView1.Columns[12].Visible = true;
                dataGridView1.Columns[13].Visible = true;
            }
            else
            {
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[13].Visible = false;

            }
            _PB.Connection.Close();
        }

            private void Sotrudniki_Load(object sender, EventArgs e)
        {
            Sotrudnikik_load();
            _PB.Connection.Close();
            try
            {
                _PB.Set_Connection();
                SqlCommand sss = new SqlCommand("select [nazv_Dolj] from [dbo].[Dolj]", _PB.Connection);
                _PB.Connection.Open();
                SqlDataReader dr = sss.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                foreach (DataRow r in dt.Rows)
                {
                    comboBox1.Items.Add(r[0]);
                }
                _PB.Connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Sotrudniki_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int Admin_Access;
            int Dost_Prog;
                if (checkBox1.Checked)
            {
                Dost_Prog = 1;
            }
            else
            {
                Dost_Prog = 0;
            }
            if (checkBox1.Checked)
            {
                Admin_Access = 1;
            }
            else
            {
                Admin_Access = 0;
            }
            _Proc.sotrudniki_add(textBox1.Text,textBox2.Text,textBox3.Text,textBox4.Text,Dost_Prog, Convert.ToInt32(textBox5.Text), Convert.ToInt32(comboBox1.SelectedIndex),Admin_Access);
            Sotrudnikik_load();
        }
    }
}
