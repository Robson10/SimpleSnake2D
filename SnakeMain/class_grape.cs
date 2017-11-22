using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SnakeMain
{
    sealed class class_grape : class_abstract_owoc
    {
        public class_grape(Form form, int _pole_size, int _szerokosc_planszy, int _wysokosc_planszy)
        {
            pkt = 50;
            respawn = 40;
            kiedy_respawn = 40;
            to_spoiled = 15;
            dispose = 10;
            fast = 0;
            big = 1;
            life = f_life(pkt);
            szerokosc_planszy = _szerokosc_planszy;
            wysokosc_planszy = _wysokosc_planszy;
            pole_size = _pole_size;

            tekstura = Image.FromFile("image\\grape.png");
            tekstura_spoiled = Image.FromFile("image\\spoiled.png");
            f_pictureBox(form,  szerokosc_planszy, wysokosc_planszy);
        }
    }
}
