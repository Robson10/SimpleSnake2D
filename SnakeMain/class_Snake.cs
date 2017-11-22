using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SnakeMain
{
    class class_Snake
    {
       
       
        private int pkt;
        private double life;
        private int big;
        private int fast;
        private int fat;
        private int time_to_get;
        private int pole_size;
        protected Image tekstura_head;
        protected Image tekstura_body;
        public PictureBox pictureBox;
        private Keys move;
        public List<Point> move_back = new List<Point>(){ new Point(0,0) };
        public List<PictureBox> tail = new List<PictureBox>();

        //konstruktor
        public class_Snake(Form form,int _pole_size)
        {

            life = 255;
            pkt = 0;
            big = 1;
            fast = 200;
            fat = 1;
            time_to_get =30;
            pole_size = _pole_size;

            tekstura_head = Image.FromFile( "image\\37.png");
            tekstura_body = Image.FromFile("image\\snake_body.png");

            pictureBox = new PictureBox();
            form.Controls.Add(pictureBox);
            pictureBox.Image = tekstura_head;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Size=new Size(pole_size,pole_size);
            pictureBox.Location = new Point(pole_size, 0);
            pictureBox.BackColor = Color.Transparent;
            pictureBox.BringToFront();
            f_tail(form);

        }
        
        public void f_move(int pole_size)
        {
            if (move == Keys.Down)//ruch na strzałkach, zapis poprzedniej pozycji oraz czy nie zawracam
            {
                
                if (pictureBox.Location.Y + pole_size != move_back[move_back.Count() - 1].Y)
                {
                    move_back.Add(pictureBox.Location);
                    pictureBox.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y + pole_size);
                }
                else
                {
                    move = Keys.Up;
                    move_back.Add(pictureBox.Location);
                    pictureBox.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y - pole_size);
                }
            }
            else if (move == Keys.Up)
            {

                if (pictureBox.Location.Y - pole_size != move_back[move_back.Count() - 1].Y)
                {
                    move_back.Add(pictureBox.Location);
                    pictureBox.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y - pole_size);
                }
                else
                {
                    move = Keys.Down;
                    move_back.Add(pictureBox.Location);
                    pictureBox.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y + pole_size);
                }
            }
            else if (move == Keys.Left)
            {
                if (pictureBox.Location.X - pole_size != move_back[move_back.Count() - 1].X)
                {
                    move_back.Add(pictureBox.Location);
                    pictureBox.Location = new Point(pictureBox.Location.X - pole_size, pictureBox.Location.Y);
                }
                else
                {
                    move = Keys.Right;
                    move_back.Add(pictureBox.Location);
                    pictureBox.Location = new Point(pictureBox.Location.X + pole_size, pictureBox.Location.Y);
                }
            }
            else if (move == Keys.Right)
            {
                    if (pictureBox.Location.X + pole_size != move_back[move_back.Count() - 1].X)
                    {
                        move_back.Add(pictureBox.Location);
                        pictureBox.Location = new Point(pictureBox.Location.X + pole_size, pictureBox.Location.Y);
                    }
                    else
                    {
                        move = Keys.Left;
                        move_back.Add(pictureBox.Location);
                        pictureBox.Location = new Point(pictureBox.Location.X - pole_size, pictureBox.Location.Y);
                    }
            }
            
            
            if (big  < move_back.Count()-1)//skracanie listy ponitow dla ogona
            {
                for (int i = 0; i < move_back.Count()-1 - big ; i++)
                {
                    move_back.RemoveAt(i);
                }
            }
            ruszanie_ogonem();
            collision();
        }
        private void ruszanie_ogonem()
        {
            for (int i = 0; i < tail.Count; i++)//ruszanie ogonem
            {
                tail[i].Location = move_back[move_back.Count - 1 - i];
            }
        }
        private void collision()
        {
            for (int i = 0; i < tail.Count(); i++)
            {
                life=(pictureBox.Location == tail[i].Location) ? 0 : life;
            }
        }

        private void f_tail(Form form)
        {
            if (tail.Count() < big)
            {
                for (int i = 0; i < big - (tail.Count() - 1); i++)
                {
                    PictureBox ogon = new PictureBox();
                    form.Controls.Add(ogon);
                    ogon.Image = tekstura_body;
                    ogon.SizeMode = PictureBoxSizeMode.StretchImage;
                    ogon.Size = new Size(pole_size, pole_size);
                    ogon.Location = move_back[i];
                    ogon.BackColor = Color.Transparent;
                    tail.Add(ogon);
                    ogon.BringToFront();
                    pictureBox.BringToFront();
                }
            }
            else if (tail.Count() > big)
            {
                for (int i = move_back.Count - 1; i >= big; i--)
                {
                    move_back[i] = new Point(-100, -100);
                    try
                    {
                        tail[i].Dispose();
                        tail.RemoveAt(i);
                    }
                    catch { }
                }
            }
        }

        public void eated(class_abstract_owoc x, Form form)
        {
            if (!x.pictureBox.Name.Equals("spoiled"))
            {

                pkt += x._pkt;
                life = (life + x._life < 255) ? life + x._life : 255;
                time_to_get = 30;
                if (x._big ==50)
                {
                    if (big == 0) life = 0;
                    else big = big / 2; 
                }
                else
                {
                    big = big + x._big;
                }
                f_tail(form);
                if (x._fast == 150)
                {
                    fast /= 2;
                    if (fast + x._fast < 10)
                    {
                        fast = 10;
                    }
                }
                else
                {
                    fast += x._fast;
                    if (fast + x._fast < 10)
                    {
                        fast = 10;
                    }
                }

            }
            else
            {
                time_to_get -= 5;
                pkt -= 20;
                life -= 25;
            }
        }

        #region _get
        public Keys _move
        {
            set
            {
                if (value == Keys.Down || value == Keys.Up || value == Keys.Left || value == Keys.Right)
                    move = value;
            }
        }
        public int _pkt
        {
            get
            {
                return pkt;
            }
        }
        public int _big
        {
            get
            {
                return big;
            }
        }

        public int _fast
        {
            get
            {
                return fast;
            }
        }
        public int _fat
        {
            get
            {
                return fat;
            }
        }
        public int _time_to_get
        {
            get
            {
                return time_to_get;
            }
            set
            {
                time_to_get -= value;
            }
        }
        public double _life
        {
            get
            {
                return life;
            }
        }

       
        #endregion
    }

}
