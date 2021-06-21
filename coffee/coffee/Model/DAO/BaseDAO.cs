using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coffee.Model.DAO
{
    public class BaseDAO
    {
        protected Model.EF.QuanLyCaPheEntities db_;

        public BaseDAO()
        {
            db_ = new EF.QuanLyCaPheEntities();
        }
    }
}
