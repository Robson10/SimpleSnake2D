using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SnakeMain
{
    sealed class class_cake : class_abstract_owoc
    {
        public class_cake(Form form, int _pole_size, int _szerokosc_planszy, int _wysokosc_planszy)
        {
            pkt = -300;
            respawn = 100;
            kiedy_respawn = 100;
            to_spoiled = 10;
            dispose = 10;
            fast = 1000;
            big = 1;
            life = f_life(pkt);
            szerokosc_planszy = _szerokosc_planszy;
            wysokosc_planszy = _wysokosc_planszy;
            pole_size = _pole_size;

            tekstura = Image.FromFile("image\\cake.png");
            tekstura_spoiled = Image.FromFile("image\\spoiled.png");
            f_pictureBox(form,  szerokosc_planszy, wysokosc_planszy);
        }

        override public double f_life(int f_pkt)
        {
            return pkt * 0.01 / 6;
        }
    }
}
