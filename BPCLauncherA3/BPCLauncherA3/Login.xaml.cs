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
using MahApps.Metro.Controls;

namespace BPCLauncherA3
{
    /// <summary>
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login
    {
        private MainWindow main;
        private bool isNormalClose = false;
        public Login(MainWindow mw)
        {
            this.main = mw;
            InitializeComponent();
        }

        private void Login_Abord(object sender, RoutedEventArgs e)
        {
            this.Login_Abord();
        }

        private void Login_Abord()
        {
            this.isNormalClose = true;
            this.Close();
            this.main.Show();
        }

        private void Login_Login(object sender, RoutedEventArgs e)
        {
            this.isNormalClose = true;

        }

        private void Login_Closed(object sender, EventArgs e)
        {
            if (!this.isNormalClose)
            {
                this.Login_Abord();
            }
        }

        
    }
}
