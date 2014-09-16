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
        //
        private Boolean isA3Connected = false;
        private Boolean isServerConnected = false;
        private Boolean isAuthentified = false;
        //
        private Boolean checkUptodateIncomming = false;
        private Boolean Uptodate = false;
        //
        private Boolean arma3Running = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void title_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Launcher_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Launcher_StartA3(object sender, RoutedEventArgs e)
        {
            if (!this.arma3Running)
            {
                Console.WriteLine("XX- Lancement de Arma3 Vanilla");
                this.arma3Running = true;
                this.Running_Arma3();
                this.NotRunning_Arma3();
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
                this.arma3Running = true;
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
                this.arma3Running = true;
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
                this.Button_Launch_ProjetX.Foreground = SystemColors.ControlDarkBrush;
                this.Button_Launch_ProjetX.Background = SystemColors.ControlLightBrush;
            }
            else
            {
                this.Button_Launch_ProjetX.IsEnabled = false;
                this.Button_Launch_ProjetX.Foreground = SystemColors.ControlDarkBrush;
                this.Button_Launch_ProjetX.Background = SystemColors.ControlLightBrush;
            }
        }
    }
}
