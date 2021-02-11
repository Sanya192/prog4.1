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

namespace prog4._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Random r = new Random();
        private string masterPassword = "123";
        private string currPassword = string.Empty;
        bool active = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Label_MouseMove(object sender,RoutedEventArgs e)
        {
            Label label = e.Source as Label;
            if (label!=null)
            {
                label.BorderBrush = new SolidColorBrush(Color.FromRgb((byte)r.Next(255), (byte)r.Next(255), (byte)r.Next(255)));
                if (active)
                {
                    if (!currPassword.Contains(label.Content.ToString()[0]))
                    {
                        currPassword += label.Content;
                    }
                    label.Background = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                }
            }
            
            e.Handled = true;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            currPassword = string.Empty;
            active = true;
        }
        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            foreach (var item in (sender as Grid).Children)
            {
                Label label = item as Label;
                if (label!=null)
                {
                    label.Background= new SolidColorBrush(Colors.Cyan);
                    
                }
            }
            if (currPassword==masterPassword)
            {
                MessageBox.Show("GG");
            }
            active = false;
            currPassword = string.Empty;
        }
    }
}
