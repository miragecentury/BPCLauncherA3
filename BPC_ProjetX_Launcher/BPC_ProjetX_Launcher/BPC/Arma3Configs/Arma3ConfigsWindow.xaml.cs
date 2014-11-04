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

namespace BPC_ProjetX_Launcher.BPC.Arma3Configs
{
    /// <summary>
    /// Logique d'interaction pour Arma3ConfigsWindow.xaml
    /// </summary>
    public partial class Arma3ConfigsWindow : MetroWindow
    {

        BPC.Arma3Configs.Manager configManager = null;
        BPC.Arma3Configs.Userconfig userConfig = null;

        public Arma3ConfigsWindow()
        {
            InitializeComponent();
            this.configManager = BPC.Common.Manager.getInstance().getConfigManager();
            this.userConfig = this.configManager.getUserConfig();
            this.initWithUserConfig();
        }

        private void initWithUserConfig()
        {
            //Dev/Debug/Log
            this.setNoLog(this.userConfig.arma3Config_noLog);
            this.setShowScriptError(this.userConfig.arma3Config_showScriptError);
            this.setOnlyPbo(this.userConfig.arma3Config_onlyPbo);
            //Arma3
            this.setEmptyWorld(this.userConfig.arma3Config_emptyStartWorld);
            this.setNoPause(this.userConfig.arma3Config_noPause);
            this.setNoScreen(this.userConfig.arma3Config_noStartScreen);
            //Système
            
        }

        public void setEmptyWorld(Boolean active)
        {
            this.Arma3ConfigWindow_CheckBox_EmptyWorld.IsChecked = active;
            this.userConfig.arma3Config_emptyStartWorld = active;
        }

        public void setNoPause(Boolean active)
        {
            this.Arma3ConfigWindow_CheckBox_NoPause.IsChecked = active;
            this.userConfig.arma3Config_noPause = active;
        }

        public void setNoScreen(Boolean active)
        {
            this.Arma3ConfigWindow_CheckBox_NoScreen.IsChecked = active;
            this.userConfig.arma3Config_noStartScreen = active;
        }

        public void setShowScriptError(Boolean active)
        {
            this.Arma3ConfigWindow_CheckBox_ShowScriptError.IsChecked = active;
            this.userConfig.arma3Config_showScriptError = active;
        }

        public void setOnlyPbo(Boolean active)
        {
            this.Arma3ConfigWindow_CheckBox_OnlyPbo.IsChecked = active;
            this.userConfig.arma3Config_onlyPbo = active;
        }

        public void setNoLog(Boolean active)
        {
            this.Arma3ConfigWindow_CheckBox_NoLog.IsChecked = active;
            this.userConfig.arma3Config_noLog = active;
        }

        public void setHyperThreading(Boolean active)
        {
            this.Arma3ConfigWindow_CheckBox_HyperThreading.IsChecked = active;
            this.userConfig.arma3Config_hyperThreading = active;
        }

        public void setNoMultiCore(Boolean active)
        {
            this.Arma3ConfigWindow_CheckBox_NoMultiCore.IsChecked = active;
            this.userConfig.arma3Config_stopMultiCore = active;
        }

        private void Arma3ConfigWindow_Button_Appliquer_Click(object sender, RoutedEventArgs e)
        {
            this.userConfig.Write();
            this.Close();
        }

        private void Arma3ConfigWindow_Button_Annuler_Click(object sender, RoutedEventArgs e)
        {
            this.userConfig.Read();
            this.Close();
        }

        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            
        }

        private void Arma3ConfigWindow_CheckBox_NoScreen_Checked(object sender, RoutedEventArgs e)
        {
            this.setNoScreen(true);
        }

        private void Arma3ConfigWindow_CheckBox_NoScreen_Unchecked(object sender, RoutedEventArgs e)
        {
            this.setNoScreen(false);
        }

        private void Arma3ConfigWindow_CheckBox_NoPause_Checked(object sender, RoutedEventArgs e)
        {
            this.setNoPause(true);
        }

        private void Arma3ConfigWindow_CheckBox_NoPause_Unchecked(object sender, RoutedEventArgs e)
        {
            this.setNoPause(false);
        }

        private void Arma3ConfigWindow_CheckBox_EmptyWorld_Checked(object sender, RoutedEventArgs e)
        {
            this.setEmptyWorld(true);
        }

        private void Arma3ConfigWindow_CheckBox_EmptyWorld_Unchecked(object sender, RoutedEventArgs e)
        {
            this.setEmptyWorld(false);
        }

        private void Arma3ConfigWindow_CheckBox_ShowScriptError_Unchecked(object sender, RoutedEventArgs e)
        {
            this.setShowScriptError(false);
        }

        private void Arma3ConfigWindow_CheckBox_ShowScriptError_Checked(object sender, RoutedEventArgs e)
        {
            this.setShowScriptError(true);
        }

        private void Arma3ConfigWindow_CheckBox_OnlyPbo_Checked(object sender, RoutedEventArgs e)
        {
            this.setOnlyPbo(true);
        }

        private void Arma3ConfigWindow_CheckBox_OnlyPbo_Unchecked(object sender, RoutedEventArgs e)
        {
            this.setOnlyPbo(false);
        }

        private void Arma3ConfigWindow_CheckBox_NoLog_Unchecked(object sender, RoutedEventArgs e)
        {
            this.setNoLog(false);
        }

        private void Arma3ConfigWindow_CheckBox_NoLog_Checked(object sender, RoutedEventArgs e)
        {
            this.setNoLog(true);
        }





    }
}
