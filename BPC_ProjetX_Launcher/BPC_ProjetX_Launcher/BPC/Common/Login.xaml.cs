using MahApps.Metro.Controls;
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

namespace BPC_ProjetX_Launcher.BPC.Common
{
    /// <summary>
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login : MetroWindow
    {
        Manager manager = null;

        public Login(Manager manager)
        {
            this.manager = manager;
            InitializeComponent();
        }

        private void Login_Button_Authentification_Click(object sender, RoutedEventArgs e)
        {
            if (this.manager.Authenticate(this.Login_TextBox_Email.Text, this.Login_PasswordBox_Password.Password))
            {
                this.manager.getMainWindow().Show();
                this.Close();
            }
            else
            {
                //TODO MESSAGE
            }
        }

        private void Login_Button_Annuler_Click(object sender, RoutedEventArgs e)
        {
            this.manager.getMainWindow().Show();
            this.Close();
        }
    }
}
