using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enigma
{
    public partial class Form3 : Form
    {
        TextBox text = new TextBox();
        public Form3()
        {
            InitializeComponent();
            KeyPreview = true;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            text.Text = "Шифр Цезаря, также известный как шифр сдвига, код Цезаря или сдвиг Цезаря — один из самых простых и наиболее широко известных методов шифрования." + 
                      Environment.NewLine + Environment.NewLine +
                       "Шифр Цезаря — это вид шифра подстановки, в котором каждый символ в открытом тексте заменяется символом, находящимся на некотором постоянном числе позиций левее или правее него в алфавите.Например," +
                       " в шифре со сдвигом вправо на 3, А была бы заменена на Г, Б станет Д, и так далее." + 
                      Environment.NewLine + Environment.NewLine +
                       "Шифр назван в честь римского императора Гая Юлия Цезаря, использовавшего его для секретной переписки со своими генералами." +
                      Environment.NewLine + Environment.NewLine + "Шифр Цезаря называют в честь Юлия Цезаря, который согласно «Жизни двенадцати цезарей» Светония использовал его со сдвигом 3, чтобы защищать военные сообщения. Хотя Цезарь был первым зафиксированным человеком, использующим эту схему, другие шифры подстановки, как известно, использовались и ранее." +
                      Environment.NewLine + Environment.NewLine + "Неизвестно, насколько эффективным шифр Цезаря был в то время, но, вероятно, он был разумно безопасен, не в последнюю очередь благодаря тому, что большинство врагов Цезаря были неграмотными, и многие предполагали, что сообщения были написаны на неизвестном иностранном языке. Нет никаких свидетельств того времени касательно методов взлома простых шифров подстановки. Самые ранние сохранившиеся записи о частотном анализе — это работы Ал-Кинди 9-го века об открытии частотного анализа." +
                      Environment.NewLine + Environment.NewLine + "Шифр Цезаря со сдвигом на один используется на обратной стороне мезузы, чтобы зашифровать имена Бога. Это может быть пережитком с раннего времени, когда еврейскому народу не разрешили иметь мезузы." +                     
                      Environment.NewLine + Environment.NewLine + "Часто для удобства использования шифра Цезаря используют два насаженных на общую ось диска разного диаметра с нарисованными по краям дисков алфавитами.Изначально диски поворачиваются так, чтобы напротив каждой буквы алфавита внешнего диска находилась та же буква алфавита малого диска.Если теперь повернуть внутренний диск на несколько символов, то мы получим соответствие между символами внешнего диска и внутреннего — шифр Цезаря. Получившийся диск можно использовать как для шифрования, так и для расшифровки.";
                      
            text.Location = new Point(25, 25);
            text.TabStop = false;
            text.Size = new Size(750, 550);
            text.Multiline = true;
            text.ScrollBars = ScrollBars.Vertical;
            text.ReadOnly = true;     
            text.BackColor = SystemColors.Control;  
            text.Font = new Font("Microsoft Sans Serif", 14, System.Drawing.FontStyle.Regular);
            Controls.Add(text);

            KeyDown += new KeyEventHandler(Form1_KeyDown);
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Help.ShowHelp(Parent, "Help.chm");
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }

        }
    }
}
