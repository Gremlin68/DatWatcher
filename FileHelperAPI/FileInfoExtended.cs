using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHelperAPI
{
    public class FileInfoExtended
    {
        private int _errorCount;

        public FileInfoExtended(string filePath)
        {
            try
            {
                // Get the current time
                var lastUpdatedTime = DateTime.Now;

                //check the folder the file is in is available, if not move onto next file
                if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(filePath)))
                {
                    //Dfd.Available = false;
                    return;
                }


                //Check FileExists, if not move on to the next file
                if (!System.IO.File.Exists(filePath))
                {
                    Dfd.Available = false;
                    return;
                }

                // Create a FileInfo object for the given file path
                var fi = new System.IO.FileInfo(filePath);

                // Populate the DatFileDetail object with information from the FileInfo object
                Dfd.CreationTime = fi.CreationTime;
                Dfd.LastWriteTime = fi.LastWriteTime;
                Dfd.LastAccessTime = fi.LastAccessTime;
                Dfd.FullFilePath = fi.FullName;
                Dfd.DatName = fi.Name;
                Dfd.LastCheckedTime = lastUpdatedTime;
                Dfd.Size = fi.Length;
                Dfd.Available = true;

                // Create a CalculateHash object
                var hash = new CRC.CalculateHash();

                // Calculate and store the SHA256, MD5, and CRC32 hashes of the file
                Dfd.SHA256 = hash.CalculateSha256Hash(filePath);
                Dfd.MD5Hash = hash.CalculateMd5Hash(filePath);
                Dfd.CRC32 = hash.CalculateCrc32Hash(filePath);

                Dfd.LocationId = 0;
            }
            catch (Exception ex)
            {
                _errorCount++;
                Debug.Print($"Error Count: {_errorCount} {ex.Message}");

                // If the error count is less than 4, rethrow the exception to be handled by the caller
                if (_errorCount < 4)
                {
                    throw;
                }
            }
        }

        public DatFileDetail Dfd { get; set; } = new DatFileDetail();
    }
}
