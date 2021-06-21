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
    public partial class frmDanhSach : Form
    {
        private bool isAdd_ = true;
        public frmDanhSach()
        {
            InitializeComponent();
        }
        public bool IsAdd
        {
            set
            {
                isAdd_ = value;
            }
        }

        private bool result_;

        public bool Result
        {
            get
            {
                return result_;
            }
        }
        private string IdDanhSach_;

        public string idDanhSach
        {
            set
            {
                IdDanhSach_ = value;
            }
        }

        private void frmDanhSach_Load(object sender, EventArgs e)
        {
            if (!isAdd_)
            {
                DanhSachDAO dao = new DanhSachDAO();

                var info = dao.GetSingleByID(IdDanhSach_);

                if (info != null)
                {
                    btxtIdDanhSach.Text = info.idDanhSach.Trim();
                    btxtTenThucDon.Text = info.TenThucDon.Trim();
                }
                else
                {
                    this.Close();
                }
            }
        }
        private DanhSach InitDanhSach()
        {
            DanhSach danhSach = new DanhSach();

            danhSach.idDanhSach = btxtIdDanhSach.Text.Trim();
            danhSach.TenThucDon = btxtTenThucDon.Text.Trim();

            return danhSach;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DanhSachDAO dao = new DanhSachDAO();

            DanhSach info = InitDanhSach();

            if (isAdd_)
            {
                if (dao.Add(info))
                {
                    MessageBox.Show("Them thang cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    result_ = true;

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Them that bai!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (dao.Edit(info))
                {
                    MessageBox.Show("Them thang cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    result_ = true;

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Them that bai!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
