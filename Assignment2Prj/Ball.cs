using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2Prj
{
    public class Ball
    {
        /// <summary>
        /// Your Ball class must have following attributes 
        /// Add more attributes if required 
        /// </summary>
        private PictureBox picBall;
        private int verticalSpeed, horizontalSpeed;

        public Ball(PictureBox picBall, int verticalSpeed, int horizontalSpeed)
        {
            this.picBall = picBall;
            this.verticalSpeed = verticalSpeed;
            this.horizontalSpeed = horizontalSpeed;
        }
        //Add methods

        public Point CalcMove(int horizontalDir, int verticalDir, double delta)
        {
            int left = picBall.Left + (int)Math.Round(delta * horizontalSpeed * horizontalDir);
            int top = picBall.Top + (int)Math.Round(delta * verticalSpeed * verticalDir);

            return new Point(left, top);
        }

        public void DoMove(Point point)
        {
            this.picBall.Left = point.X;
            this.picBall.Top = point.Y;
        }
    }
}
