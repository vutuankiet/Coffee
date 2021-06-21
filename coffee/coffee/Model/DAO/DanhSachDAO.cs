using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using coffee.Model.EF;
using coffee.Model.DAO;

namespace coffee.Model.DAO
{
    public class DanhSachDAO : BaseDAO
    {
        public List<DanhSach> GetAll()
        {
            return db_.DanhSaches.ToList();
        }

        public List<DanhSach> GetByKeyword(string keyword)
        {
            return db_.DanhSaches.Where(t => t.idDanhSach == keyword || t.TenThucDon.Contains(keyword)).ToList();
        }

        public DanhSach GetSingleByID(string IdDanhSach)
        {
            return db_.DanhSaches.Where(t => t.idDanhSach == IdDanhSach).FirstOrDefault();
        }

        public bool Add(DanhSach info)
        {
            try
            {
                db_.DanhSaches.Add(info);

                db_.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        public bool Edit(DanhSach info)
        {
            try
            {
                var info0 = GetSingleByID(info.idDanhSach);

                if (info0 != null)
                {
                    info0.TenThucDon = info.TenThucDon;

                    db_.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        public bool Delete(DanhSach info)
        {
            try
            {
                var info0 = GetSingleByID(info.idDanhSach);

                if (info0 != null)
                {
                    db_.DanhSaches.Remove(info0);

                    db_.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        public bool Delete(string IdDanhSach)
        {
            try
            {
                var info0 = GetSingleByID(IdDanhSach);
                if (info0 != null)
                {
                    db_.DanhSaches.Remove(info0);

                    db_.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }
    }
}

