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
    public class ThucDonDAO : BaseDAO
    {
        public List<ThucDon> GetAll()
        {
            return db_.ThucDons.ToList();
        }

        public List<ThucDon> GetByKeyword(string keyword)
        {
            return db_.ThucDons.Where(t => t.idThucDon == keyword || t.TenThucDon.Contains(keyword)).ToList();
        }
        public ThucDon GetSingleByID(string IdThucDon)
        {
            return db_.ThucDons.Where(t => t.idThucDon == IdThucDon).FirstOrDefault();
        }

        public bool Add(ThucDon info)
        {
            try
            {
                db_.ThucDons.Add(info);

                db_.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        public bool Edit(ThucDon info)
        {
            try
            {
                var info0 = GetSingleByID(info.idThucDon);

                if (info0 != null)
                {
                    info0.TenThucDon = info.TenThucDon;
                    info0.GiaTien = info.GiaTien;
                    //info0.DanhSach = info.DanhSach;
                    //info0.HoaDon = info.HoaDon;

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

        public bool Delete(ThucDon info)
        {
            try
            {
                var info0 = GetSingleByID(info.idThucDon);

                if (info0 != null)
                {
                    db_.ThucDons.Remove(info0);

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

        public bool Delete(string IdThucDon)
        {
            try
            {
                var info0 = GetSingleByID(IdThucDon);
                if (info0 != null)
                {
                    db_.ThucDons.Remove(info0);

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
