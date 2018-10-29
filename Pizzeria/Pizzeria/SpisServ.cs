using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Pizzeria
{
    public partial class Servers : Form
    {
        private Podkl_Bazi _PB;
        private bool proverka_serverov = true;
        private bool poluchit_spis_serverov = true;
        public Servers()
        {
            InitializeComponent();
        }



        private void Servers_Load(object sender, EventArgs e)
        {
            proverka_serverov = false;
            poluchit_spis_serverov = false;
            _PB = new Podkl_Bazi();
            _PB.Status += _PB_Status;
            toolStripStatusLabel3.Text = "Проверка подключения";
            Thread Th1 = new Thread(_PB.Connection_State); ;
            Th1.Start();
        }
        
        public void _PB_Status(bool value)
        {
            Action Act = () =>
            {
                proverka_serverov = false;
                switch (value)
                {
                    case (true):
                        poluchit_spis_serverov = false;
                        toolStripStatusLabel3.Text = "Подключение установлено!";
                        Autorization Form = new Autorization();
                        this.Hide();
                        Form.Show();
                        break;
                    case (false):
                        toolStripStatusLabel3.Text = "Отсутствует подключение!";
                        label1.Visible = true;
                        label2.Visible = true;
                        label3.Visible = true;
                        label4.Visible = true;
                        comboBox1.Visible = true;
                        comboBox2.Visible = true;
                        textBox1.Visible = true;
                        textBox2.Visible = true;
                        button1.Visible = true;
                        button2.Visible = true;
                        _PB = new Podkl_Bazi();
                        _PB.List_Server += _PB_List_Server;
                        Thread Th1 = new Thread(_PB.poluchit_spis_serverov);
                        Th1.Start();
                        break;
                }
            };
            Invoke(Act);
        }//Получение данных и проверка подключения к серверу

        public void _PB_List_Server(DataTable value)
        {
            Action Act = () =>
            {
                poluchit_spis_serverov = false;
                foreach (DataRow Row in value.Rows)
                {
                    comboBox1.Items.Add(Row[0] + "\\" + Row[1]);
                }
                comboBox1.Enabled = true;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                toolStripStatusLabel3.Text = "Список серверов получен";
            };
            Invoke(Act);
        }

        private void Servers_Leave(object sender, EventArgs e)
        {
            proverka_serverov = true;
            poluchit_spis_serverov = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _PB = new Podkl_Bazi();
            _PB.List_Dbs += _Poluechenie_Serverov;
            Podkl_Bazi.DS = comboBox1.Text;
            Podkl_Bazi.UN = textBox1.Text;
            Podkl_Bazi.UP = textBox2.Text;
            Thread Th = new Thread(_PB.Get_Base_List);
            Th.Start();
        }

        public void _Poluechenie_Serverov(DataSet value)
        {
            Action Act = () =>
            {
                comboBox2.DataSource = value.Tables[0];
                comboBox2.DisplayMember = "name";
                comboBox2.Enabled = true;
                button2.Enabled = true;
            };
            Invoke(Act);
        }

            private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime Day = DateTime.Today;
            DateTime Time = DateTime.Now;
            toolStripStatusLabel1.Text = "Сегодня - " + Day.ToString("dd-MM-yyyy");
            toolStripStatusLabel2.Text = "Время: " + Time.ToString("hh:mm:ss");
            switch (proverka_serverov)
            {
                case (true):
                    if (toolStripStatusLabel3.Text.Length > 23)
                    {
                        toolStripStatusLabel3.Text = "Проверка подключения";
                    }
                    else
                    {
                        toolStripStatusLabel3.Text = toolStripStatusLabel3.Text + ".";
                    }
                    break;
            }
            switch (poluchit_spis_serverov)
            {
                case (true):
                    if (toolStripStatusLabel3.Text.Length > 27)
                    {
                        toolStripStatusLabel3.Text = "Получение списка серверов";
                    }
                    else
                    {
                        toolStripStatusLabel3.Text = toolStripStatusLabel3.Text + ".";
                    }
                    break;
            }
            }

        private void button2_Click(object sender, EventArgs e)
        {
            _PB = new Podkl_Bazi();
            _PB.Register_set(comboBox1.Text, comboBox2.Text, textBox1.Text, textBox2.Text);
            this.Hide();
            Autorization Form = new Autorization();
            Form.Show();
        }
    }
}
