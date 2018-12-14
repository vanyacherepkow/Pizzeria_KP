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
    public partial class Ingridients : Form
    {
        public Ingridients()
        {
            InitializeComponent();
        }
        Podkl_Bazi _PB = new Podkl_Bazi();
        Vivod _Viv = new Vivod();

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Main_Menu Form = new Main_Menu();
            Form.Show();
        }

        private void Ingridients_Load(object sender, EventArgs e)
        {
            ingr_s_sklad_Load();
        }

        private void ingr_s_sklad_Load()
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            _Viv.vivod_ingr_s_sklada();
            dataGridView1.DataSource = Program.VivodSkladSIngr;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            _PB.Connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            _Viv.vivod_ingr_dla_bluda();
            dataGridView2.DataSource = Program.VivodEdaIngr;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            _PB.Connection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            _Viv.vivod_ingr_dla_pizza();
            dataGridView2.DataSource = Program.VivodPizzaIngr;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            _PB.Connection.Close();
        }
    }
}
