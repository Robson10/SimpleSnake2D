using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SnakeMain
{
    class class__interface
    {
        public PictureBox area, life;
        private int pole_size,pole_width,pole_height,width,height;
        private Image tekstura_life;

        public class__interface(Form form,int _pole_size,int _pole_width,int _pole_height,int _width,int _height,int _hp)
        {
            pole_size = _pole_size;
            pole_width = _pole_width;
            pole_height = _pole_height;
            width = _width;
            height = _height;

            area = new PictureBox();
            area.Size = new Size(pole_width*pole_size,pole_height*pole_size);
            area.Location = new Point(0, 0);
            form.Controls.Add(area);
            area.BorderStyle = BorderStyle.Fixed3D;

            life = new PictureBox();
            life.Size = new Size(3*pole_size, 3* pole_size);
            life.Location = new Point(pole_width * pole_size +pole_size, 0);
            tekstura_life = Image.FromFile("image\\life.png");
            life.Image = tekstura_life;
            life.SizeMode = PictureBoxSizeMode.StretchImage;
            life.BackColor = Color.FromArgb(_hp,0,0);
            form.Controls.Add(life);            
            
        }
       public void change_hp(int hp)
        {
            if (hp > 255) life.BackColor = Color.FromArgb(255, 0, 0);
            else if (hp < 0) life.BackColor = Color.FromArgb(0, 0, 0);
            else life.BackColor = Color.FromArgb(hp, 0, 0);
        }

    }
}