namespace FormsApp
{
    partial class frmOtherSettings
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
            this.butOk = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboPyramidDown = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboMinArea = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMinRadius = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaxAspect = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // butOk
            // 
            this.butOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.butOk.Location = new System.Drawing.Point(134, 263);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(55, 23);
            this.butOk.TabIndex = 0;
            this.butOk.Text = "Ok";
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Location = new System.Drawing.Point(197, 263);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(59, 23);
            this.butCancel.TabIndex = 1;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pyramid down ";
            // 
            // cboPyramidDown
            // 
            this.cboPyramidDown.AllowDrop = true;
            this.cboPyramidDown.FormattingEnabled = true;
            this.cboPyramidDown.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cboPyramidDown.Location = new System.Drawing.Point(173, 14);
            this.cboPyramidDown.Name = "cboPyramidDown";
            this.cboPyramidDown.Size = new System.Drawing.Size(83, 21);
            this.cboPyramidDown.TabIndex = 3;
            this.cboPyramidDown.SelectedIndexChanged += new System.EventHandler(this.cboPyramidDown_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Min Contour Area";
            // 
            // cboMinArea
            // 
            this.cboMinArea.FormattingEnabled = true;
            this.cboMinArea.Location = new System.Drawing.Point(173, 54);
            this.cboMinArea.Name = "cboMinArea";
            this.cboMinArea.Size = new System.Drawing.Size(83, 21);
            this.cboMinArea.TabIndex = 5;
            this.cboMinArea.SelectedIndexChanged += new System.EventHandler(this.cboMinArea_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Min Contour Radius";
            // 
            // txtMinRadius
            // 
            this.txtMinRadius.Location = new System.Drawing.Point(174, 90);
            this.txtMinRadius.Name = "txtMinRadius";
            this.txtMinRadius.Size = new System.Drawing.Size(81, 20);
            this.txtMinRadius.TabIndex = 7;
            this.txtMinRadius.TextChanged += new System.EventHandler(this.txtMinRadius_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Max Aspect Ratio Deviation";
            // 
            // txtMaxAspect
            // 
            this.txtMaxAspect.Location = new System.Drawing.Point(174, 120);
            this.txtMaxAspect.Name = "txtMaxAspect";
            this.txtMaxAspect.Size = new System.Drawing.Size(80, 20);
            this.txtMaxAspect.TabIndex = 9;
            // 
            // frmOtherSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butCancel;
            this.ClientSize = new System.Drawing.Size(268, 298);
            this.Controls.Add(this.txtMaxAspect);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMinRadius);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboMinArea);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboPyramidDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmOtherSettings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.frmOtherSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butOk;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPyramidDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboMinArea;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMinRadius;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaxAspect;
    }
}