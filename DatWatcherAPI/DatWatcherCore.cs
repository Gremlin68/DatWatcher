using FileHelperAPI;
using RvInstanceAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatWatcherAPI
{
    public class DatWatcherCore
    {
        public DatWatcherCore() { }

        public List<RvInstance> GetAllRvInstanceToMonitor()
        {
            RvInstanceCore Ri = new RvInstanceCore();

            var FoldersToMonitor = Ri.GetAllActiveRvInstances();


            return FoldersToMonitor;

        }

        public DatFileDetail GetFileExtendedInfo(string fullFilePath)
        {
            FileHelperCore fh = new FileHelperCore();

            var fullDetail = fh.GetDatDetail(fullFilePath);

            return fullDetail;
        }

        public List<DatFileDetail> GetFolderFileExtendedInfo(string a)
        {
            List<DatFileDetail> resultList = new List<DatFileDetail>();

            

            
        }
    }
}
