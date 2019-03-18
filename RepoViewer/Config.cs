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
            
        }

        public void reset_headers()
        {
            richTextBox1.Text = "X-Machine=iPhone10,6\r\nX-Unique-ID=33bd4929abe57b93c51fe6bbe037d368858fafeb\r\nX-Firmware=12.1.2\r\nUser-Agent=Telesphoreo APT-HTTP/1.0.592";
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
