using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public partial class Form1 : Form
    {
        private const string Filename = "C:\\ffff\\bg.png";

        // created by mooict.com 2022
        // for educational purpose only
        Image FootBall;
        bool goLeft, goRight, goUp, goDown;
        int speed = 10;
        int positionX = 200;
        int positionY = 200;
        int height = 50;
        int width = 50;
        public Form1()
        {
            InitializeComponent();
            InitializeComponent();
            this.BackgroundImage = Image.FromFile("C:\\ffff\\bg.png");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            FootBall = Image.FromFile(Filename);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void TimerEvent(object sender, EventArgs e)
        {
            if (goLeft && positionX > 0)
            {
                positionX -= speed;
            }
            if (goRight && positionX + width < this.ClientSize.Width) { positionX += speed; }
            if (goUp && positionY > 0)
            {
                positionY -= speed;
            }
            if (goDown && positionY + height < this.ClientSize.Height)
            {
                positionY += speed;
            }
            this.Invalidate();
        }
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            else if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                goUp = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                goDown = true;
            }
        }
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            else if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            else if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            else if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
        }
        private void FormPaintEvent(object sender, PaintEventArgs e)
        {
            Graphics Canvas = e.Graphics;
            Canvas.DrawImage(FootBall, positionX, positionY, width, height);
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}
