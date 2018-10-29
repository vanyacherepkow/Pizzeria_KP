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
using Microsoft.Office.Interop.Word;

namespace Pizzeria
{
    public partial class Zal : Form
    {
        Podkl_Bazi _PB = new Podkl_Bazi();
        Vivod _Viv = new Vivod();
        Procedures _Proc = new Procedures();
        int eda_vibor;
        public Zal()
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
                eda_vibor = 1;
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
            eda_vibor = 2;
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
            eda_vibor = 3;
            dataGridView1.Columns[0].Visible = false;
            _PB.Connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            int Summa;
            
            switch (eda_vibor)
            {
                case (3):
                    _Proc.zakaz_v_zale_form_eda_add(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()), Convert.ToInt32(numericUpDown1.Value.ToString()), Program.CenaVZale * Convert.ToInt32(numericUpDown1.Value.ToString()), Program.Num_Check);
                    textBox1.Text = "";
                    Program.CenaVZale = 0;
                    string Eda_Check = (dataGridView1.CurrentRow.Cells[1].Value.ToString() + " " + dataGridView1.CurrentRow.Cells[2].Value.ToString()).ToString();
                    listBox1.Items.Add(Eda_Check.ToString());
                    break;
                case (2):
                    _Proc.zakaz_v_zale_form_napitok_add(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()), Convert.ToInt32(numericUpDown1.Value.ToString()), Program.CenaVZale * Convert.ToInt32(numericUpDown1.Value.ToString()), Program.Num_Check);
                    textBox1.Text = "";
                    string Napitok_Check = (dataGridView1.CurrentRow.Cells[1].Value.ToString()+ " "+ dataGridView1.CurrentRow.Cells[3].Value.ToString()).ToString();
                    listBox1.Items.Add(Napitok_Check.ToString());
                    Program.CenaVZale = 0;
                    break;
                case (1):
                    _Proc.zakaz_v_zale_form_pizza_add(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()), Convert.ToInt32(numericUpDown1.Value.ToString()), Program.CenaVZale * Convert.ToInt32(numericUpDown1.Value.ToString()), Program.Num_Check);
                    textBox1.Text = "";
                    string Pizza_Check = (dataGridView1.CurrentRow.Cells[1].Value.ToString() + " " + dataGridView1.CurrentRow.Cells[3].Value.ToString()).ToString();
                    listBox1.Items.Add(Pizza_Check.ToString());
                    Program.CenaVZale = 0;
                    break;

                    
            }
            SqlCommand SummaSql = new SqlCommand("SELECT SUM([dbo].[zakaz_v_zale].[itog_cena_v_zale]) FROM [dbo].[zakaz_v_zale] where [dbo].[zakaz_v_zale].[tov_check_v_zale_id]=" + Program.Num_Check.ToString(), _PB.Connection);
            Summa = Convert.ToInt32(SummaSql.ExecuteScalar());
            label1.Text = "Итоговая цена:" + Summa;
            _PB.Connection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            _Proc.tov_check_zakaz_v_zale_add(Program.identificator, DateTime.Now);
            _Viv.NumCheck();
            groupBox2.Text = ("Заказ №" + Program.Num_Check.ToString());
            _PB.Connection.Close();
            button3.Visible = false;
            
        }

        private void Zal_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Program.CenaVZale= Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button3.Visible = true;
            groupBox1.Visible = false;
        }
    }
    }


