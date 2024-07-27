using FileHelperAPI;
using RvInstanceAPI;
using DatFileDetailAPI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Runtime.CompilerServices;

namespace DatWatcherAPI
{
    public class DatWatcherCore
    {

        static FileSystemWatcher[] watchers;

        FileHelperCore fhApi = new FileHelperCore();
        DatFileDetailCore dfdApi = new DatFileDetailCore();

        List<RvInstance> rvInstanceList;

        public DatWatcherCore() { }


        public List<RvInstance> GetAllRvInstanceToMonitor()
        {
            RvInstanceCore Ri = new RvInstanceCore();

            var FoldersToMonitor = Ri.GetAllActiveRvInstances();


            return FoldersToMonitor;

        }

        public FileHelperAPI.DatFileDetail GetFileExtendedInfo(string fullFilePath)
        {
            FileHelperCore fh = new FileHelperCore();

            var fullDetail = fh.GetDatDetail(fullFilePath);

            return fullDetail;
        }

        public object ProcessFile(string a)
        {

            throw new NotImplementedException();
        }

        public void StartDatWatcher()
        {
            //Get Folders to monitoe
            rvInstanceList = GetAllRvInstanceToMonitor();

            watchers = new FileSystemWatcher[rvInstanceList.Max(r => r.Id)];

            System.Timers.Timer timer = new System.Timers.Timer(5000); // Set interval to 5000ms (5 seconds)
            timer.Elapsed += CheckDrives; 
            timer.Start();
            
        }

        private void CheckDrives(object sender, ElapsedEventArgs e)
        {

            foreach (RvInstance r in rvInstanceList)
            {
                if (r.DatWatch == true)
                {
                    //todo: check drive exists
                    if (Directory.Exists(r.DatRootLocation))
                    {
                        AddFolderToMonitor(r.Id, r.DatRootLocation);
                    }
                    else
                    {
                        RemoveFolderMonitor(r.Id, r.DatRootLocation);
                    }
                }
            }
        }

        private void RemoveFolderMonitor(int id, string datRootLocation)
        {
            if (watchers[id] != null && watchers[id].EnableRaisingEvents)
            {
                watchers[id].EnableRaisingEvents = false;
                Console.WriteLine($"Drive {Path.GetPathRoot(datRootLocation)} is not available. Watcher is turned off.");
            }
        }

        private void AddFolderToMonitor(int id, string datRootLocation)
        {
            if (watchers[id] == null)
            { 
                watchers[id] = new FileSystemWatcher();
                watchers[id].Path = datRootLocation;
                watchers[id].IncludeSubdirectories = true;
                watchers[id].NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                //watchers[id].Changed += (sender, args) => OnChanged(id, args);
                watchers[id].Created += (sender, args) => OnChanged(id, args);
                watchers[id].Deleted += (sender, args) => OnDeleted(id, args);
                //watchers[id].Deleted += (sender, args) => OnChanged(id, args);
                //watchers[id].Renamed += OnRenamed;
            }

            if (!watchers[id].EnableRaisingEvents)
            {
                watchers[id].EnableRaisingEvents = true;
                Console.WriteLine($"Drive {Path.GetPathRoot(datRootLocation)} is now available. Watcher is turned on.");
            }
        }

        private void OnDeleted(int id, FileSystemEventArgs e)
        {
            this.RevokeDatFileDetail(e.FullPath);
        }

        private void OnChanged(int id, FileSystemEventArgs e)
        {
            this.AddNewFileDetail(id, e.FullPath);            

            //_eventLog1.WriteEntry($"File: {e.FullPath} {e.ChangeType}", EventLogEntryType.Information, 0);
            //WriteToFile($"File: {e.FullPath} {e.ChangeType}");
        }

        private void AddNewFileDetail(int id,string filePath)
        {
            if (File.Exists(filePath))
            {

                var fileDetail = fhApi.GetDatDetail(filePath);

                DatFileDetailAPI.DatFileDetail dfd = new DatFileDetailAPI.DatFileDetail();

                dfd.FullFilePath = filePath;
                dfd.DatName = fileDetail.DatName;
                dfd.Available = fileDetail.Available;
                dfd.MD5Hash = fileDetail.MD5Hash;
                dfd.LocationId = id; //need to retrieve
                dfd.CRC32 = fileDetail.CRC32;
                dfd.CreationTime = fileDetail.CreationTime;
                dfd.LastAccessTime = fileDetail.LastAccessTime;
                dfd.LastCheckedTime = fileDetail.LastCheckedTime;
                dfd.LastWriteTime = fileDetail.LastWriteTime;
                dfd.SHA256 = fileDetail.SHA256;
                dfd.Size = fileDetail.Size;

                dfdApi.AddNewDatFileDetail(dfd);
            }
        }

        private void RevokeDatFileDetail(string filePath)
        {
           dfdApi.RevokeDatFileDetail(filePath);
        }
    }
}
