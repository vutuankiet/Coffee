using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coffee.Presenstation.UIDashBoard
{
    public partial class ucDashBoard : UserControl
    {
        public ucDashBoard()
        {
            InitializeComponent();
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

        private void bunifuToggleSwitch2_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs e)
        {
            if (e.Checked == true)
            {
                bunifuLineChart2.BorderColor = Color.FromArgb(64, 24, 157);
                bunifuLineChart2.BackgroundColor = Color.FromArgb(64, 24, 157);
                bunifuLineChart2.Order = -2;
            }
            else
            {
                bunifuLineChart2.BorderColor = Color.Silver;
                bunifuLineChart2.BackgroundColor = Color.Silver;
                bunifuLineChart2.Order = 2;
            }
        }

        private void bunifuToggleSwitch3_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs e)
        {
            if (e.Checked == true)
            {
                bunifuLineChart1.BorderColor = Color.FromArgb(27, 208, 132);
                bunifuLineChart1.BackgroundColor = Color.FromArgb(27, 208, 132);
                bunifuLineChart1.Order = -2;
            }
            else
            {
                bunifuLineChart1.BorderColor = Color.Silver;
                bunifuLineChart1.BackgroundColor = Color.Silver;
                bunifuLineChart1.Order = 2;
            }
        }
    }
}
