using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SnakeMain
{
    sealed class class_cut : class_abstract_owoc
    {
        public class_cut(Form form, int _pole_size, int _szerokosc_planszy, int _wysokosc_planszy)
        {
            pkt = 1000;
            respawn = 5;
            kiedy_respawn = 5;
            to_spoiled = 27;
            dispose = 0;
            fast = 150;//% !!!!!
            big = 50;//% !!!!!
            life = 1;
            szerokosc_planszy = _szerokosc_planszy;
            wysokosc_planszy = _wysokosc_planszy;
            pole_size = _pole_size;

            tekstura = Image.FromFile("image\\cut.png");
            tekstura_spoiled = Image.FromFile("image\\spoiled.png");
            f_pictureBox(form, szerokosc_planszy, wysokosc_planszy);
        }
    }
}
