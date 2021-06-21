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
    public class BanDAO : BaseDAO
    {
        public List<Ban> GetAll()
        {
            return db_.Bans.ToList();
        }
        public List<Ban> GetByKeyword(string keyword)
        {
            return db_.Bans.Where(t => t.idBan == keyword || t.TenBan.Contains(keyword)).ToList();
        }
        public Ban GetSingleByID(string IdBan)
        {
            return db_.Bans.Where(t => t.idBan == IdBan).FirstOrDefault();
        }
        public bool Add(Ban info)
        {
            try
            {
                db_.Bans.Add(info);

                db_.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }
        public bool Edit(Ban info)
        {
            try
            {
                var info0 = GetSingleByID(info.idBan);

                if (info0 != null)
                {
                    info0.TenBan = info.TenBan;
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
        public bool Delete(string IdBan)
        {
            try
            {
                var info0 = GetSingleByID(IdBan);
                if (info0 != null)
                {
                    db_.Bans.Remove(info0);

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
