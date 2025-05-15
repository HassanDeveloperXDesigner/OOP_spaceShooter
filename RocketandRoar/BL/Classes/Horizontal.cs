using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.Enum;


namespace Rocket.A
{
    public  class Horizontal:Imovement
    {
        private int Speed;
        private Point Boundary;
        private Direction direction;
        private int offset = 90;

        public Horizontal()
        {
        
        }
        public Horizontal(int speed,Point Boundary,Direction direction)
        {
            this.Speed = speed;
            this.Boundary = Boundary;
            this.direction = direction;
        }
        public Point move(Point location) 
        { 
            if ((location.X + offset) >= Boundary.X ) 
            {
                direction = Direction.Left;
            }
            else if (location.X + Speed <= 0)
            {
                direction = Direction.Right;
            }
            if (direction == Direction.Left)
            {
                location.X -= Speed;
            }
            if (direction == Direction.Right)
            {
                location.X += Speed;
            }
            return location;
        
        }


    }
}
