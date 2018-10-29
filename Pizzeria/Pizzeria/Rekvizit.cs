using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizzeria
{
    public partial class Rekvizit : Form
    {
        Podkl_Bazi _PB = new Podkl_Bazi();
        Vivod _Viv = new Vivod();
        Procedures _Proc = new Procedures();
        public Rekvizit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Menu Form = new Main_Menu();
            Form.Show();
        }

        private void Rekvizit_Load(object sender, EventArgs e)
        {
            rekvizit_load();
            sotridnik_rekvizit_load();
        }

        private void rekvizit_load()
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            _Viv.vivod_rekvizit();
            dataGridView1.DataSource = Program.VivodRekvizit;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            _PB.Connection.Close();
        }

        private void sotridnik_rekvizit_load()
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            _Viv.vivod_rekvizit();
            dataGridView2.DataSource = Program.VivodSotrRekv;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            _PB.Connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _Proc.rekvizit_add(textBox1.Text, Convert.ToInt32(textBox2.Text));
            textBox1.Text = "";
            textBox2.Text = "";
            rekvizit_load();
        }
    }
}
