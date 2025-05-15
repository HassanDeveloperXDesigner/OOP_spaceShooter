using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Rocket.Enum;

namespace Rocket.A
{
    public class Playerbullet:Imovement
    {
        PictureBox Pb;
        List<PictureBox> Bullets = new List<PictureBox>();
        int speed;
        Point Boundary;
        Imovement Controller;
        public Playerbullet() 
        {

        }
        public Playerbullet(Image img, int left, int top, Imovement Controller)
        {
            Pb = new PictureBox();
            Pb.SizeMode = PictureBoxSizeMode.Zoom;
            Pb.Image = img;
            Pb.Left = left;
            Pb.Top = top;
            //Pb.Width = img.Width-100;
            //Pb.Height = img.Height-100;
            Pb.BackColor = Color.Transparent;
            this.Controller = Controller;
            Bullets.Add(Pb);

        }
        public Playerbullet(int speed, Point Boundary)
        {
            this.speed = speed;
            this.Boundary = Boundary;
        }

        public void CreateBullet()
        {

        }
        Point Imovement.move(Point Location)
        {
            Direction direction = Direction.Up;
            if(direction== Direction.Up)
            { 
                Location.Y -= speed;

            }
            return Location;
        }
        public PictureBox GetPb()
        { return Pb; }
        public void RemoveBullets()
        {
            for(int idx=0; idx<Bullets.Count; idx++) 
            {
                if(Pb.Top<=0)
                {
                    Bullets.Remove(Bullets[idx]);
                }
            }
        }

    }
}
