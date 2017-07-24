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
    public partial class frmOtherSettings : Form
    {
        public SettingsParams settings = new SettingsParams();
        public frmOtherSettings()
        {
            InitializeComponent();
        }

        private void frmOtherSettings_Load(object sender, EventArgs e)
        {
            this.cboPyramidDown.Text = settings.nPyramidDown.ToString();
            cboMinArea.Text = settings.nMinArea.ToString();
            txtMaxAspect.Text = settings.dMaxContourAspectRaioDev.ToString();
            txtMinRadius.Text = settings.dMinContourRad.ToString();
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            settings.nPyramidDown = Convert.ToInt16(cboPyramidDown.Text);
            settings.nMinArea = Convert.ToInt16(cboMinArea.Text);
            settings.dMaxContourAspectRaioDev = Convert.ToDouble(txtMaxAspect.Text);
            settings.dMinContourRad = Convert.ToDouble(txtMinRadius.Text);
        }

        private void txtMinRadius_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboMinArea_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboPyramidDown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    public class SettingsParams
    {
        public int nPyramidDown = 4;
        public int nMinArea = 5;
        public double dMinContourRad = 3.5;   //Circle enclosing contours in reduced image
        public double dMaxContourAspectRaioDev = 0.25; // Rotated rect aspect ratio deviation from 1.0
    }
}
