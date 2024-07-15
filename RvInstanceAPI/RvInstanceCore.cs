using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RvInstanceAPI
{
    public class RvInstanceCore
    {
        private readonly RvInstanceEntities db;


        public RvInstanceCore() { 
            db = new RvInstanceEntities();        
        }

        public List<RvInstance> GetAllActiveRvInstances()
        {
            return db.RvInstances.AsNoTracking().Where(dl => dl.Active).ToList();
        }

    }
}
