namespace ExampleApplication
{
    partial class Form1
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
            this.migLabel1 = new migControls.migLabel();
            this.mbtnExample = new migControls.migButton();
            this.migTextBox1 = new migControls.migTextBox();
            this.migListView1 = new migControls.migListView();
            this.migCheckbox1 = new AmigaControls.migCheckbox();
            this.migRadioButton1 = new migControls.migRadioButton();
            this.migRadioButton2 = new migControls.migRadioButton();
            this.SuspendLayout();
            // 
            // migLabel1
            // 
            this.migLabel1.Location = new System.Drawing.Point(12, 36);
            this.migLabel1.Name = "migLabel1";
            this.migLabel1.Size = new System.Drawing.Size(112, 16);
            this.migLabel1.TabIndex = 0;
            this.migLabel1.Text = "Example Label";
            // 
            // mbtnExample
            // 
            this.mbtnExample.Location = new System.Drawing.Point(12, 310);
            this.mbtnExample.marginSize = 4;
            this.mbtnExample.Name = "mbtnExample";
            this.mbtnExample.Size = new System.Drawing.Size(127, 57);
            this.mbtnExample.TabIndex = 1;
            this.mbtnExample.Text = "Example Button";
            this.mbtnExample.UseVisualStyleBackColor = true;
            this.mbtnExample.Click += new System.EventHandler(this.mbtnExample_Click);
            // 
            // migTextBox1
            // 
            this.migTextBox1.ebText = "Text here";
            this.migTextBox1.Location = new System.Drawing.Point(12, 234);
            this.migTextBox1.MultiLine = false;
            this.migTextBox1.Name = "migTextBox1";
            this.migTextBox1.Padding = new System.Windows.Forms.Padding(2);
            this.migTextBox1.Size = new System.Drawing.Size(672, 70);
            this.migTextBox1.TabIndex = 2;
            // 
            // migListView1
            // 
            this.migListView1.botText = "D";
            this.migListView1.customScrollbar1 = null;
            this.migListView1.gMargin = 5;
            this.migListView1.innerPanel = null;
            this.migListView1.Items = null;
            this.migListView1.Location = new System.Drawing.Point(12, 116);
            this.migListView1.Name = "migListView1";
            this.migListView1.Size = new System.Drawing.Size(672, 112);
            this.migListView1.TabIndex = 3;
            this.migListView1.topText = "U";
            this.migListView1.OnLabelClicked += new migControls.migListView.LabelClickedEventHandler(this.migListView1_OnLabelClicked);
            // 
            // migCheckbox1
            // 
            this.migCheckbox1.Location = new System.Drawing.Point(158, 327);
            this.migCheckbox1.Name = "migCheckbox1";
            this.migCheckbox1.showLabel = false;
            this.migCheckbox1.Size = new System.Drawing.Size(156, 16);
            this.migCheckbox1.TabIndex = 4;
            this.migCheckbox1.Text = "Checkbox Example";
            this.migCheckbox1.UseVisualStyleBackColor = true;
            // 
            // migRadioButton1
            // 
            this.migRadioButton1.Location = new System.Drawing.Point(158, 350);
            this.migRadioButton1.Name = "migRadioButton1";
            this.migRadioButton1.showLabel = false;
            this.migRadioButton1.Size = new System.Drawing.Size(148, 16);
            this.migRadioButton1.TabIndex = 5;
            this.migRadioButton1.TabStop = true;
            this.migRadioButton1.Text = "migRadioButton1";
            this.migRadioButton1.UseVisualStyleBackColor = true;
            // 
            // migRadioButton2
            // 
            this.migRadioButton2.Location = new System.Drawing.Point(158, 373);
            this.migRadioButton2.Name = "migRadioButton2";
            this.migRadioButton2.showLabel = false;
            this.migRadioButton2.Size = new System.Drawing.Size(148, 16);
            this.migRadioButton2.TabIndex = 6;
            this.migRadioButton2.TabStop = true;
            this.migRadioButton2.Text = "migRadioButton2";
            this.migRadioButton2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 488);
            this.Controls.Add(this.migRadioButton2);
            this.Controls.Add(this.migRadioButton1);
            this.Controls.Add(this.migCheckbox1);
            this.Controls.Add(this.migListView1);
            this.Controls.Add(this.migTextBox1);
            this.Controls.Add(this.mbtnExample);
            this.Controls.Add(this.migLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsResiable = true;
            this.MinimumSize = new System.Drawing.Size(94, 100);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private migControls.migLabel migLabel1;
        private migControls.migButton mbtnExample;
        private migControls.migTextBox migTextBox1;
        private migControls.migListView migListView1;
        private AmigaControls.migCheckbox migCheckbox1;
        private migControls.migRadioButton migRadioButton1;
        private migControls.migRadioButton migRadioButton2;
    }
}

