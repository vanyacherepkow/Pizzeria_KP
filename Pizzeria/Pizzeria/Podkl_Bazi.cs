using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using Microsoft.Win32;
using System.Windows.Forms;
using Crypt;

namespace Pizzeria
{
    class Podkl_Bazi
    {
        public Crypt_Class Crpt = new Crypt_Class();
        public event Action<DataSet> List_Dbs;
        public event Action<bool> Status;
        public event Action<DataTable> List_Server;
        public static string DS;
        public static string IC;
        public static string UN;
        public static string UP;
        //Подключение базы 
        public SqlConnection Connection = new SqlConnection("Data Source=Empty; Initial Catalog = Empty;Persist Security Info=True; User ID=Empty; password =\"Empty\"");
        public void Register_get()
        {
            try
            {
                RegistryKey Pizza_Option = Registry.CurrentConfig;
                RegistryKey Pizzeria = Pizza_Option.CreateSubKey("Pizzeria");
                DS = Crpt.de_code_text(Pizzeria.GetValue("DS").ToString());
                IC = Crpt.de_code_text(Pizzeria.GetValue("IC").ToString());
                UN = Crpt.de_code_text(Pizzeria.GetValue("UN").ToString());
                UP = Crpt.de_code_text(Pizzeria.GetValue("UP").ToString());
                Set_Connection();
            }
            catch
            {
                RegistryKey Pizza_Option = Registry.CurrentConfig;
                RegistryKey Pizzeria = Pizza_Option.CreateSubKey("Pizzeria");
                Pizzeria.SetValue("DS", "Empty");
                Pizzeria.SetValue("IC", "Empty");
                Pizzeria.SetValue("UN", "Empty");
                Pizzeria.SetValue("UP", "Empty");
            }
        }
        public void Register_set(string DSvalue, string ICvalue, string UNvalue, string UPvalue)
        {
            RegistryKey Pizza_Option = Registry.CurrentConfig;
            RegistryKey Pizzeria = Pizza_Option.CreateSubKey("Pizzeria");
            Pizzeria.SetValue("DS", Crpt.code_text(DSvalue));
            Pizzeria.SetValue("IC", Crpt.code_text(ICvalue));
            Pizzeria.SetValue("UN", Crpt.code_text(UNvalue));
            Pizzeria.SetValue("UP", Crpt.code_text(UPvalue));

            Register_get();
        }

        public void Set_Connection()
        {
            Connection.ConnectionString = "Data Source=" + DS + ";" +
                "Initial Catalog=" + IC + ";" +
                "Persist Security Info=True; " +
                "User ID=" + UN + ";Password=\"" + UP + "\"";
        }
        public void Connection_State()
        {
            Register_get();
            try
            {
                Connection.Open();
                Status(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Status(false);
            }
        }//Проверка данных в реестре
        public void Get_Base_List()
        {
            try
            {
                SqlConnection GDtBsLstCn = new SqlConnection("Data Source=" + DS + ";Initial Catalog = master; Persist Security Info=True;User ID=" + UN + ";Password=\"" + UP + "\"");
                GDtBsLstCn.Open();
                SqlDataAdapter BsAdpt = new SqlDataAdapter("exec sp_helpdb", GDtBsLstCn);
                DataSet CPst = new DataSet();
                BsAdpt.Fill(CPst, "db");
                List_Dbs(CPst);
                Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //Получить список баз
        }
        public void poluchit_spis_serverov()
        {
            SqlDataSourceEnumerator ServersCheck = SqlDataSourceEnumerator.Instance;
            DataTable ServersTable = ServersCheck.GetDataSources();
            List_Server(ServersTable);
        }//Получение списка серверов
    }
}
