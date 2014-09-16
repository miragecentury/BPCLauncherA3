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
using System.Runtime.InteropServices;
using MahApps.Metro.Controls;

namespace BPCLauncherA3
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow 

    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Launcher_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void title_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Launcher_StartA3(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("XX- Lancement de Arma3");
        }
    }
}
