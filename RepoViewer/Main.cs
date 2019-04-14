using ICSharpCode.SharpZipLib.BZip2;
using ICSharpCode.SharpZipLib.GZip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RepoViewer
{
    public partial class Main : Form
    {
        string uniqueid = "8843d7f92416211de9ebb963ff4ce27125932878";
        string firmware = "12.1.2";
        string machine = "iPhone10,6";
        string agent = "Cydia/0.9 CFNetwork/976 Darwin/18.2.0";

        internal class PKG
        {
            internal string package;
            internal string version;
            internal string name;
            internal string filename;
            //internal List<string> versions = new List<string>();
        }

        string[] packagefile;
        WebClient test = new WebClient();
        public Main()
        {
            InitializeComponent();
        }

        string[] empty = new string[0];
        List<PKG> toaddlist;
        string currentrepo = "";
        public void reloadheaders()
        {
            if (File.Exists("headers.cfg"))
            {
                try
                {
                    test.Headers.Clear();
                    using (StreamReader headerreader = new StreamReader("headers.cfg"))
                    {
                        while (!headerreader.EndOfStream)
                        {
                            string[] tmpheader = headerreader.ReadLine().Split('=');
                            //MessageBox.Show("Adding header: " + tmpheader[0] + "=" + tmpheader[1]);
                            test.Headers[tmpheader[0]] = tmpheader[1];
                        }
                    }
                    //MessageBox.Show(test.Headers.ToString());
                }
                catch(Exception)
                {
                    MessageBox.Show("Failed to load headers config, deleting the file...\r\n\r\nFormat:\r\nHEADER=VALUE");
                    File.Delete("headers.cfg");
                }
            }
        }



        private void Main_Load(object sender, EventArgs e)
        {
            test.Headers["Accept-Language"] = "nl-nl";
            test.Headers["Accept"] = "*/*";
            test.Headers["X-Original-Url"] = "Packages";
            test.Headers["X-Machine"] = machine;
            test.Headers["X-Unique-ID"] = uniqueid;
            test.Headers["X-Firmware"] = firmware;
            test.Headers["User-Agent"] = agent;
            reloadheaders();
            log("-----------------------------\r\nStarted up (" + DateTime.Now + ")\r\n-----------------------------\r\n");
        }

        public void addpackage()
        {
            packages.BeginUpdate();
            foreach (PKG temp in toaddlist)
            {
                    ListViewItem nieuw = new ListViewItem(temp.name);
                    nieuw.SubItems.Add(temp.version);
                    nieuw.SubItems.Add(temp.package);
                    nieuw.Tag = temp.filename;
                    packages.Items.AddRange(new ListViewItem[] { nieuw });
                //MessageBox.Show("Added: " + temp.package);
            }
            packages.EndUpdate();
        }

        public void compress(string zipFileName, string output)
        {
            using (FileStream fileToBeZippedAsStream = new FileStream(zipFileName, FileMode.Open, FileAccess.Read))
            {
                using (FileStream zipTargetAsStream = File.Create(output))
                {
                    try
                    {
                        BZip2.Compress(fileToBeZippedAsStream, zipTargetAsStream, true, 4096);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Failed to compress: " + zipFileName);
                    }
                }
            }
        }
        public void decompress(string zipFileName, string output, bool delete)
        {
            using (FileStream fileToDecompressAsStream = new FileStream(zipFileName, FileMode.Open, FileAccess.Read))
            {
                string decompressedFileName = output;
                using (FileStream decompressedStream = File.Create(decompressedFileName))
                {
                    try
                    {
                        BZip2.Decompress(fileToDecompressAsStream, decompressedStream, true);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Failed to decompress: " + zipFileName);
                    }
                }
            }
            if (delete)
            {
                File.Delete(zipFileName);
            }
        }

        public void decompress_gzip(string zipFileName, string output, bool delete)
        {
            using (FileStream fileToDecompressAsStream = new FileStream(zipFileName, FileMode.Open, FileAccess.Read))
            {
                string decompressedFileName = output;
                using (FileStream decompressedStream = File.Create(decompressedFileName))
                {
                    try
                    {
                        GZip.Decompress(fileToDecompressAsStream, decompressedStream, true);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Failed to decompress: " + zipFileName);
                    }
                }
            }
            if (delete)
            {
                File.Delete(zipFileName);
            }
        }

        public void clean_temp()
        {
            if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\temp"))
            {
                DirectoryInfo projecten = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "\\temp");
                foreach (var delfile in projecten.GetFiles("*"))
                {
                    File.Delete(delfile.FullName);
                }
            }
            else
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\temp");
            }
        }

        public bool downloadpackagefile(string repo)
        {
            if (repo.Contains("bigboss"))
            {
                try
                {
                    test.DownloadFile(cleanurl(repo + "/Packages.bz2"), "temp/Packages.bz2");
                    decompress("temp/Packages.bz2", "temp/Packages", true);
                    packagefile = File.ReadAllLines("temp/Packages");
                    //MessageBox.Show("Found: Packages.bz2");
                    return true;
                }
                catch (Exception)
                {
                    try
                    {
                        test.DownloadFile(cleanurl(repo + "/Packages.gz"), "temp/Packages.gz");
                        decompress_gzip("temp/Packages.gz", "temp/Packages", true);
                        packagefile = File.ReadAllLines("temp/Packages");
                        //MessageBox.Show("Found: Packages.gz");
                        return true;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Failed getting packages :(");
                        return false;
                    }
                }
            }
            else
            {
                try
                {
                    test.DownloadFile(cleanurl(repo + "/Packages"), "temp/Packages");
                    packagefile = File.ReadAllLines("temp/Packages");
                    //MessageBox.Show("Found: Packages");
                    return true;
                }
                catch (Exception)
                {
                    try
                    {
                        test.DownloadFile(cleanurl(repo + "/Packages.bz2"), "temp/Packages.bz2");
                        decompress("temp/Packages.bz2", "temp/Packages", true);
                        packagefile = File.ReadAllLines("temp/Packages");
                        //MessageBox.Show("Found: Packages.bz2");
                        return true;
                    }
                    catch (Exception)
                    {
                        try
                        {
                            test.DownloadFile(cleanurl(repo + "/Packages.gz"), "temp/Packages.gz");
                            decompress_gzip("temp/Packages.gz", "temp/Packages", true);
                            packagefile = File.ReadAllLines("temp/Packages");
                            //MessageBox.Show("Found: Packages.gz");
                            return true;
                        }
                        catch (Exception)
                        {
                            if (repo.Contains("https"))
                            {
                                MessageBox.Show("Failed to connect using HTTPS, click OK to retry with HTTP");
                            }
                            else
                            {
                                MessageBox.Show("Failed getting packages :(");
                            }
                            return false;
                        }
                    }
                }
            }
        }
        bool loading_done = false;
        string loading_errors = "";
        string loading_warnings = "";
        int lval = 25;
        public void loadrepo()
        {
            repo.Enabled = false;
            packages.Enabled = false;
            loading_done = false;
            loading_errors = "";
            loading_warnings = "";

            toaddlist = new List<PKG>();
            packages.Items.Clear();
            packages_search.Items.Clear();
            loading_monitor.Enabled = true;

            lval = 25;
            loading.Value = 25;
            loading.Visible = true;

            new Task(() =>
            {
            log("Loading repo: " + repo.Text + "(" + DateTime.Now + ")");
                PKG temppkg = new PKG();
                //packages.Columns.Clear();
                //packages_search.Columns.Clear();
                RichTextBox temp = new RichTextBox();
                currentrepo = repo.Text;
                //MessageBox.Show(test.DownloadString("https://whoer.net/"));
                clean_temp();
                if (currentrepo.ToLower().Contains("bigboss"))
                {
                    //MessageBox.Show("Hotfixed thebigboss, press OK to start.");
                    if (downloadpackagefile("http://apt.thebigboss.org/repofiles/cydia/dists/stable/main/binary-iphoneos-arm/") == false)
                    {
                        loading_errors = "Could not download Package file.";
                        loading_done = true;
                        return;
                    }
                }
                else
                {
                    if (downloadpackagefile(currentrepo) == false)
                    {
                        loading_errors = "Could not download Package file.";
                        loading_done = true;
                        return;
                    }
                }
                lval = 70;
                foreach (string lijn in packagefile)
                {
                    if (lijn == "")
                    {
                        //addpackage();
                        //toadd = empty;
                        //toaddcount = 0;
                        if (temppkg.package != "" && temppkg.version != "" && temppkg.name != "" && temppkg.filename != "")
                        {
                            // MessageBox.Show("Adding pkg:" + temppkg.Package);

                            /*
                                bool found = false;
                                foreach(PKG tmpcheck in toaddlist)
                                {
                                    if(tmpcheck.package == temppkg.package)
                                    {
                                        tmpcheck.versions.Add(temppkg.version);
                                        found = true;
                                        break;
                                    }
                                }
                            if (found == false)
                            {*/
                            toaddlist.Add(temppkg);
                            //}
                        }
                        temppkg = new PKG();
                        //MessageBox.Show("Done");
                        //return;
                    }
                    else
                    {
                        //toaddcount++;
                        try
                        {
                            if (lijn.Replace(": ", ":").Split(':')[0].ToLower() == "package")
                            {
                                temppkg.package = lijn.Replace(": ", ":").Split(':')[1];
                            }
                            else if (lijn.Replace(": ", ":").Split(':')[0].ToLower() == "version")
                            {
                                temppkg.version = lijn.Replace(": ", ":").Split(':')[1];
                            }
                            else if (lijn.Replace(": ", ":").Split(':')[0].ToLower() == "name")
                            {
                                temppkg.name = lijn.Replace(": ", ":").Split(':')[1];
                            }
                            else if (lijn.Replace(": ", ":").Split(':')[0].ToLower() == "filename")
                            {
                                temppkg.filename = lijn.Replace(": ", ":").Split(':')[1];
                            }
                        }
                        catch (Exception)
                        {
                            loading_warnings += "[Failed parsing] : " + lijn + "\r\nSkipped\r\n";
                        }
                        //MessageBox.Show("Found line");
                    }
                }
                //Hotfix/
                lval = 90;
                if (temppkg.package != "" && temppkg.version != "" && temppkg.name != "" && temppkg.filename != "")
                {
                    // MessageBox.Show("Adding pkg:" + temppkg.Package);
                    toaddlist.Add(temppkg);
                }
                if (currentrepo.ToLower().Contains("bigboss"))
                {
                    currentrepo = "http://apt.thebigboss.org/repofiles/cydia/";
                }
                loading_done = true;
            }).Start();
        }
        private void repo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadrepo();
            }
        }

        public string cleanurl(string url)
        {
            return url.Replace("://", "TEMP_HTTP_FIX_A1").Replace("//", "/").Replace("TEMP_HTTP_FIX_A1", "://");
        }


        public void log(string logtext)
        {
            
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                w.WriteLine(logtext);
            }
            
        }

        public void downloaddebs(bool overwrite)
        {
            ListView templ = new ListView();
            if (rcm.SourceControl == packages)
            {
                templ = packages;
            }
            if (rcm.SourceControl == packages_search)
            {
                templ = packages_search;
            }
                if(templ.SelectedItems.Count < 1)
                {
                    return;
                }
                foreach (ListViewItem item in templ.SelectedItems)
                {
                try
                {
                    if (!Directory.Exists("debs"))
                    {
                        Directory.CreateDirectory("debs");
                    }
                    string sitem = item.Tag.ToString().Replace("./", "/");
                    if (sitem.Contains(".deb"))
                    {
                        new Task(() =>
                        {
                            string[] name = sitem.Split('/');
                            try
                            {
                                    if (!(File.Exists("debs/" + name[name.Length - 1])) || overwrite == true)
                                    {
                                        //log("Downloading: " + "debs/" + name[name.Length - 1]);
                                        test.DownloadFile(currentrepo + "/" + sitem, "debs/" + name[name.Length - 1]);
                                        item.BackColor = Color.Green;
                                    }
                            }
                            catch (Exception ex)
                            {
                                File.WriteAllText("debs/" + name[name.Length - 1] + ".FAILED_DOWNLOAD", "Failed:\r\n" + ex);
                                item.BackColor = Color.Red;
                            }
                        }).Start();
                    }
                }
                catch(Exception)
                {
                    MessageBox.Show("Failed item:" + item.SubItems[0].Text);
                }
                }
            
            Process.Start(AppDomain.CurrentDomain.BaseDirectory + "/debs");
        }
        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            downloaddebs(false);
        }

        private void downloadAndOverwriteExistingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            downloaddebs(true);
        }

        int laatste;
        bool legit = false;
        public void ListBoxSorterXD(object sender, int column)
        {
            if (column == laatste)
            {
                legit = !legit;
            }
            else
            {
                legit = false;
            }
            laatste = column;
            ListView list = (ListView)sender;
            int total = list.Items.Count;
            list.BeginUpdate();
            ListViewItem[] items = new ListViewItem[total];
            for (int i = 0; i < total; i++)
            {
                int count = list.Items.Count;
                int minIdx = 0;
                if (legit == true)
                {
                    for (int j = 1; j < count; j++)
                        if (list.Items[j].SubItems[column].Text.CompareTo(list.Items[minIdx].SubItems[column].Text) > 0)
                            minIdx = j;
                    items[i] = list.Items[minIdx];
                    list.Items.RemoveAt(minIdx);
                }
                else
                {
                    for (int j = 1; j < count; j++)
                        if (list.Items[j].SubItems[column].Text.CompareTo(list.Items[minIdx].SubItems[column].Text) < 0)
                            minIdx = j;
                    items[i] = list.Items[minIdx];
                    list.Items.RemoveAt(minIdx);
                }
            }
            list.Items.AddRange(items);
            list.EndUpdate();
        }

        private void packages_search_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListBoxSorterXD(packages_search, e.Column);
        }

        public void zoek(string text)
        {
            if(text == "")
            {
                packages.Visible = true;
                packages_search.Visible = false;
                return;
            }
            packages_search.Visible = true;
            packages.Visible = false;
            packages_search.BeginUpdate();
            packages_search.Items.Clear();
            foreach (ListViewItem Item in packages.Items)
            {
                string all = Item.SubItems[0].Text + Item.SubItems[1].Text + Item.SubItems[2].Text;
                if (all.Replace("-", "").ToLower().Contains(text.ToLower()))
                {
                    packages_search.Items.Add((ListViewItem)Item.Clone());
                }
            }
            packages_search.EndUpdate();
        }

        private void search_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                zoek(search.Text);
            }
        }

        private void packages_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListBoxSorterXD(packages, e.Column);
        }

        private void copydebLinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView templ = new ListView();
            if (rcm.SourceControl == packages)
            {
                templ = packages;
            }
            if (rcm.SourceControl == packages_search)
            {
                templ = packages_search;
            }
            if (templ.SelectedItems.Count < 1)
            {
                return;
            }
            string items = "";
            int count = 0;
            foreach (ListViewItem item in templ.SelectedItems)
            {
                count++;
                string sitem = cleanurl(currentrepo + "/" + item.Tag.ToString().Replace("./", "/"));
                if (count == 1)
                {
                    items += sitem;
                }
                else
                {
                    items += "\r\n" + sitem;
                }
            }
            Clipboard.SetText(items);
        }

        private void config_Click(object sender, EventArgs e)
        {
            Form Config = new Config(this);
            Config.ShowDialog();
        }

        private void done_Tick(object sender, EventArgs e)
        {
            if(lval > 25 && loading.Value != lval)
            {
                loading.Value = lval;
            }
            if (loading_done)
            {
                loading_monitor.Enabled = false;
                if (loading_errors == "")
                {
                    addpackage();
                    label1.Text = packages.Items.Count + "\r\ndebs";
                    zoek("");
                }
                log("Completed loading: " + repo.Text + " - found " + packages.Items.Count + " debs" + "(" + DateTime.Now + ")");
                repo.Enabled = true;
                packages.Enabled = true;
                loading.Visible = false;
                if(loading_warnings != "")
                {
                    log("On the above project the followings warnings where found: " + loading_warnings);
                    MessageBox.Show(loading_warnings);
                }
            }
        }

        private void github_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/ImNotSatan/RepoViewer");
        }
    }
}
