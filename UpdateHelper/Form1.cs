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
using System.Security.Cryptography;
using System.Diagnostics;

namespace UpdateHelper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        bool shouldUpdate = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                File.Delete(appdata + "/.bluebeta/launcher.exe.new");
            }
            catch
            {

            }

            FormClosing += UpdaterClosed;
            string serverSha = "";
            string clientSha = "";
            try
            {
                WebClient client = new WebClient();
                serverSha = client.DownloadString("http://modpack.bluebeta.net/launcher/sha256.txt");
                client.Dispose();
                serverSha = serverSha.Replace("\n", "");
                serverSha = serverSha.Replace("\r", "");
                

                if(File.Exists(appdata + "/.bluebeta/launcher.exe"))
                {
                    Stream stream = new FileStream(appdata + "/.bluebeta/launcher.exe", FileMode.Open);
                    SHA256Managed hasher = new SHA256Managed();
                    byte[] hash = hasher.ComputeHash(stream);
                    string checksum = BitConverter.ToString(hash).Replace("-", "");
                    clientSha = checksum;
                    stream.Close();
                    stream.Dispose();
                }
                else
                {
                    shouldUpdate = true;
                }

                if (!serverSha.Equals(clientSha))
                    shouldUpdate = true;

            }
            catch
            {
                MessageBox.Show("Could not check for updates. Will attempt to start the launcher anyway.");
                shouldUpdate = false;
            }

            

            if (shouldUpdate)
                updateLauncher();
            else
                launch();
        }

        private void UpdaterClosed(object sender, FormClosingEventArgs e)
        {
            try
            {
                File.Delete(appdata + "/.bluebeta/launcher.exe.new");
            }
            catch
            {

            }
            Application.Exit();
        }

        private void updateLauncher()
        {
            WebClient client = new WebClient();
            client.DownloadFileCompleted += downloadComplete;
            client.DownloadProgressChanged += downloadUpdate;
            
            client.DownloadFileAsync(new Uri("http://modpack.bluebeta.net/launcher/launcher.exe"), appdata + "/.bluebeta/launcher.exe.new");
        }

        private void downloadUpdate(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void downloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            if(e.Error == null)
            {
                if (File.Exists(appdata + "/.bluebeta/launcher.exe"))
                {
                    File.Delete(appdata + "/.bluebeta/launcher.exe");
                }
                File.Move(appdata + "/.bluebeta/launcher.exe.new", appdata + "/.bluebeta/launcher.exe");
                launch();
            }
            else
            {
                MessageBox.Show("Updating the launcher failed. Please check your internet connection.");
                try
                {
                    File.Delete(appdata + "/.bluebeta/launcher.exe.new");
                }
                catch
                {

                }
                Application.Exit();
            }
        }

        private void launch()
        {
            try
            {
                Process proc = new Process();
                ProcessStartInfo info = new ProcessStartInfo(appdata + "/.bluebeta/launcher.exe");
                proc.StartInfo = info;
                proc.Start();
            }
            catch
            {
                MessageBox.Show("Could not start the launcher. It will need to be updated.");
            }
            Application.Exit();
        }
    }
}
