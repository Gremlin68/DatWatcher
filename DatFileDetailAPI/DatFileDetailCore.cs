using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatFileDetailAPI
{
    public class DatFileDetailCore
    {
        private DatFileDetailEntities db;

        public DatFileDetailCore() {

            db = new DatFileDetailEntities();
        }



        //Get 

        //Update DAT File Details

        //Get Stored DatFileDetails - DatFileDetailAPI

        //Get Current File Extended Info - FileHelperAPI

        //Compare - New / Removed / Changed
        //New - Insert a Record
        //Removed - Logical Delete on Record - Update
        //Changed - Update the record

        public void RevokeDatFileDetail(string fullPath)
        {
            var dat = db.DatFileDetails.FirstOrDefault(i => (i.FullFilePath == fullPath) && i.Available == true);
            if (dat != null)
            {
                dat.LastCheckedTime = DateTime.Now;
                dat.Available = false;
                db.SaveChanges();
            }
        }

        public void AddNewDatFileDetail(DatFileDetail newDatFileDetail) {

            var result = db.DatFileDetails.FirstOrDefault(i => (i.FullFilePath == newDatFileDetail.FullFilePath) && (i.Available == true) && (i.SHA256 == newDatFileDetail.SHA256));

            if (result != null) return;

            db.DatFileDetails.Add(newDatFileDetail);
            db.SaveChanges();
        }


    }
}

