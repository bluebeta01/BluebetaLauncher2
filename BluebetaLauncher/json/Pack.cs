using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluebetaLauncher.json
{
    public class Pack
    {
        public string name;
        public string friendlyname;
        public string mcversion;
        public string[] versions;
        public string forgeversion;
        public string args;

        public override string ToString()
        {
            return friendlyname;
        }
    }
}
