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
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace zhihu
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        string post = "client_id=4bc899f2695f417eb733f3d21a7be0&client_key=d179a1e11f2347a48c7f928d354621&email=jeffreyyao@outlook.com&grant_type=password&password=953264261jeffrey";
								string url = "http://api.zhihu.com/explore/random_question?client_id=4bc899f2695f417eb733f3d21a7be0&client_key=d179a1e11f2347a48c7f928d354621&email=jeffreyyao@outlook.com&grant_type=password&password=953264261jeffrey";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            load();
        }
        void load()
        {
            try
            {
                WebClient webc = new WebClient();
                byte[] data = webc.DownloadData("http://api.zhihu.com/explore/random_question?" + post);
                Regex reg_title = new Regex("\"title\":\".*?\"");
                Regex reg_name = new Regex("\"name\":\".*?\"");
                string json = Encoding.UTF8.GetString(data);
                string title = reg_title.Match(json).ToString().Replace("\"","").Replace("title:","");
                string name = reg_name.Match(json).ToString().Replace("\"", "").Replace("name:", "");
                TextBlock title_text = new TextBlock();
                TextBlock name_text = new TextBlock();
                title_text.Text = title;
                title_text.TextWrapping = TextWrapping.WrapWithOverflow;
                name_text.TextWrapping = TextWrapping.WrapWithOverflow;
                name_text.Text = name;
                name_text.HorizontalAlignment = HorizontalAlignment.Right;
                title_text.FontSize = 25;
                name_text.FontSize = 15;
                stack.Children.Add(title_text);
                stack.Children.Add(name_text);
                MessageBox.Show(json);
            }
            catch(Exception e)
            {
                Label label = new Label();
                label.Content = "网络连接有问题？？"+"\n"+e.Message;
                stack.Children.Add(label);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            stack.Children.Clear();
            load();
        }
    }
}

