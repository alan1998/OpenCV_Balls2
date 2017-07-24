using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace FormsApp
{
    using static CImageProc;
    public partial class frmAdaptiveSettings : Form
    {
        public AdaptiveParams settings = new AdaptiveParams();
        private int nImage = -1;
        private int nTempImage = -1;
        PictureBox picBox = null;

        public int PreviewImage
        {
            set { nImage = value; }
            get { return nImage; }
        }

        public PictureBox PicDisplay
        {
            set { picBox = value; }
        }
        public frmAdaptiveSettings()
        {
            InitializeComponent();
        }

        private void frmAdaptiveSettings_Load(object sender, EventArgs e)
        {
            this.cboBlockSize.Text = settings.nBlockSize.ToString();
            this.radGaus.Checked = (settings.bMean != true);
            this.radMean.Checked = (settings.bMean == true);
            this.numConstant.Value = settings.nConst;
            if (nImage > 0)
            {
                butPreview.Visible = true;
                chkToggleImage.Visible = true;
                chkToggleImage.Enabled = false;
            }

        }

        private void GetSettings()
        {
            settings.nBlockSize = Convert.ToInt16(cboBlockSize.Text);
            settings.nConst = Convert.ToInt16(numConstant.Value);
            settings.bMean = radMean.Checked;
        }
        private void butOk_Click(object sender, EventArgs e)
        {
            GetSettings();
            if(nImage > 0)
            {
                if(nTempImage > 0)
                {
                    FreeImage(nImage);
                    nImage = nTempImage;
                }
            }
        }

        private void butPreview_Click(object sender, EventArgs e)
        {
            // Apply parameters to preview image if there is 1
            
            if (nImage > 0)
            {
                GetSettings();
                if (nTempImage > 0)
                    FreeImage(nTempImage);
                int nType = 0;
                if (settings.bMean != true)
                    nType = 1;
                nTempImage = AdaptiveThreshold(nImage, 255, nType, 1, settings.nBlockSize, settings.nConst);
                if(picBox != null)
                {
                    Image img = Image.FromHbitmap(GetHBmp(nTempImage));
                    picBox.Image = img;
                }
                chkToggleImage.Enabled = true;
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            if (nTempImage > 0)
                FreeImage(nTempImage);
        }

        private void chkToggleImage_Click(object sender, EventArgs e)
        {
            Image img;
            if (chkToggleImage.Checked)
                img = Image.FromHbitmap(GetHBmp(nImage));
            else
                img = Image.FromHbitmap(GetHBmp(nTempImage));
            picBox.Image = img;
        }
    }

    public class AdaptiveParams
    {
        public int nBlockSize = 7;
        public int nConst = -8;
        public bool bMean = true;
    }

}
