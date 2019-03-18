using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RepoViewer
{
    public partial class Config : Form
    {
        Main CallingForm;
        public Config(Main cfm)
        {
            CallingForm = cfm;
            InitializeComponent();
        }

        private void reset_Click(object sender, EventArgs e)
        {
            reset_headers();
        }

        public void reset_headers()
        {
            string xtra = "Accept-Language=nl-nl\r\nAccept-Encoding=gzip, deflate\r\nAccept=*/*\r\nX-Original-Url=Packages\r\n";
            richTextBox1.Text = xtra + "X-Machine=iPhone10,6\r\nX-Unique-ID=8843d7f92416211de9ebb963ff4ce27125932878\r\nX-Firmware=12.1.2\r\nUser-Agent=Cydia/0.9 CFNetwork/976 Darwin/18.2.0";
            if (File.Exists("headers.cfg"))
            {
                File.Delete("headers.cfg");
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            File.WriteAllText("headers.cfg", richTextBox1.Text);
            CallingForm.reloadheaders();
        }

        private void Config_Load(object sender, EventArgs e)
        {
            if (File.Exists("headers.cfg"))
            {
                richTextBox1.LoadFile("headers.cfg", RichTextBoxStreamType.PlainText);
            }
            else
            {
                reset_headers();
            }
        }
    }
}
