using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1002_MyCanvas
{
    class MyButton
    {
        protected Point topLeft;
        protected Point bottomRight;

        private int width, height;

        internal MyButton(Point topLeft, Point bottomRight)
        {
            this.topLeft = topLeft;
            this.bottomRight = bottomRight;
        }

        internal int GetWidth()
        {
            return this.width;
        }
        internal int GetHeight()
        {
            return this.height;
        }
        internal bool SetTopLeft(Point p)
        {
            if ((p.GetX() < this.bottomRight.GetX()) && (p.GetY() < this.bottomRight.GetY()))
            {
                this.topLeft = p;
                this.height = this.bottomRight.GetX() - this.topLeft.GetX();
                this.width = this.bottomRight.GetY() - this.topLeft.GetY();
                return true;
            }
            else
            {
                Console.WriteLine("point is not on the top left of button");
                return false;
            }

        }
        internal bool SetBotomRight(Point p)
        {
            if ((p.GetX() > this.topLeft.GetX()) && (p.GetY() > this.topLeft.GetY()))
            {
                this.bottomRight = p;
                this.height = this.bottomRight.GetX() - this.topLeft.GetX();
                this.width = this.bottomRight.GetY() - this.topLeft.GetY();
                return true;
            }
            else
            {
                Console.WriteLine("point is not on the Botom Right of button");
                return false;
            }
        }
        internal Point GetTopLeft()
        {
            return topLeft;
        }
        internal Point GetBottomRight()
        {
            return bottomRight;
        }

        public override string ToString()
        {
            return $"width {this.width}, height {this.height}, topPoint {this.topLeft}, bottomRight {this.bottomRight}";
        }
    }
}
