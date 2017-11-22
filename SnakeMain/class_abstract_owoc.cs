using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace SnakeMain
{
    abstract class class_abstract_owoc
    {
        
        protected int respawn;
        protected int kiedy_respawn;
        protected int to_spoiled;
        protected int spoiled_when;
        protected int dispose;
        protected int dispose_when;

        protected int pkt;
        protected int fast;
        protected int big;
        protected double life;
        protected int szerokosc_planszy;
        protected int wysokosc_planszy;
        protected int pole_size;
        protected Image tekstura;
        protected Image tekstura_spoiled;
        public PictureBox pictureBox = new PictureBox();
        protected Random rnd = new Random();

        #region get
        public int _big
        {
            get
            {
                return big;
            }
        }
        public int _pkt
        {
            get
            {
                return pkt;
            }
        }
        public int _fast
        {
            get
            {
                return fast;
            }
        }
        public double _life
        {
            get
            {
                return life;
            }
        }
        public int _kiedy_respawn
        {
            get
            {
                return kiedy_respawn;
            }
            set
            {
                kiedy_respawn = value + respawn;
            }
        }
        public int _dispose_when
        {
            get
            {
                return dispose_when;
            }
        }
        public int _spoiled_when
        {
            get
            {
                return spoiled_when;
            }
        }
        #endregion 
        public void f_pictureBox(Form form, int _szerokosc_planszy,int _wysokosc_planszy)
        {

            pictureBox = new PictureBox();
            form.Controls.Add(pictureBox);
            pictureBox.Name = "ok";
            pictureBox.Image = tekstura;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Size = new Size(pole_size, pole_size);
            pictureBox.BackColor = Color.Transparent;
            pictureBox.Location = new Point(losowanie(szerokosc_planszy), losowanie(wysokosc_planszy));
            pictureBox.Visible=false;
            pictureBox.BringToFront();
        }

        public void f_respawn(int _time_owoce)
        {
            pictureBox.Name = "ok";
            pictureBox.Image = tekstura;
            pictureBox.Location = new Point(losowanie(szerokosc_planszy),losowanie(wysokosc_planszy));
            pictureBox.Visible = true;
            dispose_when =dispose+ _time_owoce + to_spoiled;
            spoiled_when = _time_owoce + to_spoiled;
        }
        public int losowanie(int zakres)
        {
            return rnd.Next(0,zakres)*pole_size;
        }
        public void zebrane(int time_owoce)
        {
            kiedy_respawn = time_owoce + respawn;
            pictureBox.Visible = false;
        }
        public void f_spoiled()
        {
            pictureBox.Image = tekstura_spoiled;
            pictureBox.Name = "spoiled";
        }
        public virtual double f_life(int f_pkt)
        {
            return f_pkt * 0.2;
        }
        
    }
}
