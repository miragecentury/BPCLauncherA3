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
using Microsoft.Win32;
using MahApps.Metro.Controls;
using System.Diagnostics;
using BPCLauncherA3.Arma3;

namespace BPCLauncherA3
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {

        private Manager a3manager = null;
        //
        private Arma3Configs cfgwindow;
        private Boolean cfgwindow_open = false;
        //TODO REFACTO :
        private Boolean arma3Running = false;
        private Boolean isAuthentified = false;

        public MainWindow()
        {
            this.a3manager = new Manager();
            InitializeComponent();
        }
        
        private void title_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        //-- CallBack des Fenêtres

        public void CallBack_Close_Arma3Configs(){
            this.cfgwindow_open = false;
            this.cfgwindow = null;
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
            Process.Start("http://french-life.eu");
        }

        private void Launcher_Site_ProjetX(object sender, RoutedEventArgs e)
        {
            Process.Start("http://nordri.fr");
        }

        private void Launcher_Options_Arma3(object sender, RoutedEventArgs e)
        {
            if (!this.cfgwindow_open)
            {
                this.cfgwindow_open = true;
                this.cfgwindow = new Arma3Configs(this,this.a3manager);
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
