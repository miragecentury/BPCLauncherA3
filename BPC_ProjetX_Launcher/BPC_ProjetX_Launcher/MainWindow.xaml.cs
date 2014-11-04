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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BPC_ProjetX_Launcher
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Initialisation();
            BPC.Common.Manager.getInstance().setMainWindow(this);
        }

        private void Initialisation(){
            this.setEnableTileLaunchProjetX(false);
            this.setEnableTileModCheck(false);
            this.setStatusServerStatus(false);
            this.setStatusServerConnectionStatus(false);
            this.setStatusServeurAuthentification(false);
            this.setStatusGameLinkConnection(false);
            this.setStatusModsCheck(false);
        }

        public void setStatusServerStatus(bool status){
            if(status){
                this.MainWindow_Status_ServeurStatus.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Green"));
                this.MainWindow_Status_ServeurStatus_Rct.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Green"));
            }else{
                this.MainWindow_Status_ServeurStatus.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
                this.MainWindow_Status_ServeurStatus_Rct.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
                this.setEnableTileModCheck(false);
                this.setEnableTileLaunchProjetX(false);
                this.setStatusServerConnectionStatus(false);
                this.setStatusServeurAuthentification(false);
            }
        }

        public void setStatusServerConnectionStatus(bool status)
        {
            if (status)
            {
                this.MainWindow_Status_ServeurConnectionStatus.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Green"));
                this.MainWindow_Status_ServeurConnectionStatus_Rct.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Green"));
                this.MainWindow_Status_ServeurConnectionStatus.Content = "Connected";
            }
            else
            {
                this.MainWindow_Status_ServeurConnectionStatus.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
                this.MainWindow_Status_ServeurConnectionStatus_Rct.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
                this.setEnableTileModCheck(false);
                this.setEnableTileLaunchProjetX(false);
                this.setStatusServeurAuthentification(false);
                this.MainWindow_Status_ServeurConnectionStatus.Content = "Not Connected";
            }
        }

        public void setStatusServeurAuthentification(bool status)
        {
            if (status)
            {
                this.MainWindow_Status_ServeurAuthentification.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Green"));
                this.MainWindow_Status_ServeurAuthentification_Rct.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Green"));
                this.MainWindow_Status_ServeurAuthentification.Content = "Authentifed";
                this.setEnableTileModCheck(true);
                this.setEnableTileLaunchProjetX(true);
                this.MainWindow_Menu_Login.IsEnabled = false;
                this.MainWindow_Menu_Logout.IsEnabled = true;
            }
            else
            {
                this.MainWindow_Status_ServeurAuthentification.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
                this.MainWindow_Status_ServeurAuthentification_Rct.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
                this.MainWindow_Status_ServeurAuthentification.Content = "Not Authentifed";
                this.setEnableTileModCheck(false);
                this.setEnableTileLaunchProjetX(false);
                this.MainWindow_Menu_Login.IsEnabled = true;
                this.MainWindow_Menu_Logout.IsEnabled = false;
            }
        }

        public void setStatusGameLinkConnection(bool status)
        {
            if (status)
            {
                this.MainWindow_Status_GameLinkConnection.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Green"));
                this.MainWindow_Status_GameLinkConnection_Rct.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Green"));
            }
            else
            {
                this.MainWindow_Status_GameLinkConnection.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
                this.MainWindow_Status_GameLinkConnection_Rct.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
            }
        }

        public void setStatusModsCheck(bool status)
        {
            if (status)
            {
                this.MainWindow_Status_ModsCheck.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Green"));
                this.MainWindow_Status_ModsCheck_Rct.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Green"));
            }
            else
            {
                this.MainWindow_Status_ModsCheck.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
                this.MainWindow_Status_ModsCheck_Rct.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
            }
        }

        public void setEnableTileLaunchProjetX(bool enable)
        {
            this.MainWindow_Tile_LaunchProjetX.IsEnabled = enable;
            if (enable == true)
            {
                this.MainWindow_Tile_LaunchProjetX.Opacity = 1.0;
            }
            else
            {
                this.MainWindow_Tile_LaunchProjetX.Opacity = 0.4;
            }
        }

        public void setEnableTileLaunchVanilla(bool enable)
        {
            this.MainWindow_Tile_LaunchVanilla.IsEnabled = enable;
            if (enable == true)
            {
                this.MainWindow_Tile_LaunchVanilla.Opacity = 1.0;
            }
            else
            {
                this.MainWindow_Tile_LaunchVanilla.Opacity = 0.4;
            }
        }

        public void setEnableTileOpenSite(bool enable)
        {
            this.MainWindow_Tile_OpenSite.IsEnabled = enable;
            if (enable == true)
            {
                this.MainWindow_Tile_OpenSite.Opacity = 1.0;
            }
            else
            {
                this.MainWindow_Tile_OpenSite.Opacity = 0.4;
            }
        }

        public void setEnableTileModCheck(bool enable)
        {
            this.MainWindow_Tile_ModCheck.IsEnabled = enable;
            if (enable == true)
            {
                this.MainWindow_Tile_ModCheck.Opacity = 1.0;
            }
            else
            {
                this.MainWindow_Tile_ModCheck.Opacity = 0.4;
            }
        }

        public void setEnableTileArma3Settings(bool enable)
        {
            this.MainWindow_Tile_Arma3Settings.IsEnabled = enable;
            if (enable == true)
            {
                this.MainWindow_Tile_Arma3Settings.Opacity = 1.0;
            }
            else
            {
                this.MainWindow_Tile_Arma3Settings.Opacity = 0.4;
            }
        }

        public void setEnableMenuDebug(bool enable)
        {
            this.MainWindow_Menu_Debug.IsEnabled = enable;
            if (enable)
            {
                this.MainWindow_Menu_Debug.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("White"));
            }
            else
            {
                this.MainWindow_Menu_Debug.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Auto"));
            }
        }

        public void setEnableMenuDebugLiveLog(bool enable)
        {
            this.MainWindow_Menu_Debug_LiveLog.IsEnabled = enable;
            if (enable)
            {
                this.setEnableMenuDebug(true);
            }
        }

        public void setEnableMenuDebugLiveEvent(bool enable)
        {
            this.MainWindow_Menu_Debug_LiveEvent.IsEnabled = enable;
            if (enable)
            {
                this.setEnableMenuDebug(true);
            }
        }

        public void setActivedTileLaunchVanilla(bool active)
        {
            this.MainWindow_Tile_LaunchVanilla.IsEnabled = !active;
            if (active)
            {
                this.MainWindow_Tile_LaunchVanilla.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#CCECC61A"));
                this.setEnableTileArma3Settings(false);
            }
            else
            {
                this.MainWindow_Tile_LaunchVanilla.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#CC119EDA"));
                this.setEnableTileArma3Settings(true);
            }
            
        }

        private void MainWindow_Tile_LaunchVanilla_Click(object sender, RoutedEventArgs e)
        {
            BPC.Common.Manager.getInstance().StartArma3Vanilla();
        }

        private void MainWindow_Tile_Arma3Settings_Click(object sender, RoutedEventArgs e)
        {
            BPC.Arma3Configs.Arma3ConfigsWindow cfgWindow = new BPC.Arma3Configs.Arma3ConfigsWindow();
            cfgWindow.Show();
        }

        private void MainWindow_Menu_Login_Click(object sender, RoutedEventArgs e)
        {
            BPC.Common.Manager.getInstance().StartLogin();
        }
    }
}
