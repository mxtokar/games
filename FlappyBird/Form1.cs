using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {
        Player bird;
        TheWall wall1;
        TheWall wall2;
        TheWall wall3;
        TheWall wall4;
        TheWall wall5;
        TheWall wall6;
        TheWall wall7;
        TheWall wall8;
        TheWall wall9;
        TheWall wall10;
        float gravity;
        int Inscore = 0;
        int BestScore = 0;
        int difficult = 1;
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 10;
            timer1.Tick += new EventHandler(update);
            Init();
            Invalidate();
        }

        public void Init()
        {
            this.BackgroundImage = new Bitmap(Properties.Resources.background);

            bird = new Player(150, 200);

            wall1 = new TheWall(500, -100, true);
            wall2 = new TheWall(500, 300);
            wall3 = new TheWall(750, -200, true);
            wall4 = new TheWall(750, 200);
            wall5 = new TheWall(1000, -70, true);
            wall6 = new TheWall(1000, 330);
            wall7 = new TheWall(1250, -100, true);
            wall8 = new TheWall(1250, 300);
            wall9 = new TheWall(1500, -140, true);
            wall10 = new TheWall(1500, 260);

            gravity = 0;

            if(Inscore > BestScore)
            {
                BestScore = Inscore;
                label2.Text = "Best Score: " + BestScore;
            }
            Inscore = 0;
            label1.Text = "Score: " + Inscore;
            Invalidate();
        }

        private void update(object sender, EventArgs e)
        {
            if (bird.y > 600)
            {
                bird.isAlive = false;
                timer1.Stop();
                Init();
            }

            
            if(wall1.x == bird.x - 50)
            {
                Inscore += 1;
                label1.Text = "Score: " + Inscore;

            }
            if (wall3.x == bird.x - 70)
            {
                Inscore += 1;
                label1.Text = "Score: " + Inscore;
            }
            if (wall5.x == bird.x - 80)
            {
                Inscore += 1;
                label1.Text = "Score: " + Inscore;
            }
            if (wall7.x == bird.x - 120)
            {
                Inscore += 1;
                label1.Text = "Score: " + Inscore;
            }
            if (wall9.x == bird.x - 110)
            {
                Inscore += 1;
                label1.Text = "Score: " + Inscore;
            }


            if (Collide(bird, wall1) || Collide(bird, wall2))
            {
                bird.isAlive = false;
                timer1.Stop();
                Init();

            }


            if (Collide(bird, wall3) || Collide(bird, wall4))
            {
                bird.isAlive = false;
                timer1.Stop();
                Init();
            }


            if (Collide(bird, wall5) || Collide(bird, wall6))
            {
                bird.isAlive = false;
                timer1.Stop();
                Init();
            }

            if (Collide(bird, wall7) || Collide(bird, wall8))
            {
                bird.isAlive = false;
                timer1.Stop();
                Init();
            }

            if (Collide(bird, wall9) || Collide(bird, wall10))
            {
                bird.isAlive = false;
                timer1.Stop();
                Init();
            }

            if (bird.gravityValue != 0.1f)
                bird.gravityValue += 0.005f;
            gravity += bird.gravityValue;
            bird.y += gravity;


            if (bird.isAlive)
            {
                MoveWalls();
            }
            Invalidate();
        }

        private bool Collide(Player bird, TheWall wall1)
        {
            PointF delta = new PointF();
            delta.X = (bird.x + bird.size / 2) - (wall1.x + wall1.sizeX / 2);
            delta.Y = (bird.y + bird.size / 2) - (wall1.y + wall1.sizeY / 2);
            if (Math.Abs(delta.X) <= bird.size / 2 + wall1.sizeX / 2)
            {
                if (Math.Abs(delta.Y) <= bird.size / 2 + wall1.sizeY / 2)
                {
                    return true;
                }

            }
            return false;
        }





        private void CreateNewWall()
        {
            if (wall1.x < bird.x - 1150)
            {
                Random r = new Random();
                int y1, y2, y3, y4, y5;
                y1 = r.Next(-200, 000);
                y2 = r.Next(-210, 000);
                y3 = r.Next(-150, 000);
                y4 = r.Next(-210, 000);
                y5 = r.Next(-180, 000);
                wall1 = new TheWall(500, y1, true);
                wall2 = new TheWall(500, y1 + 400);
                wall3 = new TheWall(750, y2, true);
                wall4 = new TheWall(750, y2 + 400);
                wall5 = new TheWall(1000, y3, true);
                wall6 = new TheWall(1000, y3 + 400);
                wall7 = new TheWall(1250, y4, true);
                wall8 = new TheWall(1250, y4 + 400);
                wall9 = new TheWall(1500, y5, true);
                wall10 = new TheWall(1500, y5 + 400);
            }
        }

        private void MoveWalls()
        {
            if(difficult == 1)
            {
                wall1.x -= 2;
                wall2.x -= 2;
                wall3.x -= 2;
                wall4.x -= 2;
                wall5.x -= 2;
                wall6.x -= 2;
                wall7.x -= 2;
                wall8.x -= 2;
                wall9.x -= 2;
                wall10.x -= 2;
            }
            if (difficult == 2)
            {
                wall1.x -= 4;
                wall2.x -= 4;
                wall3.x -= 4;
                wall4.x -= 4;
                wall5.x -= 4;
                wall6.x -= 4;
                wall7.x -= 4;
                wall8.x -= 4;
                wall9.x -= 4;
                wall10.x -= 4;
            }
            if (difficult == 3)
            {
                wall1.x -= 5;
                wall2.x -= 5;
                wall3.x -= 5;
                wall4.x -= 5;
                wall5.x -= 5;
                wall6.x -= 5;
                wall7.x -= 5;
                wall8.x -= 5;
                wall9.x -= 5;
                wall10.x -= 5;
            }
            CreateNewWall();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            graphics.DrawImage(bird.birdImg, bird.x, bird.y, bird.size, bird.size);

            graphics.DrawImage(wall1.wallImg, wall1.x, wall1.y, wall1.sizeX, wall1.sizeY);

            graphics.DrawImage(wall2.wallImg, wall2.x, wall2.y, wall2.sizeX, wall2.sizeY);

            graphics.DrawImage(wall3.wallImg, wall3.x, wall3.y, wall3.sizeX, wall3.sizeY);

            graphics.DrawImage(wall4.wallImg, wall4.x, wall4.y, wall4.sizeX, wall4.sizeY);

            graphics.DrawImage(wall5.wallImg, wall5.x, wall5.y, wall5.sizeX, wall5.sizeY);

            graphics.DrawImage(wall6.wallImg, wall6.x, wall6.y, wall6.sizeX, wall6.sizeY);

            graphics.DrawImage(wall7.wallImg, wall7.x, wall7.y, wall7.sizeX, wall7.sizeY);

            graphics.DrawImage(wall8.wallImg, wall8.x, wall8.y, wall8.sizeX, wall8.sizeY);

            graphics.DrawImage(wall9.wallImg, wall9.x, wall9.y, wall9.sizeX, wall9.sizeY);

            graphics.DrawImage(wall10.wallImg, wall10.x, wall10.y, wall10.sizeX, wall10.sizeY);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();

            if (bird.isAlive)
                {
                    gravity = 0;
                    bird.gravityValue = -0.125f;
                }           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void yellowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bird.birdImg = new Bitmap(Properties.Resources.yellow_bird);
            Invalidate();
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bird.birdImg = new Bitmap(Properties.Resources.red_bird);
            Invalidate();
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bird.birdImg = new Bitmap(Properties.Resources.green_bird);
            Invalidate();
        }

        private void easyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            difficult = 1;
        }

        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            difficult = 2;
        }

        private void hardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            difficult = 3;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
