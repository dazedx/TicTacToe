using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe
{
    class TTT_Feld
    {
        private Image Cross;
        private Image Circle;

        public Button b = new Button();

        public TTT_Feld(Point Location, Size Size)
        {
            Cross   = Image.FromFile("../../Pictures/Cross.png");
            Circle  = Image.FromFile("../../Pictures/Circle.png");

            b.Location = Location;
            b.Size = Size;
        }

        public void DisplayCircle()
        {
            b.BackgroundImageLayout = ImageLayout.Stretch;
            b.BackgroundImage = Circle;
        }

        public void DisplayCross()
        {
            b.BackgroundImageLayout = ImageLayout.Stretch;
            b.BackgroundImage = Cross;
        }

        public bool IsCross()
        {
            return (b.BackgroundImage == Cross);
        }

        public bool IsCircle()
        {
            return (b.BackgroundImage == Circle);
        }
    }
}
