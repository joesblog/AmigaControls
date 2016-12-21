using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace migControls
{
    public class migPanel : Panel
    {
        public DockStyle partialDock
        {
            get; set;
        }

        System.Drawing.Point defLocation { get; set; }
        System.Drawing.Size defSize { get; set; }
        bool defsSet { get; set; }
        const int borderSize = 4;
        protected override void OnCreateControl()
        {
            if (Parent != null)
            {
                Parent.SizeChanged += Parent_SizeChanged;
                Parent.ClientSizeChanged += Parent_ClientSizeChanged;
                Parent.Resize += Parent_Resize;
                if (Parent.GetType().BaseType == typeof(migform))
                {
                    ((migform)Parent).AResize += MigPanel_AResize;
                }
            }
 
                setDock();
          
            base.OnCreateControl();
        }

        private void MigPanel_AResize(EventArgs e)
        {
            setDock();

        }

        protected override void WndProc(ref Message m)
        {

            if (m.Msg == 0x0112) // WM_SYSCOMMAND
            {
                // Check your window state here
                if (m.WParam == new IntPtr(0xF030)) // Maximize event - SC_MAXIMIZE from Winuser.h
                {
                    // THe window is being maximized
                }
            }
            base.WndProc(ref m);
        }

        private void Parent_Resize(object sender, EventArgs e)
        {
            setDock();
        }

        private void Parent_ClientSizeChanged(object sender, EventArgs e)
        {
            setDock();
        }

        private void Parent_SizeChanged(object sender, EventArgs e)
        {
            setDock();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
          

            base.OnSizeChanged(e);
        }

        protected override void OnAutoSizeChanged(EventArgs e)
        {
        
            base.OnAutoSizeChanged(e);
        }

        public int topMargin { get; set; }

        private void setDock() {
            if (partialDock == DockStyle.Fill)
            {
                setFullDock();
            }
            else if (partialDock == DockStyle.Left)
            {
                setLeftDock();
            }
            else if (partialDock == DockStyle.Right)
            {
                setRightDock();
            }  




        }

        private void setLeftDock() {
            if (!defsSet)
            {
                defLocation = this.Location;
                defSize = this.defSize;
            }
            this.Left = borderSize;
            this.Top = 22;
            if (this.Parent != null)
            {
                this.Width = ((this.Parent.Width -4) /2);
                this.Height = this.Parent.Height - 26;
                if (topMargin > 0)
                {
                    this.Height -= topMargin;
                    this.Top += topMargin;
                }
              
            }
          
        }
        private void setRightDock()
        {
            if (!defsSet)
            {
                defLocation = this.Location;
                defSize = this.defSize;
            }
           
            this.Top = 22;
            if (this.Parent != null)
            {
                this.Left = ((this.Parent.Width -4)/ 2) + borderSize ;
                this.Width = ((this.Parent.Width - 4) / 2) - borderSize;
                this.Height = this.Parent.Height - 26;
                if (topMargin > 0)
                {
                    this.Height -= topMargin;
                    this.Top += topMargin;
                }

            }
        }
        private void setFullDock() {
            if (!defsSet)
            {
                defLocation = this.Location;
                defSize = this.defSize;
            }
            this.Left = 4;
            this.Top = 22;
            if (this.Parent != null)
            {
                this.Width = this.Parent.Width - 8;
                this.Height = this.Parent.Height - 26;
           
            }
        }

    }
}
