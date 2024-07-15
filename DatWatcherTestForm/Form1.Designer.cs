namespace DatWatcherTestForm
{
    partial class btnGetFolderExtendedFileInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGetFoldersToMonitor = new System.Windows.Forms.Button();
            this.btnStartMonitor = new System.Windows.Forms.Button();
            this.btnGetExtendedFileInfo = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFolderExtendedFileInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetFoldersToMonitor
            // 
            this.btnGetFoldersToMonitor.Location = new System.Drawing.Point(12, 12);
            this.btnGetFoldersToMonitor.Name = "btnGetFoldersToMonitor";
            this.btnGetFoldersToMonitor.Size = new System.Drawing.Size(134, 51);
            this.btnGetFoldersToMonitor.TabIndex = 0;
            this.btnGetFoldersToMonitor.Text = "GetFoldersToMonitor";
            this.btnGetFoldersToMonitor.UseVisualStyleBackColor = true;
            this.btnGetFoldersToMonitor.Click += new System.EventHandler(this.btnGetFoldersToMonitor_Click);
            // 
            // btnStartMonitor
            // 
            this.btnStartMonitor.Enabled = false;
            this.btnStartMonitor.Location = new System.Drawing.Point(12, 387);
            this.btnStartMonitor.Name = "btnStartMonitor";
            this.btnStartMonitor.Size = new System.Drawing.Size(134, 51);
            this.btnStartMonitor.TabIndex = 1;
            this.btnStartMonitor.Text = "Start Monitor";
            this.btnStartMonitor.UseVisualStyleBackColor = true;
            this.btnStartMonitor.Click += new System.EventHandler(this.btnStartMonitor_Click);
            // 
            // btnGetExtendedFileInfo
            // 
            this.btnGetExtendedFileInfo.Location = new System.Drawing.Point(12, 69);
            this.btnGetExtendedFileInfo.Name = "btnGetExtendedFileInfo";
            this.btnGetExtendedFileInfo.Size = new System.Drawing.Size(134, 51);
            this.btnGetExtendedFileInfo.TabIndex = 2;
            this.btnGetExtendedFileInfo.Text = "GetExtendedFileInfo";
            this.btnGetExtendedFileInfo.UseVisualStyleBackColor = true;
            this.btnGetExtendedFileInfo.Click += new System.EventHandler(this.btnGetExtendedFileInfo_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(262, 100);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(452, 20);
            this.txtFilePath.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(152, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "FilePath (Temporary)";
            // 
            // btnFolderExtendedFileInfo
            // 
            this.btnFolderExtendedFileInfo.Location = new System.Drawing.Point(12, 126);
            this.btnFolderExtendedFileInfo.Name = "btnFolderExtendedFileInfo";
            this.btnFolderExtendedFileInfo.Size = new System.Drawing.Size(134, 51);
            this.btnFolderExtendedFileInfo.TabIndex = 5;
            this.btnFolderExtendedFileInfo.Text = "Get FolderExtendedFileInfo";
            this.btnFolderExtendedFileInfo.UseVisualStyleBackColor = true;
            this.btnFolderExtendedFileInfo.Click += new System.EventHandler(this.btnFolderExtendedFileInfo_Click);
            // 
            // btnGetFolderExtendedFileInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnFolderExtendedFileInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnGetExtendedFileInfo);
            this.Controls.Add(this.btnStartMonitor);
            this.Controls.Add(this.btnGetFoldersToMonitor);
            this.Name = "btnGetFolderExtendedFileInfo";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetFoldersToMonitor;
        private System.Windows.Forms.Button btnStartMonitor;
        private System.Windows.Forms.Button btnGetExtendedFileInfo;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFolderExtendedFileInfo;
    }
}

