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

namespace coffee.Presenstation.UIDanhSach
{
    public partial class ucDanhSach : UserControl
    {
        public ucDanhSach()
        {
            InitializeComponent();
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void ucDanhSach_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            LoadData();
        }
        private void LoadData()
        {
            DanhSachDAO dao = new DanhSachDAO();
            bdgvDanhSach.DataSource = dao.GetAll();
        }

        private void bdgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bbtnSearch_Click(object sender, EventArgs e)
        {
            DanhSachDAO dao = new DanhSachDAO();
            bdgvDanhSach.DataSource = dao.GetByKeyword(btxtKeyword.Text.Trim());
        }

        private void bbtnAdd_Click(object sender, EventArgs e)
        {
            frmDanhSach frm = new frmDanhSach();
            frm.IsAdd = true;
            frm.ShowDialog();

            if (frm.Result)
            {
                LoadData();
            }
        }

        private void bbtnEdit_Click(object sender, EventArgs e)
        {
            string IdDanhSach = bdgvDanhSach.CurrentRow.Cells["idDanhSach"].Value.ToString();

            frmDanhSach frm = new frmDanhSach();
            frm.IsAdd = false;
            frm.idDanhSach = IdDanhSach;
            frm.ShowDialog();

            if (frm.Result)
            {
                LoadData();
            }
        }

        private void bbtnDelete_Click(object sender, EventArgs e)
        {
            string IdDanhSach = bdgvDanhSach.CurrentRow.Cells["idDanhSach"].Value.ToString();

            BanDAO dao = new BanDAO();

            if (dao.Delete(IdDanhSach))
            {
                MessageBox.Show("Xoa thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
            }
            else
            {
                MessageBox.Show("Xoa that bai!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
