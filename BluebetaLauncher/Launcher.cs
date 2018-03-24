using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluebetaLauncher
{
    public class Launcher
    {
        public json.ModpackManager modpackManager;

        public Launcher()
        {
            Utils.init();
            modpackManager = Utils.createModpackManager();
        }
    }
}
