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
using System.Windows.Shapes;

namespace MihProjectExamen
{
    /// <summary>
    /// Логика взаимодействия для CheckedWindow.xaml
    /// </summary>
    public partial class CheckedWindow : Window
    {
        public int Count { get; set; }

        public CheckedWindow(int count)
        {
            Count = count;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Message.Content = $"В этом списке находитмся {Count} задач, вы действительно хотите удалить его?";
        }
    }
}
