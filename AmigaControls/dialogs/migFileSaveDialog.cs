﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static migControls.migListView;

namespace migControls
{
    public partial class migFileSaveDialog : migform
    {

        public delegate void folderSelectEventHandler(object sender, migFolderDialogSelect e);
        public event folderSelectEventHandler onFolderSelected;

        public delegate void folderTextChangeEventHandler(object sender, migFolderDialogTextChange e);
        public event folderSelectEventHandler onFolderPathTextChanged;

        public delegate void fileSelectSaveEventHandler(object sender, migFileSaveSelect e);
        public event fileSelectSaveEventHandler onFileSelected;

        public string currentPath { get; set; }

        public string selectedPath { get; set; }

        public string selectedFile { get; set; }
        protected override void OnCreateControl()
        {


            base.OnCreateControl();
        }
        public migFileSaveDialog()
        {
            InitializeComponent();
        }

        private void migFileSaveDialog_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            var dl = DriveInfo.GetDrives().ToList();
            int offsetLeft = 0;
            int offsetTop = 0;



            List<DriveInfo> dlist = new List<DriveInfo>();


            foreach (DriveInfo d in dl)
            {
                dlist.Add(d);

            }


            foreach (DriveInfo d in dlist)
            {
                migButton mbD = new migButton();
                mbD.Text = d.Name;
                mbD.Click += MbD_Click;
                if ((offsetLeft + mbD.Width - 50) >= panel1.Width)
                {
                    offsetLeft = 0; offsetTop += mbD.Height + 5;
                }

                mbD.Left = offsetLeft;
                mbD.Top = offsetTop;
                mbD.Tag = d.Name;

                offsetLeft += mbD.Width + 20;



                panel1.Controls.Add(mbD);
            }

            if (String.IsNullOrEmpty(currentPath))
            {

                changeDir(dlist.Where(p => p.IsReady).First().Name);
            }
            this.Height += (int)(offsetTop * 0.75);
            this.Visible = true;

        }


        public void updateDirs()
        {
            if (!string.IsNullOrEmpty(currentPath))
            {
                migListView1.Items = new List<migListViewItem>();
                migListView1.OnLabelClicked -= MigListView1_OnLabelClicked;
                DirectoryInfo dinf = new DirectoryInfo(currentPath);

                mtbDrawer.EditBox.KeyDown += (sender, e) =>
                {
                    if ((onFolderPathTextChanged != null) && e.KeyCode == Keys.Enter)
                    {
                        onFolderPathTextChanged(sender, new migFolderDialogSelect(mtbDrawer.EditBox.Text));
                    }
                };

                mtbDrawer.ebText = currentPath.Replace("\\\\", "\\");
                mtbDrawer.EditBox.SelectionStart = mtbDrawer.EditBox.Text.Length;
                mtbDrawer.EditBox.ScrollToCaret();
                try
                {


                    if (dinf.GetDirectories() != null)
                    {

                        if (dinf.Parent != null)
                        {
                            migListView1.Items.Add(new migListViewItem("../Parent", "PARENT"));

                        }
                        foreach (DirectoryInfo d in dinf.GetDirectories())
                        {
                            migListView1.Items.Add(new migListViewItem(d.Name, "DIR"));
                        }

                    }

                    if (dinf.GetFiles() != null)
                    {
                        foreach (FileInfo f in dinf.GetFiles())
                        {
                            migListView1.Items.Add(new migListViewItem(f.Name, "FILE", f.FullName));

                        }
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    parentDir();
                    migListView1.OnLabelClicked -= MigListView1_OnLabelClicked;

                    MessageBox.Show("Not allowed");

                }
            }

            this.onFolderPathTextChanged += MigFolderDialog_onFolderPathTextChanged;
            migListView1.OnLabelClicked += MigListView1_OnLabelClicked;
            migListView1.itemsBound();
        }

        private void MigFolderDialog_onFolderPathTextChanged(object sender, migFolderDialogSelect e)
        {
            string r = "";
            if (sender is TextBox)
            {
                r = ((TextBox)sender).Text;
            }
            else if (sender is migTextBox)
            {
                r = ((migTextBox)sender).ebText;
            }

            if (!r.EndsWith("\\")) { r += "\\"; }
            try
            {


                DirectoryInfo dinf = new DirectoryInfo(r);

                if (!dinf.Exists)
                {
                    DialogResult x = Dialogs.MsgBox("Create Directory?", string.Format("The Directory specified \"{0}\" does not exist, do you want to attempt creation?", new object[] { dinf.FullName }), MessageBoxButtons.YesNo);
                    if (x == DialogResult.Yes)
                    {
                        try
                        {
                            Directory.CreateDirectory(r);
                            changeDir(r);
                        }
                        catch (Exception exp)
                        {
                            Dialogs.MsgBox("Error", exp.Message);
                        }
                    }
                }
                else
                {
                    changeDir(r);
                }
            }
            catch (Exception exp)
            {
                Dialogs.MsgBox("Error", exp.Message);
            }
        }

        private void MigListView1_OnLabelClicked(object sender, migListView.migListViewLabelEventArgs e)
        {

            switch (e.tag)
            {
                case "PARENT":
                    parentDir();
                    break;
                case "DIR":
                    changeDir(currentPath + e.Name);
                    break;
                case "FILE":
                    selectedFile = e.tag2;
                    if (!string.IsNullOrEmpty(selectedFile) && File.Exists(selectedFile))
                    {
                        FileInfo finf = new FileInfo(selectedFile);
                        tbFile.ebText = finf.Name;
                       // changeDir(finf.DirectoryName);
                    }
                    
                    break;
                   
            }


        }


        public void parentDir()
        {
            DirectoryInfo dinf = new DirectoryInfo(currentPath);
            changeDir(dinf.Parent.FullName);
        }
        public void changeDir(string val)
        {
            currentPath = val;
            if (!currentPath.EndsWith("\\")) { currentPath += "\\"; }
            selectedPath = currentPath;

            updateDirs();
        }

        private void MbD_Click(object sender, EventArgs e)
        {
            migButton b = (migButton)sender;
            changeDir((string)b.Tag);

        }

        private void migLabel1_Click(object sender, EventArgs e)
        {

        }

        public class migFolderDialogSelect : EventArgs
        {
            public migFolderDialogSelect(string _path)
            {
                this.selectedPath = _path;
            }

            public migFolderDialogSelect(string _path, DialogResult _res)
            {
                this.selectedPath = _path;
                this.res = _res;
            }
            public string selectedPath { get; private set; }
            public DialogResult res { get; set; }
        }


        public class migFileSaveSelect : EventArgs
        {
            public migFileSaveSelect(string _path, string _file)
            {
                this.selectedPath = _path;
                this.selectedFile = _file;
            }

            public migFileSaveSelect(string _path, string _file, DialogResult _res)
            {
                this.selectedPath = _path;
                this.selectedFile = _file;

                this.res = _res;
            }

            public migFileSaveSelect(string _path, string _file, string _fullPath)
            {
                this.selectedPath = _path;
                this.selectedFile = _file;
                this.fullPath = _fullPath;

            }
            public string selectedPath { get; private set; }
            public string selectedFile { get; private set; }

            public string fullPath { get; private set; }
            public DialogResult res { get; set; }
        }

        public class migFolderDialogTextChange : EventArgs
        {
            public string Text { get; set; }
            public migFolderDialogTextChange(string _text)
            {
                Text = _text;
            }
        }
        private void mbSelect_Click(object sender, EventArgs e)
        {

            if (currentPath != mtbDrawer.ebText)
            {
                if (!Directory.Exists(mtbDrawer.ebText))
                {
                    try
                    {


                        DirectoryInfo dinf = new DirectoryInfo(mtbDrawer.ebText);

                        if (!dinf.Exists)
                        {
                            DialogResult x = Dialogs.MsgBox("Create Directory?", string.Format("The Directory specified \"{0}\" does not exist, do you want to attempt creation?", new object[] { dinf.FullName }), MessageBoxButtons.YesNo);
                            if (x == DialogResult.Yes)
                            {
                                try
                                {
                                    Directory.CreateDirectory(mtbDrawer.ebText);
                                    changeDir(mtbDrawer.ebText);
                                }
                                catch (Exception exp)
                                {
                                    Dialogs.MsgBox("Error", exp.Message);
                                }
                            }
                        }
                    }
                    catch (Exception exp)
                    {
                        Dialogs.MsgBox("Error", "Invalid directory specified\n\n" + exp.Message);
                    }
                }
                else
                {
                    changeDir(mtbDrawer.ebText);
                }

            }
            if (Directory.Exists(currentPath))
            {
                if (onFolderSelected != null)
                    onFolderSelected(this, new migFolderDialogSelect(currentPath));
                this.Close();
            }
        }

        private void mbCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNewDrawer_Click(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists(currentPath))
            {
                var x = Dialogs.InputBox("New Drawer", "What would you like to name the new drawer?", MessageBoxButtons.OKCancel);
                if (x.res == DialogResult.OK && !(String.IsNullOrEmpty(x.input)))
                {
                    try
                    {
                        System.IO.Directory.CreateDirectory(currentPath + x.input);


                        changeDir(currentPath + x.input);
                    }
                    catch (Exception exp)
                    {
                        Dialogs.MsgBox("Error", exp.Message, MessageBoxButtons.OK);
                    }
                }

            }
        }

        private void migButton1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbFile.ebText))
            {
                if (onFileSelected != null)
                {
                    var r = migControls.Dialogs.MsgBox("Save File As..", "Are you sure you want to save the file as " + selectedPath + tbFile.ebText);
                    if (r == DialogResult.OK)
                    {

                        string fullpath = (selectedPath + tbFile.ebText).Replace(@"\\", @"\");
       
                        onFileSelected(this, new migFileSaveSelect(selectedPath, tbFile.ebText,fullpath));
                        this.Close();
                        this.Dispose();
                    }
                }
            }
            else if (!string.IsNullOrEmpty(selectedFile) && System.IO.File.Exists(selectedFile))
            {
                System.IO.FileInfo finf = new FileInfo(selectedFile);
                if (finf.Attributes == FileAttributes.ReadOnly)
                {
                     migControls.Dialogs.MsgBox("Save File Error", selectedFile + " is READ ONLY");
            

                }
                var r = migControls.Dialogs.MsgBox("Save File As..", "Are you sure you want to overwrite: " + selectedFile);
                if (r == DialogResult.OK)
                {
                    onFileSelected(this, new migFileSaveSelect(finf.DirectoryName, finf.Name, finf.FullName));
                    this.Close();
              
                }
            }

        }
    }
}
