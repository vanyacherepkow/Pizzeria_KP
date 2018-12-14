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
    public partial class Main_Menu : Form
    {
        public Main_Menu()
        {
            InitializeComponent();
        }
        private void Main_Menu_Load(object sender, EventArgs e)
        {
            switch (Program.ZakazVZale)
            {
                case (0):
                    break;
                case (1):
                    button1.Enabled = true;
                    break;
            }
            switch (Program.ZakazNaDost)
            {
                case (0):
                    break;
                case (1):
                    button2.Enabled = true;
                    break;
            }
            switch (Program.KlientsAccess)
            {
                case (0):
                    break;
                case (1):
                    button3.Enabled = true;
                    break;
            }
            switch (Program.SotrudnikiAccess)
            {
                case (0):
                    break;
                case (1):
                    button4.Enabled = true;
                    break;
            }
            switch (Program.IngridientsAccess)
            {
                case (0):
                    break;
                case (1):
                    button5.Enabled = true;
                    break;
            }
            switch (Program.EdaAccess)
            {
                case (0):
                    break;
                case (1):
                    button6.Enabled = true;
                    break;
            }
            switch (Program.IngridientsAccess)
            {

                case (1):
                    button7.Enabled = true;
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Dostavka Form = new Dostavka();
            Form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Eda Form = new Eda();
            Form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Klients Form = new Klients();
            Form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Sotrudniki Form = new Sotrudniki();
            Form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
            Rekvizit Form = new Rekvizit();
            Form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Ingridients Form = new Ingridients();
            Form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Zal Form = new Zal();
            Form.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
             Program.ProgAccess = 0;
            Program.identificator = 0;
            Program.AdminAccess = 0;
            Program.Systemaccess = 0;
            Program.IngridientsAccess = 0;
            Program.EdaAccess = 0;
            Program.SotrudnikiAccess = 0;
            Program.KlientsAccess = 0;
            Program.RekvizitAccess = 0;
            Program.ZakazVZale = 0;
            Program.ZakazNaDost = 0;
            Autorization Form = new Autorization();
            Form.Show();
        }
    }
}
