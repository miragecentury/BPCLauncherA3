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

namespace BPC_ProjetX_Launcher.BPC.Arma3Mods
{

    public class ItemEntry
    {
        public string type { get; set; }
        public double progress { get; set; }
        public string path { get; set; }
        public string size { get; set; }
    }

    /// <summary>
    /// Logique d'interaction pour Arma3ModsWindow.xaml
    /// </summary>
    public partial class Arma3ModsWindow : MetroWindow
    {
        ProgressDialogController controller= null;
        Task<ProgressDialogController> tsk = null;
        public Arma3ModsWindow()
        {
            InitializeComponent();
        }

        public async void StartCheck(Manifest mani, Manager mana)
        {
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

            foreach (var item in mani.getDirsToDelete())
            {
                ItemEntry it = new ItemEntry { type = "DIR DELETE", path = item, progress = 0, size = "inconnu" };
                this.DataGrid.Items.Add(it);
            }

            foreach (var item in mani.getDirsToCreate())
            {
                ItemEntry it = new ItemEntry { type = "DIR CREATE", path = item, progress = 0, size = "inconnu" };
            }

            foreach (var item in mani.getFilesToDelete())
            {
                ItemEntry it = new ItemEntry { type = "FILE DELETE", path = item, progress = 0, size = "inconnu" };
            }

            foreach (var item in mani.getFilesToUpdate())
            {
                ItemEntry it = new ItemEntry { type = "FILE UPDATE", path = item, progress = 0, size = "inconnu" };
            }

            foreach (var item in mani.getFilesToDownload())
            {
                ItemEntry it = new ItemEntry { type = "FILE DOWNLOAD", path = item, progress = 0, size = "inconnu" };
            }
            
            await this.controller.CloseAsync();
        }

        public void EndCheck()
        {
           
        }
    }
}
