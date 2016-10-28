namespace migControls
{
    partial class migFolderDialog
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
            this.mbCancel = new migControls.migButton();
            this.mbSelect = new migControls.migButton();
            this.migListView1 = new migControls.migListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.migLabel1 = new migControls.migLabel();
            this.mtbDrawer = new migControls.migTextBox();
            this.btnNewDrawer = new migControls.migButton();
            this.SuspendLayout();
            // 
            // mbCancel
            // 
            this.mbCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mbCancel.AutoSize = true;
            this.mbCancel.hideBottomBorder = false;
            this.mbCancel.hoverOver = false;
            this.mbCancel.IsSelected = false;
            this.mbCancel.Location = new System.Drawing.Point(275, 291);
            this.mbCancel.marginSize = 20;
            this.mbCancel.Name = "mbCancel";
            this.mbCancel.Size = new System.Drawing.Size(96, 51);
            this.mbCancel.stopHoverChange = false;
            this.mbCancel.tabIndex = 0;
            this.mbCancel.TabIndex = 3;
            this.mbCancel.Text = "Cancel";
            this.mbCancel.UseVisualStyleBackColor = true;
            this.mbCancel.Click += new System.EventHandler(this.mbCancel_Click);
            // 
            // mbSelect
            // 
            this.mbSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mbSelect.hideBottomBorder = false;
            this.mbSelect.hoverOver = false;
            this.mbSelect.IsSelected = false;
            this.mbSelect.Location = new System.Drawing.Point(12, 291);
            this.mbSelect.marginSize = 20;
            this.mbSelect.Name = "mbSelect";
            this.mbSelect.Size = new System.Drawing.Size(96, 51);
            this.mbSelect.stopHoverChange = false;
            this.mbSelect.tabIndex = 0;
            this.mbSelect.TabIndex = 4;
            this.mbSelect.Text = "Select";
            this.mbSelect.UseVisualStyleBackColor = true;
            this.mbSelect.Click += new System.EventHandler(this.mbSelect_Click);
            // 
            // migListView1
            // 
            this.migListView1.botText = "D";
            this.migListView1.customScrollbar1 = null;
            this.migListView1.gMargin = 5;
            this.migListView1.innerPanel = null;
            this.migListView1.Items = null;
            this.migListView1.Location = new System.Drawing.Point(12, 29);
            this.migListView1.Name = "migListView1";
            this.migListView1.singleCol = true;
            this.migListView1.Size = new System.Drawing.Size(379, 168);
            this.migListView1.TabIndex = 3;
            this.migListView1.topText = "U";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Location = new System.Drawing.Point(12, 243);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(365, 36);
            this.panel1.TabIndex = 6;
            // 
            // migLabel1
            // 
            this.migLabel1.Location = new System.Drawing.Point(12, 211);
            this.migLabel1.Name = "migLabel1";
            this.migLabel1.Size = new System.Drawing.Size(56, 16);
            this.migLabel1.TabIndex = 9;
            this.migLabel1.Text = "Drawer";
            this.migLabel1.Click += new System.EventHandler(this.migLabel1_Click);
            // 
            // mtbDrawer
            // 
            this.mtbDrawer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
          //  this.mtbDrawer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(85)))), ((int)(((byte)(169)))));
            this.mtbDrawer.borderThickness = null;
            this.mtbDrawer.ebText = "";
            this.mtbDrawer.hideMigBorder = false;
            this.mtbDrawer.Location = new System.Drawing.Point(65, 203);
            this.mtbDrawer.MultiLine = false;
            this.mtbDrawer.Name = "mtbDrawer";
            this.mtbDrawer.Pad = new System.Windows.Forms.Padding(2, 8, 2, 2);
            this.mtbDrawer.Padding = new System.Windows.Forms.Padding(2, 8, 2, 2);
            this.mtbDrawer.readOnly = false;
            this.mtbDrawer.Size = new System.Drawing.Size(306, 34);
            this.mtbDrawer.TabIndex = 13;
            // 
            // btnNewDrawer
            // 
            this.btnNewDrawer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNewDrawer.AutoSize = true;
            this.btnNewDrawer.hideBottomBorder = false;
            this.btnNewDrawer.hoverOver = false;
            this.btnNewDrawer.IsSelected = false;
            this.btnNewDrawer.Location = new System.Drawing.Point(114, 291);
            this.btnNewDrawer.marginSize = 20;
            this.btnNewDrawer.Name = "btnNewDrawer";
            this.btnNewDrawer.Size = new System.Drawing.Size(128, 51);
            this.btnNewDrawer.stopHoverChange = false;
            this.btnNewDrawer.tabIndex = 0;
            this.btnNewDrawer.TabIndex = 15;
            this.btnNewDrawer.Text = "New Drawer";
            this.btnNewDrawer.UseVisualStyleBackColor = true;
            this.btnNewDrawer.Click += new System.EventHandler(this.btnNewDrawer_Click);
            // 
            // migFolderDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 354);
            this.Controls.Add(this.btnNewDrawer);
            this.Controls.Add(this.mtbDrawer);
            this.Controls.Add(this.migLabel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.migListView1);
            this.Controls.Add(this.mbSelect);
            this.Controls.Add(this.mbCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(190, 100);
            this.Name = "migFolderDialog";
            this.Text = "Select a folder..";
            this.Load += new System.EventHandler(this.migFolderDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private migButton mbCancel;
        private migButton mbSelect;
        private migListView migListView1;
        private System.Windows.Forms.Panel panel1;
        private migLabel migLabel1;
        private migTextBox mtbDrawer;
        private migButton btnNewDrawer;
    }
}