using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hatodikgyakorlat.Abstractions
{
    public abstract class Toy:Label
    {
        public Toy()
        {
            AutoSize = false;
            Height = 50;
            Width = Height;
            Paint += Toy_Paint;

        }

        protected abstract void DrawImage(Graphics g);
        
            
        

        private void Toy_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);
        }

        public void MoveToy()
        {
            Left += 1;
        }

    }
}
