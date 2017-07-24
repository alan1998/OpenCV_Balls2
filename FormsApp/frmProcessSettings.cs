using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsApp
{
    public partial class frmProcessSettings : Form
    {
        public SettingsProcess settings = new SettingsProcess();
        public SettingsCircle setCircle = new SettingsCircle();
        public frmProcessSettings()
        {
            InitializeComponent();
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            settings.nBlurSize = Convert.ToInt16(cboBlurSize.Text);
            if (radioButtonMean.Checked == true)
                settings.nSmoothType = 0;
            if (radioButtonMedian.Checked == true)
                settings.nSmoothType = 1;
            setCircle.dInRad = Convert.ToDouble(this.textBoxInRad);
            setCircle.dOutRad = Convert.ToDouble(this.textBoxOutRad);
            setCircle.nLineBlur = Convert.ToInt16(this.textBoxLineBlur);
            setCircle.dStdDevReject = Convert.ToDouble(this.textBoxMaxDev);
            setCircle.dMinCor = Convert.ToDouble(this.textBoxMinCor);
            setCircle.dStepDeg = Convert.ToDouble(this.textBoxStepSize);
        }

        private void frmProcessSettings_Load(object sender, EventArgs e)
        {
            cboBlurSize.Text = settings.nBlurSize.ToString();
            if (settings.nSmoothType == 0)
                radioButtonMean.Checked = true;
            else
                radioButtonMean.Checked = false;
            this.textBoxInRad.Text = setCircle.dInRad.ToString();
            this.textBoxOutRad.Text = setCircle.dOutRad.ToString();
            this.textBoxLineBlur.Text = setCircle.nLineBlur.ToString();
            this.textBoxMaxDev.Text = setCircle.dStdDevReject.ToString();
            this.textBoxMinCor.Text = setCircle.dMinCor.ToString();
            this.textBoxStepSize.Text = setCircle.dStepDeg.ToString();
        }
    }

    public class SettingsProcess
    {
        // Blur kernel size
        public int nBlurSize = 7;
        public int nSmoothType = 0;
        // Canny filter parameters
        public double dTh1 = 1050;
        public double dTh2 = 550;
        public int nAppertureSize = 5;
        public int nMethod = 0;
    }

    public class SettingsCircle
    {
        //Fraction of rough circle radius to use for sample line
        public double dInRad = 0.85;
        public double dOutRad = 1.48;
        // Line sample frequency
        public double dStepDeg = 2;
        public int nLineBlur = 7;
        public double dMinCor = 0.96;
        //Cicle  fit
        public double dStdDevReject = 0.75;
    }
}
