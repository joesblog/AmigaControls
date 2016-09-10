using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace migControls
{
    public  class migTextBox : Panel
    {

        public delegate void TextChangedHandler(object sender, EventArgs e);
        public event TextChangedHandler OnInnerTextChanged;
        private Color _NormalBorderColor = Color.Gray;
        private Color _FocusBorderColor = Color.Red;

        public TextBox EditBox;

        public string ebText { get {
                if (EditBox != null)
                {
                    return EditBox.Text;
                }
                else {
                    return "";
                }
            } set {

                if (EditBox != null)
                {
                    EditBox.Text = value;
                }
            } }
        public bool MultiLine { get; set; }
        public migTextBox()
        {
            this.DoubleBuffered = true;
            this.Padding = new Padding(2);

            EditBox = new TextBox();
            EditBox.AutoSize = false;
            EditBox.BorderStyle = BorderStyle.None;
            EditBox.Dock = DockStyle.Fill;
            EditBox.Enter += new EventHandler(EditBox_Refresh);
            EditBox.Leave += new EventHandler(EditBox_Refresh);
            EditBox.Resize += new EventHandler(EditBox_Refresh);
            EditBox.TextChanged += EditBox_TextChanged;
            globalMig.LoadFont();
            EditBox.Font = globalMig.topaz_std12;
            EditBox.BackColor = globalMig.stdBlue;
            EditBox.ForeColor = Color.White;
            EditBox.BorderStyle = BorderStyle.None;
            this.Controls.Add(EditBox);
        }

        private void EditBox_TextChanged(object sender, EventArgs e)
        {
            if (OnInnerTextChanged == null) return;

            EventArgs e2 = new EventArgs();
            OnInnerTextChanged(EditBox, e2);
        }

        protected override void OnCreateControl()
        {
            EditBox.Multiline = this.MultiLine;
           
            base.OnCreateControl();
        }

        private void EditBox_Refresh(object sender, EventArgs e)
        {
            
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(SystemColors.Window);
           
                e.Graphics.DrawRectangle(globalMig.stdWhitePen, new Rectangle(0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1));
           
            base.OnPaint(e);
        }
    }
}

/*
globalMig.LoadFont();
            this.Font = globalMig.topaz_std12;
            this.BackColor = globalMig.stdBlue;
            this.ForeColor = Color.White;
            this.BorderStyle = BorderStyle.Fixed3D  ;
            */