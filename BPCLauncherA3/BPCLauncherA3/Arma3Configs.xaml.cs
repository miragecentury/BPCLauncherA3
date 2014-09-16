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

namespace BPCLauncherA3
{
    /// <summary>
    /// Logique d'interaction pour Arma3Configs.xaml
    /// </summary>
    public partial class Arma3Configs
    {
        private MainWindow mwindow;
        public Arma3Configs(MainWindow mw)
        {
            this.mwindow = mw;
            InitializeComponent();
        }

        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            this.mwindow.CallBack_Close_Arma3Configs();
        }

        private void Arma3Configs_Abord(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
