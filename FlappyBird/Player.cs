using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FlappyBird
{
    class Player
    {
        public float x;
        public float y;

        public int size;
        public float gravityValue;

        public Image birdImg;

        public bool isAlive;

        public int color = 0;

        public int setcolor(int color)
        {
            return this.color = color;
        }
        public Player(int x, int y)
        {
            if(color == 0)
            {
                birdImg = new Bitmap(Properties.Resources.yellow_bird);
            }
            if (color == 1)
            {
                birdImg = new Bitmap(Properties.Resources.red_bird);
            }
            if (color == 2)
            {
                birdImg = new Bitmap(Properties.Resources.green_bird);
            }
            this.x = x;
            this.y = y;
            size = 50;
            gravityValue = 0.1f;
            isAlive = true;
        }


    }
}
