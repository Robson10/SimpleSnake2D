using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeMain
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region instancje class
        List <class_abstract_owoc> owoce = new List<class_abstract_owoc>();
        class_Snake snake;
        class_apple apple;
        class_banana banana;
        class_cherry cherry;
        class_grape grape;
        class_pear pear;
        class_cake cake;
        class_cut cut;
        class__interface area;
        #endregion

        #region
        int szerokosc_planszy,wysokosc_planszy,pole_size;
        bool cover;
        int time_owoce = 0;
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(50, 50, 50);
            this.WindowState = FormWindowState.Maximized;
            pole_size = Width / 60;
            szerokosc_planszy = Width*3/4 / pole_size;
            wysokosc_planszy = Height*10/11 / pole_size;


            
            snake = new class_Snake(this, pole_size);
            apple = new class_apple(this, pole_size, szerokosc_planszy, wysokosc_planszy);
            banana = new class_banana(this, pole_size, szerokosc_planszy, wysokosc_planszy);
            cake = new class_cake(this, pole_size, szerokosc_planszy, wysokosc_planszy);
            cherry = new class_cherry(this, pole_size, szerokosc_planszy, wysokosc_planszy);
            cut = new class_cut(this, pole_size, szerokosc_planszy, wysokosc_planszy);
            grape = new class_grape(this, pole_size, szerokosc_planszy, wysokosc_planszy);
            pear = new class_pear(this, pole_size, szerokosc_planszy, wysokosc_planszy);
            area = new class__interface(this, pole_size, szerokosc_planszy, wysokosc_planszy, Width, Height,(int)snake._life);

            timer_Snake.Interval = snake._fast;
            textBox1.KeyDown += Form1_KeyDown;
            textBox1.Multiline = true;
            textBox1.Size = new Size(Width * 10 / 100, Height * 10 / 100);
            textBox1.Location = new Point(szerokosc_planszy * pole_size, 4 * pole_size);
            owoce.Add(apple);
            owoce.Add(banana);
            owoce.Add(cake);
            owoce.Add(cherry);
            owoce.Add(cut);
            owoce.Add(grape);
            owoce.Add(pear);
            
        }

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            snake._move = e.KeyCode;
        }

        private void timer_Snake_Tick(object sender, EventArgs e)
        {
            snake.f_move(pole_size);
            if (przegrana() == false)
            {
                for (int i = 0; i < owoce.Count; i++)
                {
                    if (owoce[i].pictureBox.Visible == true)
                    {
                        if (snake.pictureBox.Location == owoce[i].pictureBox.Location)
                        {
                            snake.eated(owoce[i], this);
                            owoce[i].zebrane(time_owoce);
                            area.change_hp((int)snake._life);
                        }
                    }
                }
            }
        }

        private void timer_owoc_Tick(object sender, EventArgs e)
        {
            time_owoce++;
            snake._time_to_get = 1;
            textBox1.Text ="life: "+ snake._life + Environment.NewLine + "pkt: "+snake._pkt + Environment.NewLine + "czas: "+snake._time_to_get;
            for (int i = 0; i < owoce.Count(); i++)
            {
                if (owoce[i]._dispose_when == time_owoce)
                {
                    owoce[i].zebrane(time_owoce);
                }
                if (owoce[i]._kiedy_respawn == time_owoce && owoce[i].pictureBox.Visible == false)
                {
                    cover = true;
                    while (cover == true)
                    {
                        cover = false;
                        owoce[i].f_respawn(time_owoce);
                        for (int i2 = 0; i2 < owoce.Count(); i2++)
                        {
                            if (owoce[i].pictureBox.Location == owoce[i2].pictureBox.Location && i!=i2)
                            {
                                cover = true;
                            }
                        }
                    }
                }
                if(owoce[i]._spoiled_when==time_owoce)
                {
                    owoce[i].f_spoiled();
                }
            }
        }

        bool przegrana()
        {
            if (snake._life <= 0 || snake._time_to_get <= 0 || snake.pictureBox.Location.X < 0 || snake.pictureBox.Location.X > (szerokosc_planszy-1) * (pole_size) || snake.pictureBox.Location.Y < 0 || snake.pictureBox.Location.Y>(wysokosc_planszy-1)*(pole_size))
            {
                timer_Snake.Enabled = false;
                MessageBox.Show("przegrałeś");
                snake = null;
                Application.Exit();
                return true;
            }
            else
            { return false; }
        }
       
    }
}
// menu, highscoor, od nowa,