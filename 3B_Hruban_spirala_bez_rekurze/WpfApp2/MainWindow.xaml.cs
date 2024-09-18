using System;
using System.Collections.Generic;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
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
            SolidColorBrush strokeColor = new SolidColorBrush(Colors.Black);
            this.Content = canvas;
            canvas.Height = 800;
            canvas.Width = 800;
            double gap = 50;
            double prevXPossition = 0;
            double prevYPossition = 0;
            double lenght = 1000;

           
            while (lenght - gap >= gap)
            {
                Line LineToRight = createLine(prevXPossition, prevYPossition, prevXPossition + lenght, prevYPossition);
                Line LineDown = createLine(LineToRight.X2, LineToRight.Y2, LineToRight.X2, LineToRight.Y2 + lenght);
                Line LineToLeft = createLine(LineDown.X2, LineDown.Y2, LineDown.X2 - lenght + gap, LineDown.Y2);
                Line LineUp = createLine(LineToLeft.X2, LineToLeft.Y2, LineToLeft.X2, LineToLeft.Y2 - lenght + gap);

                drawLines(new Line[] { LineToRight, LineDown, LineToLeft, LineUp });

                prevXPossition = LineUp.X2;
                prevYPossition = LineUp.Y2;
                lenght -= 2 * gap;

            }

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

            void drawLines(Line[] linesToDraw)
            {
                foreach (Line line in linesToDraw)
                {
                    canvas.Children.Add(line);
                }
            }
        }
    }
}
