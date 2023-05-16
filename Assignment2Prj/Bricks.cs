using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2Prj
{
    public class Bricks
    {
        /// <summary>
        /// Your Brick class must have following attributes 
        /// Add more attributes if required 
        /// </summary>
        private PictureBox[,] bricks;
        private int rows;
        private int cols;
        private int[,] firmness;
        private Random rand;

        public Bricks(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            this.bricks = new PictureBox[rows, cols];
            this.firmness = new int[rows, cols];
            this.rand = new Random();

            // init brick
            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    PictureBox box = new PictureBox();
                    box.Left = i * 101;
                    box.Top = j * 31;
                    box.Size = new Size(100, 30);
                    this.bricks[j, i] = box;
                    this.firmness[j, i] = rand.Next(1, 5);
                }
            }

            // init bomb
            for (int i = 0; i < 2; i++)
            {
                this.firmness[rand.Next(0, rows), rand.Next(0, cols)] = -1;
            }

            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    switch (this.firmness[j, i])
                    {
                        case -1:
                            this.bricks[j, i].BackColor = Color.Gold;
                            break;
                        case 1:
                            this.bricks[j, i].BackColor = Color.Gray;
                            break;
                        case 2:
                            this.bricks[j, i].BackColor = Color.Blue;
                            break;
                        case 3:
                            this.bricks[j, i].BackColor = Color.Green;
                            break;
                        case 4:
                            this.bricks[j, i].BackColor = Color.Red;
                            break;
                    }
                }
            }
        }
        //Add methods 

        public PictureBox[,] GetBricks()
        {
            return bricks;
        }

        public int GetCols()
        {
            return cols;
        }

        public int GetRows()
        {
            return rows;
        }

        public int GetFirmness(int row, int col)
        {
            return firmness[row, col];
        }

        public void SetFirmness(int row, int col, int value)
        {
            firmness[row, col] = value;
            switch (value)
            {
                case 1:
                    this.bricks[row, col].BackColor = Color.Gray;
                    break;
                case 2:
                    this.bricks[row, col].BackColor = Color.Blue;
                    break;
                case 3:
                    this.bricks[row, col].BackColor = Color.Green;
                    break;
                case 0:
                    this.bricks[row, col].Hide();
                    break;
            }
        }

        public void OnBomb()
        {
            for (int i = 0; i < firmness.GetLength(0); i++)
            {
                for (int j = 0; j < firmness.GetLength(1); j++)
                {
                    firmness[i, j] = 0;
                    bricks[i, j].Hide();
                }
            }
        }

    }
}
