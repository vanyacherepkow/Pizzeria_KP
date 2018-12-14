using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Windows.Forms;

namespace Pizzeria
{
    class Procedures
    {
        Podkl_Bazi _PB = new Podkl_Bazi();
        Vivod _V = new Vivod();
        
        public void Klient_add(string FamValue, string ImValue, string OtchValue, string TelValue, string AdresValue)
        {

            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand Klient_add = new SqlCommand("Klient_add", _PB.Connection);
            Klient_add.CommandType = CommandType.StoredProcedure;
            Klient_add.Parameters.AddWithValue("@Fam_Klient", FamValue);
            Klient_add.Parameters.AddWithValue("@Im_Klient", ImValue);
            Klient_add.Parameters.AddWithValue("@Otch_Klient", OtchValue);
            Klient_add.Parameters.AddWithValue("@Tel_Klient", TelValue);
            Klient_add.Parameters.AddWithValue("@Adres_Klient", AdresValue);
            Klient_add.ExecuteNonQuery();
            _PB.Connection.Close();
        }
        public void Klient_edit(int ID, string FamValue, string ImValue, string OtchValue, string TelValue, string AdresValue)
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand Klient_edit = new SqlCommand("Klient_edit", _PB.Connection);
            Klient_edit.CommandType = CommandType.StoredProcedure;
            Klient_edit.Parameters.AddWithValue("@ID_Klient", ID);
            Klient_edit.Parameters.AddWithValue("@Fam_Klient", FamValue);
            Klient_edit.Parameters.AddWithValue("@Im_Klient", ImValue);
            Klient_edit.Parameters.AddWithValue("@Otch_Klient", OtchValue);
            Klient_edit.Parameters.AddWithValue("@Tel_Klient", TelValue);
            Klient_edit.Parameters.AddWithValue("@Adres_Klient", AdresValue);
            Klient_edit.ExecuteNonQuery();
            _PB.Connection.Close();
        }
        public void Klient_delete(int ID)
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand Klient_add = new SqlCommand("Klient_delete", _PB.Connection);
            Klient_add.CommandType = CommandType.StoredProcedure;
            Klient_add.Parameters.AddWithValue("@ID_Klient", ID);
            Klient_add.ExecuteNonQuery();
            _PB.Connection.Close();
        }

        public void rekvizit_add(string Nazv_Rekv, int Kol)
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand rekvizit_add = new SqlCommand("rekvizit_add", _PB.Connection);
            rekvizit_add.CommandType = CommandType.StoredProcedure;
            rekvizit_add.Parameters.AddWithValue("@Nazv_rekvizita", Nazv_Rekv);
            rekvizit_add.Parameters.AddWithValue("@Kolichestvo", Kol);
            rekvizit_add.ExecuteNonQuery();
            _PB.Connection.Close();
        }

        public void zakaz_v_zale_form_eda_add ( int eda_v_zale_id, int kol_v_za_poz_zale, int itog_cena_v_zale, int tov_check_v_zale_id)
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand zakaz_v_zale_add = new SqlCommand ("zakaz_v_zale_eda_add", _PB.Connection);
            zakaz_v_zale_add.CommandType = CommandType.StoredProcedure;
            zakaz_v_zale_add.Parameters.AddWithValue("@eda_v_zale_id", eda_v_zale_id);
            zakaz_v_zale_add.Parameters.AddWithValue("@Kol_vo_za_poz_v_zale", kol_v_za_poz_zale);
            zakaz_v_zale_add.Parameters.AddWithValue("@itog_cena_v_zale", itog_cena_v_zale);
            zakaz_v_zale_add.Parameters.AddWithValue("@tov_check_v_zale_id", tov_check_v_zale_id);
            zakaz_v_zale_add.ExecuteNonQuery();
            _PB.Connection.Close();
        }

        public void zakaz_v_zale_form_napitok_add(int napiitok_v_zale_id,  int kol_v_za_poz_zale, int itog_cena_v_zale, int tov_check_v_zale_id)
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand zakaz_v_zale_add = new SqlCommand("zakaz_v_zale_napitok_add", _PB.Connection);
            zakaz_v_zale_add.CommandType = CommandType.StoredProcedure;
            zakaz_v_zale_add.Parameters.AddWithValue("@Napitok_v_zale_id", napiitok_v_zale_id);
            zakaz_v_zale_add.Parameters.AddWithValue("@Kol_vo_za_poz_v_zale", kol_v_za_poz_zale);
            zakaz_v_zale_add.Parameters.AddWithValue("@itog_cena_v_zale", itog_cena_v_zale);
            zakaz_v_zale_add.Parameters.AddWithValue("@tov_check_v_zale_id", tov_check_v_zale_id);
            zakaz_v_zale_add.ExecuteNonQuery();
            _PB.Connection.Close();
        }

        public void zakaz_v_zale_form_pizza_add(int pizza_na_zale_id, int kol_v_za_poz_zale, int itog_cena_v_zale, int tov_check_v_zale_id)
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand zakaz_v_zale_add = new SqlCommand("zakaz_v_zale_pizza_add", _PB.Connection);
            zakaz_v_zale_add.CommandType = CommandType.StoredProcedure;
            zakaz_v_zale_add.Parameters.AddWithValue("@pizza_v_zale_id", pizza_na_zale_id);
            zakaz_v_zale_add.Parameters.AddWithValue("@Kol_vo_za_poz_v_zale", kol_v_za_poz_zale);
            zakaz_v_zale_add.Parameters.AddWithValue("@itog_cena_v_zale", itog_cena_v_zale);
            zakaz_v_zale_add.Parameters.AddWithValue("@tov_check_v_zale_id", tov_check_v_zale_id);
            zakaz_v_zale_add.ExecuteNonQuery();
            _PB.Connection.Close();
        }

        public void zakaz_na_dost_form_pizza_add(int pizza_v_dost_id, int kol_v_za_poz_na_dost, int itog_cena_za_dost,int tov_check_za_dost_id)
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand zakaz_na_dost_add = new SqlCommand("zakaz_na_dost_pizza_add", _PB.Connection);
            zakaz_na_dost_add.CommandType = CommandType.StoredProcedure;
            zakaz_na_dost_add.Parameters.AddWithValue("@pizza_v_dost_id", pizza_v_dost_id);
            zakaz_na_dost_add.Parameters.AddWithValue("@kol_vo_za_poz_v_dost", kol_v_za_poz_na_dost);
            zakaz_na_dost_add.Parameters.AddWithValue("@itog_cena_za_dost", itog_cena_za_dost);
            zakaz_na_dost_add.Parameters.AddWithValue("@tov_check_na_dost_id", tov_check_za_dost_id);
            zakaz_na_dost_add.ExecuteNonQuery();
            _PB.Connection.Close();
        }

        public void zakaz_na_dost_form_napitok_add(int napitok_v_dost_id, int kol_v_za_poz_na_dost, int itog_cena_za_dost,int tov_check_za_dost_id)
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand zakaz_na_dost_add = new SqlCommand("zakaz_na_dost_napitok_add", _PB.Connection);
            zakaz_na_dost_add.CommandType = CommandType.StoredProcedure;
            zakaz_na_dost_add.Parameters.AddWithValue("@napitok_v_dost_id", napitok_v_dost_id);
            zakaz_na_dost_add.Parameters.AddWithValue("@kol_vo_za_poz_v_dost", kol_v_za_poz_na_dost);
            zakaz_na_dost_add.Parameters.AddWithValue("@itog_cena_za_dost", itog_cena_za_dost);
            zakaz_na_dost_add.Parameters.AddWithValue("@tov_check_na_dost_id", tov_check_za_dost_id);
            zakaz_na_dost_add.ExecuteNonQuery();
            _PB.Connection.Close();
        }

        public void zakaz_na_dost_form_eda_add(int eda_v_dost_id, int kol_v_za_poz_na_dost, int itog_cena_za_dost, int tov_check_za_dost_id)
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand zakaz_na_dost_add = new SqlCommand("zakaz_na_dost_eda_add", _PB.Connection);
            zakaz_na_dost_add.CommandType = CommandType.StoredProcedure;
            zakaz_na_dost_add.Parameters.AddWithValue("@eda_v_dost_id", eda_v_dost_id);
            zakaz_na_dost_add.Parameters.AddWithValue("@kol_vo_za_poz_v_dost", kol_v_za_poz_na_dost);
            zakaz_na_dost_add.Parameters.AddWithValue("@itog_cena_za_dost", itog_cena_za_dost);
            zakaz_na_dost_add.Parameters.AddWithValue("@tov_check_na_dost_id", tov_check_za_dost_id);
            zakaz_na_dost_add.ExecuteNonQuery();
            _PB.Connection.Close();
        }

        public void tov_check_zakaz_v_zale_add(int sotr_id, DateTime vrem_zakaz_v_zale)
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand tov_check_zakaz_v_zale_add = new SqlCommand("tov_check_za_zakaz_add", _PB.Connection);
            tov_check_zakaz_v_zale_add.CommandType = CommandType.StoredProcedure;
            tov_check_zakaz_v_zale_add.Parameters.AddWithValue("@sotr_id", sotr_id);
            tov_check_zakaz_v_zale_add.Parameters.AddWithValue("@vrem_zakaz_v_zale", vrem_zakaz_v_zale);
            tov_check_zakaz_v_zale_add.ExecuteNonQuery();
            _PB.Connection.Close();
        }

        public void tov_check_zakaz_na_dost_add(int sotr_v_dost_id, int klient_id,int kureer_id, DateTime vrem_zakaz_na_dost)
        {
                _PB.Set_Connection();
                _PB.Connection.Open();
                SqlCommand tov_check_zakaz_na_dost_add = new SqlCommand("tov_check_za_dost_add", _PB.Connection);
                tov_check_zakaz_na_dost_add.CommandType = CommandType.StoredProcedure;
                tov_check_zakaz_na_dost_add.Parameters.AddWithValue("@sotr_v_dost_id", sotr_v_dost_id);
                tov_check_zakaz_na_dost_add.Parameters.AddWithValue("@kureer_id", kureer_id);
                tov_check_zakaz_na_dost_add.Parameters.AddWithValue("@klient_id", klient_id);
                tov_check_zakaz_na_dost_add.Parameters.AddWithValue("@vrem_zakaz_na_dost", vrem_zakaz_na_dost);
                tov_check_zakaz_na_dost_add.ExecuteNonQuery();
                _PB.Connection.Close();
        }

        public void zakaz_na_dost_delete(int id_zakaz_na_dost)
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand zakaz_na_dost_delete = new SqlCommand("tov_check_za_dost_delete", _PB.Connection);
            zakaz_na_dost_delete.CommandType = CommandType.StoredProcedure;
            zakaz_na_dost_delete.Parameters.AddWithValue("@id_zakaz_na_dost", id_zakaz_na_dost);
            zakaz_na_dost_delete.ExecuteNonQuery();
            _PB.Connection.Close();
        }

        public void zakaz_v_zale_delete(int id_zakaz_v_zale)
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand zakaz_v_zale_delete = new SqlCommand("tov_check_v_zale_delete", _PB.Connection);
            zakaz_v_zale_delete.CommandType = CommandType.StoredProcedure;
            zakaz_v_zale_delete.Parameters.AddWithValue("@id_zakaz_v_zale", id_zakaz_v_zale);
            zakaz_v_zale_delete.ExecuteNonQuery();
            _PB.Connection.Close();
        }
        public void sotrudniki_add(string Fam_Sotr, string Im_Sotr, string Otch_Sotr, string Pass_Sotr, int syst_access, int kol_vo_rekvizit, int dolj, int admin_access)
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand sotrudnik_add = new SqlCommand("sotrudnik_add", _PB.Connection);
            sotrudnik_add.CommandType = CommandType.StoredProcedure;
            sotrudnik_add.Parameters.AddWithValue("@Fam_Sotr", Fam_Sotr);
            sotrudnik_add.Parameters.AddWithValue("@Im_Sotr", Im_Sotr);
            sotrudnik_add.Parameters.AddWithValue("@Otch_Sotr", Otch_Sotr);
            sotrudnik_add.Parameters.AddWithValue("@Password ", Pass_Sotr);
            sotrudnik_add.Parameters.AddWithValue("@System_Access",syst_access);
            sotrudnik_add.Parameters.AddWithValue("@Kol_vo_rek_za_kot_otv_sotr ", kol_vo_rekvizit);
            sotrudnik_add.Parameters.AddWithValue("@dolj_id", dolj);
            sotrudnik_add.Parameters.AddWithValue("@Admin_access", admin_access);
            sotrudnik_add.ExecuteNonQuery();
            _PB.Connection.Close();
        }
    }
}
