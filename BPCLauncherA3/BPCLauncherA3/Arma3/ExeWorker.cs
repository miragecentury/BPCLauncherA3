using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using BPCLauncherA3;
using BPCLauncherA3.Arma3;

namespace BPCLauncherA3.Arma3
{

    delegate void MangerSetArma3Running(Boolean IsRunning);

    class ExeWorker
    {
        private String pathToExe = "";
        private String Args;
        private Process pr = null;
        private Manager manager = null;

        public ExeWorker(String PathToExe, String Args,Manager man)
        {
            this.pathToExe = PathToExe;
            this.Args = Args;
            this.manager = man;
        }

        public void DoWork()
        {
            this.pr = new Process();
            this.pr.StartInfo.FileName = this.pathToExe;
            this.pr.StartInfo.Arguments = this.Args;
            this.pr.Start();
            lock (this.manager)
            {
                MangerSetArma3Running mar = delegate(Boolean IsRunning)
                {
                    Manager m = Manager.getCurrent();
                    m.set_Arma3Running(IsRunning);
                };
                App.Current.Dispatcher.Invoke(mar,true);
            }
            this.pr.WaitForExit();
            lock (this.manager)
            {
                MangerSetArma3Running mar = delegate(Boolean IsRunning)
                {
                    Manager m = Manager.getCurrent();
                    m.set_Arma3Running(IsRunning);
                };
                App.Current.Dispatcher.Invoke(mar, false);
            }
        }

        public void RequestStop()
        {

        }
    }
}
