namespace LightwaveBrowser
{
    partial class Browser
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BrowserBar = new System.Windows.Forms.Panel();
            this.BookmarkBar = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ControlBar = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.AddonButtons = new System.Windows.Forms.Panel();
            this.NavBar = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.WebControl = new Awesomium.Windows.Forms.WebControl(this.components);
            this.Bookmarks = new System.Windows.Forms.Button();
            this.Downloads = new System.Windows.Forms.Button();
            this.Reload = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.Forward = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.BrowserBar.SuspendLayout();
            this.BookmarkBar.SuspendLayout();
            this.panel2.SuspendLayout();
            this.ControlBar.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.NavBar.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BrowserBar
            // 
            this.BrowserBar.Controls.Add(this.BookmarkBar);
            this.BrowserBar.Controls.Add(this.panel2);
            this.BrowserBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.BrowserBar.Location = new System.Drawing.Point(0, 0);
            this.BrowserBar.Name = "BrowserBar";
            this.BrowserBar.Size = new System.Drawing.Size(404, 60);
            this.BrowserBar.TabIndex = 0;
            // 
            // BookmarkBar
            // 
            this.BookmarkBar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BookmarkBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BookmarkBar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BookmarkBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.BookmarkBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.BookmarkBar.Location = new System.Drawing.Point(0, 30);
            this.BookmarkBar.Name = "BookmarkBar";
            this.BookmarkBar.Size = new System.Drawing.Size(404, 30);
            this.BookmarkBar.TabIndex = 1;
            this.BookmarkBar.Text = "toolStrip1";
            this.BookmarkBar.Paint += new System.Windows.Forms.PaintEventHandler(this.BookmarkBar_Paint);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(102, 25);
            this.toolStripLabel1.Text = "toolStripLabel1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.ControlBar);
            this.panel2.Controls.Add(this.AddonButtons);
            this.panel2.Controls.Add(this.NavBar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(404, 30);
            this.panel2.TabIndex = 0;
            // 
            // ControlBar
            // 
            this.ControlBar.Controls.Add(this.tableLayoutPanel2);
            this.ControlBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ControlBar.Location = new System.Drawing.Point(60, 0);
            this.ControlBar.Name = "ControlBar";
            this.ControlBar.Size = new System.Drawing.Size(291, 30);
            this.ControlBar.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.Controls.Add(this.panel6, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(291, 30);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.textBox1);
            this.panel6.Controls.Add(this.Bookmarks);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(225, 24);
            this.panel6.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(190, 16);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.Downloads, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.Reload, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(234, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(54, 24);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // AddonButtons
            // 
            this.AddonButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.AddonButtons.Location = new System.Drawing.Point(351, 0);
            this.AddonButtons.Name = "AddonButtons";
            this.AddonButtons.Size = new System.Drawing.Size(53, 30);
            this.AddonButtons.TabIndex = 1;
            // 
            // NavBar
            // 
            this.NavBar.Controls.Add(this.tableLayoutPanel1);
            this.NavBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.NavBar.Location = new System.Drawing.Point(0, 0);
            this.NavBar.Name = "NavBar";
            this.NavBar.Size = new System.Drawing.Size(60, 30);
            this.NavBar.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.Back, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Forward, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(60, 30);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // WebControl
            // 
            this.WebControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WebControl.Location = new System.Drawing.Point(0, 60);
            this.WebControl.Size = new System.Drawing.Size(404, 254);
            this.WebControl.TabIndex = 1;
            this.WebControl.LoadingFrame += new Awesomium.Core.LoadingFrameEventHandler(this.Awesomium_Windows_Forms_WebControl_LoadingFrame);
            this.WebControl.LoadingFrameComplete += new Awesomium.Core.FrameEventHandler(this.Awesomium_Windows_Forms_WebControl_LoadingFrameComplete);
            // 
            // Bookmarks
            // 
            this.Bookmarks.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Bookmarks.BackgroundImage = global::LightwaveBrowser.Properties.Resources.bookmark;
            this.Bookmarks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Bookmarks.FlatAppearance.BorderSize = 0;
            this.Bookmarks.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.Bookmarks.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.Bookmarks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bookmarks.Location = new System.Drawing.Point(197, 1);
            this.Bookmarks.Name = "Bookmarks";
            this.Bookmarks.Size = new System.Drawing.Size(25, 19);
            this.Bookmarks.TabIndex = 0;
            this.toolTip1.SetToolTip(this.Bookmarks, "Bookmarks");
            this.Bookmarks.UseVisualStyleBackColor = true;
            // 
            // Downloads
            // 
            this.Downloads.BackgroundImage = global::LightwaveBrowser.Properties.Resources.download_normal;
            this.Downloads.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Downloads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Downloads.FlatAppearance.BorderSize = 0;
            this.Downloads.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.Downloads.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.Downloads.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Downloads.Location = new System.Drawing.Point(30, 3);
            this.Downloads.Name = "Downloads";
            this.Downloads.Size = new System.Drawing.Size(21, 18);
            this.Downloads.TabIndex = 1;
            this.toolTip1.SetToolTip(this.Downloads, "Downloads");
            this.Downloads.UseVisualStyleBackColor = true;
            // 
            // Reload
            // 
            this.Reload.BackgroundImage = global::LightwaveBrowser.Properties.Resources.refresh;
            this.Reload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Reload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Reload.FlatAppearance.BorderSize = 0;
            this.Reload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.Reload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.Reload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Reload.Location = new System.Drawing.Point(3, 3);
            this.Reload.Name = "Reload";
            this.Reload.Size = new System.Drawing.Size(21, 18);
            this.Reload.TabIndex = 0;
            this.toolTip1.SetToolTip(this.Reload, "Refresh");
            this.Reload.UseVisualStyleBackColor = true;
            this.Reload.Click += new System.EventHandler(this.Reload_Click);
            // 
            // Back
            // 
            this.Back.BackgroundImage = global::LightwaveBrowser.Properties.Resources.Navigete_Back_Disabled;
            this.Back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Back.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Back.Enabled = false;
            this.Back.FlatAppearance.BorderSize = 0;
            this.Back.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.Back.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Back.Location = new System.Drawing.Point(3, 3);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(24, 24);
            this.Back.TabIndex = 0;
            this.toolTip1.SetToolTip(this.Back, "Back");
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // Forward
            // 
            this.Forward.BackgroundImage = global::LightwaveBrowser.Properties.Resources.Navigete_Forward_Disabled;
            this.Forward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Forward.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Forward.Enabled = false;
            this.Forward.FlatAppearance.BorderSize = 0;
            this.Forward.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.Forward.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.Forward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Forward.Location = new System.Drawing.Point(33, 3);
            this.Forward.Name = "Forward";
            this.Forward.Size = new System.Drawing.Size(24, 24);
            this.Forward.TabIndex = 1;
            this.toolTip1.SetToolTip(this.Forward, "Forward");
            this.Forward.UseVisualStyleBackColor = true;
            this.Forward.Click += new System.EventHandler(this.Forward_Click);
            // 
            // Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.WebControl);
            this.Controls.Add(this.BrowserBar);
            this.Name = "Browser";
            this.Size = new System.Drawing.Size(404, 314);
            this.Load += new System.EventHandler(this.Browser_Load);
            this.BrowserBar.ResumeLayout(false);
            this.BrowserBar.PerformLayout();
            this.BookmarkBar.ResumeLayout(false);
            this.BookmarkBar.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ControlBar.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.NavBar.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BrowserBar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip BookmarkBar;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Panel ControlBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Bookmarks;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button Downloads;
        private System.Windows.Forms.Button Reload;
        private System.Windows.Forms.Panel AddonButtons;
        private System.Windows.Forms.Panel NavBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Button Forward;
        private Awesomium.Windows.Forms.WebControl WebControl;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
