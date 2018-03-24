using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;

namespace BluebetaLauncher
{
    public partial class PackDLForm : Form
    {
        public string name;
        public string version;

        WebClient client;

        public PackDLForm()
        {
            InitializeComponent();
        }

        private void PackDLForm_Load(object sender, EventArgs e)
        {
            dlpack(name, version);
        }

        public void dlpack(string name, string version)
        {
            try
            {
                client = new WebClient();
                Uri uri = new Uri("http://modpack.bluebeta.net/packs/" + name + "/" + version + ".zip");
                client.DownloadProgressChanged += downloadProgressChanged;
                client.DownloadFileCompleted += downloadFinished;
                client.DownloadFileAsync(uri, Utils.appdata + "/.bluebeta/packs/" + name + "/" + version + "/" + version + ".zip");
                
            }
            catch
            {
                MessageBox.Show("Could not connect to the server to download the pack! Pack install has been canceled.");
                return;
            }
        }

        private void downloadFinished(object sender, AsyncCompletedEventArgs e)
        {
            client.Dispose();
            client.CancelAsync();

            try
            {
                ZipFile.ExtractToDirectory(Utils.appdata + "/.bluebeta/packs/" + name + "/" + version + "/" + version + ".zip", Utils.appdata + "/.bluebeta/packs/" + name + "/" + version);
            }
            catch
            {
                MessageBox.Show("Could not extract modpack files. Ensure that Windows Explorer is not open to the modpack path during installation and that you have an internet connection.");
                MessageBox.Show("The install will now exit.");
                Close();
                return;
            }
            
            MessageBox.Show("Pack install complete. Click login to launch the modpack.");
            File.WriteAllText(Utils.appdata + "/.bluebeta/packs/" + name + "/" + version + "/verify.txt", "verified");
            Close();
        }

        private void downloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
