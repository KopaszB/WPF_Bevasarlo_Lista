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
using System.IO;

namespace WPF_Bevasarlo_Lista
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<object> lista = new List<object>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_hozzaad_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem ujElem = new ListBoxItem();
            ujElem.Content = tbx_bevitel.Text.Trim();
            
            if (ujElem.Content.ToString()!="")
            {
                lb_termeklista.Items.Add(ujElem);
                lista.Add(ujElem.Content.ToString());
            }
            tbx_bevitel.Clear();
        }

        private void bt_torol_Click(object sender, RoutedEventArgs e)
        {
            if (lb_termeklista.SelectedItems.Count>0)
            {
                ListBoxItem kivalsztott = lb_termeklista.SelectedItem as ListBoxItem;
                lb_termeklista.Items.Remove(kivalsztott);
            }
            
        }

        private void bt_megvasarolt_Click(object sender, RoutedEventArgs e)
        {
            if (lb_termeklista.SelectedItem!=null)
            {
                ListBoxItem item = lb_termeklista.SelectedItem as ListBoxItem;
                if (item!=null)
                {
                    TextBlock tb = item.Content as TextBlock;
                    if (tb == null)
                    {
                        string szoveg = item.Content.ToString();
                        tb = new TextBlock();
                        tb.Text = szoveg;
                        tb.TextDecorations = TextDecorations.Strikethrough;
                        Color color = (Color)ColorConverter.ConvertFromString("#FFDFD991");
                        tb.Foreground = new System.Windows.Media.SolidColorBrush(color);
                        item.Content = tb;
                    }
                    else
                    {
                        if (tb.TextDecorations== TextDecorations.Strikethrough)
                        {
                            TextBlock ujTb = new TextBlock();
                            ujTb.Text = tb.Text;
                            ujTb.TextDecorations = null;
                            ujTb.Foreground = Brushes.Black;
                            item.Content = ujTb;
                            
                        }
                        else
                        {
                            TextBlock ujTb = new TextBlock();
                            ujTb.Text = tb.Text;
                            ujTb.TextDecorations = TextDecorations.Strikethrough;
                            ujTb.Foreground = Brushes.DarkGray;
                            item.Content = ujTb;
                            
                        }
                    }
                }
            }
        }

        private void bt_ujlista_Click(object sender, RoutedEventArgs e)
        {
            lb_termeklista.Items.Clear();
        }

        private void btn_listamentese_Click(object sender, RoutedEventArgs e)
        {
            if (tbx_listaneve.Text!="")
            {
                if (lb_termeklista.Items.Count > 0)
                {
                    string fajlnev = $"{tbx_listaneve.Text}.txt";
                    using (StreamWriter iro = new StreamWriter(fajlnev))
                    {
                        foreach (var item in lista)
                        {
                            iro.WriteLine(item);
                        }
                    }
                    lb_termeklista.Items.Clear();
                    tbx_listaneve.Clear();
                    MessageBox.Show("A lista mentésre került", "Sikeres mentés", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("A lista nem tartalmaz elemeket!", "Üres lista!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }
            else
            {
                MessageBox.Show("Hiányzó listanév!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }
    }
}
