using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Canvas canvas = new Canvas();
            this.Content = canvas;
            canvas.Height = 800;
            canvas.Width = 800;
            double gap = 50;
            double lenght = 100;
            SolidColorBrush strokeColor = new SolidColorBrush(Colors.Black);

            if (gap < lenght)
            {
                snail(0, 0, lenght);
            }

            void snail(double prevXPossition, double prevYPossition , double lenght)
            {
                Line LineToRight = createLine(prevXPossition, prevYPossition, prevXPossition + lenght, prevYPossition);
                Line LineDown = createLine(LineToRight.X2, LineToRight.Y2, LineToRight.X2, LineToRight.Y2 + lenght);
                Line LineToLeft = createLine(LineDown.X2, LineDown.Y2, LineDown.X2 - lenght + gap, LineDown.Y2);
                Line LineUp = createLine(LineToLeft.X2, LineToLeft.Y2, LineToLeft.X2, LineToLeft.Y2 - lenght + gap);


                drawLines(new Line[] { LineToRight, LineDown, LineToLeft, LineUp });

                if(lenght - 2*gap >= gap)
                {
                        snail(LineUp.X2, LineUp.Y2, lenght - 2*gap);
                }
            }

            //vytvoreni lajn
            Line createLine(double x, double y, double x2, double y2)
            {
                Line newLine = new Line()
                {
                    StrokeThickness = 4,
                    Stroke = strokeColor,
                    X1 = x,
                    Y1 = y,
                    X2 = x2,
                    Y2 = y2
                };

                return newLine;
            }

            //vykresleni lajn
            void drawLines(Line[] linesToDraw)
            {
                foreach(Line line in linesToDraw)
                {
                    canvas.Children.Add(line);
                }
            }
        }
    }
}
