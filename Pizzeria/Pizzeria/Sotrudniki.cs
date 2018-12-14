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
using Crypt;

namespace Pizzeria
{
    public partial class Sotrudniki : Form
    {
        int id;
        Podkl_Bazi _PB = new Podkl_Bazi();
        public Crypt_Class Crpt = new Crypt_Class();
        Vivod _Viv = new Vivod();
        Procedures _Proc = new Procedures();
        public Sotrudniki()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
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
            dataGridView1.Columns[0].Visible = false;
            if (Program.AdminAccess == 1)
            {
                dataGridView1.Columns[5].Visible = true;
                dataGridView1.Columns[6].Visible = true;
                dataGridView1.Columns[7].Visible = true;
                dataGridView1.Columns[8].Visible = true;
                dataGridView1.Columns[9].Visible = true;
                dataGridView1.Columns[10].Visible = true;
                dataGridView1.Columns[11].Visible = true;
                dataGridView1.Columns[12].Visible = true;
                dataGridView1.Columns[13].Visible = true;
                dataGridView1.Columns[14].Visible = true;
            }
            else
            {
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[13].Visible = false;
                dataGridView1.Columns[14].Visible = false;

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
            _Proc.sotrudniki_add(textBox1.Text,textBox2.Text,textBox3.Text,Crpt.code_text(textBox4.Text),Dost_Prog, Convert.ToInt32(textBox5.Text), Convert.ToInt32(comboBox1.SelectedIndex),Admin_Access);
            Sotrudnikik_load();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox4.Text = Crpt.de_code_text(dataGridView1.CurrentRow.Cells[5].Value.ToString());
                if (Convert.ToInt32(dataGridView1.CurrentRow.Cells[7].Value.ToString()) == 1)
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }
                textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                comboBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                if (Convert.ToInt32(dataGridView1.CurrentRow.Cells[8].Value.ToString()) == 1)
                {
                    checkBox2.Checked = true;
                }
                else
                {
                    checkBox2.Checked = false;
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    int Admin_Access;
                    int System_Access;
                    _PB.Set_Connection();
                    _PB.Connection.Open();
                    SqlCommand sotr_edit = new SqlCommand("update Sotrudnik set Fam_Sotr = @Fam_Sotr, Im_Sotr = @Im_Sotr,Otch_Sotr = @Otch_Sotr,Password = @Password,System_Access=@System_Access,kol_vo_rek_za_kot_otv_sotr=@kol_vo_rek_za_kot_otv_sotr ,Dolj_ID = @Dolj_ID, Admin_Access=@Admin_Access where id_sotr = @ID_Sotr", _PB.Connection);
                    sotr_edit.Parameters.AddWithValue("@Fam_Sotr", textBox1.Text);
                    sotr_edit.Parameters.AddWithValue("@Im_Sotr", textBox2.Text);
                    sotr_edit.Parameters.AddWithValue("@Otch_Sotr", textBox3.Text);
                    sotr_edit.Parameters.AddWithValue("@Password", Crpt.code_text(textBox4.Text));
                    sotr_edit.Parameters.AddWithValue("@kol_vo_rek_za_kot_otv_sotr", Convert.ToInt32(textBox5.Text));
                    sotr_edit.Parameters.AddWithValue("@Dolj_ID", (comboBox1.SelectedIndex + 1));
                    if (checkBox2.Checked)
                    {
                        Admin_Access = 1;
                    }
                    else
                    {
                        Admin_Access = 0;
                    }
                    if (checkBox2.Checked)
                    {
                        System_Access = 1;
                    }
                    else
                    {
                        System_Access = 0;
                    }
                    sotr_edit.Parameters.AddWithValue("@Admin_Access", (Admin_Access));
                    sotr_edit.Parameters.AddWithValue("@System_Access", (System_Access));
                    sotr_edit.Parameters.AddWithValue("@ID_Sotr", id);
                    sotr_edit.ExecuteNonQuery();
                    _PB.Connection.Close();
                    MessageBox.Show("Данные успешно изменены");
                    Sotrudnikik_load();
                }
           
            }
            catch
            {
                MessageBox.Show("Возникла ошибка, перепроверьте данные");
            }
        }
    }
}
