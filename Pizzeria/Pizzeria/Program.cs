﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace Pizzeria
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Servers());

        }

        public static int ProgAccess;
        public static int identificator;
        public static bool Value;
        public static int AdminAccess;
        public static int Systemaccess;
        public static int IngridientsAccess;
        public static int EdaAccess;
        public static int SotrudnikiAccess;
        public static int KlientsAccess;
        public static int RekvizitAccess;
        public static int ZakazVZale;
        public static int ZakazNaDost;
        public static DataTable Vivodklients;
        public static DataTable VivodEdaVEda;
        public static DataTable VivodPizzaVEda;
        public static DataTable VivodNapitokVEda;
        public static DataTable VivodSkladSIngr;
        public static DataTable VivodPizzaIngr;
        public static DataTable VivodEdaIngr;
        public static DataTable VivodRekvizit;
        public static DataTable VivodSotrRekv;
        public static DataTable VivodSotrobj;
        public static DataTable VivodKliDost;
        public static DataTable VivodKurDost;
        public static int Num_Check_v_zale;
        public static int CenaVZale;
        public static int Num_Check_za_dost;
        public static int CenaZaDost;
        public static DataTable VivodNapVZaleLB;
        public static DataTable VivodEdaVZaleLB;
        public static DataTable VivodPizzaVZaleLB;
        public static DataTable VivodNapNADostLB;
        public static DataTable VivodEdaNADostLB;
        public static DataTable VivodPizzaNADostLB;

    }
}
