using DatWatcherAPI;
using RvInstanceAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatWatcherTestForm
{
    public partial class btnGetFolderExtendedFileInfo : Form
    {
        public btnGetFolderExtendedFileInfo()
        {
            InitializeComponent();
        }

        private void btnGetFoldersToMonitor_Click(object sender, EventArgs e)
        {
            //Connect to aggregate API
            DatWatcherCore dw = new DatWatcherCore();

            var FoldersToMonitor = dw.GetAllRvInstanceToMonitor().Where(a => a.DatWatch == true);

        }

        private void btnStartMonitor_Click(object sender, EventArgs e)
        {


            // Get Folders to Monitor

            //Loop

            //Set-up Monitor

            //End Loop


            // Events - File Watcher

            //Get FileInfo
            //Compare Aginst Stored
            //Revoke
            //Add New



        }

        private void btnGetExtendedFileInfo_Click(object sender, EventArgs e)
        {
            var a = @"Q:\DATFiles\Master\ADVANsCEne\ADVANsCEne_NDS_Release_Dat_7256.dat";

            DatWatcherCore dw = new DatWatcherCore();
            var result = dw.GetFileExtendedInfo(a);


        }

        private void btnFolderExtendedFileInfo_Click(object sender, EventArgs e)
        {
            var a = @"Q:\DATFiles\Master\ADVANsCEne\";
            DatWatcherCore dw = new DatWatcherCore();
            var result = dw.GetFolderFileExtendedInfo(a);
        }
    }
}
