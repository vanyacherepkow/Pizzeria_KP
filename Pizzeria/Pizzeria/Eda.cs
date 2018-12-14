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
    public partial class Eda : Form
    {
        private SqlCommand _ComandaSQL = new SqlCommand();
        Podkl_Bazi _PB = new Podkl_Bazi();
        Vivod _V = new Vivod();
        public int eda_vibor;
        public Eda()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            _V.vivod_eda();
            dataGridView1.DataSource = Program.VivodEdaVEda;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.Columns[0].Visible = false;
            eda_vibor = 1;
            _PB.Connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            _V.vivod_napitki();
            dataGridView1.DataSource = Program.VivodNapitokVEda;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.Columns[0].Visible = false;
            eda_vibor = 2;
            _PB.Connection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            _V.vivod_pizza();
            dataGridView1.DataSource = Program.VivodPizzaVEda;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.Columns[0].Visible = false;
            eda_vibor = 3;
            _PB.Connection.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Main_Menu Form = new Main_Menu();
            Form.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (eda_vibor)
            {
                case (1):
                    textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    break;
                case (2):
                    textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    _PB.Set_Connection();
                    SqlCommand sss = new SqlCommand("select [obem] from [dbo].[obem_napitka]", _PB.Connection);
                    _PB.Connection.Open();
                    SqlDataReader dr = sss.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    foreach (DataRow r in dt.Rows)
                    {
                        comboBox1.Items.Add(r[0]);
                    }
                    _PB.Connection.Close();//Вывод столбца из таблицы в Combobox

                    break;
                case (3):
                    textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    _PB.Set_Connection();
                    SqlCommand sss1 = new SqlCommand("select [razmer] from [dbo].[razmer_pizza]", _PB.Connection);
                    _PB.Connection.Open();
                    SqlDataReader dr1 = sss1.ExecuteReader();
                    DataTable dt1 = new DataTable();
                    dt1.Load(dr1);
                    foreach (DataRow r in dt1.Rows)
                    {
                        comboBox1.Items.Add(r[0]);
                    }
                    _PB.Connection.Close();//Вывод столбца из таблицы в Combobox

                    break;
            }

        }
        public void eda_edit(int ID, string NaimBlud, int CenaBluda)
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand eda_edit = new SqlCommand("eda_edit", _PB.Connection);

            eda_edit.CommandType = CommandType.StoredProcedure;
            eda_edit.Parameters.AddWithValue("@ID_eda", ID);
            eda_edit.Parameters.AddWithValue("@Naim_Blud", NaimBlud);
            eda_edit.Parameters.AddWithValue("@Im_Klient", CenaBluda);
            eda_edit.ExecuteNonQuery();
            SqlCommand EdaEditCmd = new SqlCommand("Select Fam_Klient as 'Фамилия клиента', Im_Klient as 'Имя клиента', Otch_Klient as 'Отчество клиента', Tel_Klient as 'Телефон клиента', Adres_Klient as 'Адрес клиента' from [dbo].[Klient]", _PB.Connection);
            SqlDataReader TableReader = EdaEditCmd.ExecuteReader();
            DataTable Table = new DataTable();
            Table.Load(TableReader);
            dataGridView1.DataSource = Table;
            dataGridView1.Columns[0].Visible = false;
            _PB.Connection.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
        }
    }
}
