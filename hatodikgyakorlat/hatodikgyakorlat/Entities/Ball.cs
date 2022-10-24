using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hatodikgyakorlat.Entities
{
    internal class Ball:Label
    {
        public Ball()
        {
            AutoSize = false;
            Height = 50;
            Width = Height;
            Paint += Ball_Paint;
            
        }

        protected void DrawImage(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Blue), 0, 0, Width, Height); //nem volt meg
        }

        private void Ball_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);
        }

        public void MoveBall()
        {
            Left += 1;
        }
    }
}
