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

        private String userEmail = "";
        private String userPassword = "";
        private String userToken = "";
        //
        private Boolean isA3Connected = false;
        private Boolean isServerConnected = false;
        private Boolean isAuthentified = false;
        //
        private Boolean checkUptodateIncomming = false;

        // 0 : not check
        // 1 : need Authentification
        // 2 : check incomming
        // 4 : check all ok
        // 5 : downloading maj
        private int Uptodate = 0;
        //
        private Boolean arma3Running = false;
        //
        private Arma3Configs cfgwindow;
        private Boolean cfgwindow_open = false;

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void title_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        //-- Setter Logique
        public void setUptodate(int set)
        {
            switch (set)
            {
                case 0:
                    this.Uptodate = 0;
                    this.Launcher_Label_Uptodate.Content = "Uptodate : non vérifier";
                    break;
                case 1:
                    this.Uptodate = 1;
                    this.Launcher_Label_Uptodate.Content = "Uptodate : need Authentification";
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
        }

        //-- CallBack des Fenêtres

        public void CallBack_Close_Arma3Configs(){
            this.cfgwindow_open = false;
            this.cfgwindow = null;
        }

        public void CallBack_Authenticate_Login(String email, String password, String token)
        {
            this.userEmail = email;
            this.userPassword = password;
            this.userToken = token;
            this.isAuthentified = true;
            if (!this.arma3Running)
            {
                this.Button_Launch_ProjetX.IsEnabled = true;
                this.Button_Launch_ProjetX.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("White"));
                this.Button_Launch_ProjetX.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF39B00"));
            }
        }

        //-- Logique Allumage Arma

        private void Launcher_StartA3(object sender, RoutedEventArgs e)
        {
            if (!this.arma3Running)
            {
                Console.WriteLine("XX- Lancement de Arma3 Vanilla");
                this.Running_Arma3();
            }
            else
            {
                //Arma3 Alredy Running Force Closing and Start This or Abord
            }
        }

        private void Launcher_StartA3_FrenchLife(object sender, RoutedEventArgs e)
        {
            if (!this.arma3Running)
            {
                Console.WriteLine("XX- Lancement de Arma3 FrenchLife");
                this.Running_Arma3();
            }
            else
            {
                //Arma3 Alredy Running Force Closing and Start This or Abord
            }
        }

        private void Launcher_StartA3_ProjetX(object sender, RoutedEventArgs e)
        {
            if (!this.arma3Running)
            {
                Console.WriteLine("XX- Lancement de Arma3 Projet X");
                this.Running_Arma3();
                
            }
            else
            {
                //Arma3 Alredy Running Force Closing and Start This or Abord
            }
        }

        private void Launcher_StartLogin(object sender, RoutedEventArgs e)
        {
            Login loginWindow = new Login(this);
            this.Hide();
            loginWindow.Show();
        }

        private void Running_Arma3()
        {
            this.arma3Running = true;
            this.Button_Launch_Arma3.IsEnabled = false;
            this.Button_Launch_Arma3.Foreground = SystemColors.ControlDarkBrush;
            this.Button_Launch_Arma3.Background = SystemColors.ControlLightBrush;
            this.Button_Launch_FrenchLife.IsEnabled = false;
            this.Button_Launch_FrenchLife.Foreground = SystemColors.ControlDarkBrush;
            this.Button_Launch_FrenchLife.Background = SystemColors.ControlLightBrush;
            this.Button_Launch_ProjetX.IsEnabled = false;
            this.Button_Launch_ProjetX.Foreground = SystemColors.ControlDarkBrush;
            this.Button_Launch_ProjetX.Background = SystemColors.ControlLightBrush;
        }

        private void NotRunning_Arma3()
        {
            this.arma3Running = false;
            this.Button_Launch_Arma3.IsEnabled = true;
            this.Button_Launch_Arma3.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("White"));
            this.Button_Launch_Arma3.Background = SystemColors.HighlightBrush;
            this.Button_Launch_FrenchLife.IsEnabled = true;
            this.Button_Launch_FrenchLife.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("White"));
            this.Button_Launch_FrenchLife.Background = SystemColors.HotTrackBrush;
            
            if (this.isAuthentified)
            {
                this.Button_Launch_ProjetX.IsEnabled = true;
                this.Button_Launch_ProjetX.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("White"));
                this.Button_Launch_ProjetX.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF39B00"));
            }
            else
            {
                this.Button_Launch_ProjetX.IsEnabled = false;
                this.Button_Launch_ProjetX.Foreground = SystemColors.ControlDarkBrush;
                this.Button_Launch_ProjetX.Background = SystemColors.ControlLightBrush;
            }
        }

        //-- Logique des Menus

        private void Launcher_Site_FrenchLife(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://french-life.eu");
        }

        private void Launcher_Site_ProjetX(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://nordri.fr");
        }

        private void Launcher_Options_Arma3(object sender, RoutedEventArgs e)
        {
            if (!this.cfgwindow_open)
            {
                this.cfgwindow_open = true;
                this.cfgwindow = new Arma3Configs(this);
                this.cfgwindow.Show();
                this.cfgwindow.Focus();
            }
            else
            {
                this.cfgwindow.Show();
                this.cfgwindow.Focus();
            }
        }

        //-- Logique de Mise à jour

        //-- Logique d'Authentification
    }
}
