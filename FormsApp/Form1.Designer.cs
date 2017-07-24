namespace FormsApp
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adaptiveThresholdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adaptiveThresholdProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.processToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blurMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cannyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adaptiveThresholdToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.measureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getPerimeterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.vScrollBar = new System.Windows.Forms.VScrollBar();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButAdaptive = new System.Windows.Forms.ToolStripButton();
            this.butToggleResults = new System.Windows.Forms.Button();
            this.butFind = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox.Location = new System.Drawing.Point(20, 49);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(735, 359);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.processToolStripMenuItem,
            this.measureToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(793, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFiles});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openFiles
            // 
            this.openFiles.Name = "openFiles";
            this.openFiles.Size = new System.Drawing.Size(152, 22);
            this.openFiles.Text = "Open...";
            this.openFiles.Click += new System.EventHandler(this.openFiles_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generalToolStripMenuItem,
            this.adaptiveThresholdToolStripMenuItem,
            this.adaptiveThresholdProcessToolStripMenuItem,
            this.processToolStripMenuItem1});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // generalToolStripMenuItem
            // 
            this.generalToolStripMenuItem.Name = "generalToolStripMenuItem";
            this.generalToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.generalToolStripMenuItem.Text = "General...";
            this.generalToolStripMenuItem.Click += new System.EventHandler(this.generalToolStripMenuItem_Click);
            // 
            // adaptiveThresholdToolStripMenuItem
            // 
            this.adaptiveThresholdToolStripMenuItem.Name = "adaptiveThresholdToolStripMenuItem";
            this.adaptiveThresholdToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.adaptiveThresholdToolStripMenuItem.Text = "Adaptive Threshold (Ball)";
            this.adaptiveThresholdToolStripMenuItem.Click += new System.EventHandler(this.adaptiveThresholdToolStripMenuItem_Click);
            // 
            // adaptiveThresholdProcessToolStripMenuItem
            // 
            this.adaptiveThresholdProcessToolStripMenuItem.Name = "adaptiveThresholdProcessToolStripMenuItem";
            this.adaptiveThresholdProcessToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.adaptiveThresholdProcessToolStripMenuItem.Text = "Adaptive Threshold (Process)";
            this.adaptiveThresholdProcessToolStripMenuItem.Click += new System.EventHandler(this.adaptiveThresholdProcessToolStripMenuItem_Click);
            // 
            // processToolStripMenuItem1
            // 
            this.processToolStripMenuItem1.Name = "processToolStripMenuItem1";
            this.processToolStripMenuItem1.Size = new System.Drawing.Size(228, 22);
            this.processToolStripMenuItem1.Text = "Process...";
            this.processToolStripMenuItem1.Click += new System.EventHandler(this.processToolStripMenuItem1_Click);
            // 
            // processToolStripMenuItem
            // 
            this.processToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blurMenuItem,
            this.cannyToolStripMenuItem,
            this.adaptiveThresholdToolStripMenuItem1});
            this.processToolStripMenuItem.Name = "processToolStripMenuItem";
            this.processToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.processToolStripMenuItem.Text = "Process";
            // 
            // blurMenuItem
            // 
            this.blurMenuItem.Name = "blurMenuItem";
            this.blurMenuItem.Size = new System.Drawing.Size(174, 22);
            this.blurMenuItem.Text = "Blur";
            this.blurMenuItem.Click += new System.EventHandler(this.blurMenuItem_Click);
            // 
            // cannyToolStripMenuItem
            // 
            this.cannyToolStripMenuItem.Name = "cannyToolStripMenuItem";
            this.cannyToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.cannyToolStripMenuItem.Text = "Canny";
            this.cannyToolStripMenuItem.Click += new System.EventHandler(this.cannyToolStripMenuItem_Click);
            // 
            // adaptiveThresholdToolStripMenuItem1
            // 
            this.adaptiveThresholdToolStripMenuItem1.Name = "adaptiveThresholdToolStripMenuItem1";
            this.adaptiveThresholdToolStripMenuItem1.Size = new System.Drawing.Size(174, 22);
            this.adaptiveThresholdToolStripMenuItem1.Text = "Adaptive threshold";
            this.adaptiveThresholdToolStripMenuItem1.Click += new System.EventHandler(this.adaptiveThresholdToolStripMenuItem1_Click);
            // 
            // measureToolStripMenuItem
            // 
            this.measureToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getLinesToolStripMenuItem,
            this.getPerimeterToolStripMenuItem});
            this.measureToolStripMenuItem.Name = "measureToolStripMenuItem";
            this.measureToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.measureToolStripMenuItem.Text = "Measure";
            // 
            // getLinesToolStripMenuItem
            // 
            this.getLinesToolStripMenuItem.Name = "getLinesToolStripMenuItem";
            this.getLinesToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.getLinesToolStripMenuItem.Text = "Get lines";
            this.getLinesToolStripMenuItem.Click += new System.EventHandler(this.getLinesToolStripMenuItem_Click);
            // 
            // getPerimeterToolStripMenuItem
            // 
            this.getPerimeterToolStripMenuItem.Name = "getPerimeterToolStripMenuItem";
            this.getPerimeterToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.getPerimeterToolStripMenuItem.Text = "Get perimeter";
            this.getPerimeterToolStripMenuItem.Click += new System.EventHandler(this.getPerimeterToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "pgm";
            this.openFileDialog1.Filter = "(Point Grey Image)|*.pgm";
            this.openFileDialog1.Multiselect = true;
            // 
            // vScrollBar
            // 
            this.vScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.vScrollBar.LargeChange = 1;
            this.vScrollBar.Location = new System.Drawing.Point(0, 49);
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.Size = new System.Drawing.Size(18, 421);
            this.vScrollBar.TabIndex = 2;
            this.vScrollBar.ValueChanged += new System.EventHandler(this.vScrollBar_ValueChanged);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip.Location = new System.Drawing.Point(0, 470);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(793, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(63, 17);
            this.toolStripStatusLabel1.Text = "Image Size";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(58, 17);
            this.toolStripStatusLabel2.Text = "File name";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButAdaptive});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(793, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Process";
            this.toolStripButton1.ToolTipText = "Down";
            this.toolStripButton1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripButton1_MouseUp);
            // 
            // toolStripButAdaptive
            // 
            this.toolStripButAdaptive.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButAdaptive.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButAdaptive.Image")));
            this.toolStripButAdaptive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButAdaptive.Name = "toolStripButAdaptive";
            this.toolStripButAdaptive.Size = new System.Drawing.Size(23, 22);
            this.toolStripButAdaptive.Text = "toolStripButAdaptive";
            this.toolStripButAdaptive.ToolTipText = "Adaptive threshold";
            this.toolStripButAdaptive.Click += new System.EventHandler(this.toolStripButAdaptive_Click);
            // 
            // butToggleResults
            // 
            this.butToggleResults.Location = new System.Drawing.Point(96, 27);
            this.butToggleResults.Name = "butToggleResults";
            this.butToggleResults.Size = new System.Drawing.Size(40, 23);
            this.butToggleResults.TabIndex = 5;
            this.butToggleResults.Text = "S/H";
            this.butToggleResults.UseVisualStyleBackColor = true;
            this.butToggleResults.Click += new System.EventHandler(this.butToggleResults_Click);
            // 
            // butFind
            // 
            this.butFind.Location = new System.Drawing.Point(54, 26);
            this.butFind.Name = "butFind";
            this.butFind.Size = new System.Drawing.Size(36, 23);
            this.butFind.TabIndex = 6;
            this.butFind.Text = "Find";
            this.butFind.UseVisualStyleBackColor = true;
            this.butFind.Click += new System.EventHandler(this.butFind_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 492);
            this.Controls.Add(this.butFind);
            this.Controls.Add(this.butToggleResults);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.vScrollBar);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFiles;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.VScrollBar vScrollBar;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButAdaptive;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adaptiveThresholdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blurMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cannyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem measureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getLinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getPerimeterToolStripMenuItem;
        private System.Windows.Forms.Button butToggleResults;
        private System.Windows.Forms.ToolStripMenuItem adaptiveThresholdProcessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adaptiveThresholdToolStripMenuItem1;
        private System.Windows.Forms.Button butFind;
    }
}

