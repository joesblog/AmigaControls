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
        private migTextBox migTextBox1;
        private Brush _currentBrush;
        public int marginSize {
            get {
                if (_marginSize == 0)
                {
                    _marginSize = 20;
                }
                return _marginSize;
            }
            set { _marginSize = value; }
        }
        public bool? _hideBottomBorder;

        public bool? hideBottomBorder
        {
            get {
                if (!_hideBottomBorder.HasValue)
                {
                    _hideBottomBorder = false;
                }
                return _hideBottomBorder;
            }
            set {
                _hideBottomBorder = value;
            }
        }

        public bool stopHoverChange { get; set; }
        public bool IsSelected { get; set; }
        public int tabIndex { get; set; }
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
            this.migTextBox1 = new migControls.migTextBox();
            this.SuspendLayout();
            // 
            // migTextBox1
            // 
            this.migTextBox1.ebText = "";
            this.migTextBox1.Location = new System.Drawing.Point(0, 0);
            this.migTextBox1.MultiLine = false;
            this.migTextBox1.Name = "migTextBox1";
            this.migTextBox1.Padding = new System.Windows.Forms.Padding(2);
            this.migTextBox1.Size = new System.Drawing.Size(200, 100);
            this.migTextBox1.TabIndex = 0;
            // 
            // migButton
            // 
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResumeLayout(false);

        }
        protected override void OnCreateControl()
        {

            Size tSize = TextRenderer.MeasureText(this.Text,  globalMig.topaz_std12);

            this.Width = marginSize*2 + tSize.Width;

            base.OnCreateControl();
        }

        public bool hoverOver { get; set; }
        
        protected override void OnPaint(PaintEventArgs pevent)

        {
            if (globalMig.loadBoringWindows)
            {
                base.OnPaint(pevent);
                return;
            }
            pevent.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            Size tSize = TextRenderer.MeasureText(this.Text,  globalMig.topaz_std12);

            Rectangle rtMain = this.DisplayRectangle;

            Pen cPen; Brush cBrush;
            if (IsSelected)
            {
                cPen = globalMig.thickOrangePen;
                cBrush = globalMig.stdOrangeBrush;
            }
            else {
                cPen = globalMig.thickWhitePen;
                cBrush = globalMig.stdWhiteBrush;
            }


            if (!stopHoverChange)
            {
                if (hoverOver)
                {
                    cPen = globalMig.thickOrangePen;
                    cBrush = globalMig.stdOrangeBrush;
                }
                else
                {
                    cPen = globalMig.thickWhitePen;
                    cBrush = globalMig.stdWhiteBrush;
                }
            }
            if (!hideBottomBorder.Value)
            {
                pevent.Graphics.FillRectangle(cBrush, rtMain);

                Rectangle rtInner = new Rectangle(rtMain.X + 2, rtMain.Y + 2, rtMain.Width - 4, rtMain.Height - 4);

                pevent.Graphics.FillRectangle(globalMig.stdBlueBrush, rtInner);
            }
            else {
                pevent.Graphics.FillRectangle(globalMig.stdBlueBrush, rtMain);

                pevent.Graphics.DrawLine(cPen, rtMain.X+1 , rtMain.Y , rtMain.X+1, rtMain.Height );
                pevent.Graphics.DrawLine(cPen, rtMain.Width-2, rtMain.Y, rtMain.Width-2 ,rtMain.Height);
                pevent.Graphics.DrawLine(cPen, rtMain.X+1, rtMain.Y+1, rtMain.Width - 2, rtMain.Y+1);



            }

            int textX = (rtMain.Width / 2) - (tSize.Width/2) +4;
            int textY = (rtMain.Height / 2) - (tSize.Height / 2)+2;

            pevent.Graphics.DrawString(this.Text, globalMig.topaz_std12, cBrush, textX, textY, StringFormat.GenericTypographic);

        }

        protected override void OnMouseMove(MouseEventArgs mevent)
        {
           
            base.OnMouseMove(mevent);
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            if (!stopHoverChange)
            {
                hoverOver = true;
                this.Invalidate();
            }

            base.OnMouseEnter(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            if (!stopHoverChange)

            {
              hoverOver = false;
                this.Invalidate();

            }

            base.OnMouseLeave(e);
        }
    }
}
