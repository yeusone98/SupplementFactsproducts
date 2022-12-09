using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    
    public class DVT
    {
        Entities db;
        public DVT()
        {
            db = Entities.CreateEntities();
        }
        public List<tb_DonViTinh> getList()
        {
            return db.tb_DonViTinh.ToList();
        }
    }
}
