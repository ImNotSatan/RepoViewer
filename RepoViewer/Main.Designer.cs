namespace RepoViewer
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.packages = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rcm = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadAndOverwriteExistingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copydebLinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.search = new System.Windows.Forms.TextBox();
            this.config = new System.Windows.Forms.Button();
            this.loading_monitor = new System.Windows.Forms.Timer(this.components);
            this.loading = new System.Windows.Forms.ProgressBar();
            this.github = new System.Windows.Forms.Label();
            this.packages_search = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rcm.SuspendLayout();
            this.SuspendLayout();
            // 
            // packages
            // 
            this.packages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.packages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.packages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader5});
            this.packages.ContextMenuStrip = this.rcm;
            this.packages.FullRowSelect = true;
            this.packages.GridLines = true;
            this.packages.HideSelection = false;
            this.packages.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.packages.Location = new System.Drawing.Point(12, 90);
            this.packages.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.packages.Name = "packages";
            this.packages.Size = new System.Drawing.Size(512, 354);
            this.packages.TabIndex = 11;
            this.packages.UseCompatibleStateImageBehavior = false;
            this.packages.View = System.Windows.Forms.View.Details;
            this.packages.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.packages_ColumnClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 233;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Version";
            this.columnHeader2.Width = 77;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Package";
            this.columnHeader5.Width = 182;
            // 
            // rcm
            // 
            this.rcm.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.rcm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadToolStripMenuItem,
            this.downloadAndOverwriteExistingToolStripMenuItem,
            this.copydebLinkToolStripMenuItem});
            this.rcm.Name = "rcm";
            this.rcm.Size = new System.Drawing.Size(246, 70);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.downloadToolStripMenuItem.Text = "Download (ignore exsisting)";
            this.downloadToolStripMenuItem.Click += new System.EventHandler(this.downloadToolStripMenuItem_Click);
            // 
            // downloadAndOverwriteExistingToolStripMenuItem
            // 
            this.downloadAndOverwriteExistingToolStripMenuItem.Name = "downloadAndOverwriteExistingToolStripMenuItem";
            this.downloadAndOverwriteExistingToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.downloadAndOverwriteExistingToolStripMenuItem.Text = "Download (redownload existing)";
            this.downloadAndOverwriteExistingToolStripMenuItem.Click += new System.EventHandler(this.downloadAndOverwriteExistingToolStripMenuItem_Click);
            // 
            // copydebLinkToolStripMenuItem
            // 
            this.copydebLinkToolStripMenuItem.Name = "copydebLinkToolStripMenuItem";
            this.copydebLinkToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.copydebLinkToolStripMenuItem.Text = "Copy .deb link";
            this.copydebLinkToolStripMenuItem.Click += new System.EventHandler(this.copydebLinkToolStripMenuItem_Click);
            // 
            // repo
            // 
            this.repo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.repo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repo.Location = new System.Drawing.Point(12, 12);
            this.repo.Name = "repo";
            this.repo.Size = new System.Drawing.Size(397, 32);
            this.repo.TabIndex = 12;
            this.repo.Text = "http://apt.thebigboss.org/repofiles/cydia/";
            this.repo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.repo_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(410, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 32);
            this.label1.TabIndex = 13;
            this.label1.Text = "0\r\ndebs";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // search
            // 
            this.search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.search.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search.Location = new System.Drawing.Point(12, 50);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(512, 32);
            this.search.TabIndex = 14;
            this.search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search_KeyDown);
            // 
            // config
            // 
            this.config.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.config.BackColor = System.Drawing.Color.White;
            this.config.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.config.Location = new System.Drawing.Point(451, 12);
            this.config.Name = "config";
            this.config.Size = new System.Drawing.Size(73, 32);
            this.config.TabIndex = 16;
            this.config.Text = "Config";
            this.config.UseVisualStyleBackColor = false;
            this.config.Click += new System.EventHandler(this.config_Click);
            // 
            // loading_monitor
            // 
            this.loading_monitor.Interval = 50;
            this.loading_monitor.Tick += new System.EventHandler(this.done_Tick);
            // 
            // loading
            // 
            this.loading.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loading.Location = new System.Drawing.Point(12, 50);
            this.loading.Name = "loading";
            this.loading.Size = new System.Drawing.Size(512, 32);
            this.loading.TabIndex = 17;
            this.loading.Visible = false;
            // 
            // github
            // 
            this.github.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.github.AutoSize = true;
            this.github.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.github.ForeColor = System.Drawing.Color.Blue;
            this.github.Location = new System.Drawing.Point(374, 449);
            this.github.Name = "github";
            this.github.Size = new System.Drawing.Size(150, 13);
            this.github.TabIndex = 18;
            this.github.Text = "By ImNotSatan on Github";
            this.github.Click += new System.EventHandler(this.github_Click);
            // 
            // packages_search
            // 
            this.packages_search.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.packages_search.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.packages_search.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader6});
            this.packages_search.ContextMenuStrip = this.rcm;
            this.packages_search.FullRowSelect = true;
            this.packages_search.GridLines = true;
            this.packages_search.HideSelection = false;
            this.packages_search.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.packages_search.Location = new System.Drawing.Point(12, 90);
            this.packages_search.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.packages_search.Name = "packages_search";
            this.packages_search.Size = new System.Drawing.Size(512, 354);
            this.packages_search.TabIndex = 19;
            this.packages_search.UseCompatibleStateImageBehavior = false;
            this.packages_search.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Name";
            this.columnHeader3.Width = 233;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Version";
            this.columnHeader4.Width = 77;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Package";
            this.columnHeader6.Width = 182;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 471);
            this.Controls.Add(this.packages_search);
            this.Controls.Add(this.github);
            this.Controls.Add(this.config);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.repo);
            this.Controls.Add(this.packages);
            this.Controls.Add(this.loading);
            this.Controls.Add(this.search);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Repo Viewer v1.6";
            this.Load += new System.EventHandler(this.Main_Load);
            this.rcm.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView packages;
        private System.Windows.Forms.TextBox repo;
        private System.Windows.Forms.ContextMenuStrip rcm;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadAndOverwriteExistingToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox search;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ToolStripMenuItem copydebLinkToolStripMenuItem;
        private System.Windows.Forms.Button config;
        private System.Windows.Forms.Timer loading_monitor;
        private System.Windows.Forms.ProgressBar loading;
        private System.Windows.Forms.Label github;
        private System.Windows.Forms.ListView packages_search;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}

