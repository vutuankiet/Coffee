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
    public partial class frmBan : Form
    {
        public frmBan()
        {
            InitializeComponent();
        }
        private bool isAdd_ = true;
        
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

        private string IdBan_;

        public string idBan
        {
            set
            {
                IdBan_ = value;
            }
        }

        private void frmBan_Load(object sender, EventArgs e)
        {
            if (!isAdd_)
            {
                BanDAO dao = new BanDAO();

                var info = dao.GetSingleByID(IdBan_);

                if (info != null)
                {
                    btxtIdBan.Text = info.idBan.Trim();
                    btxtTenBan.Text = info.TenBan.Trim();
                    btxtTrangThai.Text = info.TrangThai.Trim();
                }
                else
                {
                    this.Close();
                }
            }
        }
        private Ban InitBan()
        {
            Ban ban = new Ban();

            ban.idBan = btxtIdBan.Text.Trim();
            ban.TenBan = btxtTenBan.Text.Trim();
            ban.TrangThai = btxtTrangThai.Text.Trim();

            return ban;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BanDAO dao = new BanDAO();

            Ban info = InitBan();

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
