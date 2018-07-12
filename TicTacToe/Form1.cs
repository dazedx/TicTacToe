using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        TTT_Feld[,] SpielFeld = new TTT_Feld[3, 3];
        int Clicks = 0;

        public Form1()
        {
            InitializeComponent();

            int Reset = 20;

            Size Size = new Size(80, 80);
            Point Location = new Point(20, 20);

            for (int Line = 0; Line < SpielFeld.GetLength(0); Line++)
            {
                for (int Column = 0; Column < SpielFeld.GetLength(1); Column++)
                {
                    SpielFeld[Line, Column] = new TTT_Feld(Location, Size);
                    SpielFeld[Line, Column].b.Name = string.Format("{0} {1}", Line, Column);
                    //SpielFeld[Line, Column].b.Text = string.Format("{0} {1}", Line, Column);
                    SpielFeld[Line, Column].b.Click += new EventHandler(this.btn_Click);
                    this.Controls.Add(SpielFeld[Line, Column].b);

                    Location.X += Size.Width;
                }

                Location.X = Reset;
                Location.Y += Size.Height;
            }

            int Width = SpielFeld.GetLength(0) * Size.Width + (Size.Width / 2);
            int Height = SpielFeld.GetLength(1) * Size.Height + (Size.Height / 2);

            this.ClientSize = new Size(Width, Height);
            this.MaximizeBox = false;
            this.Text = "TicTacToe";
        }

        private bool CheckHorizontal(int currentLine)
        {
            int Line = currentLine;
            int MaxColumn = SpielFeld.GetLength(1) - 1;
            int HitCross = 0;
            int HitCircle = 0;

            for (int Column = MaxColumn; Column > 0; Column--)
            {
                if (SpielFeld[Line, Column].IsCross() && SpielFeld[Line, Column - 1].IsCross())
                {
                    HitCross++;

                    if (HitCross == MaxColumn)
                    {
                        MessageBox.Show("Kreuz hat Gewonnen! (Horizontal)");
                        return true;
                    }
                }
                else if (SpielFeld[Line, Column].IsCircle() && SpielFeld[Line, Column - 1].IsCircle())
                {
                    HitCircle++;

                    if (HitCircle == MaxColumn)
                    {
                        MessageBox.Show("Kreis hat Gewonnen! (Horizontal)");
                        return true;
                    }
                }
            }

            return false;
        }

        private bool CheckVertical(int currentColumn)
        {
            int Column = currentColumn;
            int MaxLine = SpielFeld.GetLength(0) - 1;
            int HitCross = 0;
            int HitCircle = 0;

            for (int Line = MaxLine; Line > 0; Line--)
            {
                if (SpielFeld[Line, Column].IsCross() && SpielFeld[Line - 1, Column].IsCross())
                {
                    HitCross++;

                    if (HitCross == MaxLine)
                    {
                        MessageBox.Show("Kreuz hat Gewonnen! (Vertikal)");
                        return true;
                    }
                }
                else if (SpielFeld[Line, Column].IsCircle() && SpielFeld[Line - 1, Column].IsCircle())
                {
                    HitCircle++;

                    if (HitCircle == MaxLine)
                    {
                        MessageBox.Show("Kreis hat Gewonnen! (Vertikal)");
                        return true;
                    }
                }
            }

            return false;
        }

        private bool CheckDiagonalLeftToRight()
        {
            int MaxDiagonal = SpielFeld.GetLength(0) - 1;
            int HitCross = 0;
            int HitCircle = 0;

            for (int Diagonale = 0; Diagonale < SpielFeld.GetLength(0) - 1; Diagonale++)
            {
                if (SpielFeld[Diagonale, Diagonale].IsCross() && SpielFeld[Diagonale + 1, Diagonale + 1].IsCross())
                {
                    HitCross++;

                    if (HitCross == MaxDiagonal)
                    {
                        MessageBox.Show("Kreuz hat Gewonnen! (Diagonal)");
                        return true;
                    }
                }
                else if (SpielFeld[Diagonale, Diagonale].IsCircle() && SpielFeld[Diagonale + 1, Diagonale + 1].IsCircle())
                {
                    HitCircle++;

                    if (HitCircle == MaxDiagonal)
                    {
                        MessageBox.Show("Kreis hat Gewonnen! (Diagonal)");
                        return true;
                    }
                }
            }

            return false;
        }

        private bool CheckDiagonalRightToLeft()
        {
            int Line = 1;
            int Column = 1;

            if (SpielFeld[Line, Column].IsCircle() && SpielFeld[Line - 1, Column + 1].IsCircle() && SpielFeld[Line + 1, Column - 1].IsCircle())
            {
                MessageBox.Show("Kreis hat gewonnen (Diagonal)");
                return true;
            }
            else if (SpielFeld[Line, Column].IsCross() && SpielFeld[Line - 1, Column + 1].IsCross() && SpielFeld[Line + 1, Column - 1].IsCross())
            {
                MessageBox.Show("Kreuz hat gewonnen (Diagonal)");
                return true;
            }

            return false;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button currentButton = (Button)sender;

            string[] Parts = currentButton.Name.Split(' ');

            int Line = int.Parse(Parts[0]);
            int Column = int.Parse(Parts[1]);

            if (currentButton.BackgroundImage == null)
            {
                ++Clicks;

                if (Clicks % 2 == 1)
                {
                    SpielFeld[Line, Column].DisplayCircle();
                }
                else
                {
                    SpielFeld[Line, Column].DisplayCross();
                }
            }

            if (CheckHorizontal(Line) || CheckVertical(Column) || CheckDiagonalLeftToRight() || CheckDiagonalRightToLeft())
            {
                for (Line = 0; Line < SpielFeld.GetLength(0); Line++)
                {
                    for (Column = 0; Column < SpielFeld.GetLength(1); Column++)
                    {
                        SpielFeld[Line, Column].b.BackgroundImage = null;
                    }
                }
            }
        }
    }
}
