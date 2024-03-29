﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32;
using BPCLauncherA3.Tools;

namespace BPCLauncherA3
{
    namespace Arma3
    {

        public class Manager
        {
            // -cpucount=8 -maxVRAM=2048  -mod= "-name=[SAMU]MirageCentury" -maxMem=4096 -world=empty
            // -connect=195.154.199.224 -port=2302 -password=********
            static private MainWindow mw = null;
            //
            static private Manager self = null;
            static private Userconfigs usercfg = null;
            static private ModsList modslist = null;
            //
            private String path;
            //
            private Boolean cfg_noStartScreen = false;
            private Boolean cfg_noPause = false;
            private Boolean cfg_emptyStartWorld = false;
            private Boolean cfg_showScriptError = false;
            private Boolean cfg_stopMultiCore = false;
            private Boolean cfg_onlyPbo = false;
            private Boolean cfg_noLog = false;
            //TODO
            private Boolean cfg_fixNbCpu = false;
            private UInt32 cfg_fixNbCpu_nb = 0;
            private Boolean cfg_MaxMem = false;
            private UInt32 cfg_MaxMem_nb = 0;
            private Boolean cfg_MaxMemVideo = false;
            private UInt32 cfg_MaxMemVideo_nb = 0;
            //
            private UInt32 cfg_ExtraThread = 0;
            private Boolean cfg_HyperThreading = false;
            //
            private Boolean Arma3Running = false;
            //
            public Manager(MainWindow mainwindow)
            {
                this.setupPath();
                this.setupConfigs();
                Manager.self = this;
                Manager.mw = mainwindow;
            }

            static public Manager getCurrent()
            {
                return Manager.self;
            }

            private void setupPath()
            {
                try
                {
                    RegistryKey rk = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\bohemia interactive\arma 3");
                    String test = (String)rk.GetValue("main");
                    this.path = test + @"/arma3.exe";
                }
                catch (Exception e)
                {
                    Console.Write(e.ToString());
                }
            }

            public void setupConfigs()
            {
               
                Manager.usercfg = new Userconfigs();
                Manager.usercfg.Initialize();
                Manager.usercfg.Read();
                this.cfg_emptyStartWorld = Manager.usercfg.emptyStartWorld;
                this.cfg_ExtraThread = Manager.usercfg.ExtraThread;
                this.cfg_HyperThreading = Manager.usercfg.HyperThreading;
                this.cfg_noLog = Manager.usercfg.noLog;
                this.cfg_noPause = Manager.usercfg.noPause;
                this.cfg_noStartScreen = Manager.usercfg.noStartScreen;
                this.cfg_onlyPbo = Manager.usercfg.onlyPbo;
                this.cfg_showScriptError = Manager.usercfg.showScriptError;
                this.cfg_stopMultiCore = Manager.usercfg.stopMultiCore;
                Manager.modslist = new ModsList();
                Manager.modslist.Initialize();
                Manager.modslist.Read();
            }

            public void InitView(Arma3Configs arma3ConfigsView)
            {
                if (this.cfg_noStartScreen)
                {
                    arma3ConfigsView.noStartScreen.IsChecked = true;
                }
                else
                {
                    arma3ConfigsView.noStartScreen.IsChecked = false;
                }

                if (this.cfg_noPause)
                {
                    arma3ConfigsView.noPause.IsChecked = true;

                }
                else
                {
                    arma3ConfigsView.noPause.IsChecked = false;
                }

                if (this.cfg_emptyStartWorld)
                {
                    arma3ConfigsView.emptyWorld.IsChecked = true;

                }
                else
                {
                    arma3ConfigsView.emptyWorld.IsChecked = false;
                }

                if (this.cfg_showScriptError)
                {
                    arma3ConfigsView.showScriptError.IsChecked = true;

                }
                else
                {
                    arma3ConfigsView.showScriptError.IsChecked = false;
                }

                if (this.cfg_stopMultiCore)
                {
                    arma3ConfigsView.noCB.IsChecked = true;

                }
                else
                {
                    arma3ConfigsView.noCB.IsChecked = false;
                }

                if (this.cfg_onlyPbo)
                {
                    arma3ConfigsView.onlyPbo.IsChecked = true;

                }
                else
                {
                    arma3ConfigsView.onlyPbo.IsChecked = false;
                }

                if (this.cfg_noLog)
                {
                    arma3ConfigsView.noLog.IsChecked = true;

                }
                else
                {
                    arma3ConfigsView.noLog.IsChecked = false;
                }

                arma3ConfigsView.extraThread.Text = this.cfg_ExtraThread.ToString();

                if (this.cfg_HyperThreading)
                {
                    arma3ConfigsView.hyperThreading.IsChecked = true;
                }
                else
                {
                    arma3ConfigsView.hyperThreading.IsChecked = false;
                }
            }

            public void set_cfg_noStartScreen(Boolean IsChecked)
            {
                this.cfg_noStartScreen = IsChecked;
            }

            public void set_cfg_noPause(Boolean IsChecked)
            {
                this.cfg_noPause = IsChecked;
            }

            public void set_cfg_emptyStartWorld(Boolean IsChecked)
            {
                this.cfg_emptyStartWorld = IsChecked;
            }

            public void set_cfg_showScriptError(Boolean IsChecked)
            {
                this.cfg_showScriptError = IsChecked;
            }

            public void set_cfg_stopMultiCore(Boolean IsChecked)
            {
                this.cfg_stopMultiCore = IsChecked;
            }

            public void set_cfg_onlyPbo(Boolean IsChecked)
            {
                this.cfg_onlyPbo = IsChecked;
            }

            public void set_cfg_noLog(Boolean IsChecked)
            {
                this.cfg_noLog = IsChecked;
            }

            public void set_cfg_hyperThreading(Boolean IsChecked)
            {
                this.cfg_HyperThreading = IsChecked;
            }

            public void set_cfg_extraThread(UInt32 val)
            {
                this.cfg_ExtraThread = val;
            }

            public void set_Arma3Running(Boolean IsRunning)
            {
                this.Arma3Running = IsRunning;
                if (this.Arma3Running)
                {
                    Manager.mw.Running_Arma3();
                }
                else
                {
                    Manager.mw.NotRunning_Arma3();
                }
            }

            public void save()
            {
                //Save Config to UserSettings
                Manager.usercfg.emptyStartWorld = this.cfg_emptyStartWorld;
                Manager.usercfg.ExtraThread = this.cfg_ExtraThread;
                Manager.usercfg.HyperThreading = this.cfg_HyperThreading;
                Manager.usercfg.noLog = this.cfg_noLog;
                Manager.usercfg.noPause = this.cfg_noPause ;
                Manager.usercfg.noStartScreen = this.cfg_noStartScreen;
                Manager.usercfg.onlyPbo = this.cfg_onlyPbo;
                Manager.usercfg.showScriptError = this.cfg_showScriptError;
                Manager.usercfg.stopMultiCore = this.cfg_stopMultiCore;
                Manager.usercfg.Write();
            }

            public void abord()
            {
                Manager.usercfg.Read();
                this.cfg_emptyStartWorld = Manager.usercfg.emptyStartWorld;
                this.cfg_ExtraThread = Manager.usercfg.ExtraThread;
                this.cfg_HyperThreading = Manager.usercfg.HyperThreading;
                this.cfg_noLog = Manager.usercfg.noLog;
                this.cfg_noPause = Manager.usercfg.noPause;
                this.cfg_noStartScreen = Manager.usercfg.noStartScreen;
                this.cfg_onlyPbo = Manager.usercfg.onlyPbo;
                this.cfg_showScriptError = Manager.usercfg.showScriptError;
                this.cfg_stopMultiCore = Manager.usercfg.stopMultiCore;
            }

            private String computeArg()
            {
                String args = "";

                if (this.cfg_showScriptError)
                {
                    args += "-showScriptErrors ";
                }

                if (this.cfg_emptyStartWorld)
                {
                    args += "-world=empty ";
                }

                if (this.cfg_noPause)
                {
                    args += "-noPause ";
                }

                if (this.cfg_noStartScreen)
                {
                    args += "-nosplash ";
                    args += "-skipintro ";
                }

                if (this.cfg_stopMultiCore)
                {
                    args += "-noCB ";
                }

                if (this.cfg_ExtraThread != 0)
                {
                    args += "-exThreads=";
                    args += this.cfg_ExtraThread;
                    args += " ";
                }

                return args;
            }

            public void LaunchArma3Vanilla()
            {

                ExeWorker exe = new ExeWorker(this.path, this.computeArg(), this);
                Thread th = new Thread(exe.DoWork);
                th.Start();
            }
        }
    }
}
