using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace migControls
{

    public class migProgressBar : ProgressBar
    {


        public migProgressBar()
        {
            this.SuspendLayout();

            if (!globalMig.loadBoringWindows)
            {
                base.SetStyle(ControlStyles.UserPaint, true);

            }

            this.ResumeLayout();
        }

        public bool breakup { get; set; }
        private int _breakupPartsSize = 20;
        public int breakupPartsWidth {
            get {
                return _breakupPartsSize;
            }
            set {
                _breakupPartsSize = value;
            }
        }
        private int _breakupMargin = 4;
        private int _breakupOffset =2;

        public int breakupMargin {
            get { return _breakupMargin; }
            set { _breakupMargin = value; }
        }

        public int breakupOffset
        {
            get { return _breakupOffset; }
            set { _breakupOffset = value;}

        }
        protected override CreateParams CreateParams
        {
            get
            {

                if (globalMig.loadBoringWindows)
                {
                    return base.CreateParams;
                }
                CreateParams result = base.CreateParams;
                result.ExStyle |= 0x02000000; // WS_EX_COMPOSITED 
                return result;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            if (globalMig.loadBoringWindows)
            {
                base.OnPaint(e);
                return;
            }
            Rectangle rectangle;
            

            rectangle = new Rectangle(0, 0, base.Width, base.Height);
            if (ProgressBarRenderer.IsSupported)
            {
                //  ProgressBarRenderer.DrawHorizontalBar(e.Graphics, rectangle);
            }
            rectangle.Width = ((int)(rectangle.Width * (((double)base.Value) / ((double)base.Maximum)))) - 4;
            rectangle.Height -= 4;
            e.Graphics.FillRectangle(globalMig.stdWhiteBrush, 0, 0, this.DisplayRectangle.Width -2, this.DisplayRectangle.Height -2);
            e.Graphics.FillRectangle(globalMig.stdBlueBrush, 2, 2, this.DisplayRectangle.Width -6, this.DisplayRectangle.Height -6);

            if (!breakup)
            {



                e.Graphics.FillRectangle(globalMig.stdOrangeBrush, 2, 2, rectangle.Width - 2, rectangle.Height - 2);
            }
            else {
                int total = rectangle.Width - 2;
                int soFar = 2;
                int count = 0;
             
                while (soFar < total )
                {
                    //if (count == 100) { break; }
                   // if (soFar + (breakupPartsWidth*2) + breakupMargin  == total) { soFar = total; break; }

                    if ((soFar + breakupPartsWidth + breakupMargin) > rectangle.Width)
                    {
                        int size = (soFar + breakupPartsWidth + breakupMargin) - rectangle.Width - breakupOffset;

                        e.Graphics.FillRectangle(globalMig.stdOrangeBrush, soFar, 2, size, rectangle.Height - 2);

                        break;
                    }
                    else {
                        e.Graphics.FillRectangle(globalMig.stdOrangeBrush, soFar, 2, breakupPartsWidth, rectangle.Height - 2);

                    }

                    soFar += (breakupPartsWidth + breakupMargin + breakupOffset);
                    count++;
                }


            }
            string labelText = this.LabelText;
            Font lableFont = this.LableFont;
            SolidBrush brush2 = new SolidBrush(this.LableCOLOUR);
            if (this.CentreText)
            {
                StringFormat format = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                rectangle = new Rectangle(0, 0, base.Width, base.Height);
                e.Graphics.DrawString(labelText, lableFont, brush2, rectangle, format);
            }
            else
            {
                PointF point = new PointF(0f, 0f);
                e.Graphics.DrawString(labelText, lableFont, brush2, point);
            }
        }

        public bool CentreText { get; set; }

        public string LabelText { get; set; }

        public Color LableCOLOUR { get; set; }

        public Font LableFont { get; set; }

    }

}