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
    class ball
    {
            private float size;
            private PointF position;
            private Color color;

            public ball(float m_size, PointF m_position)
            {
                size = m_size;
                position = m_position;
                color = Color.ForestGreen;
            }

        
        //Methods
        private static float GetDistance(ball ballUno, ball ballDuo)
        {
            return (float)(Math.Sqrt(Math.Pow(ballDuo.position.X - ballUno.position.X, 2) + Math.Pow(ballDuo.position.Y - ballUno.position.Y, 2)));
        }

        public void Render(CDrawer canvas)
        {
            canvas.AddCenteredEllipse((int)position.X, (int)position.Y,
                (int)size,
                (int)size,
                color,
                1,
                Color.Orchid);
        }
        public override bool Equals(object obj)
        {
            if(!(obj is ball))
            {
                return false;
            }

            ball temporaryBall = (ball)obj;

            return (GetDistance(this, temporaryBall) < ((this.size / 2) + (temporaryBall.size / 2)));
        }
        public override int GetHashCode()
        {
            return 1;
        }
    }
}
