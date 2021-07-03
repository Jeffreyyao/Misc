using System;
using System.Net;
using System.Text.RegularExpressions;
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
using System.Net.Http;

namespace 知乎
{
    /// <summary>
    /// name,value,domain,path,expires,httpOnly,secure
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        string url;
        Random rand = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender,RoutedEventArgs e)
        {
            load();
        }
        private void load()
        {
            try
            {
                //获取html与内容
                WebClient webc = new WebClient();
                webc.Headers.Add(HttpRequestHeader.Cookie, "_xsrf:ff5db44a80e2339a22435d71fb266e97");
                webc.Headers.Add(HttpRequestHeader.Cookie, "email:953264261@qq.com");
                webc.Headers.Add(HttpRequestHeader.Cookie, "password:953264261jeffrey");
                webc.Headers.Add(HttpRequestHeader.Cookie, "remember_me:true");
                byte[] data = webc.DownloadData("https://www.zhihu.com/explore");
                string html = Encoding.UTF8.GetString(data);
                Regex reg = new Regex("question/[0-9]{8}/answer/[0-9]{9}");
                MatchCollection coll = reg.Matches(html);
                url = coll[0].ToString();
                data = webc.DownloadData("http://www.zhihu.com/" + url);
                html = Encoding.UTF8.GetString(data);
                reg = new Regex("<title>.*?</title>");

                //设置UI
                //标题

                scroll.ScrollToTop();
                container.RowDefinitions.Add(new RowDefinition());
                TextBlock text = new TextBlock()
                {
                    Text = reg.Match(html).ToString().Replace("<title>", "").Replace("</title>", ""),
                    TextWrapping=TextWrapping.WrapWithOverflow,
                    FontSize=30,
                    FontWeight=FontWeights.Bold,
                    Cursor=Cursors.Hand,
                };
                text.MouseLeftButtonDown += new MouseButtonEventHandler(tb_MouseLeftButtonDown);
                container.Children.Add(text);


                //内容
                reg = new Regex("<div class=\"zm-editable-content clearfix\">\n.*?\n</div>");
                html = reg.Match(html).ToString().Replace("<div class=\"zm-editable-content clearfix\">\n", "").Replace("\n</div>", "");
                reg = new Regex("<noscript>.*?</noscript>");
                html = reg.Replace(html, "");
                string[] str = html.ToString().Split(new string[] { "<br>" }, StringSplitOptions.None);
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i].StartsWith("<img") == false)
                    {
                        reg = new Regex("<.*?>");
                        str[i] = reg.Replace(str[i], "");
                        container.RowDefinitions.Add(new RowDefinition());
                        TextBlock tex = new TextBlock();
                        tex.TextWrapping = TextWrapping.WrapWithOverflow;
                        tex.FontSize = 18;
                        tex.Text = str[i];
                        Grid.SetRow(tex, i + 1);
                        container.Children.Add(tex);
                    }
                    else
                    {
                        reg = new Regex("http\\S*?_b.jpg");
                        string match = reg.Match(str[i]).ToString();
                        if (match != "")
                        {
                            Image im = new Image();
                            im.Source = new BitmapImage(new Uri(match),
                                new System.Net.Cache.RequestCachePolicy());
                            container.RowDefinitions.Add(new RowDefinition());
                            Grid.SetRow(im, i + 1);
                            container.Children.Add(im);
                        }
                    }
                }
            }
            catch (Exception a)
            {
                Label label = new Label();
                label.VerticalAlignment = VerticalAlignment.Center;
                label.Content = a.Message;
                label.FontSize = 20;
                label.Foreground = Brushes.Black;
                container.Children.Add(label);
                container.RowDefinitions.Add(new RowDefinition());
                Grid.SetRow(label, container.RowDefinitions.Count);
            }
            TextBlock tb = new TextBlock();
            tb.Text = "http://www.zhihu.com/" + url;
            tb.FontWeight = FontWeights.Bold;
            tb.Foreground = Brushes.Blue;
            tb.Cursor = Cursors.Hand;
            tb.HorizontalAlignment = HorizontalAlignment.Right;
            container.RowDefinitions.Add(new RowDefinition());
            Grid.SetRow(tb, container.RowDefinitions.Count + 2);
            container.Children.Add(tb);
            tb.MouseLeftButtonDown += new MouseButtonEventHandler(tb_MouseLeftButtonDown);
        }
        void tb_MouseLeftButtonDown(object sender,MouseButtonEventArgs e)
        {
            TextBlock te = (TextBlock)sender;
            WebBrowser wb = new WebBrowser();
            System.Diagnostics.Process.Start("http://www.zhihu.com/" + url);
        }
        private void green_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            container.Children.Clear();
            container.RowDefinitions.Clear();
            load();
        }

        private void red_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            window.Close();
        }

        private void green_MouseEnter(object sender, MouseEventArgs e)
        {
            green.Background = Brushes.DarkGreen;
        }

        private void green_MouseLeave(object sender, MouseEventArgs e)
        {
            green.Background = Brushes.Green;
        }

        private void red_MouseEnter(object sender, MouseEventArgs e)
        {
            red.Background = Brushes.DarkRed;
        }

        private void red_MouseLeave(object sender, MouseEventArgs e)
        {
            red.Background = Brushes.Red;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                window.DragMove();
            }
            catch { }
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            red.Background = Brushes.Red;
            green.Background = Brushes.Green;
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            red.Background = Brushes.Blue;
            green.Background = Brushes.Blue;
        }

        private void window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                scroll.ScrollToVerticalOffset(scroll.VerticalOffset - 25);
            }
            else if (e.Key == Key.Down)
            {
                scroll.ScrollToVerticalOffset(scroll.VerticalOffset + 25);
            }
        }
    }
}
