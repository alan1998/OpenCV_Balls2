namespace FormsApp
{
    partial class frmProcessSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboBlurSize = new System.Windows.Forms.ComboBox();
            this.butOk = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.radioButtonMedian = new System.Windows.Forms.RadioButton();
            this.radioButtonMean = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxInRad = new System.Windows.Forms.TextBox();
            this.textBoxOutRad = new System.Windows.Forms.TextBox();
            this.textBoxStepSize = new System.Windows.Forms.TextBox();
            this.textBoxLineBlur = new System.Windows.Forms.TextBox();
            this.textBoxMinCor = new System.Windows.Forms.TextBox();
            this.textBoxMaxDev = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Blur - size";
            // 
            // cboBlurSize
            // 
            this.cboBlurSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBlurSize.FormattingEnabled = true;
            this.cboBlurSize.Items.AddRange(new object[] {
            "3",
            "5",
            "7",
            "9",
            "11"});
            this.cboBlurSize.Location = new System.Drawing.Point(135, 13);
            this.cboBlurSize.Name = "cboBlurSize";
            this.cboBlurSize.Size = new System.Drawing.Size(74, 21);
            this.cboBlurSize.TabIndex = 1;
            // 
            // butOk
            // 
            this.butOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.butOk.Location = new System.Drawing.Point(116, 289);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(75, 23);
            this.butOk.TabIndex = 2;
            this.butOk.Text = "Ok";
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Location = new System.Drawing.Point(198, 289);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 3;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            // 
            // radioButtonMedian
            // 
            this.radioButtonMedian.AutoSize = true;
            this.radioButtonMedian.Checked = true;
            this.radioButtonMedian.Location = new System.Drawing.Point(15, 49);
            this.radioButtonMedian.Name = "radioButtonMedian";
            this.radioButtonMedian.Size = new System.Drawing.Size(60, 17);
            this.radioButtonMedian.TabIndex = 4;
            this.radioButtonMedian.TabStop = true;
            this.radioButtonMedian.Text = "Median";
            this.radioButtonMedian.UseVisualStyleBackColor = true;
            // 
            // radioButtonMean
            // 
            this.radioButtonMean.AutoSize = true;
            this.radioButtonMean.Location = new System.Drawing.Point(15, 72);
            this.radioButtonMean.Name = "radioButtonMean";
            this.radioButtonMean.Size = new System.Drawing.Size(52, 17);
            this.radioButtonMean.TabIndex = 5;
            this.radioButtonMean.TabStop = true;
            this.radioButtonMean.Text = "Mean";
            this.radioButtonMean.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxMaxDev);
            this.groupBox1.Controls.Add(this.textBoxMinCor);
            this.groupBox1.Controls.Add(this.textBoxLineBlur);
            this.groupBox1.Controls.Add(this.textBoxStepSize);
            this.groupBox1.Controls.Add(this.textBoxOutRad);
            this.groupBox1.Controls.Add(this.textBoxInRad);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(10, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 164);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Circle Fit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Inside radius fraction";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Outside radius fraction";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Step size (deg)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Max Std Dev";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Line blur width";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Min Correlation";
            // 
            // textBoxInRad
            // 
            this.textBoxInRad.Location = new System.Drawing.Point(152, 15);
            this.textBoxInRad.Name = "textBoxInRad";
            this.textBoxInRad.Size = new System.Drawing.Size(72, 20);
            this.textBoxInRad.TabIndex = 6;
            // 
            // textBoxOutRad
            // 
            this.textBoxOutRad.Location = new System.Drawing.Point(152, 41);
            this.textBoxOutRad.Name = "textBoxOutRad";
            this.textBoxOutRad.Size = new System.Drawing.Size(72, 20);
            this.textBoxOutRad.TabIndex = 7;
            // 
            // textBoxStepSize
            // 
            this.textBoxStepSize.Location = new System.Drawing.Point(152, 64);
            this.textBoxStepSize.Name = "textBoxStepSize";
            this.textBoxStepSize.Size = new System.Drawing.Size(73, 20);
            this.textBoxStepSize.TabIndex = 8;
            // 
            // textBoxLineBlur
            // 
            this.textBoxLineBlur.Location = new System.Drawing.Point(152, 90);
            this.textBoxLineBlur.Name = "textBoxLineBlur";
            this.textBoxLineBlur.Size = new System.Drawing.Size(72, 20);
            this.textBoxLineBlur.TabIndex = 9;
            // 
            // textBoxMinCor
            // 
            this.textBoxMinCor.Location = new System.Drawing.Point(152, 116);
            this.textBoxMinCor.Name = "textBoxMinCor";
            this.textBoxMinCor.Size = new System.Drawing.Size(72, 20);
            this.textBoxMinCor.TabIndex = 10;
            // 
            // textBoxMaxDev
            // 
            this.textBoxMaxDev.Location = new System.Drawing.Point(152, 142);
            this.textBoxMaxDev.Name = "textBoxMaxDev";
            this.textBoxMaxDev.Size = new System.Drawing.Size(72, 20);
            this.textBoxMaxDev.TabIndex = 11;
            // 
            // frmProcessSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 324);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.radioButtonMean);
            this.Controls.Add(this.radioButtonMedian);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.cboBlurSize);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmProcessSettings";
            this.Text = "frmProcessSettings";
            this.Load += new System.EventHandler(this.frmProcessSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboBlurSize;
        private System.Windows.Forms.Button butOk;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.RadioButton radioButtonMedian;
        private System.Windows.Forms.RadioButton radioButtonMean;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxMaxDev;
        private System.Windows.Forms.TextBox textBoxMinCor;
        private System.Windows.Forms.TextBox textBoxLineBlur;
        private System.Windows.Forms.TextBox textBoxStepSize;
        private System.Windows.Forms.TextBox textBoxOutRad;
        private System.Windows.Forms.TextBox textBoxInRad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}