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
    public partial class Form2 : Form
    {
        public TextBox text1 = new TextBox();
        public TextBox text2 = new TextBox();
        public TextBox ЧислоСдвига = new TextBox();
        private TextBox text3 = new TextBox();
        private Label label = new Label();
        private Label label2 = new Label();
        private Label label3 = new Label();
        private Label label4 = new Label();       
        private Label Сдвиг = new Label();
        private Panel panel1 = new Panel();
        public Button Knopka = new Button();
        public Button Knopka1 = new Button();
        private Button KnopkaSave = new Button();
        public Button Nazad = new Button();
        private PictureBox picture1 = new PictureBox();
        private string alf = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        private string ALF = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        private string alf1 = "abcdefghijklmnopqrstuvwxyz";
        private string ALF1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public int Nok;
        private int Язык;

        public Form2(int Nokna,int Язык)
        {
            InitializeComponent();
            Nok = Nokna;
            this.Язык = Язык;
            KeyPreview = true;
        }        
        private void Form2_Load(object sender, EventArgs e)
        {
            Menushka();
            KeyDown += new KeyEventHandler(Form1_KeyDown);
        }
        private void Menushka()
        {
            MaximizeBox = false;
            MinimizeBox = false;
            BackColor = SystemColors.ControlLightLight;
            Text = "Enigma";
            StartPosition = FormStartPosition.CenterScreen;
            Location = new Point(100, 100);
            Size = new Size(680, 480);

            label.Text = "Как работает:";
            label.BackColor = SystemColors.ControlLightLight;
            label.Font = new Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold);
            label.Location = new Point(30, 10);
            label.Size = new Size(100, 15);
            Controls.Add(label);

            label2.Text = "Введите текст для преобразования в левое окно.";
            label2.BackColor = SystemColors.ControlLightLight;
            label2.Location = new Point(45, 25);
            label2.Size = new Size(400, 15);
            Controls.Add(label2);

            picture1.Location = new Point(600, 5);
            picture1.Size = new Size(35, 35);
            picture1.Image = Properties.Resources._300px;
            picture1.Visible = true;
            Controls.Add(picture1);

            label3.Text = "[Входной текст]";
            label3.BackColor = SystemColors.Control;
            label3.Location = new Point(120, 80);
            label3.Size = new Size(150, 15);
            Controls.Add(label3);

            label4.Text = "[Преобразованный текст]";
            label4.BackColor = SystemColors.Control;
            label4.Location = new Point(430, 80);
            label4.Size = new Size(150, 15);
            Controls.Add(label4);

            text1.Location = new Point(30, 100);
            text1.ScrollBars = ScrollBars.Vertical;
            text1.Multiline = true;            
            text1.Size = new Size(300, 300);
            text1.Font = new Font("Microsoft Sans Serif", 10.25f, System.Drawing.FontStyle.Regular);
            Controls.Add(text1);

            text2.Location = new Point(340, 100);
            text2.ScrollBars = ScrollBars.Vertical;
            text2.ReadOnly = true;
            text2.BackColor = SystemColors.ControlLightLight;  //выбор цвета
            text2.Multiline = true;
            text2.Size = new Size(300, 300);
            text2.Font = new Font("Microsoft Sans Serif", 10.25f, System.Drawing.FontStyle.Regular);
            Controls.Add(text2);

            Сдвиг.Text = "Введите число сдвига:";
            Сдвиг.BackColor = SystemColors.Control;
            Сдвиг.Location = new Point(30, 405);
            Сдвиг.Size = new Size(140, 15);

            ЧислоСдвига.Text = "1";
            ЧислоСдвига.Location = new Point(170, 405);
            ЧислоСдвига.Size = new Size(20, 22);
            ЧислоСдвига.BringToFront();
            ЧислоСдвига.MaxLength = 2;

            Knopka.Text = "Преобразовать";
            Knopka.Location = new Point(220, 405);
            Knopka.Size = new Size(110, 22);
            Knopka.Click += new EventHandler(button0_Click);
            Knopka.BringToFront();

            Knopka1.Text = "Преобразовать";
            Knopka1.Location = new Point(120, 405);
            Knopka1.Size = new Size(110, 22);
            Knopka1.Click += new EventHandler(button1_Click);
            Knopka1.BringToFront();

            KnopkaSave.Text = "Сохранить в файл";
            KnopkaSave.Location = new Point(450, 405);
            KnopkaSave.Size = new Size(110, 22);
            KnopkaSave.Click += new EventHandler(button3_Click);
            KnopkaSave.BringToFront();

            if (Nok == 2) { Controls.Add(Knopka); Controls.Add(KnopkaSave);  Controls.Add(Сдвиг); Controls.Add(ЧислоСдвига); text1.MaxLength = 40000; }
            if (Nok == 3) { Controls.Add(Knopka1); text1.MaxLength = 578; }

            Nazad.Text = "Назад";
            Nazad.Location = new Point(570, 405);
            Nazad.Size = new Size(70, 22);
            Nazad.Click += new EventHandler(button2_Click);
            Nazad.BringToFront();
            Controls.Add(Nazad);

            panel1.BackColor = SystemColors.Control;
            panel1.Location = new Point(-1, 50);
            panel1.Size = new Size(800, 700);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Visible = true;
            Controls.Add(panel1);
        }
        private void button0_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ЧислоСдвига.Text.Length; i++)
                if ((int)ЧислоСдвига.Text[i] < 48 || (int)ЧислоСдвига.Text[i] > 57) { MessageBox.Show("Введите число от 1 до 32"); return; }
            byte sdvig = Convert.ToByte(ЧислоСдвига.Text);

            string small = alf1, big = ALF1;
            if (Язык == 1)
            {
                small = alf;
                big = ALF;
            }

            if (sdvig<1 || sdvig>small.Length)
            { MessageBox.Show("Введите число от 1 до "+small.Length); return; }

            string text = "";          
            
            for (int i=0;i<text1.Text.Length;i++)
            {
                int p = 0;                
                for (int j = 0; j < small.Length; j++)
                {                    
                    if (text1.Text[i] == small[j])
                    {                       
                        int k = 0;
                        if (j + sdvig >= small.Length)
                            k = j + sdvig - small.Length;
                        else
                            k = j+ sdvig;
                        text += small[k];
                        p = 1;
                        break;
                    }
                    if (text1.Text[i] == big[j])
                    {                        
                        int k = 0;
                        if (j + sdvig >= big.Length)
                            k = j + sdvig - big.Length;
                        else
                            k = j + sdvig;
                        text += big[k];
                        p = 1;
                        break;
                    }   
                }                
                if (p == 0) text += text1.Text[i];
            }

            text2.Text = Convert.ToString(text);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            text2.Text = "";
            string small = alf1, big = ALF1;
            if (Язык == 1)
            {
                small = alf;
                big = ALF;
            }

            for (int n = 1; n < small.Length; n++)
            {
                string text = "";
                for (int i = 0; i < text1.Text.Length; i++)
                {
                    int p = 0;
                    for (int j = 0; j < small.Length; j++)
                    {
                        if (text1.Text[i] == small[j])
                        {
                            int k = 0;
                            if (j + n >= small.Length)
                                k = j + n - small.Length;
                            else
                                k = j + n;
                            text += small[k];
                            p = 1;
                            break;
                        }
                        if (text1.Text[i] == big[j])
                        {
                            int k = 0;
                            if (j + n >= big.Length)
                                k = j + n - big.Length;
                            else
                                k = j + n;
                            text += big[k];
                            p = 1;
                            break;
                        }
                    }                 
                    if (p == 0) text += text1.Text[i];
                }
                text2.Text += "Шаг " + n + " -- " + Convert.ToString(text) + Environment.NewLine;                
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.StartPosition = FormStartPosition.Manual;
            f.Show();
            Hide();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFile = new SaveFileDialog();
            SaveFile.Filter = "Текстовые документы (*.txt)|*.txt";

            if (SaveFile.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriter = new StreamWriter(SaveFile.FileName);
                streamWriter.WriteLine(text2.Text);
                streamWriter.Close();
            }
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Help.ShowHelp(Parent, "Help.chm");
            }
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }

        }
    }
}
