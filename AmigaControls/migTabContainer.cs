using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace migControls
{
    public class migTabContainer : Panel
    {
        protected override void OnPaint(PaintEventArgs e)
        {

            if (globalMig.loadBoringWindows)
            {
                base.OnPaint(e);
                return;
            }
            e.Graphics.FillRectangle(globalMig.stdWhiteBrush, this.DisplayRectangle);

            Rectangle brect = Rectangle.Inflate(this.DisplayRectangle, -2, -2);
            e.Graphics.FillRectangle(globalMig.stdBlueBrush, brect);

            //  base.OnPaint(e);

        }
      public  Control tabContainer { get; set; }
    }


    public interface ITabData
    {
        string tabId { get; set; }
    bool defaultTab { get; set; }
    }
}
