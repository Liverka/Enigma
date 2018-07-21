using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Enigma
{
    public partial class Form1 : Form
    {
        private Button btnAdd = new Button();
        private Button btnAdd1 = new Button();
        private Button btnAdd2 = new Button();
        private Button btnAdd3= new Button(); 
        private Panel panel = new Panel();
        private Panel panel1 = new Panel();
        private PictureBox picture = new PictureBox();
        private PictureBox picture1 = new PictureBox();         
        private RadioButton RB1 = new RadioButton();
        private RadioButton RB2 = new RadioButton();
        private RadioButton RB3 = new RadioButton();
        private RadioButton RB4 = new RadioButton();        
        private Label label2 = new Label();
        private Label label3 = new Label();
        private Label label4 = new Label();
        private Label Язык = new Label();
        private Label Язык1 = new Label();
        private Label ОписаниеЯзычков = new Label();
        private Label ОписаниеКодирования = new Label();
        private Label ОписаниеДекодирования = new Label();
        private Label ОписаниеВыбора = new Label();
        public ComboBox СписокЯзыков = new ComboBox();
        private TextBox text1 = new TextBox();
        private LinkLabel link = new LinkLabel();
        private LinkLabel Cezar = new LinkLabel();
        OpenFileDialog ofd = new OpenFileDialog();
        public int Nokna = 0;
        private int OknoLang = 0;
        private int chek = 0;        

        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            BackColor = SystemColors.ControlLightLight;
            Text = "Enigma";
            StartPosition = FormStartPosition.Manual;
            Location = new Point(100, 100);
            Size = new Size(465, 385);
            AutoScroll = false;
            one();
            ОписаниеВсего();
            KeyDown += new KeyEventHandler(Form1_KeyDown);
        }                
        private void ОписаниеВсего()
        {
            СписокЯзыков.Items.Insert(0, "English");
            СписокЯзыков.Items.Insert(1, "Русский");
            СписокЯзыков.SelectedIndex = 0;
            СписокЯзыков.DropDownStyle = ComboBoxStyle.DropDownList;
            СписокЯзыков.Location = new Point(20, 180);
            СписокЯзыков.Size = new Size(200, 20);
            СписокЯзыков.Visible = true;

            btnAdd3.Text = "Обзор";
            btnAdd3.Location = new Point(360, 184);
            btnAdd3.Size = new Size(80, 22);
            btnAdd3.Click += new EventHandler(button3_Click);
            btnAdd3.Visible = true;
            btnAdd3.BringToFront();

            btnAdd.Text = "Отмена";
            btnAdd.Location = new Point(365, 315);
            btnAdd.Size = new Size(70, 22);
            btnAdd.Click += new EventHandler(button0_Click);
            btnAdd.BringToFront();

            btnAdd1.Text = "Далее";
            btnAdd1.Location = new Point(280, 315);
            btnAdd1.Size = new Size(70, 22);
            btnAdd1.Click += new EventHandler(button1_Click);
            btnAdd1.BringToFront();

            btnAdd2.Text = "Назад";
            btnAdd2.Location = new Point(209, 315);
            btnAdd2.Size = new Size(70, 22);
            btnAdd2.Click += new EventHandler(button2_Click);
            btnAdd2.BringToFront();
            btnAdd2.Enabled = false;

            panel.BackColor = SystemColors.Control;
            panel.Location = new Point(0, 300);
            panel.Size = new Size(465, 85);
            panel.BorderStyle = BorderStyle.FixedSingle;

            picture.Location = new Point(12, 12);
            picture.Size = new Size(161, 259);
            picture.Image = Properties.Resources.Cezar;

            link.Text = "О разработчике";
            link.AutoSize = true;
            link.Location = new Point(180, 250);
            link.Size = new Size(80, 30);
            link.LinkClicked += new LinkLabelLinkClickedEventHandler(linkLabel1);

            Cezar.Name = "Cezar";
            Cezar.Text = "Добро пожаловать в Enigma! \n\nЭто приложение созданное для преобразования текста с секретом (ключом) для обеспечения секретности передаваемой информации при ведении тайной переписки . Программа для преобразования информации использует шифр Цезаря.\n\n" +
            "Пожалуйста обратите внимание, что шифр Цезаря является самым простым и наиболее широко известным методом шифрования. И если предложить любому человеку придумать свой алгоритм шифровки, то он, наверняка, «придумает» именно такой способ, ввиду его простоты.";
            Cezar.Location = new Point(180, 25);
            Cezar.Size = new Size(240, 210);
            Cezar.Links.Add(239, 6);
            Cezar.Font = new Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular);
            Cezar.BringToFront();
            Cezar.LinkClicked += new LinkLabelLinkClickedEventHandler(linkLabel2);

            RB1.Location = new Point(20, 100);
            RB1.Size = new Size(200, 20);
            RB1.BackColor = SystemColors.Control;
            RB1.Text = "Кодирование текста";
            RB1.BringToFront();

            RB2.Location = new Point(20, 160);
            RB2.Size = new Size(200, 20);
            RB2.BackColor = SystemColors.Control;
            RB2.Text = "Декодирование текста";
            RB2.BringToFront();
            
            label3.Font = new Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold);
            label3.BackColor = SystemColors.ControlLightLight;
            label3.Location = new Point(20, 10);
            label3.Size = new Size(140, 15);

            label4.Text = "Кодирование или декодирование текста";
            label4.BackColor = SystemColors.ControlLightLight;
            label4.Location = new Point(40, 25);
            label4.Size = new Size(350, 15);

            ОписаниеКодирования.Text = "Шифрует входной текст на русском языке всеми возможными\nкомбинациями шифра Цезаря.";
            ОписаниеКодирования.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
            ОписаниеКодирования.BackColor = SystemColors.Control;
            ОписаниеКодирования.Location = new Point(40, 122);
            ОписаниеКодирования.Size = new Size(450, 30);

            ОписаниеДекодирования.Text = "Выдает таблицу всех возможных в шифре Цезаря\nпреобразований введенного текста.";
            ОписаниеДекодирования.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
            ОписаниеДекодирования.BackColor = SystemColors.Control;
            ОписаниеДекодирования.Location = new Point(40, 182);
            ОписаниеДекодирования.Size = new Size(450, 30);

            picture1.Location = new Point(401, 5);
            picture1.Size = new Size(35, 35);
            picture1.Image = Properties.Resources._300px;

            panel1.BackColor = SystemColors.Control;
            panel1.Location = new Point(-1, 55);
            panel1.Size = new Size(465, 335);
            panel1.BorderStyle = BorderStyle.FixedSingle;

            RB3.Location = new Point(20, 100);
            RB3.Size = new Size(100, 20);
            RB3.BackColor = SystemColors.Control;
            RB3.Text = "Ввод текста";
            RB3.BringToFront();

            RB4.Location = new Point(20, 125);
            RB4.BackColor = SystemColors.Control;
            RB4.Size = new Size(110, 20);
            RB4.Text = "Текст из файла";
            RB4.CheckedChanged += new EventHandler(radioButton2_CheckedChanged);
            RB4.BringToFront();


            label3.Font = new Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold);
            label3.BackColor = SystemColors.ControlLightLight;
            label3.Location = new Point(20, 10);
            label3.Size = new Size(250, 15);
            
            label4.BackColor = SystemColors.ControlLightLight;
            label4.Location = new Point(40, 25);
            label4.Size = new Size(300, 15);

            label2.Text = "Файл для декодирования:";
            label2.BackColor = SystemColors.Control;
            label2.Location = new Point(50, 165);
            label2.AutoSize = true;

            text1.Location = new Point(50, 185);
            text1.Multiline = true;
            text1.Size = new Size(300, 20);

            panel1.BackColor = SystemColors.Control;
            panel1.Location = new Point(-1, 55);
            panel1.Size = new Size(465, 335);
            panel1.BorderStyle = BorderStyle.FixedSingle;

            Язык.Text = "Выберите язык:";
            Язык.Font = new Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold);
            Язык.BackColor = SystemColors.ControlLightLight;
            Язык.Location = new Point(20, 10);
            Язык.Size = new Size(140, 15);

            Язык1.Text = "Выберите язык изменяемого текста";
            Язык1.BackColor = SystemColors.ControlLightLight;
            Язык1.Location = new Point(40, 25);
            Язык1.Size = new Size(300, 15);

            ОписаниеЯзычков.Text = "Энигма может работать только с 1 языком.\nПожалуйста убедитесь, что выбрали нужный язык и перейдите к следующему шагу нажав \"Далее\".";
            ОписаниеЯзычков.BackColor = SystemColors.Control;
            ОписаниеЯзычков.Location = new Point(20, 85);
            ОписаниеЯзычков.Size = new Size(380, 55);
            
            ОписаниеВыбора.Text = "Язык для кодирования:";
            ОписаниеВыбора.Font = new Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular);
            ОписаниеВыбора.BackColor = SystemColors.Control;
            ОписаниеВыбора.Location = new Point(20, 150);
            ОписаниеВыбора.Size = new Size(140, 15);
        }
        private void one()
        {                
            Controls.Add(btnAdd);
                       
            Controls.Add(btnAdd1);
                        
            Controls.Add(btnAdd2);
                        
            Controls.Add(panel);
                       
            Controls.Add(picture);           
            
            Controls.Add(link);
                      
            Controls.Add(Cezar);

        }  //Окно 1
        private void linkLabel1(object sender, LinkLabelLinkClickedEventArgs e)
        {           
           AboutBox1 spravka = new AboutBox1();
           spravka.Show();
        }    //О разработчике
        private void linkLabel2(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }    //О шифре Цезаря
        private void button0_Click(object sender, EventArgs e)
        {
            Close();
        }      //Отмена
        private void button1_Click(object sender, EventArgs e)
        {
            if (Nokna == 0)
            {
                two();
                one_off();
            }
            else if (OknoLang == 1)
            {
                Form2 f2= new Form2(Nokna,СписокЯзыков.SelectedIndex);
                if (chek==1)
                f2.text1.Text = File.ReadAllText(ofd.FileName, Encoding.Default);
                f2.Show();
                Hide();
            }
            else if (Nokna == 1)
            {
                if (RB1.Checked == true)
                {
                    three();                    
                    Nokna = 2;
                }
                if (RB2.Checked == true)
                {
                    three();
                    Nokna = 3;                   
                }

                RB1.Visible = false;
                RB2.Visible = false;
                RB3.Checked = true;
                ОписаниеДекодирования.Visible = false;
                ОписаниеКодирования.Visible = false;
            }
            else if (Nokna==2)
            {
                Form2 f2 = new Form2(Nokna,СписокЯзыков.SelectedIndex);
                if (RB3.Checked == true)
                {
                   four();
                }
                if (RB4.Checked == true)
                {
                    if (text1.Text != "")
                    {
                        chek = 1;   
                    }
                    four();
                }
                three_off();
            }            
            else if (Nokna == 3)
            {
                Form2 f2 = new Form2(Nokna, СписокЯзыков.SelectedIndex);
                if (RB3.Checked == true)
                {
                    four();
                }
                if (RB4.Checked == true)
                {
                    if (text1.Text != "")
                    {
                        chek = 1;             
                    }                    
                    four();
                }
                three_off();
            }
            
        }      //Далее
        private void button2_Click(object sender, EventArgs e)
        {           
            if (Nokna==1)
                two_off();
            if (OknoLang == 1)
            {
                three();
                ОписаниеВыбора.Visible = false;
                ОписаниеЯзычков.Visible = false;
                СписокЯзыков.Visible = false;
                Язык.Visible = false;
                Язык1.Visible = false;
                OknoLang = 0;
                Nokna = 2;
            }
            else if (Nokna == 2 || Nokna==3)
            {
                three_off();
                ОписаниеДекодирования.Visible = true;
                ОписаниеКодирования.Visible = true;
                RB1.Checked = true;
                RB1.Visible = true;
                RB2.Visible = true;
                text1.Text = "";
                Nokna = 1;
            }

        }      //Назад
        private void button3_Click(object sender,EventArgs e)
        {
            ofd.Filter = "Текстовые файлы(*.txt)|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                text1.Text = ofd.FileName;
            }
            if (text1.Text != "") btnAdd1.Enabled = true;
        }       //обзор
        public void two()
        {
            RB1.Visible = true;
            RB1.Checked = true;
            Controls.Add(RB1);
           
            RB2.Visible = true;
            Controls.Add(RB2);

            label3.Text = "Выберите действие:";
            label3.Visible = true;       
            Controls.Add(label3);
                       
            label4.Visible = true;
            Controls.Add(label4);
                      
            ОписаниеКодирования.Visible = true;
            Controls.Add(ОписаниеКодирования);
                       
            ОписаниеДекодирования.Visible = true;           
            Controls.Add(ОписаниеДекодирования);
                       
            picture1.Visible = true;
            Controls.Add(picture1);            
                        
            panel1.Visible = true;
            Controls.Add(panel1);           

            Nokna=1;
        }   //Окно 2
        private void one_off()
        {                    
            link.Visible = false;
            Cezar.Visible = false;
            btnAdd2.Enabled = true;
            picture.Visible = false;
        }
        private void two_off()
        {
            RB1.Checked = false;
            RB1.Visible = false;
            RB2.Visible = false;
            btnAdd3.Visible = false;
            btnAdd2.Enabled = false;
            btnAdd1.Enabled = true;
            Cezar.Visible = true;
            picture.Visible = true;
            picture1.Visible = false;
            panel1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;          
            link.Visible = true;
            ОписаниеДекодирования.Visible = false;
            ОписаниеКодирования.Visible = false;
            Nokna = 0; 
        }   //Отключение окна 2
        private void three_off()
        {           
            RB3.Visible = false;
            RB4.Visible = false;        
            label2.Visible = false;
            label3.Text = "Выберите действие:";
            label4.Text = "Кодирование или декодирование текста";       
            btnAdd3.Visible = false;
            text1.Visible = false;            
                        
        }   //Отключение окна 3
        public void three()
        {
            panel1.Visible = false;

            RB3.Visible = true;
           
            Controls.Add(RB3);
                        
            RB4.Visible = true;
            Controls.Add(RB4);

            label3.Text = "Выберите способ добавления текста:";
            label3.Visible = true;
            Controls.Add(label3);

            label4.Text = "Ввод текста или добавление текста из файла";
            label4.Visible = true;
            Controls.Add(label4);
                      
            label2.Visible = true;
            Controls.Add(label2);

            btnAdd3.Visible = true;
            Controls.Add(btnAdd3);
                       
            text1.Enabled = false;
            text1.Visible = true;
            Controls.Add(text1);
                     
            panel1.Visible = true;
            Controls.Add(panel1);
        }  //Окно 3
        public void four()
        {            
            panel1.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
                       
            Язык.Visible = true;
            Controls.Add(Язык);
                       
            Язык1.Visible = true;
            Controls.Add(Язык1);
            
            ОписаниеЯзычков.Visible = true;
            ОписаниеЯзычков.BringToFront();
            Controls.Add(ОписаниеЯзычков);

            ОписаниеВыбора.Visible = true;
            Controls.Add(ОписаниеВыбора);

            СписокЯзыков.Visible = true;
            Controls.Add(СписокЯзыков);

            panel1.Visible = true;
            Controls.Add(panel1);

            OknoLang = 1;
        }   //Окно 4
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (RB4.Checked == true && text1.Text == "") btnAdd1.Enabled = false;
            else
                btnAdd1.Enabled = true;

            if (RB4.Checked == true)
            {
                label2.Enabled = true;
                btnAdd3.Enabled = true;
            }
            else
            {
                label2.Enabled = false;
                btnAdd3.Enabled = false;
            }
        }         //Выбор из файла
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void Form1_KeyDown(object sender,KeyEventArgs e)
        {
            if (e.KeyCode==Keys.F1)
            {
                Help.ShowHelp(Parent, "Help.chm");
            }
            if (e.KeyCode==Keys.Escape)
            {
                Application.Exit();
            }

        }
    }      
}
