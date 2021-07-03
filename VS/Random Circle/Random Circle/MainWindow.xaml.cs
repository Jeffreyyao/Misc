using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Shapes;
namespace Random_Circle
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rand = new Random();
        public MainWindow()
        {
            InitializeComponent();
            drawcircle(500);
        }
        void drawcircle(int count)
        {
            for(int i = 0; i < count; i++)
            {
                Line l = new Line();
                l.Stroke = System.Windows.Media.Brushes.Black;
                double theta1 = rand.Next(0, 360);
                double x1 = 250 + 200 * Math.Cos(theta1);
                double y1 = 250 + 200 * Math.Sin(theta1);

                double theta2 = rand.Next(0, 360);
                double x2 = 250 + 200 * Math.Cos(theta2);
                double y2 = 250 + 200 * Math.Sin(theta2);
                l.X1 = x1;
                l.X2 = x2;
                l.Y1 = y1;
                l.Y2 = y2;
                c.Children.Add(l);
            }
        }
    }
}
