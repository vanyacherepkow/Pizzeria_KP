using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Data;

namespace Pizzeria
{
    class Vivod
    {
        Podkl_Bazi _PB = new Podkl_Bazi();
        public void vivod_sotr()
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand pizza1 = new SqlCommand("Select id_Klient,Fam_Klient as 'Фамилия клиента', Im_Klient as 'Имя клиента', Otch_Klient as 'Отчество клиента', Tel_Klient as 'Телефон клиента', Adres_Klient as 'Адрес клиента' from [dbo].[Klient]", _PB.Connection);
            SqlDataReader TableReader = pizza1.ExecuteReader();
            DataTable Table = new DataTable();
            Table.Load(TableReader);
            Program.Vivodklients = Table;
            _PB.Connection.Close();
        }

        public void vivod_eda()
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand pizza1 = new SqlCommand("Select id_eda as 'ID блюда', Naim_Blud as 'Наименование блюда', Cena_bluda as 'Цена блюда' from [dbo].[eda]", _PB.Connection);
            SqlDataReader TableReader = pizza1.ExecuteReader();
            DataTable Table = new DataTable();
            Table.Load(TableReader);
            Program.VivodEdaVEda = Table;
            _PB.Connection.Close();
        }

        public void vivod_napitki()
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand pizza1 = new SqlCommand("Select id_napitok as 'ID напитка', Nazv_Napitka as 'Наименование напитка', Cena_napitka as 'Цена напитка', obem as 'Объем напитка' from [dbo].[Napitok] inner join [dbo].[obem_napitka] on [dbo].[napitok].[obem_id]=[dbo].[obem_napitka].[id_obem]", _PB.Connection);
            SqlDataReader TableReader = pizza1.ExecuteReader();
            DataTable Table = new DataTable();
            Table.Load(TableReader);
            Program.VivodNapitokVEda = Table;
            _PB.Connection.Close();
        }

        public void vivod_pizza()
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand pizza1 = new SqlCommand("Select id_pizza as 'ID пиццы', Nazv_Pizza as 'Наименование пиццы', Cena_Pizza as 'Цена пиццы', razmer as Размер from [dbo].[pizza] inner join [dbo].[Razm_pizza] on [dbo].[pizza].[razm_id]=[dbo].[Razm_pizza].[id_razm]", _PB.Connection);
            SqlDataReader TableReader = pizza1.ExecuteReader();
            DataTable Table = new DataTable();
            Table.Load(TableReader);
            Program.VivodPizzaVEda = Table;
            _PB.Connection.Close();
        }
        public void vivod_ingr_s_sklada()
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand ingr = new SqlCommand("Select Nazv_ingr as 'Наименование ингридиента', kol_vo_ingr as 'Количество на складе' from [dbo].[sklad_s_ingrid]", _PB.Connection);
            SqlDataReader TableReader = ingr.ExecuteReader();
            DataTable Table = new DataTable();
            Table.Load(TableReader);
            Program.VivodSkladSIngr = Table;
            _PB.Connection.Close();
        }

        public void vivod_ingr_dla_pizza()
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand pizzaingr = new SqlCommand("Select Nazv_pizza as 'Наименование пиццы', Nazv_ingr as 'Наименование ингридиента' from [dbo].[sklad_s_ingrid] inner join [dbo].[pizza_ingr] on [dbo].[sklad_s_ingrid].[id_ingr]=[dbo].[pizza_ingr].[ingr_pizza_id] inner join [dbo].[pizza] on [dbo].[pizza].[id_pizza]=[dbo].[pizza_ingr].[pizza_ingr_id]", _PB.Connection);
            SqlDataReader TableReader =pizzaingr.ExecuteReader();
            DataTable Table = new DataTable();
            Table.Load(TableReader);
            Program.VivodPizzaIngr = Table;
            _PB.Connection.Close();
        }

        public void vivod_ingr_dla_bluda()
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand edaingr = new SqlCommand("Select Naim_blud as 'Наименование блюда', Nazv_ingr as 'Наименование ингридиента' from [dbo].[sklad_s_ingrid] inner join [dbo].[eda_ingr] on [dbo].[sklad_s_ingrid].[id_ingr]=[dbo].[eda_ingr].[ingr_eda_id] inner join [dbo].[eda] on [dbo].[eda].[id_eda]=[dbo].[eda_ingr].[eda_ingr_id]", _PB.Connection);
            SqlDataReader TableReader = edaingr.ExecuteReader();
            DataTable Table = new DataTable();
            Table.Load(TableReader);
            Program.VivodEdaIngr = Table;
            _PB.Connection.Close();
        }

        public void vivod_rekvizit()
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand rekvizit = new SqlCommand("Select Nazv_rekvizita as 'Наименование рекизита', Kolichestvo as 'Доступное количество' from [dbo].[Rekvizit]", _PB.Connection);
            SqlDataReader TableReader = rekvizit.ExecuteReader();
            DataTable Table = new DataTable();
            Table.Load(TableReader);
            Program.VivodRekvizit = Table;
            _PB.Connection.Close();
        }

        public void vivod_sotr_rekv()
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand sotrrekv = new SqlCommand("Select concat (Fam_Sotr, ' ', Im_Sotr,' ',Otch_Sotr) as 'ФИО сотрудника', Nazv_rekvizita as 'Наименование реквизита' from [dbo].[rekvizit] inner join [dbo].[sotr_rekv] on [dbo].[rekvizit].[id_rekvizit]=[dbo].[sotr_rekv].[rekvizit_id] inner join [dbo].[sotrudnik] on [dbo].[rekvizit].[id_rekvizit]=[dbo].[sotr_rekv].[sotr_v_rekv_id]", _PB.Connection);
            SqlDataReader TableReader = sotrrekv.ExecuteReader();
            DataTable Table = new DataTable();
            Table.Load(TableReader);
            Program.VivodSotrRekv = Table;
            _PB.Connection.Close();
        }
        public void vivod_sotrudnik_obj()
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand sotrobj = new SqlCommand("Select ID_Sotr,Fam_Sotr as 'Фамииля сотрудника', Im_Sotr as 'Имя сотрудника', Otch_Sotr as 'Отчество сотрудника', nazv_Dolj as 'Занимаемая должность', password as 'Пароль сотрудника', System_access as 'Доступ к системе', Admin_access as 'Доступ администратора', [dbo].[dost_v_prog].[sotrudniki] as 'Доступ к сотрудникам', " +
                "[dbo].[dost_v_prog].[Klients] as 'Доступ к клиентам', [dbo].[dost_v_prog].[zakaz_v_zale] as 'Досутп к заказу в зале', [dbo].[dost_v_prog].[zakaz_na_dost] as 'Досутп к заказе на доставку',  [dbo].[dost_v_prog].[ingridients] as 'Доступ к ингридиентам',  [dbo].[dost_v_prog].[eda] as 'Доступ к еде',  [dbo].[dost_v_prog].[rekvizit] as 'Досутп к реквизиту' from  " +
                "[dbo].[sotrudnik] inner join [dbo].[dolj] on [dbo].[sotrudnik].[dolj_id]=[dbo].[dolj].[id_dolj] inner join [dbo].[dost_v_prog] on  [dbo].[dost_v_prog].[id_dostup]=[dbo].[dolj].[dostup_id] ", _PB.Connection);
            SqlDataReader TableReader = sotrobj.ExecuteReader();
            DataTable Table = new DataTable();
            Table.Load(TableReader);
            Program.VivodSotrobj = Table;
            _PB.Connection.Close();
        }
        public void NumCheckVZale()
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand NumberCheck = new SqlCommand("select top 1 * from [tov_check_za_zakaz] order by id_tov_check_v_zale desc", _PB.Connection);
            Program.Num_Check_v_zale = Convert.ToInt32(NumberCheck.ExecuteScalar().ToString());
            _PB.Connection.Close();
        }

        public void NumCheckZaDost()
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand NumberCheck = new SqlCommand("select top 1 * from [tov_check_za_dost] order by id_tov_check_za_dost desc", _PB.Connection);
            Program.Num_Check_za_dost = Convert.ToInt32(NumberCheck.ExecuteScalar().ToString());
            _PB.Connection.Close();
        }


        public void vivod_klient_dost()
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand KliDost = new SqlCommand("Select id_Klient,concat(Fam_Klient,' ',Im_Klient,' ',Otch_Klient) as 'Клиент', Tel_Klient as 'Телефон клиента', Adres_Klient as 'Адрес клиента' from [dbo].[Klient]", _PB.Connection);
            SqlDataReader TableReader = KliDost.ExecuteReader();
            DataTable Table = new DataTable();
            Table.Load(TableReader);
            Program.VivodKliDost = Table;
            _PB.Connection.Close();
        }
        public void vivod_kurer_dost()
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand KurDost = new SqlCommand("Select id_sotr,concat(Fam_Sotr,' ',Im_Sotr,' ',Otch_Sotr) as 'Курьер'  from [dbo].[sotrudnik] inner join [dbo].[Dolj] on [dbo].[sotrudnik].[dolj_id]=[dbo].[Dolj].[id_dolj] where [dbo].[Dolj].[nazv_dolj]='Курьер' ", _PB.Connection);
            SqlDataReader TableReader = KurDost.ExecuteReader();
            //MessageBox.Show(TableReader.ToString());
            DataTable Table = new DataTable();
            Table.Load(TableReader);
            Program.VivodKurDost = Table;
            //MessageBox.Show(Program.Viv)
            _PB.Connection.Close();
            
        }
        public void Napitok_dost_lb()
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand List_Nap = new SqlCommand("select top 1 nazv_napitka from zakaz_na_dost inner join tov_check_za_dost  on tov_check_na_dost_id=id_tov_check_za_dost inner join napitok on id_napitok=napitok_v_dost_id  order by id_zakaz_na_dost desc", _PB.Connection);
            SqlDataReader TableReader = List_Nap.ExecuteReader();
            DataTable Table = new DataTable();
            Table.Load(TableReader);
            Program.VivodNapNADostLB = Table;
            _PB.Connection.Close();
        }
        public void Pizza_dost_lb()
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand List_Nap = new SqlCommand("select top 1 Nazv_pizza from zakaz_na_dost inner join tov_check_za_dost  on tov_check_na_dost_id=id_tov_check_za_dost inner join pizza on id_pizza=pizza_v_dost_id  order by id_zakaz_na_dost desc ", _PB.Connection);
            SqlDataReader TableReader = List_Nap.ExecuteReader();
            DataTable Table = new DataTable();
            Table.Load(TableReader);
            Program.VivodPizzaNADostLB = Table;
            _PB.Connection.Close();
        }
        public void Eda_dost_lb()
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand List_Nap = new SqlCommand("select top 1 naim_blud from zakaz_na_dost inner join tov_check_za_dost  on tov_check_na_dost_id=id_tov_check_za_dost inner join eda on id_eda=eda_v_dost_id  order by id_zakaz_na_dost desc", _PB.Connection);
            SqlDataReader TableReader = List_Nap.ExecuteReader();
            DataTable Table = new DataTable();
            Table.Load(TableReader);
            Program.VivodEdaNADostLB = Table;
            _PB.Connection.Close();
        }
        public void Napitok_zal_lb()
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand List_Nap_zal = new SqlCommand("select top 1 concat(kol_vo_za_poz_v_zale,' ', Nazv_napitka,' ',itog_cena_v_zale) from zakaz_v_zale inner join tov_check_za_zakaz  on tov_check_v_zale_id=id_tov_check_v_zale inner join napitok on id_napitok=napitok_v_zale_id  order by id_zakaz_v_zale desc", _PB.Connection);
            SqlDataReader TableReader = List_Nap_zal.ExecuteReader();
            DataTable Table = new DataTable();
            Table.Load(TableReader);
            Program.VivodNapVZaleLB = Table;
            _PB.Connection.Close();
        }
        public void Pizza_zal_lb()
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand List_Pizza_zal = new SqlCommand("select top 1 concat(kol_vo_za_poz_v_zale,' ', Nazv_pizza,' ',itog_cena_v_zale) from zakaz_v_zale inner join tov_check_za_zakaz  on tov_check_v_zale_id=id_tov_check_v_zale inner join pizza on id_pizza=pizza_v_zale_id  order by id_zakaz_v_zale desc", _PB.Connection);
            SqlDataReader TableReader = List_Pizza_zal.ExecuteReader();
            DataTable Table = new DataTable();
            Table.Load(TableReader);
            Program.VivodPizzaVZaleLB = Table;
            _PB.Connection.Close();
        }
        public void Eda_zal_lb()
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand List_Eda_zal = new SqlCommand("select top 1 concat(kol_vo_za_poz_v_zale,' ', Naim_blud,' ',itog_cena_v_zale) from zakaz_v_zale inner join tov_check_za_zakaz  on tov_check_v_zale_id=id_tov_check_v_zale inner join eda on id_eda=eda_v_zale_id  order by id_zakaz_v_zale desc", _PB.Connection);
            SqlDataReader TableReader = List_Eda_zal.ExecuteReader();
            DataTable Table = new DataTable();
            Table.Load(TableReader);
            Program.VivodEdaVZaleLB = Table;
            _PB.Connection.Close();
        }
    }
}
