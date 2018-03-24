using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace BluebetaLauncher
{
    class Utils
    {
        public static string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public static void init()
        {
            if (!Directory.Exists(appdata + "/.bluebeta"))
                Directory.CreateDirectory(appdata + "/.bluebeta");
            if (!Directory.Exists(appdata + "/.bluebeta/packs"))
                Directory.CreateDirectory(appdata + "/.bluebeta/packs");
        }

        public static json.ModpackManager createModpackManager()
        {
            string rawjson = "";
            
            try
            {
                WebClient client = new WebClient();
                rawjson = client.DownloadString("http://modpack.bluebeta.net/packfile.json");
                client.Dispose();
            }
            catch
            {
                
            }

            if(rawjson.Equals(""))
            {
                try
                {
                    FileStream stream = new FileStream(appdata + "/.bluebeta/packfile.json", FileMode.Open);
                    StreamReader reader = new StreamReader(stream);
                    rawjson = reader.ReadToEnd();
                    reader.Close();
                    stream.Close();
                }
                catch
                {

                }
            }

            if(rawjson.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Could not download packfile and you don't have a cached version. Please connect to the internet and try again.");
                System.Windows.Forms.Application.Exit();
                
            }

            try
            {
                File.Delete(appdata + "/.bluebeta/packfile.json");
                File.WriteAllText(appdata + "/.bluebeta/packfile.json", rawjson);
            }
            catch { }

            rawjson = rawjson.Replace("\r", "");
            rawjson = rawjson.Replace("\n", "");
            rawjson = rawjson.Replace("\t", "");
            json.ModpackManager manager = Newtonsoft.Json.JsonConvert.DeserializeObject<BluebetaLauncher.json.ModpackManager>(rawjson);
            return manager;
        }

        public static bool verifyPack(string name, string version)
        {
            if (File.Exists(appdata + "/.bluebeta/packs/" + name + "/" + version + "/verify.txt"))
                return true;
            else
                return false;
        }

        public static void downloadPack(string name, string version)
        {
            if (!Directory.Exists(appdata + "/.bluebeta/packs/" + name))
                Directory.CreateDirectory(appdata + "/.bluebeta/packs/" + name);

            if(Directory.Exists(appdata + "/.bluebeta/packs/" + name + "/" + version))
            {
                DialogResult result = MessageBox.Show("The pack to be installed was previously installed but could not be verified. Would you like to continue with the installation?\nNOTE: This will delete the partially installed pack and its contents.", "Verification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }
                else if(result == DialogResult.Yes)
                {
                    Directory.Delete(appdata + "/.bluebeta/packs/" + name + "/" + version, true);
                }
            }

            Directory.CreateDirectory(appdata + "/.bluebeta/packs/" + name + "/" + version);

            PackDLForm dlform = new PackDLForm();
            dlform.name = name;
            dlform.version = version;
            dlform.ShowDialog();
            
        }

        public static bool launchGame(json.Pack pack, string gamedir, MojangAuth.UserInfo userInfo, string memory)
        {
            if(pack.mcversion.Equals("1.10.2"))
            {
                string args = @"-XX:HeapDumpPath=MojangTricksIntelDriversForPerformance_javaw.exe_minecraft.exe.heapdump -Djava.library.path=$gamedir\jars\natives -Dminecraft.client.jar=$gamedir\jars\1.10.2.jar -cp $gamedir\jars\libraries\net\minecraftforge\forge\1.10.2-12.18.3.2511\forge-1.10.2-12.18.3.2511.jar;$gamedir\jars\libraries\net\minecraft\launchwrapper\1.12\launchwrapper-1.12.jar;$gamedir\jars\libraries\org\ow2\asm\asm-all\5.0.3\asm-all-5.0.3.jar;$gamedir\jars\libraries\jline\jline\2.13\jline-2.13.jar;$gamedir\jars\libraries\com\typesafe\akka\akka-actor_2.11\2.3.3\akka-actor_2.11-2.3.3.jar;$gamedir\jars\libraries\com\typesafe\config\1.2.1\config-1.2.1.jar;$gamedir\jars\libraries\org\scala-lang\scala-actors-migration_2.11\1.1.0\scala-actors-migration_2.11-1.1.0.jar;$gamedir\jars\libraries\org\scala-lang\scala-compiler\2.11.1\scala-compiler-2.11.1.jar;$gamedir\jars\libraries\org\scala-lang\plugins\scala-continuations-library_2.11\1.0.2\scala-continuations-library_2.11-1.0.2.jar;$gamedir\jars\libraries\org\scala-lang\plugins\scala-continuations-plugin_2.11.1\1.0.2\scala-continuations-plugin_2.11.1-1.0.2.jar;$gamedir\jars\libraries\org\scala-lang\scala-library\2.11.1\scala-library-2.11.1.jar;$gamedir\jars\libraries\org\scala-lang\scala-parser-combinators_2.11\1.0.1\scala-parser-combinators_2.11-1.0.1.jar;$gamedir\jars\libraries\org\scala-lang\scala-reflect\2.11.1\scala-reflect-2.11.1.jar;$gamedir\jars\libraries\org\scala-lang\scala-swing_2.11\1.0.1\scala-swing_2.11-1.0.1.jar;$gamedir\jars\libraries\org\scala-lang\scala-xml_2.11\1.0.2\scala-xml_2.11-1.0.2.jar;$gamedir\jars\libraries\lzma\lzma\0.0.1\lzma-0.0.1.jar;$gamedir\jars\libraries\net\sf\jopt-simple\jopt-simple\4.6\jopt-simple-4.6.jar;$gamedir\jars\libraries\java3d\vecmath\1.5.2\vecmath-1.5.2.jar;$gamedir\jars\libraries\net\sf\trove4j\trove4j\3.0.3\trove4j-3.0.3.jar;$gamedir\jars\libraries\com\mojang\netty\1.6\netty-1.6.jar;$gamedir\jars\libraries\oshi-project\oshi-core\1.1\oshi-core-1.1.jar;$gamedir\jars\libraries\net\java\dev\jna\jna\3.4.0\jna-3.4.0.jar;$gamedir\jars\libraries\net\java\dev\jna\platform\3.4.0\platform-3.4.0.jar;$gamedir\jars\libraries\com\ibm\icu\icu4j-core-mojang\51.2\icu4j-core-mojang-51.2.jar;$gamedir\jars\libraries\net\sf\jopt-simple\jopt-simple\4.6\jopt-simple-4.6.jar;$gamedir\jars\libraries\com\paulscode\codecjorbis\20101023\codecjorbis-20101023.jar;$gamedir\jars\libraries\com\paulscode\codecwav\20101023\codecwav-20101023.jar;$gamedir\jars\libraries\com\paulscode\libraryjavasound\20101123\libraryjavasound-20101123.jar;$gamedir\jars\libraries\com\paulscode\librarylwjglopenal\20100824\librarylwjglopenal-20100824.jar;$gamedir\jars\libraries\com\paulscode\soundsystem\20120107\soundsystem-20120107.jar;$gamedir\jars\libraries\io\netty\netty-all\4.0.23.Final\netty-all-4.0.23.Final.jar;$gamedir\jars\libraries\com\google\guava\guava\17.0\guava-17.0.jar;$gamedir\jars\libraries\org\apache\commons\commons-lang3\3.3.2\commons-lang3-3.3.2.jar;$gamedir\jars\libraries\commons-io\commons-io\2.4\commons-io-2.4.jar;$gamedir\jars\libraries\commons-codec\commons-codec\1.9\commons-codec-1.9.jar;$gamedir\jars\libraries\net\java\jinput\jinput\2.0.5\jinput-2.0.5.jar;$gamedir\jars\libraries\net\java\jutils\jutils\1.0.0\jutils-1.0.0.jar;$gamedir\jars\libraries\com\google\code\gson\gson\2.2.4\gson-2.2.4.jar;$gamedir\jars\libraries\com\mojang\authlib\1.5.22\authlib-1.5.22.jar;$gamedir\jars\libraries\com\mojang\realms\1.9.8\realms-1.9.8.jar;$gamedir\jars\libraries\org\apache\commons\commons-compress\1.8.1\commons-compress-1.8.1.jar;$gamedir\jars\libraries\org\apache\httpcomponents\httpclient\4.3.3\httpclient-4.3.3.jar;$gamedir\jars\libraries\commons-logging\commons-logging\1.1.3\commons-logging-1.1.3.jar;$gamedir\jars\libraries\org\apache\httpcomponents\httpcore\4.3.2\httpcore-4.3.2.jar;$gamedir\jars\libraries\it\unimi\dsi\fastutil\7.0.12_mojang\fastutil-7.0.12_mojang.jar;$gamedir\jars\libraries\org\apache\logging\log4j\log4j-api\2.0-beta9\log4j-api-2.0-beta9.jar;$gamedir\jars\libraries\org\apache\logging\log4j\log4j-core\2.0-beta9\log4j-core-2.0-beta9.jar;$gamedir\jars\libraries\org\lwjgl\lwjgl\lwjgl\2.9.4-nightly-20150209\lwjgl-2.9.4-nightly-20150209.jar;$gamedir\jars\libraries\org\lwjgl\lwjgl\lwjgl_util\2.9.4-nightly-20150209\lwjgl_util-2.9.4-nightly-20150209.jar;$gamedir\jars\1.10.2.jar -Xmx$memG -XX:+UnlockExperimentalVMOptions -XX:+UseG1GC -XX:G1NewSizePercent=20 -XX:G1ReservePercent=20 -XX:MaxGCPauseMillis=50 -XX:G1HeapRegionSize=16M -Dlog4j.configurationFile=$gamedir\jars\assets\log_configs\client-1.7.xml net.minecraft.launchwrapper.Launch --username $username --version 1.10.2-forge1.10.2-12.18.3.2511 --gameDir $gamedir --assetsDir $gamedir\jars\assets --assetIndex 1.10 --uuid $uuid --accessToken $token --userType mojang --tweakClass net.minecraftforge.fml.common.launcher.FMLTweaker --versionType Forge";

                args = args.Replace("$gamedir", gamedir);
                args = args.Replace("$mem", memory);
                args = args.Replace("$username", userInfo.getUsername());
                args = args.Replace("$uuid", userInfo.getUUID());
                args = args.Replace("$token", userInfo.getAccessToken());

                Process proc = new Process();
                ProcessStartInfo info = new ProcessStartInfo("java", args);
                info.WorkingDirectory = gamedir;
                info.CreateNoWindow = true;
                info.UseShellExecute = false;
                proc.StartInfo = info;
                
                proc.Start();

                return true;
            }
            
            if(pack.mcversion.Equals("1.12.2"))
            {
                string args = @"-XX:HeapDumpPath=MojangTricksIntelDriversForPerformance_javaw.exe_minecraft.exe.heapdump -Djava.library.path=$gamedir\jars\natives -Dminecraft.client.jar=$gamedir\jars\1.12.2.jar -cp $gamedir\jars\libraries\net\minecraftforge\forge\1.12.2-14.23.2.2624\forge-1.12.2-14.23.2.2624.jar;$gamedir\jars\libraries\net\minecraft\launchwrapper\1.12\launchwrapper-1.12.jar;$gamedir\jars\libraries\org\ow2\asm\asm-all\5.2\asm-all-5.2.jar;$gamedir\jars\libraries\jline\jline\2.13\jline-2.13.jar;$gamedir\jars\libraries\com\typesafe\akka\akka-actor_2.11\2.3.3\akka-actor_2.11-2.3.3.jar;$gamedir\jars\libraries\com\typesafe\config\1.2.1\config-1.2.1.jar;$gamedir\jars\libraries\org\scala-lang\scala-actors-migration_2.11\1.1.0\scala-actors-migration_2.11-1.1.0.jar;$gamedir\jars\libraries\org\scala-lang\scala-compiler\2.11.1\scala-compiler-2.11.1.jar;$gamedir\jars\libraries\org\scala-lang\plugins\scala-continuations-library_2.11\1.0.2\scala-continuations-library_2.11-1.0.2.jar;$gamedir\jars\libraries\org\scala-lang\plugins\scala-continuations-plugin_2.11.1\1.0.2\scala-continuations-plugin_2.11.1-1.0.2.jar;$gamedir\jars\libraries\org\scala-lang\scala-library\2.11.1\scala-library-2.11.1.jar;$gamedir\jars\libraries\org\scala-lang\scala-parser-combinators_2.11\1.0.1\scala-parser-combinators_2.11-1.0.1.jar;$gamedir\jars\libraries\org\scala-lang\scala-reflect\2.11.1\scala-reflect-2.11.1.jar;$gamedir\jars\libraries\org\scala-lang\scala-swing_2.11\1.0.1\scala-swing_2.11-1.0.1.jar;$gamedir\jars\libraries\org\scala-lang\scala-xml_2.11\1.0.2\scala-xml_2.11-1.0.2.jar;$gamedir\jars\libraries\lzma\lzma\0.0.1\lzma-0.0.1.jar;$gamedir\jars\libraries\net\sf\jopt-simple\jopt-simple\5.0.3\jopt-simple-5.0.3.jar;$gamedir\jars\libraries\java3d\vecmath\1.5.2\vecmath-1.5.2.jar;$gamedir\jars\libraries\net\sf\trove4j\trove4j\3.0.3\trove4j-3.0.3.jar;$gamedir\jars\libraries\com\mojang\patchy\1.1\patchy-1.1.jar;$gamedir\jars\libraries\oshi-project\oshi-core\1.1\oshi-core-1.1.jar;$gamedir\jars\libraries\net\java\dev\jna\jna\4.4.0\jna-4.4.0.jar;$gamedir\jars\libraries\net\java\dev\jna\platform\3.4.0\platform-3.4.0.jar;$gamedir\jars\libraries\com\ibm\icu\icu4j-core-mojang\51.2\icu4j-core-mojang-51.2.jar;$gamedir\jars\libraries\net\sf\jopt-simple\jopt-simple\5.0.3\jopt-simple-5.0.3.jar;$gamedir\jars\libraries\com\paulscode\codecjorbis\20101023\codecjorbis-20101023.jar;$gamedir\jars\libraries\com\paulscode\codecwav\20101023\codecwav-20101023.jar;$gamedir\jars\libraries\com\paulscode\libraryjavasound\20101123\libraryjavasound-20101123.jar;$gamedir\jars\libraries\com\paulscode\librarylwjglopenal\20100824\librarylwjglopenal-20100824.jar;$gamedir\jars\libraries\com\paulscode\soundsystem\20120107\soundsystem-20120107.jar;$gamedir\jars\libraries\io\netty\netty-all\4.1.9.Final\netty-all-4.1.9.Final.jar;$gamedir\jars\libraries\com\google\guava\guava\21.0\guava-21.0.jar;$gamedir\jars\libraries\org\apache\commons\commons-lang3\3.5\commons-lang3-3.5.jar;$gamedir\jars\libraries\commons-io\commons-io\2.5\commons-io-2.5.jar;$gamedir\jars\libraries\commons-codec\commons-codec\1.10\commons-codec-1.10.jar;$gamedir\jars\libraries\net\java\jinput\jinput\2.0.5\jinput-2.0.5.jar;$gamedir\jars\libraries\net\java\jutils\jutils\1.0.0\jutils-1.0.0.jar;$gamedir\jars\libraries\com\google\code\gson\gson\2.8.0\gson-2.8.0.jar;$gamedir\jars\libraries\com\mojang\authlib\1.5.25\authlib-1.5.25.jar;$gamedir\jars\libraries\com\mojang\realms\1.10.19\realms-1.10.19.jar;$gamedir\jars\libraries\org\apache\commons\commons-compress\1.8.1\commons-compress-1.8.1.jar;$gamedir\jars\libraries\org\apache\httpcomponents\httpclient\4.3.3\httpclient-4.3.3.jar;$gamedir\jars\libraries\commons-logging\commons-logging\1.1.3\commons-logging-1.1.3.jar;$gamedir\jars\libraries\org\apache\httpcomponents\httpcore\4.3.2\httpcore-4.3.2.jar;$gamedir\jars\libraries\it\unimi\dsi\fastutil\7.1.0\fastutil-7.1.0.jar;$gamedir\jars\libraries\org\apache\logging\log4j\log4j-api\2.8.1\log4j-api-2.8.1.jar;$gamedir\jars\libraries\org\apache\logging\log4j\log4j-core\2.8.1\log4j-core-2.8.1.jar;$gamedir\jars\libraries\org\lwjgl\lwjgl\lwjgl\2.9.4-nightly-20150209\lwjgl-2.9.4-nightly-20150209.jar;$gamedir\jars\libraries\org\lwjgl\lwjgl\lwjgl_util\2.9.4-nightly-20150209\lwjgl_util-2.9.4-nightly-20150209.jar;$gamedir\jars\libraries\com\mojang\text2speech\1.10.3\text2speech-1.10.3.jar;$gamedir\jars\1.12.2.jar -Xmx$memG -XX:+UnlockExperimentalVMOptions -XX:+UseG1GC -XX:G1NewSizePercent=20 -XX:G1ReservePercent=20 -XX:MaxGCPauseMillis=50 -XX:G1HeapRegionSize=16M -Dcofh.rf.crashOnOldAPI=false net.minecraft.launchwrapper.Launch --username $username --version 1.12.2-forge1.12.2-14.23.2.2624 --gameDir $gamedir --assetsDir $gamedir\jars\assets --assetIndex 1.12 --uuid $uuid --accessToken $token --userType mojang --tweakClass net.minecraftforge.fml.common.launcher.FMLTweaker --versionType Forge";

                args = args.Replace("$gamedir", gamedir);
                args = args.Replace("$mem", memory);
                args = args.Replace("$username", userInfo.getUsername());
                args = args.Replace("$uuid", userInfo.getUUID());
                args = args.Replace("$token", userInfo.getAccessToken());

                Process proc = new Process();
                ProcessStartInfo info = new ProcessStartInfo("java", args);
                info.WorkingDirectory = gamedir;
                info.CreateNoWindow = true;
                info.UseShellExecute = false;
                proc.StartInfo = info;

                proc.Start();

                return true;
            }

             MessageBox.Show("This modpack is not supported by this version of the launcher. It probably needs to be updated.");
             return false;
            
        }
    }
}
