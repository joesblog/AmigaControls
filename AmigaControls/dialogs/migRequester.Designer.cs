namespace migControls
{
    partial class migRequester
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
            this.lblQuestion = new migControls.migLabel();
            this.tbAnswer = new migControls.migTextBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblQuestion
            // 
            this.lblQuestion.Location = new System.Drawing.Point(12, 35);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(24, 16);
            this.lblQuestion.TabIndex = 0;
            this.lblQuestion.Text = "  ";
            // 
            // tbAnswer
            // 
            this.tbAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
    //        this.tbAnswer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(85)))), ((int)(((byte)(169)))));
            this.tbAnswer.borderThickness = null;
            this.tbAnswer.ebText = "";
            this.tbAnswer.hideMigBorder = false;
            this.tbAnswer.Location = new System.Drawing.Point(15, 70);
            this.tbAnswer.MultiLine = false;
            this.tbAnswer.Name = "tbAnswer";
            this.tbAnswer.Pad = new System.Windows.Forms.Padding(2);
            this.tbAnswer.Padding = new System.Windows.Forms.Padding(2);
            this.tbAnswer.readOnly = false;
            this.tbAnswer.Size = new System.Drawing.Size(544, 51);
            this.tbAnswer.TabIndex = 1;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlButtons.Location = new System.Drawing.Point(15, 127);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(544, 54);
            this.pnlButtons.TabIndex = 2;
            // 
            // migRequester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(574, 193);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.tbAnswer);
            this.Controls.Add(this.lblQuestion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(182, 100);
            this.Name = "migRequester";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "migTextRequester";
            this.Load += new System.EventHandler(this.migRequester_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private migLabel lblQuestion;
        private migTextBox tbAnswer;
        private System.Windows.Forms.Panel pnlButtons;
    }
}