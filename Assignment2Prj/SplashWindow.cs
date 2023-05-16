using System;
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
    public partial class SplashWindow : Form
    {
        private Game game;

        public SplashWindow()
        {
            InitializeComponent();
            game = new Game();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            game.Show();
            this.Hide();
        }

        private void btn_continue_Click(object sender, EventArgs e)
        {
            game.Show();
            this.Hide();
        }
    }
}
