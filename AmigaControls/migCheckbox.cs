using migControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace migControls
{
    public class migCheckbox : CheckBox
    {

        public int boxSize = 16;
        public int marginSize = 4;
        private Rectangle boxRectangle;
        public bool showLabel { get; set; }
        

        public override bool AutoSize
        {
            get
            {
                return false;
            }

            set
            {
                base.AutoSize = false;
            }
        }


 

        protected override void OnCreateControl()
        {

            Size textSize = TextRenderer.MeasureText(this.Text, globalMig.topaz_std12);
            Size nSize = new Size(textSize.Width + boxSize + marginSize +10, textSize.Height);
            this.Size = nSize;

            base.OnCreateControl();
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {

            if (globalMig.loadBoringWindows)
            {
                base.OnPaint(pevent);
                return;
            }

            Size textSize = TextRenderer.MeasureText(this.Text, globalMig.topaz_std12);

            boxRectangle = new Rectangle(0, 0, boxSize, boxSize);

            pevent.Graphics.Clear(migControls.globalMig.stdColorBlue);

            pevent.Graphics.FillRectangle(globalMig.stdWhiteBrush, boxRectangle);
            pevent.Graphics.FillRectangle(globalMig.stdBlueBrush, Rectangle.Inflate(boxRectangle, -2, -2));
             

            if (this.Checked)
            {
                pevent.Graphics.DrawString("x", globalMig.topaz_std10, globalMig.stdWhiteBrush, new PointF(2, 0));
            }
            pevent.Graphics.DrawString(this.Text, globalMig.topaz_std12, globalMig.stdWhiteBrush, new PointF(boxSize + marginSize,0));
            //  base.OnPaint(pevent);
        }


    }
}
