namespace FormsApp
{
    partial class frmAdaptiveSettings
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
            this.radMean = new System.Windows.Forms.RadioButton();
            this.radGaus = new System.Windows.Forms.RadioButton();
            this.cboBlockSize = new System.Windows.Forms.ComboBox();
            this.numConstant = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.butPreview = new System.Windows.Forms.Button();
            this.chkToggleImage = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numConstant)).BeginInit();
            this.SuspendLayout();
            // 
            // butOk
            // 
            this.butOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.butOk.Location = new System.Drawing.Point(161, 226);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(56, 23);
            this.butOk.TabIndex = 0;
            this.butOk.Text = "Ok";
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Location = new System.Drawing.Point(223, 226);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(54, 23);
            this.butCancel.TabIndex = 1;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // radMean
            // 
            this.radMean.AutoSize = true;
            this.radMean.Location = new System.Drawing.Point(31, 24);
            this.radMean.Name = "radMean";
            this.radMean.Size = new System.Drawing.Size(52, 17);
            this.radMean.TabIndex = 2;
            this.radMean.TabStop = true;
            this.radMean.Text = "Mean";
            this.radMean.UseVisualStyleBackColor = true;
            // 
            // radGaus
            // 
            this.radGaus.AutoSize = true;
            this.radGaus.Location = new System.Drawing.Point(31, 47);
            this.radGaus.Name = "radGaus";
            this.radGaus.Size = new System.Drawing.Size(64, 17);
            this.radGaus.TabIndex = 3;
            this.radGaus.TabStop = true;
            this.radGaus.Text = "Gausian";
            this.radGaus.UseVisualStyleBackColor = true;
            // 
            // cboBlockSize
            // 
            this.cboBlockSize.FormattingEnabled = true;
            this.cboBlockSize.Items.AddRange(new object[] {
            "3",
            "5",
            "7",
            "9",
            "11",
            "13"});
            this.cboBlockSize.Location = new System.Drawing.Point(31, 79);
            this.cboBlockSize.Name = "cboBlockSize";
            this.cboBlockSize.Size = new System.Drawing.Size(52, 21);
            this.cboBlockSize.TabIndex = 4;
            // 
            // numConstant
            // 
            this.numConstant.Location = new System.Drawing.Point(31, 118);
            this.numConstant.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numConstant.Name = "numConstant";
            this.numConstant.Size = new System.Drawing.Size(52, 20);
            this.numConstant.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Block size";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Constant";
            // 
            // butPreview
            // 
            this.butPreview.Location = new System.Drawing.Point(31, 226);
            this.butPreview.Name = "butPreview";
            this.butPreview.Size = new System.Drawing.Size(75, 23);
            this.butPreview.TabIndex = 8;
            this.butPreview.Text = "Preview";
            this.butPreview.UseVisualStyleBackColor = true;
            this.butPreview.Visible = false;
            this.butPreview.Click += new System.EventHandler(this.butPreview_Click);
            // 
            // chkToggleImage
            // 
            this.chkToggleImage.AutoSize = true;
            this.chkToggleImage.Location = new System.Drawing.Point(31, 195);
            this.chkToggleImage.Name = "chkToggleImage";
            this.chkToggleImage.Size = new System.Drawing.Size(90, 17);
            this.chkToggleImage.TabIndex = 9;
            this.chkToggleImage.Text = "Toggle image";
            this.chkToggleImage.UseVisualStyleBackColor = true;
            this.chkToggleImage.Visible = false;
            this.chkToggleImage.Click += new System.EventHandler(this.chkToggleImage_Click);
            // 
            // frmAdaptiveSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.chkToggleImage);
            this.Controls.Add(this.butPreview);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numConstant);
            this.Controls.Add(this.cboBlockSize);
            this.Controls.Add(this.radGaus);
            this.Controls.Add(this.radMean);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Name = "frmAdaptiveSettings";
            this.Text = "Adaptive Settings";
            this.Load += new System.EventHandler(this.frmAdaptiveSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numConstant)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butOk;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.RadioButton radMean;
        private System.Windows.Forms.RadioButton radGaus;
        private System.Windows.Forms.ComboBox cboBlockSize;
        private System.Windows.Forms.NumericUpDown numConstant;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button butPreview;
        private System.Windows.Forms.CheckBox chkToggleImage;
    }
}