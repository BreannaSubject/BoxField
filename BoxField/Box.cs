using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BoxField
{
    
    class Box
    {
        public Color colour;
        public int size, x, y;
       

        public Box(int _x, int _y, int _size, Color _colour)
        {
            x = _x;
            y = _y;
            size = _size;
            colour = _colour;
        }

        public Box(int _x, int _y, int _size)
        {
            x = _x;
            y = _y;
            size = _size;
        }



        public void Move(int speed)
        { 
            y += speed;
           
        }
        public void Move(int speed, Boolean direction)
        {
           if (direction)
            {
                x += speed;
            }
            else
            {
                x -= speed;
            }

        }

    }
}
