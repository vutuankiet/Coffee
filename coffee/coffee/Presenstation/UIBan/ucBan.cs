using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using coffee.Model.DAO;
using coffee.Model.EF;

namespace coffee.Presenstation.UIBan
{
    public partial class ucBan : UserControl
    {
        public ucBan()
        {
            InitializeComponent();
        }

        private void ucBan_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            LoadData();
        }
        private void LoadData()
        {
            BanDAO dao = new BanDAO();
            bdgvBan.DataSource = dao.GetAll();
        }

        private void bbtnSearch_Click(object sender, EventArgs e)
        {
            BanDAO dao = new BanDAO();
            bdgvBan.DataSource = dao.GetByKeyword(btxtKeyword.Text.Trim());
        }

        private void bbtnAdd_Click(object sender, EventArgs e)
        {
            frmBan frm = new frmBan();
            frm.IsAdd = true;
            frm.ShowDialog();

            if (frm.Result)
            {
                LoadData();
            }
        }

        private void bbtnEdit_Click(object sender, EventArgs e)
        {
            string IdBan = bdgvBan.CurrentRow.Cells["idBan"].Value.ToString();

            frmBan frm = new frmBan();
            frm.IsAdd = false;
            frm.idBan = IdBan;
            frm.ShowDialog();

            if (frm.Result)
            {
                LoadData();
            }
        }

        private void bbtnDelete_Click(object sender, EventArgs e)
        {
            string IdBan = bdgvBan.CurrentRow.Cells["idBan"].Value.ToString();

            BanDAO dao = new BanDAO();

            if (dao.Delete(IdBan))
            {
                MessageBox.Show("Xoa thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
            }
            else
            {
                MessageBox.Show("Xoa that bai!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bdgvBan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}
