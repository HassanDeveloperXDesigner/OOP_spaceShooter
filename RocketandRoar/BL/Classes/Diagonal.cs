using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Rocket.A
{
    public class Diagonal:Imovement
    {
        private int Speed;
        private Point Boundary;
        private int offset = 90;
        private string direction1;
        private string direction2;

        public Diagonal()
        {

        }

        public Diagonal(int speed, Point boundary, string direction1, string direction2)
        {
            Speed = speed;
            Boundary = boundary;
            this.direction1 = direction1;
            this.direction2 = direction2;
        }

        public Point move(Point Location)
        {
            if (((Location.X + offset) >= Boundary.X) && ((Location.Y - Speed) <= 0))
            {
                direction1 = "Left";
                direction2 = "down";
            }
            if (((Location.X + Speed) <= 0) && ((Location.Y + offset) >= Boundary.Y))
            {
                direction1 = "right";
                direction2 = "up";
            }
            if((Location.X + Speed) <= 0 && (Location.Y - Speed) <= 0)
            {
                direction1 = "right";
                direction2 = "down";
            }
            if(((Location.X + offset) >= Boundary.X) &&((Location.Y + offset) >= Boundary.Y))
            {
                direction1 = "Left";
                direction2 = "up";
            }
            if ((direction1 == "Left") && (direction2 == "down"))
            {
                Location.X -= Speed;
                Location.Y += Speed;
            }
            if ((direction1 == "down") && (direction2 == "Left"))
            {
                Location.X -= Speed;
                Location.Y += Speed;
            }
            if ((direction1 == "right") && (direction2 == "up"))
            {
                Location.X += Speed;
                Location.Y -= Speed;
            }
            if ((direction1 == "up") && (direction2 == "right"))
            {
                Location.X += Speed;
                Location.Y -= Speed;
            }
            if (direction1 == "right" && direction2 == "down")
            {
                Location.X += Speed;
                Location.Y += Speed;
            }
            if (direction1 == "down" && direction2 == "right")
            {
                Location.X += Speed;
                Location.Y += Speed;
            }
            if(direction1 == "up" && direction2 =="Left")
            {
                Location.X -= Speed;
                Location.Y -= Speed;
            }
            if (direction1 == "Left" && direction2 == "up")
            {
                Location.X -= Speed;
                Location.Y -= Speed;
            }
            return Location;

        }
    }
}
