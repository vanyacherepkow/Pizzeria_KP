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
    public partial class Klients : Form
    {
        Podkl_Bazi _PB = new Podkl_Bazi();
        Procedures _Proc = new Procedures();
        Vivod _V = new Vivod();
        public Klients()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Menu Form = new Main_Menu();
            Form.Show();
        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_AutoSizeRowsModeChanged(object sender, DataGridViewAutoSizeModeEventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _Proc.Klient_add(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text,textBox5.Text);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            grid_Load();
        }
        

        private void button4_Click(object sender, EventArgs e)
        {
            _Proc.Klient_edit(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()), textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            grid_Load();
        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            _Proc.Klient_delete(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            grid_Load();
        }

        private void grid_Load()
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            _V.vivod_sotr();
            dataGridView1.DataSource = Program.Vivodklients;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.Columns[0].Visible = false;
            _PB.Connection.Close();
            if (Program.AdminAccess == 1)
            {
                button2.Enabled = true;
            }
        }

        private void Klients_Load(object sender, EventArgs e)
        {
            grid_Load();
        }
    }
}
