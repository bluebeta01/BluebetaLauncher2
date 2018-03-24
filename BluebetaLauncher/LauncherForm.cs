using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BluebetaLauncher
{
    public partial class LauncherForm : Form
    {
        public Launcher launcher;

        public LauncherForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            launcher = new Launcher();
            populateModpackCombobox();
            loadRemeberMe();
            buildnumberlabel.Text = "V. " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void loadRemeberMe()
        {
            if(File.Exists(Utils.appdata + "/.bluebeta/remember.json"))
            {
                string rawjson = File.ReadAllText(Utils.appdata + "/.bluebeta/remember.json");
                json.RemeberMeObject remeberMe = (json.RemeberMeObject)JsonConvert.DeserializeObject<json.RemeberMeObject>(rawjson);
                modpackCombobox.Text = remeberMe.modpack;
                versionCombobox.Text = remeberMe.version;
                ramCombobox.Text = remeberMe.memory;
                emailBox.Text = remeberMe.email;
                passwordBox.Text = remeberMe.password;
                rememberBox.Checked = true;
            }
        }

        private void populateModpackCombobox()
        {
            try
            {
                modpackCombobox.Items.Clear();
                for (int i = 0; i < launcher.modpackManager.modpacks.Length; i++)
                {
                    modpackCombobox.Items.Add(launcher.modpackManager.modpacks[i]);
                }
            }

            catch
            {

            }
        }

        private void refreshVersionCombobox(object sender, EventArgs e)
        {
            versionCombobox.Items.Clear();
            json.Pack pack = (json.Pack)modpackCombobox.SelectedItem;
            foreach(string v in pack.versions)
            {
                versionCombobox.Items.Add(v);
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if(modpackCombobox.Text.Equals("") || versionCombobox.Text.Equals("") || emailBox.Text.Equals("") || passwordBox.Text.Equals(""))
            {
                MessageBox.Show("Please fill out all fields before loging in!");
                return;
            }

            MojangAuth.UserInfo userInfo = MojangAuth.Authinticator.authinticate(emailBox.Text, passwordBox.Text);
            if(userInfo == null)
            {
                MessageBox.Show("Could not login. Check your email and password.");
                return;
            }

            json.Pack pack = (json.Pack)modpackCombobox.SelectedItem;
            bool verified = Utils.verifyPack(pack.name, versionCombobox.Text);

            if(!verified)
            {
                DialogResult result = MessageBox.Show("The pack you've selected is not installed. Install it now?", "Verification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Utils.downloadPack(pack.name, versionCombobox.Text);
                    return;
                }
                else if (result == DialogResult.No)
                {
                    return;
                }
            }

            if(Utils.launchGame(pack, Utils.appdata + "/.bluebeta/packs/" + pack.name + "/" + versionCombobox.Text, userInfo, ramCombobox.Text))
            {
                try
                {
                    File.Delete(Utils.appdata + "/.bluebeta/remember.json");
                }
                catch{}
                
                if(rememberBox.Checked)
                {
                    json.RemeberMeObject remeberMe = new json.RemeberMeObject();
                    remeberMe.modpack = modpackCombobox.Text;
                    remeberMe.version = versionCombobox.Text;
                    remeberMe.memory = ramCombobox.Text;
                    remeberMe.email = emailBox.Text;
                    remeberMe.password = passwordBox.Text;
                    string rawjson = JsonConvert.SerializeObject(remeberMe);
                    File.WriteAllText(Utils.appdata + "/.bluebeta/remember.json", rawjson);
                }

                loginButton.Text = "Launching";
                loginButton.Enabled = false;
                System.Threading.ThreadStart threadStart = new System.Threading.ThreadStart(waitthread);
                System.Threading.Thread thread = new System.Threading.Thread(threadStart);
                thread.Start();
            }

        }

        private void waitthread()
        {
            System.Threading.Thread.Sleep(2000);
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void versionCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void emailBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buildnumberlabel_Click(object sender, EventArgs e)
        {

        }
    }
}
