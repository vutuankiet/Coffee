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

namespace coffee.Presenstation.UIThucDon
{
    public partial class ucThucDon : UserControl
    {
        public ucThucDon()
        {
            InitializeComponent();
        }

        private void ucThucDon_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            LoadData();
        }
        private void LoadData()
        {
            ThucDonDAO dao = new ThucDonDAO();
            bdgvThucDon.DataSource = dao.GetAll();
        }

        private void bbtnSearch_Click(object sender, EventArgs e)
        {
            ThucDonDAO dao = new ThucDonDAO();
            bdgvThucDon.DataSource = dao.GetByKeyword(btxtKeyword.Text.Trim());
        }

        private void bbtnAdd_Click(object sender, EventArgs e)
        {
            frmThucDon frm = new frmThucDon();
            frm.IsAdd = true;
            frm.ShowDialog();

            if (frm.Result)
            {
                LoadData();
            }
        }

        private void bbtnEdit_Click(object sender, EventArgs e)
        {
            string IdThucDon = bdgvThucDon.CurrentRow.Cells["idThucDon"].Value.ToString();

            frmThucDon frm = new frmThucDon();
            frm.IsAdd = false;
            frm.idThucDon = IdThucDon;
            frm.ShowDialog();

            if (frm.Result)
            {
                LoadData();
            }
        }

        private void bbtnDelete_Click(object sender, EventArgs e)
        {
            string IdThucDon = bdgvThucDon.CurrentRow.Cells["idThucDon"].Value.ToString();

            ThucDonDAO dao = new ThucDonDAO();

            if (dao.Delete(IdThucDon))
            {
                MessageBox.Show("Xoa thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
            }
            else
            {
                MessageBox.Show("Xoa that bai!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bdgvThucDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
