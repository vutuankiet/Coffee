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
    public class HoaDonDAO : BaseDAO
    {
        public List<HoaDon> GetAll()
        {
            return db_.HoaDons.ToList();
        }

        public List<HoaDon> GetByKeyword(string keyword)
        {
            return db_.HoaDons.Where(t => t.idHoaDon == keyword || t.TenBan.Contains(keyword)).ToList();
        }

        public HoaDon GetSingleByID(string IdHoaDon)
        {
            return db_.HoaDons.Where(t => t.idHoaDon == IdHoaDon).FirstOrDefault();
        }

        public bool Add(HoaDon info)
        {
            try
            {
                db_.HoaDons.Add(info);

                db_.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        public bool Edit(HoaDon info)
        {
            try
            {
                var info0 = GetSingleByID(info.idHoaDon);

                if (info0 != null)
                {
                    info0.TenBan = info.TenBan;
                    info0.TenThucDon = info.TenThucDon;
                    info0.ThoiDiemDen = info.ThoiDiemDen;
                    info0.ThoiDiemRa = info.ThoiDiemRa;
                    info0.TrangThai = info.TrangThai;

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

        public bool Delete(HoaDon info)
        {
            try
            {
                var info0 = GetSingleByID(info.idHoaDon);

                if (info0 != null)
                {
                    db_.HoaDons.Remove(info0);

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

        public bool Delete(string IdHoaDon)
        {
            try
            {
                var info0 = GetSingleByID(IdHoaDon);
                if (info0 != null)
                {
                    db_.HoaDons.Remove(info0);

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
