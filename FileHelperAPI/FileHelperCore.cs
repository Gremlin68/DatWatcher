using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHelperAPI
{
    public class FileHelperCore
    {
        private readonly FileHelperEntities db;

        public FileHelperCore() { 
            db = new FileHelperEntities();        
        }

        public DatFileDetail GetDatDetail(string filePath)
        {
            var fullDetail = new FileInfoExtended(filePath) { Dfd = { LocationId = 0 } };
            return fullDetail.Dfd;
        }

    }
}
