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
    public partial class frmThucDon : Form
    {
        private bool isAdd_ = true;
        public frmThucDon()
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

        private string IdThucDon_ = "";

        public string idThucDon
        {
            set
            {
                IdThucDon_ = value;
            }
        }

        private void frmThucDon_Load(object sender, EventArgs e)
        {
            if (!isAdd_)
            {
                ThucDonDAO dao = new ThucDonDAO();

                var info = dao.GetSingleByID(IdThucDon_);

                if (info != null)
                {
                    btxtIdThucDon.Text = info.idThucDon.Trim();
                    btxtTenThucDon.Text = info.TenThucDon.Trim();
                    btxtGiaTien.Text = info.GiaTien.Trim();
                    //btxtDanhMuc.Text = info.DanhSach.Trim();
                    //btxtHoaDon.Text = info.HoaDon.Trim();
                }
                else
                {
                    this.Close();
                }
            }
        }
        private ThucDon InitThucDon()
        {
            ThucDon thucDon = new ThucDon();

            thucDon.idThucDon = btxtIdThucDon.Text.Trim();
            thucDon.TenThucDon = btxtTenThucDon.Text.Trim();
            thucDon.GiaTien = btxtGiaTien.Text.Trim();
            //thucDon.DanhSach = btxtDanhMuc.Text.Trim();
            //thucDon.HoaDon = btxtHoaDon.Text.Trim();

            return thucDon;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ThucDonDAO dao = new ThucDonDAO();

            ThucDon info = InitThucDon();

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

        private void bunifuLabel4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel5_Click(object sender, EventArgs e)
        {

        }
    }
}
