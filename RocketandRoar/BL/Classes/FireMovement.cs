using Rocket.Enum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocket.A {
    public class FireMovement : Imovement
    {
        private int Speed;
        private Point Boundary;
        private Direction Direction;

        public FireMovement(int speed, Point boundary, Direction direction)
        {
            this.Speed = speed;
            this.Boundary = boundary;
            this.Direction = direction;
        }

      

        Point Imovement.move(Point Location)
        {
            if (Direction == Direction.Up)
            {
                Location.Y -= Speed;
            }
            //else if (Direction == Direction.Right)
            //    Location.X += Speed;
            return Location;
        }
    }
}

