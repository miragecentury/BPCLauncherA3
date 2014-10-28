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
            }
        }

        public void setStatusServerConnectionStatus(bool status)
        {
            if (status)
            {
                this.MainWindow_Status_ServeurConnectionStatus.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Green"));
                this.MainWindow_Status_ServeurConnectionStatus_Rct.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Green"));
            }
            else
            {
                this.MainWindow_Status_ServeurConnectionStatus.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
                this.MainWindow_Status_ServeurConnectionStatus_Rct.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
            }
        }

        public void setStatusServeurAuthentification(bool status)
        {
            if (status)
            {
                this.MainWindow_Status_ServeurAuthentification.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Green"));
                this.MainWindow_Status_ServeurAuthentification_Rct.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Green"));
            }
            else
            {
                this.MainWindow_Status_ServeurAuthentification.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
                this.MainWindow_Status_ServeurAuthentification_Rct.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
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
    }
}
