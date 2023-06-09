﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2Prj
{
    public partial class Game : Form
    {
        /// <summary>
        /// 
        /// </summary>
        /// 

        private Bricks bricks;
        private Ball ball;
        private Paddle paddle;
        private Manager manager;

        private int verticalSpeed;
        private int horizontalSpeed;
        private int bricksRows;
        private int bricksCols;
        private int paddleSpeed;


        public Game()
        {
            InitializeComponent();
            //Adjust these numbers 
            this.verticalSpeed = 5;
            this.horizontalSpeed = 5;
            this.bricksRows = 5;
            this.bricksCols = 8;
            this.paddleSpeed = 5;

            //Create objects 
            this.ball = new Ball(picBall, verticalSpeed, horizontalSpeed);
            this.paddle = new Paddle(picPaddle, paddleSpeed);
            this.bricks = new Bricks(bricksRows, bricksCols);

            this.manager = new Manager(bricks, ball, paddle);
        }

        private void Game_Load(object sender, EventArgs e)
        {
            PictureBox[,] array = this.bricks.GetBricks();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    this.Controls.Add(array[i, j]);
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.manager.Tick();
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Left:
                    this.paddle.Move(-1);
                    break;
                case Keys.Right:
                    this.paddle.Move(1);
                    break;
            }
        }
    }
}
