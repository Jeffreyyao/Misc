using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OLVocabPrac
{
				/// <summary>
				/// MainWindow.xaml 的交互逻辑
				/// </summary>
				public partial class MainWindow : Window
				{
								List<String> words = new List<string>();

								public MainWindow()
								{
												InitializeComponent();
								}

								void init()
								{
												words = new List<string>();
												grnell.Width = 180; grnell.Height = 180;
												grnell.Margin = new Thickness(0);
												grnell.VerticalAlignment = VerticalAlignment.Center; grnell.HorizontalAlignment = HorizontalAlignment.Center;
												redell.Visibility = Visibility.Collapsed;
												bluell.Visibility = Visibility.Collapsed;
												txtword.Text = "";
												txtdef.Text = "";
								}

								String getOnlineVocabDef(String word)
								{
												try
												{
																String url = "https://www.bing.com/dict/search?q=";
																WebClient cli = new WebClient();
																String def = Encoding.UTF8.GetString(cli.DownloadData(url + word));

																var match = new Regex("name=\"description.+?/>").Match(def);
																string definition = match.Value.Replace("name=\"description\" content=\"","");
																definition = definition.Replace("必应词典为您提供"+word+"的释义，", "");
																definition = definition.Replace("\" />", "");
																return definition;
												}catch(Exception e)
												{
																return "\n无网络连接或连接已超时";
												}
								}

								private void Ellipse_MouseEnter(object sender, MouseEventArgs e)
								{
												((Ellipse)sender).Fill = Brushes.DarkGreen;
								}

								private void Ellipse_MouseLeave(object sender, MouseEventArgs e)
								{
												((Ellipse)sender).Fill = Brushes.Green;
								}

								void displayRandomWord()
								{
												Random rand = new Random();
												txtword.Text = words[rand.Next(words.Count)];
								}

								private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
								{
												if (grnell.Width == 44.9)  //复习
												{
																displayRandomWord();
																txtdef.Text = "";
												}
												if (grnell.Width == 45)  //选词
												{
																foreach (string i in txtbox.Text.Split(new String[] { }, StringSplitOptions.None))
																{
																				words.Add(i);
																}
																txtbox.Visibility = Visibility.Collapsed;
																grnell.Width = 44.9; grnell.Height = 44.9;
																redell.Visibility = Visibility.Visible;
																bluell.Visibility = Visibility.Visible;
																displayRandomWord();
												}
												if (grnell.Width == 180)  //最开始
												{
																txtbox.Visibility = Visibility.Visible;
																grnell.Width = 45; grnell.Height = 45;
																grnell.Margin = new Thickness(10);
																grnell.VerticalAlignment = VerticalAlignment.Bottom; grnell.HorizontalAlignment = HorizontalAlignment.Right;
												}
								}

								private void bluell_MouseLeave(object sender, MouseEventArgs e)
								{
												bluell.Fill = Brushes.Blue;
								}

								private void bluell_MouseEnter(object sender, MouseEventArgs e)
								{
												bluell.Fill = Brushes.DarkBlue;
								}

								private void redell_MouseEnter(object sender, MouseEventArgs e)
								{
												redell.Fill = Brushes.DarkRed;
								}

								private void redell_MouseLeave(object sender, MouseEventArgs e)
								{
												redell.Fill = Brushes.Red;
								}

								void bluell_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
								{
												txtdef.Text = getOnlineVocabDef(txtword.Text);
								}

								private void redell_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
								{
												init();
								}
				}
}
