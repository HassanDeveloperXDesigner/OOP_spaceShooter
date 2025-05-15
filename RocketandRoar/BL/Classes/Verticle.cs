using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.Enum;

namespace Rocket.A
{
    public class Verticle : Imovement
    {

        private int Speed;
        private Point Boundary;
        private Direction direction;
        private int offset = 90;

        public Verticle()
        {

        }
        public Verticle(int speed, Point Boundary, Direction direction)
        {
            this.Speed = speed;
            this.Boundary = Boundary;
            this.direction = direction;
        }
        public Point move(Point location)
        {
            if ((location.Y+ offset) >= Boundary.Y)
            {
                direction = Direction.Up ;
            }
            else if ((location.Y - Speed) <= 0)
            {
                direction = Direction.Down;
            }
            if (direction == Direction.Up)
            {
                location.Y -= Speed;
            }
            if (direction == Direction.Down)
            {
                location.Y += Speed;
            }
            return location;

        }
    }
}
