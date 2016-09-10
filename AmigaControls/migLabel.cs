using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using migControls;
namespace TheNewDownloader
{
    public class migLabel : Label
    {
        protected override void OnCreateControl()
        {
            globalMig.LoadFont() ;

            Size tSize = TextRenderer.MeasureText(this.Text, globalMig.topaz_std12);
            this.AutoSize = false;
            this.Width = tSize.Width;
            this.Height = tSize.Height;

         //   base.OnCreateControl();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
          


            e.Graphics.DrawString(this.Text, globalMig.topaz_std12, globalMig.stdWhiteBrush, this.DisplayRectangle.X, this.DisplayRectangle.Y);

            //base.OnPaint(e);
        }

    }
}
