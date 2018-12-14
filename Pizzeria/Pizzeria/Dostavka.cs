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
    public partial class Dostavka : Form
    {
        Podkl_Bazi _PB = new Podkl_Bazi();
        Vivod _Viv = new Vivod();
        Procedures _Proc = new Procedures();
        int zakaz_vibor;
        int VibKli;
        int VibKur;
        public Dostavka()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Main_Menu Form = new Main_Menu();
            Form.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            _PB.Set_Connection();
            _PB.Connection.Open();
            _Viv.vivod_pizza();
            dataGridView1.DataSource = Program.VivodPizzaVEda;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            zakaz_vibor = 1;
            dataGridView1.Columns[0].Visible = false;
            _PB.Connection.Close();
        }



        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            _Viv.vivod_napitki();
            dataGridView1.DataSource = Program.VivodNapitokVEda;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            zakaz_vibor = 2;
            dataGridView1.Columns[0].Visible = false;
            _PB.Connection.Close();

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            _Viv.vivod_eda();
            dataGridView1.DataSource = Program.VivodEdaVEda;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            zakaz_vibor = 3;
            dataGridView1.Columns[0].Visible = false;
            _PB.Connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            int Summa;

            switch (zakaz_vibor)
            {
                case (3):
                    _Proc.zakaz_na_dost_form_eda_add(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()), Convert.ToInt32(numericUpDown1.Value.ToString()), Program.CenaZaDost * Convert.ToInt32(numericUpDown1.Value.ToString()), Program.Num_Check_za_dost);
                    textBox1.Text = "";
                    Program.CenaZaDost = 0;
                    string Eda_Check = (dataGridView1.CurrentRow.Cells[1].Value.ToString() + " " + dataGridView1.CurrentRow.Cells[2].Value.ToString()).ToString();
                    listBox1.Items.Add(Eda_Check.ToString());
                    break;
                case (2):
                    _Proc.zakaz_na_dost_form_napitok_add(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()), Convert.ToInt32(numericUpDown1.Value.ToString()), Program.CenaZaDost * Convert.ToInt32(numericUpDown1.Value.ToString()), Program.Num_Check_za_dost);
                    textBox1.Text = "";
                    string Napitok_Check = (dataGridView1.CurrentRow.Cells[1].Value.ToString() + " " + dataGridView1.CurrentRow.Cells[3].Value.ToString()).ToString();
                    listBox1.Items.Add(Napitok_Check.ToString());
                    Program.CenaZaDost = 0;
                    break;
                case (1):
                    _Proc.zakaz_na_dost_form_pizza_add(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()), Convert.ToInt32(numericUpDown1.Value.ToString()), Program.CenaZaDost * Convert.ToInt32(numericUpDown1.Value.ToString()), Program.Num_Check_za_dost);
                    textBox1.Text = "";
                    string Pizza_Check = (dataGridView1.CurrentRow.Cells[1].Value.ToString() + " " + dataGridView1.CurrentRow.Cells[3].Value.ToString()).ToString();
                    listBox1.Items.Add(Pizza_Check.ToString());
                    Program.CenaZaDost = 0;
                    break;


            }
            SqlCommand SummaSql = new SqlCommand("SELECT SUM([dbo].[zakaz_na_dost].[itog_cena_za_dost]) FROM [dbo].[zakaz_na_dost] where [dbo].[zakaz_na_dost].[tov_check_na_dost_id]=" + Program.Num_Check_za_dost.ToString(), _PB.Connection);
            Summa = Convert.ToInt32(SummaSql.ExecuteScalar());
            MessageBox.Show(Summa.ToString());
            label1.Text = "Итоговая цена:" + Summa;
            _PB.Connection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((VibKli != 0) & (VibKur != 0))
            {
                groupBox2.Visible = true;
                _Proc.tov_check_zakaz_na_dost_add(Program.identificator, VibKli, VibKur, DateTime.Now);
                _Viv.NumCheckZaDost();
                groupBox2.Text = ("Заказ №" + Program.Num_Check_za_dost.ToString());
                groupBox3.Visible = false;
                _PB.Connection.Close();
                button3.Visible = false;
            }
            else
            {
                MessageBox.Show("Одно из полей не заполнено. Пожалуйста заполните всё");
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Program.CenaZaDost = Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button3.Visible = true;
            groupBox3.Visible = true;
            groupBox1.Visible = false;
        }

        private void Dostavka_Load(object sender, EventArgs e)
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            _Viv.vivod_klient_dost();
            dataGridView2.DataSource = Program.VivodKliDost;
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            _Viv.vivod_kurer_dost();
            dataGridView3.DataSource = Program.VivodKurDost;
            dataGridView3.Columns[0].Visible = false;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView3.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            _PB.Connection.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Klients Form = new Klients();
            Form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
            Main_Menu Form = new Main_Menu();
            Form.Show();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            VibKur = Convert.ToInt32( dataGridView3.CurrentRow.Cells[0].Value.ToString());
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            VibKli = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
