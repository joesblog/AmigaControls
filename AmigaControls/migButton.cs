using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace migControls
{
   public  class migButton :Button
    {

 
 
        private int _marginSize;
        private Brush _currentBrush;
        public int marginSize {
            get {
                if (_marginSize == 0)
                {
                    _marginSize = 4;
                }
                return _marginSize;
            }
            set { _marginSize = value; }
        }

        public Brush currentBrush {
            get {
                if (_currentBrush == null)
                {
                    _currentBrush = globalMig.stdWhiteBrush;
                }
                return _currentBrush;
            }
            set { _currentBrush = value; }
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // migButton
            // 
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResumeLayout(false);

        }
        protected override void OnCreateControl()
        {

           

            base.OnCreateControl();
        }

        
        protected override void OnPaint(PaintEventArgs pevent)
        {
            pevent.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            Size tSize = TextRenderer.MeasureText(this.Text,  globalMig.topaz_std14);

            Rectangle rtMain = this.DisplayRectangle;

            pevent.Graphics.FillRectangle(currentBrush, rtMain);


            Rectangle rtInner = new Rectangle(rtMain.X + 2, rtMain.Y + 2, rtMain.Width - 4, rtMain.Height - 4);

            pevent.Graphics.FillRectangle(globalMig.stdBlueBrush, rtInner);

            int textX = (rtMain.Width / 2) - (tSize.Width/2) +4;
            int textY = (rtMain.Height / 2) - (tSize.Height / 2)+2;

            pevent.Graphics.DrawString(this.Text, globalMig.topaz_std14, currentBrush, textX, textY, StringFormat.GenericTypographic);

        }

        protected override void OnMouseMove(MouseEventArgs mevent)
        {
           
            base.OnMouseMove(mevent);
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            currentBrush = globalMig.stdOrangeBrush;
            base.OnMouseEnter(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            currentBrush = globalMig.stdWhiteBrush;
            base.OnMouseLeave(e);
        }
    }
}
