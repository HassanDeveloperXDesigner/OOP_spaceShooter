using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using EZInput;
using Point = System.Drawing.Point;

namespace Rocket.A
{
    public class PlayerMove: Imovement
    {
        private int Speed;
        private Point Boundary;
        private string direction;
        private int offset = 90;
        public PlayerMove() 
        {

        }
        public PlayerMove(int speed,Point Boundary)
        {
            this.Speed = speed;
            this.Boundary = Boundary;

        }
        

        public Point move(Point Location)
        {
            
            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {                
                Location.X += Speed;

            }

            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {               
                Location.X -= Speed;
            }

            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {                
                Location.Y -= Speed;
            }

            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {               
                Location.Y += Speed;
            }
           
            return Location;

        }
    }
}
