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
using MahApps.Metro.Controls.Dialogs;
using BPC_ProjetX_Launcher.BPC.Arma3Mods.tool;
using System.Runtime.CompilerServices;
using System.IO;
using System.Threading;

namespace BPC_ProjetX_Launcher.BPC.Arma3Mods
{

    public class ItemEntry
    {
        public string TypeValue { get; set; }
        public double ProgressValue { get; set; }
        public string PathValue { get; set; }
        public string SizeValue { get; set; }
    }

    /// <summary>
    /// Logique d'interaction pour Arma3ModsWindow.xaml
    /// </summary>
    public partial class Arma3ModsWindow : MetroWindow
    {
        ProgressDialogController controller= null;
        Task<ProgressDialogController> tsk = null;

        Manifest mani;
        Manager mana;
        List<string> populate = new List<string>();

        public Arma3ModsWindow()
        {
            InitializeComponent();
        }

        public async void StartCheck(Manifest mani, Manager mana)
        {
            this.mani = mani;
            this.mana = mana;
            this.controller = await this.ShowProgressAsync("Please wait...", "Initialisation");
            this.controller.SetProgress(0.1);
            this.controller.SetMessage("Aquisition du Manifest");
            await Task.Delay(1000);
            mani.setManifestServer(mana.getManifestServer());
            this.controller.SetMessage("Vérification du contenu locale");
            this.controller.SetProgress(0.3);
            mani.parse();
            this.controller.SetMessage("Comparaison des Dossiers et Fichiers");
            this.controller.SetProgress(0.5);
            mani.check(false);
            this.controller.SetMessage("Chargement des Résultats");
            this.controller.SetProgress(0.8);

            foreach (var item in this.DataGrid.Items)
            {
                this.DataGrid.Items.Remove(item);
            }

            foreach (var item in mani.getDirsToDelete())
            {
                ItemEntry it = new ItemEntry { TypeValue = "DELETE DIR", PathValue = item, ProgressValue = 0, SizeValue = "inconnu" };
                this.DataGrid.Items.Add(it);
                this.populate.Add(item);
            }

            foreach (var item in mani.getDirsToCreate())
            {
                ItemEntry it = new ItemEntry { TypeValue = "CREATE DIR", PathValue = item, ProgressValue = 0, SizeValue = "inconnu" };
                this.DataGrid.Items.Add(it);
                this.populate.Add(item);
            }

            foreach (var item in mani.getFilesToDelete())
            {
                ItemEntry it = new ItemEntry { TypeValue = "DELETE FILE", PathValue = item, ProgressValue = 0, SizeValue = "inconnu" };
                this.DataGrid.Items.Add(it);
                this.populate.Add(item);
            }

            foreach (var item in mani.getFilesToUpdate())
            {
                ItemEntry it = new ItemEntry { TypeValue = "UPDATE FILE", PathValue = item, ProgressValue = 0, SizeValue = "inconnu" };
                this.DataGrid.Items.Add(it);
                this.populate.Add(item);
            }

            foreach (var item in mani.getFilesToDownload())
            {
                ItemEntry it = new ItemEntry { TypeValue = "DOWNLOAD FILE", PathValue = item, ProgressValue = 0, SizeValue = "inconnu" };
                this.DataGrid.Items.Add(it);
                this.populate.Add(item);
            }
            
            await this.controller.CloseAsync();

        }

        private void LaunchMaj_Click(object sender, RoutedEventArgs e)
        {
            this.LaunchMaj.IsEnabled = false;
            this.mani.prepareAction(this.DataGrid, this.populate);
            Thread th = new Thread(this.mani.Action);
            th.Start();
            //this.StartCheck(this.mani, this.mana);
            this.LaunchMaj.IsEnabled = true;
        }
    }
}
