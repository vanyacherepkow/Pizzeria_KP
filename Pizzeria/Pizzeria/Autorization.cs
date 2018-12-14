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
    public partial class Autorization : Form
    {
        public Autorization()
        {
            InitializeComponent();
        }
        public string id_identificator = "select [dbo].[Sotrudnik].[id_sotr] from [dbo].[Sotrudnik] inner join [dbo].[Dolj] on [dbo].[Dolj].[id_Dolj]=[dbo].[Sotrudnik].[Dolj_id] inner join [dbo].[Dost_v_prog] on [dbo].[Dolj].[dostup_id]=[dbo].[Dost_v_prog].[Id_dostup] where [Sotrudnik].[Password]='";
        public string Password = "select [dbo].[Sotrudnik].[Password] from [dbo].[Dolj] inner join [dbo].[Dost_v_prog] on [dbo].[Dost_v_prog].[id_dostup]=[dbo].[Dolj].[dostup_id] inner join [dbo].[Sotrudnik] on [dbo].[Dolj].[ID_Dolj]=[dbo].[Sotrudnik].[Dolj_id] where [Sotrudnik].[id_Sotr]=";
        public string Prog_access = "select[dbo].[Sotrudnik].[System_access] from[dbo].[Sotrudnik] inner join[dbo].[Dolj] on[dbo].[Dolj].[id_Dolj]=[dbo].[Sotrudnik].[Dolj_id] inner join[dbo].[Dost_v_Prog] on[dbo].[Dolj].[dostup_id]=[dbo].[Dost_v_prog].[Id_dostup] where [Sotrudnik].[id_Sotr]=";
        public string Rekvezit_access = "select [dbo].[Dost_V_Prog].[Rekvizit] from [dbo].[Dost_V_Prog] inner join [dbo].[Dolj]on [dbo].[Dost_v_prog].[id_dostup]=[dbo].[Dolj].[dostup_id] inner join [dbo].[Sotrudnik] on [dbo].[Sotrudnik].[Dolj_id]=[dbo].[Dolj].[ID_Dolj] where [Sotrudnik].[id_Sotr]=";
        public string Zakaz_V_Zale_access = "select [dbo].[Dost_V_Prog].[zakaz_v_zale] from [dbo].[Dost_V_Prog] inner join [dbo].[Dolj]on [dbo].[Dost_v_prog].[id_dostup]=[dbo].[Dolj].[dostup_id] inner join [dbo].[Sotrudnik] on [dbo].[Sotrudnik].[Dolj_id]=[dbo].[Dolj].[ID_Dolj] where [Sotrudnik].[id_Sotr]=";
        public string Zakaz_Na_dost_access = "select [dbo].[Dost_V_Prog].[zakaz_na_dost] from [dbo].[Dost_V_Prog] inner join [dbo].[Dolj]on [dbo].[Dost_v_prog].[id_dostup]=[dbo].[Dolj].[dostup_id] inner join [dbo].[Sotrudnik] on [dbo].[Sotrudnik].[Dolj_id]=[dbo].[Dolj].[ID_Dolj] where [Sotrudnik].[id_Sotr]=";
        public string Klients_access = "select [dbo].[Dost_V_Prog].[Klients] from [dbo].[Dost_V_Prog] inner join [dbo].[Dolj]on [dbo].[Dost_v_prog].[id_dostup]=[dbo].[Dolj].[dostup_id] inner join [dbo].[Sotrudnik] on [dbo].[Sotrudnik].[Dolj_id]=[dbo].[Dolj].[ID_Dolj] where [Sotrudnik].[id_Sotr]=";
        public string Sotrudniki_access = "select [dbo].[Dost_V_Prog].[Sotrudniki] from [dbo].[Dost_V_Prog] inner join [dbo].[Dolj]on [dbo].[Dost_v_prog].[id_dostup]=[dbo].[Dolj].[dostup_id] inner join [dbo].[Sotrudnik] on [dbo].[Sotrudnik].[Dolj_id]=[dbo].[Dolj].[ID_Dolj] where [Sotrudnik].[id_Sotr]=";
        public string Eda_access = "select [dbo].[Dost_V_Prog].[eda] from [dbo].[Dost_V_Prog] inner join [dbo].[Dolj]on [dbo].[Dost_v_prog].[id_dostup]=[dbo].[Dolj].[dostup_id] inner join [dbo].[Sotrudnik] on [dbo].[Sotrudnik].[Dolj_id]=[dbo].[Dolj].[ID_Dolj] where [Sotrudnik].[id_Sotr]=";
        public string Admin_access = "select[dbo].[Sotrudnik].[Admin_access] from[dbo].[Sotrudnik] inner join[dbo].[Dolj] on[dbo].[Dolj].[id_Dolj]=[dbo].[Sotrudnik].[Dolj_id] inner join[dbo].[Dost_v_Prog] on[dbo].[Dolj].[dostup_id]=[dbo].[Dost_v_prog].[Id_dostup] where [Sotrudnik].[id_Sotr]=";
        public string Ingridients_access = "select [dbo].[Dost_V_Prog].[ingridients] from [dbo].[Dost_V_Prog] inner join [dbo].[Dolj]on [dbo].[Dost_v_prog].[id_dostup]=[dbo].[Dolj].[dostup_id] inner join [dbo].[Sotrudnik] on [dbo].[Sotrudnik].[Dolj_id]=[dbo].[Dolj].[ID_Dolj] where [Sotrudnik].[id_Sotr]=";
        private Podkl_Bazi _PB;
        private SqlCommand _ComandaSQL;
        public Crypt_Class Crpt = new Crypt_Class();

        public void Vhod(string password_BD)
        {
            try
            {
                _PB = new Podkl_Bazi();
                _PB.Set_Connection();
                _ComandaSQL = new SqlCommand(id_identificator + password_BD + "'", _PB.Connection);
                _PB.Connection.Open();
                Program.identificator = Convert.ToInt32(_ComandaSQL.ExecuteScalar().ToString());
                switch (Program.identificator)
                {
                    case (0):
                        MessageBox.Show("У вас нет доступа к этой системе!");
                        break;
                    default:
                        _PB = new Podkl_Bazi();
                        _PB.Set_Connection();
                        _PB.Connection.Open();
                        Program.Systemaccess = Convert.ToInt32(_ComandaSQL.ExecuteScalar().ToString());
                        SqlCommand PassSotrCmd = new SqlCommand(Password + Program.identificator, _PB.Connection);
                        SqlCommand ProgAccessCmd = new SqlCommand(Prog_access + Program.identificator, _PB.Connection);
                        SqlCommand IngridientsAccessCmd = new SqlCommand(Ingridients_access + Program.identificator, _PB.Connection);
                        SqlCommand EdaAccessCmd = new SqlCommand(Eda_access + Program.identificator, _PB.Connection);
                        SqlCommand SotrudnikiAccessCmd = new SqlCommand(Sotrudniki_access + Program.identificator, _PB.Connection); ;
                        SqlCommand KlientsAccessCmd = new SqlCommand(Klients_access + Program.identificator, _PB.Connection); ;
                        SqlCommand RekvizitAccessCmd = new SqlCommand(Rekvezit_access + Program.identificator, _PB.Connection); ;
                        SqlCommand ZakazVZaleCmd = new SqlCommand(Zakaz_V_Zale_access + Program.identificator, _PB.Connection); ;
                        SqlCommand ZakazNaDostCmd = new SqlCommand(Zakaz_Na_dost_access + Program.identificator, _PB.Connection);
                        SqlCommand AdminAccessCmd = new SqlCommand(Admin_access + Program.identificator, _PB.Connection);
                        Program.ProgAccess = Convert.ToInt32(ProgAccessCmd.ExecuteScalar().ToString());
                        Program.IngridientsAccess = Convert.ToInt32(IngridientsAccessCmd.ExecuteScalar().ToString());
                        Program.EdaAccess = Convert.ToInt32(EdaAccessCmd.ExecuteScalar().ToString());
                        Program.SotrudnikiAccess = Convert.ToInt32(SotrudnikiAccessCmd.ExecuteScalar().ToString());
                        Program.KlientsAccess = Convert.ToInt32(KlientsAccessCmd.ExecuteScalar().ToString());
                        Program.RekvizitAccess = Convert.ToInt32(RekvizitAccessCmd.ExecuteScalar().ToString());
                        Program.ZakazVZale = Convert.ToInt32(ZakazVZaleCmd.ExecuteScalar().ToString());
                        Program.ZakazNaDost = Convert.ToInt32(ZakazNaDostCmd.ExecuteScalar().ToString());
                        Program.AdminAccess = Convert.ToInt32(AdminAccessCmd.ExecuteScalar().ToString());
                        Program.Value = true;
                        _PB.Connection.Close();
                        break;
                }
                _PB.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (textBox1.Text == "")
            {
                case (true):
                    {
                        MessageBox.Show("Вы не ввели пароль, пожалуйста введите пароль");
                    }
                    break;//Проверка на пустое поле ввода пароля и отсутствие данных в реестре
                case (false):
                    {
                        Vhod(Crpt.code_text(textBox1.Text));

                        switch (Program.ProgAccess)
                        {
                            case (0):
                                MessageBox.Show("Пользователя с таким паролем нет в базе, введите другой пароль!");
                                break;//Проверка на наличие пользователя в базе
                            case (1):
                                {

                                    this.Close();
                                    Main_Menu Form = new Main_Menu();
                                    Form.Show();
                                    
                                    break;//скрытие данной формы и открытие главного меню
                                    
                                }
                        }
                        break;
                    }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.UseSystemPasswordChar = false;
            }
            else
            {
                textBox1.PasswordChar = '*';
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Text = "Скрыть пароль";
                textBox1.PasswordChar = (char)0;
            }
            else
            {
                
                checkBox1.Text = "Показать пароль";
                textBox1.PasswordChar = '*';
            }
        }
    }
}
