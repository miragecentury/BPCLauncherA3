using BPC_ProjetX_Launcher.BPC.Arma3Configs;
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
        Boolean ProjetX = false;

        public Instance(Manager manager,bool ProjetX)
        {
            this.manager = manager;
            this.compileAllArguments();
        }

        public void compileAllArguments()
        {
            String args = this.compileConfigArguments(this.manager.getUserConfig());
            String modargs = "";
            if (this.ProjetX)
            {
                modargs = this.compileConfigMods();
            }
            this.compileArguments = args + modargs;
        }

        public String compileConfigArguments(Userconfig usercfg)
        {
            String args = "";

            if (usercfg.arma3Config_showScriptError)
            {
                args += "-showScriptErrors ";
            }

            if (usercfg.arma3Config_emptyStartWorld)
            {
                args += "-world=empty ";
            }

            if (usercfg.arma3Config_noPause)
            {
                args += "-noPause ";
            }

            if (usercfg.arma3Config_noStartScreen)
            {
                args += "-nosplash ";
                args += "-skipintro ";
            }

            if (usercfg.arma3Config_stopMultiCore)
            {
                args += "-noCB ";
            }

            if (usercfg.arma3Config_extraThread != 0)
            {
                args += "-exThreads=";
                args += usercfg.arma3Config_extraThread;
                args += " ";
            }

            return args;
            return "";
        }

        public String compileConfigMods()
        {
            return "";
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
