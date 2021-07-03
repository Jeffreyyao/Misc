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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace gameoflife
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        Rectangle[,] board = new Rectangle[21,21] ;
        public MainWindow()
        {
            InitializeComponent();
            generateBlocks();
        }

        void generateBlocks() {
            for(int i = 1; i < 19; i++)
            {
                for (int j = 1; j < 19; j++) {                    
                    Rectangle r = new Rectangle();
                    
                    r.Fill = Brushes.White;
                    Grid.SetColumn(r, i);
                    Grid.SetRow(r, j);
                    grid.Children.Add(r);
                    board[i,j] = r;
                    r.MouseLeftButtonDown += new MouseButtonEventHandler((object o, MouseButtonEventArgs e) => 
                    {
                        r.Fill = Brushes.Black;
                    });
                }
            }
        }

        List<Rectangle> findSurroundingBlocks(int i,int j, Rectangle[,] r) {
            List<Rectangle> rectCollection = new List<Rectangle>();
            if (r[i + 1, j] != null)
            {
                rectCollection.Add(r[i + 1, j]);
            }
            if (r[i - 1, j] != null)
            {
                rectCollection.Add(r[i - 1, j]);
            }
            if (r[i + 1, j+1] != null)
            {
                rectCollection.Add(r[i + 1, j+1]);
            }
            if (r[i, j+1] != null)
            {
                rectCollection.Add(r[i, j+1]);
            }
            if (r[i, j-1] != null)
            {
                rectCollection.Add(r[i, j-1]);
            }
            if (r[i + 1, j-1] != null)
            {
                rectCollection.Add(r[i + 1, j-1]);
            }
            if (r[i - 1, j+1] != null)
            {
                rectCollection.Add(r[i - 1, j+1]);
            }
            if (r[i - 1, j-1] != null)
            {
                rectCollection.Add(r[i - 1, j-1]);
            }
            return rectCollection;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int[,] temp = new int[21,21];
            for (int i = 1; i < 19; i++)
            {
                for (int j = 1; j < 19; j++)
                {
                    temp[i, j] = 0;
                }
            }
            for (int i = 1; i < 19; i++)
            {
                for (int j = 1; j < 19; j++)
                {
                    int count = 0;
                    foreach (Rectangle r in findSurroundingBlocks(i, j, board))
                    {
                        if (r.Fill == Brushes.Black)
                        {
                            count += 1;
                        }
                    };
                    if (count == 2)
                    {
                        
                    }
                    else
                    {
                        if (count == 3) {temp[i, j] = 1; }
                        else
                        {
                            temp[i, j] = 0;
                        }
                    }
                }
            }
            for (int i = 1; i < 19; i++)
            {
                for (int j = 1; j < 19; j++)
                {
                    if (temp[i, j] == 0)
                    {
                        board[i, j].Fill = Brushes.White;
                    }
                    else
                    {
                        board[i, j].Fill = Brushes.Black;
                    }
                }
            }
        }
    }

}
