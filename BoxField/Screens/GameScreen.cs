using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoxField
{
    public partial class GameScreen : UserControl
    {
        //player1 button control keys
        Boolean leftArrowDown, rightArrowDown;

        //used to draw boxes on screen
        SolidBrush boxBrush = new SolidBrush(Color.White);
        Random random = new Random();
        Color colour = Color.White;
        int red, green, blue;

        List<Box> left = new List<Box>();
        List<Box> right = new List<Box>();
        int leftX = 250;
        int gap = 300;
        int patternLegth = 11;
        Boolean patternDirection = true;

        Box hero;
        int heroSpeed = 10;
        int heroSize = 30;

        


        public GameScreen()
        {
            InitializeComponent();
            OnStart();
        }

        /// <summary>
        /// Set initial game values here
        /// </summary>
        public void OnStart()
        {
            //set game start values

            MakeBox();

            hero = new Box(this.Width / 2 - heroSize / 2, 400, heroSize);

           



        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //player 1 button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;           
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //player 1 button releases
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
            }
        }

        private void MakeBox()
        {
            patternLegth--;

            if (patternLegth == 0)
            {
                if (patternDirection == true)
                {
                    patternDirection = false;
                }
                else
                {
                    patternDirection = true;
                }
                
                patternLegth = random.Next (2, 20);
            }
            if (patternDirection == true)
            {
                leftX += 9;
            }
            else 
            {
                leftX -= 9;
            }
            Box leftBox = new Box(leftX, 0, 20, colour);
            left.Add(leftBox);
            Box rightBox = new Box(leftX + gap, 0, 20, colour);
            right.Add(rightBox);
            red = random.Next(1, 255);
            green = random.Next(1, 255);
            blue = random.Next(1, 255);
            colour = Color.FromArgb(red, green, blue);
        }

        private void gameLoop_Tick(object sender, EventArgs e)
        {
            
            
         

            //update location of all boxes (drop down screen)
            foreach (Box b in left)
            {
                b.Move(5);
               
            }

            foreach (Box b in right)
            {
                b.Move(5);
                
            }

            //TODO - remove box if it has gone of screen
            if (left [0].y > 500)
            {
                left.RemoveAt(0);
            }
            
            if (right [0].y > 500)
            {
                right.RemoveAt(0);
            }

            //add new box if it is time
            if (left[left.Count - 1].y > 21)
            {
                MakeBox();

            }

            if (right[right.Count - 1].y > 21)
            {
                MakeBox();
      
            }
            

            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
           
            //draw boxes to screen
            foreach (Box b in left)
            {
                boxBrush.Color = b.colour;
                e.Graphics.FillRectangle(boxBrush, b.x, b.y, b.size, b.size); 
            }

            foreach (Box b in right)
            {
                boxBrush.Color = b.colour;
                e.Graphics.FillRectangle(boxBrush, b.x, b.y, b.size, b.size);
            }

            boxBrush.Color = Color.White;
            e.Graphics.FillRectangle(boxBrush, hero.x, hero.y, hero.size, hero.size);


        }
    }
}
