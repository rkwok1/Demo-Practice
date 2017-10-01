using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;


namespace EqualsOverridePractice
{
    
    public partial class Form1 : Form
    {
        //Global Members
        private Random rnd = new Random();
        private CDrawer drawSpace = new CDrawer(600, 900, false);
        private List<ball> ballList = new List<ball>();

        public Form1()
        {
            InitializeComponent();
            drawSpace.MouseLeftClick += DrawSpace_MouseLeftClick;
        }

        private void DrawSpace_MouseLeftClick(Point pos, CDrawer dr)
        {
            ball temp = new ball((float)(rnd.NextDouble() * 100 + 10), pos);

            //Access the list to see if it contains a ball
            lock (ballList)
            {
                if (ballList.Contains(temp))
                    return; //return nothing!
            }

            //Add ball to the list
            lock (ballList)
            {
                ballList.Add(temp);
            }
            Render();
        }
        private void Render()
        {
            drawSpace.Clear();

            lock (ballList)
            {
                foreach  (ball b in ballList)
                {
                    b.Render(drawSpace);
                }
            }
            drawSpace.Render();
        }
    }
}
