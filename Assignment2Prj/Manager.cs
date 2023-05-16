using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2Prj
{
    public class Manager
    {
        /// <summary>
        /// Your Manager class must have following attributes 
        /// Add more attributes if required 
        /// </summary>
        private Bricks bricks;
        private Ball ball;
        private Paddle paddle;

        private int horizontalDir = -1, verticalDir = -1;

        public Manager(Bricks bricks, Ball ball, Paddle paddle)
        {
            this.bricks = bricks;
            this.ball = ball;
            this.paddle = paddle;


        }

        private void CheckCollision()
        {

        }

        public void Tick()
        {
            Point point = this.ball.CalcMove(horizontalDir, verticalDir, 0.5);

            if (point.X <= 0)
            {
                point.X = 0;
                horizontalDir *= -1;
            }
            if (point.X >= 800 - 16)
            {
                point.X = 800 - 16;
                horizontalDir *= -1;
            }
            if (point.Y <= 0)
            {
                point.Y = 0;
                verticalDir *= -1;
            }
            if (point.Y >= 500)
            {
                point.Y = 500;
                verticalDir *= -1;
            }

            int row = point.Y / 31;

            if (row < bricks.GetRows())
            {
                int col = point.X / 101;

                int firmness = bricks.GetFirmness(row, col);

                if (firmness > 0)
                {
                    bricks.SetFirmness(row, col, firmness - 1);
                    verticalDir *= -1;
                }
                else if (firmness == -1)
                {
                    bricks.OnBomb();
                    verticalDir *= -1;
                }
            }
            this.ball.DoMove(point);
        }
    }
}
