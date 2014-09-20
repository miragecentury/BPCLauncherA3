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
using BPCLauncherA3;
using BPCLauncherA3.Arma3;

namespace BPCLauncherA3
{
    /// <summary>
    /// Logique d'interaction pour Arma3Configs.xaml
    /// </summary>
    public partial class Arma3Configs
    {
        private MainWindow mwindow = null;
        private Manager arma3manager = null;

        public Arma3Configs(MainWindow mw, Manager arma3managerp)
        {
            this.mwindow = mw;
            this.arma3manager = arma3managerp;
            InitializeComponent();
            this.arma3manager.InitView(this);
        }

        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            this.mwindow.CallBack_Close_Arma3Configs();
        }

        private void Arma3Configs_Abord(object sender, RoutedEventArgs e)
        {
            this.arma3manager.abord();
            this.Close();
        }

        private void Arma3Configs_Appliquer(object sender, RoutedEventArgs e)
        {
            this.arma3manager.save();
            this.Close();
        }

        private void noStartScreen_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox s = (CheckBox)sender;
            this.arma3manager.set_cfg_noStartScreen((Boolean) s.IsChecked);
        }

        private void noPause_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox s = (CheckBox)sender;
            this.arma3manager.set_cfg_noPause((Boolean)s.IsChecked);
        }

        private void emptyWorld_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox s = (CheckBox)sender;
            this.arma3manager.set_cfg_emptyStartWorld((Boolean)s.IsChecked);
        }

        private void showScriptError_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox s = (CheckBox)sender;
            this.arma3manager.set_cfg_showScriptError((Boolean)s.IsChecked);
        }

        private void noCB_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox s = (CheckBox)sender;
            this.arma3manager.set_cfg_stopMultiCore((Boolean)s.IsChecked);
        }

        private void onlyPbo_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox s = (CheckBox)sender;
            this.arma3manager.set_cfg_onlyPbo((Boolean)s.IsChecked);
        }

        private void noLog_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox s = (CheckBox)sender;
            this.arma3manager.set_cfg_noLog((Boolean)s.IsChecked);
        }

        private void extraThread_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox s = (ComboBox) sender;
            Console.WriteLine(e.AddedItems[0]);
            UInt32 val = (UInt32) e.AddedItems[0];
            Console.WriteLine("Valeur Récupérer :"+val);
            this.arma3manager.set_cfg_extraThread(val);
        }

        private void hyperThreading_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox s = (CheckBox)sender;
            this.arma3manager.set_cfg_hyperThreading((Boolean)s.IsChecked);
        }

    }
}
