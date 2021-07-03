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

namespace Timer
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
        }
        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        void window_mouse_left_button_down(object sender,MouseButtonEventArgs e)
        {
            
        }
        private void window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
        }
    }
}
