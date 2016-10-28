using migControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace migControls
{

   
    public    class migRadioButton :RadioButton
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
            Size nSize = new Size(textSize.Width + boxSize + marginSize, textSize.Height);
            this.Size = nSize;

            base.OnCreateControl();
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {

            Size textSize = TextRenderer.MeasureText(this.Text, globalMig.topaz_std12);

            boxRectangle = new Rectangle(0, 0, boxSize, boxSize);

            pevent.Graphics.Clear(migControls.globalMig.stdColorBlue);
            //pevent.Graphics.FillEllipse()
            pevent.Graphics.FillEllipse(globalMig.stdWhiteBrush, boxRectangle);
            pevent.Graphics.FillEllipse(globalMig.stdBlueBrush, Rectangle.Inflate(boxRectangle, -2, -2));


            if (this.Checked)
            {
                pevent.Graphics.FillEllipse(globalMig.stdOrangeBrush, Rectangle.Inflate(boxRectangle, -4, -4));

            }
            pevent.Graphics.DrawString(this.Text, globalMig.topaz_std12, globalMig.stdWhiteBrush, new PointF(boxSize + marginSize, 0));
            //  base.OnPaint(pevent);
        }
    }
}
