using DamienG.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileHelperAPI.CRC
{
    internal class CalculateHash
    {
        private string _path;


        public string CalculateSha256Hash(string fullPath)
        {
            _path = fullPath;

            if (IsFileLocked(fullPath))
            {
                Thread.Sleep(5000);
            }

            using (var stream = File.OpenRead(fullPath))
            {
                var sha = new SHA256Managed();
                var hash = sha.ComputeHash(stream);
                return BitConverter.ToString(hash).Replace("-", string.Empty);
            }
        }


        public string CalculateCrc32Hash(string fullPath)
        {
            _path = fullPath;

            if (IsFileLocked(fullPath))
            {
                Thread.Sleep(5000);
            }

            var crc32 = new Crc32();
            var hash = string.Empty;

            using (var fs = File.Open(fullPath, FileMode.Open))
            {
                foreach (var b in crc32.ComputeHash(fs)) hash += b.ToString("x2").ToLower();
            }

            return hash;
        }

        internal string CalculateMd5Hash(string fullPath)
        {
            _path = fullPath;

            if (IsFileLocked(fullPath))
            {
                Thread.Sleep(5000);
            }

            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(_path))
                {
                    var bytes = md5.ComputeHash(stream);

                    var result = new StringBuilder(bytes.Length * 2);

                    for (var i = 0; i < bytes.Length; i++)
                    {
                        result.Append(bytes[i].ToString("X2"));
                    }

                    return result.ToString();
                }
            }
        }

        protected virtual bool IsFileLocked(string fullPath)
        {
            FileStream stream = null;

            FileInfo file = new FileInfo(fullPath);

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }
    }
}
