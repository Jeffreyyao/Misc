using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.IO;

namespace FileE
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            showFileDirectories(pathTextBox.Text);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                showFileDirectories(pathTextBox.Text);
            }
            if (e.Key == Key.Back)
            {
                try
                {
                    string[] npath = pathTextBox.Text.Split('/');
                    string path = pathTextBox.Text.Replace(npath[npath.Length - 2], "").Replace("//","/").Replace("C:/","C://").Replace("C:///","C://");
                    showFileDirectories(path);
                    pathTextBox.Text = path;
                }
                catch { }
            }
        }


        void showFileDirectories(string path)
        {
            container.Children.Clear();
            container.RowDefinitions.Clear();
            try
            {
                DirectoryInfo direct = new DirectoryInfo(path);
                int count = 0;
                foreach (FileSystemInfo a in direct.GetFileSystemInfos())
                {
                    RowDefinition row = new RowDefinition();
                    row.Height = new GridLength(30);
                    container.RowDefinitions.Add(row);
                    TextBlock text = new TextBlock();
                    text.MouseLeftButtonDown += new MouseButtonEventHandler(tbMouseDown);
                    text.Text = a.Name;
                    text.MouseEnter += new MouseEventHandler(tbMouseEnter);
                    text.MouseLeave += new MouseEventHandler(tbMouseLeave);
                    Grid.SetRow(text, count);
                    container.Children.Add(text);

                    TextBlock timeText = new TextBlock();
                    timeText.Text = a.CreationTime.ToString();
                    timeText.HorizontalAlignment = HorizontalAlignment.Right;
                    Grid.SetRow(timeText, count);
                    container.Children.Add(timeText);

                    count++;
                }
            }
            catch
            {
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(30);
                container.RowDefinitions.Add(row);
                TextBlock text = new TextBlock();
                text.Text = "Error in opening the directory";
                container.Children.Add(text);
            }
        }
        void tbMouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock text = (TextBlock)sender;
            text.Background = Brushes.AliceBlue;
            string path = pathTextBox.Text + text.Text + "/";
            if (Directory.Exists(path))
            {
                pathTextBox.Text = path;
                showFileDirectories(path);
            }
        }
        void tbMouseEnter(object sender, MouseEventArgs e)
        {
            TextBlock t = (TextBlock)sender;
            t.Background = Brushes.AliceBlue;
        }

            void tbMouseLeave(object sender, MouseEventArgs e)
        {
            TextBlock t = (TextBlock)sender;
            t.Background = Brushes.White;
        }
    }
}
