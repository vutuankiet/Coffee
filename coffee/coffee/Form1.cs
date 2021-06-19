using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coffee
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.ActiveControl = bunifuButton1;
            this.Dock = DockStyle.Fill;
            bunifuDropdown1.SelectedIndex = 0;
        }

        private void bunifuToggleSwitch3_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs e)
        {

        }

        private void bunifuToggleSwitch1_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs e)
        {
            List<Color> bunifuColors = new List<Color>();
            if (e.Checked == true)
            {
                if (bunifuColors.Count > 0)
                {
                    bunifuColors.Clear();
                    bunifuColors.Add(Color.FromArgb(210, 72, 169, 248));
                }
                else
                {
                    bunifuColors.Add(Color.FromArgb(210, 72, 169, 248));
                }
                bunifuBarChart1.BackgroundColor = bunifuColors;
            }
            else
            {
                if (bunifuColors.Count > 0)
                {
                    bunifuColors.Clear();
                    bunifuColors.Add(Color.FromArgb(100, 170, 170, 170));
                }
                else
                {
                    bunifuColors.Add(Color.FromArgb(100, 170, 170, 170));
                }
                bunifuBarChart1.BackgroundColor = bunifuColors;
            }
        }
    }
}
