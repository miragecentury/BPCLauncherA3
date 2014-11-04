using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BPC_ProjetX_Launcher.BPC.Arma3
{
    delegate void changeMainWindowActiveTile(Boolean IsRunning);

    class Instance
    {
        Process arma3Process = null;
        String compileArguments = "";
        Manager manager = null;

        public Instance(Manager manager)
        {
            this.manager = manager;
        }

        public void Launch()
        {
            Thread th = new Thread(this.Thread);
            th.Start();
        }

        private void Thread()
        {
            MainWindow mw = BPC.Common.Manager.getInstance().getMainWindow();
            this.arma3Process = new Process();
            this.arma3Process.StartInfo.FileName = this.manager.getPathToExeArma3();
            this.arma3Process.StartInfo.Arguments = this.compileArguments;
            Console.WriteLine(this.manager.getPathToExeArma3());
            lock (mw)
            {
                changeMainWindowActiveTile mar = delegate(Boolean IsRunning)
                {
                    mw.setActivedTileLaunchVanilla(IsRunning);
                };
                App.Current.Dispatcher.Invoke(mar, true);
            }

            try
            {
                this.arma3Process.Start();
                this.arma3Process.WaitForExit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            lock (mw)
            {
                changeMainWindowActiveTile mar = delegate(Boolean IsRunning)
                {
                    mw.setActivedTileLaunchVanilla(IsRunning);
                };
                App.Current.Dispatcher.Invoke(mar, false);
            }
        }
    }
}
