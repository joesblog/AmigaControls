using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace migControls
{
    public class migform : System.Windows.Forms.Form
    {



        public Brush testBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Orange);

        public int borderWidth = 4;
        public int remainderStart = 0;
        Rectangle rectExitButton { get; set; }
        Rectangle rectMaxButton { get; set; }

        Rectangle rectMinTButton { get; set; }

        Rectangle rectToolBar { get; set; }
        public bool IsResiable { get; set; }
        public bool setAllFonts { get; set; }

        public bool showResizeCorner { get; set; }
        private bool miniSizeSet { get; set; }


        protected override void OnLoad(EventArgs e)
        {

            globalMig.LoadFont();
            if (setAllFonts)
            {
                setFonts(this);

            }

            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(255, 0, 85, 169);

            base.OnLoad(e);
        }


        public void setFonts(Control root)
        {
            root.Font = new Font(globalMig.fonts.Families[0], 12);
            if (root.GetType() == typeof(Label))
            {
                root.ForeColor = Color.White;
            }

            foreach (Control z in root.Controls)
            {
                setFonts(z);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Point pLeftBorderStart = new Point(this.DisplayRectangle.Left + 5, this.DisplayRectangle.Location.Y);
            Point pRightBorderStart = new Point(this.DisplayRectangle.Left + 5, this.DisplayRectangle.Height);
            Pen wPen = new Pen(Color.Red, 1);




            drawLeftBorder(e);
            drawTBorder(e);
            drawRightBorder(e);
            drawBottomBorder(e);
            base.OnPaint(e);
        }


        protected void drawLeftBorder(PaintEventArgs e)
        {

            Rectangle lBorde = new Rectangle(this.DisplayRectangle.Left, 0, borderWidth, this.DisplayRectangle.Height - borderWidth);
            e.Graphics.FillRectangle(globalMig.stdWhiteBrush, lBorde);
        }

        protected void drawRightBorder(PaintEventArgs e)
        {

            Rectangle lBorde = new Rectangle(this.DisplayRectangle.Width - borderWidth, 0, borderWidth, this.DisplayRectangle.Height - borderWidth);
            e.Graphics.FillRectangle(globalMig.stdWhiteBrush, lBorde);
        }

        public void drawBottomBorder(PaintEventArgs e)
        {
            Rectangle bBorder = new Rectangle(this.DisplayRectangle.Left, this.DisplayRectangle.Height - borderWidth, this.DisplayRectangle.Width, borderWidth);
            e.Graphics.FillRectangle(globalMig.stdWhiteBrush, bBorder);
        }


        protected void drawTBorder(PaintEventArgs e)
        {
            Size tSize = TextRenderer.MeasureText(this.Text, globalMig.topaz_std12);

            int lNubWidth = 4;
            int barButtonHeight = tSize.Height + 6; // 2 padding each vert;
                                                    //  int lBubWidth = tSize.Width + 6; // 2 padding each horiz;

            int offsetX = borderWidth;

            //draw little top nub
            Rectangle littleLeftNub = new Rectangle(offsetX, 0, lNubWidth, barButtonHeight);
            e.Graphics.FillRectangle(globalMig.stdWhiteBrush, littleLeftNub);

            offsetX += lNubWidth + 2;
            offsetX += drawExitButton(e, offsetX, 0, barButtonHeight, barButtonHeight);
            offsetX += 2;

            Size textSize = TextRenderer.MeasureText(this.Text, globalMig.topaz_std12);
            Rectangle textBackground = new Rectangle(offsetX, 0, textSize.Width, barButtonHeight);
            e.Graphics.FillRectangle(globalMig.stdWhiteBrush, textBackground);

            e.Graphics.DrawString(this.Text, globalMig.topaz_std12, globalMig.stdBlueBrush, offsetX, 4);


            offsetX += 2 + textSize.Width;
            if (!miniSizeSet)
            {

                this.MinimumSize = new Size(offsetX + 10, 100);
            }

            int titleBarWidth = 0;
            if (base.MaximizeBox)
            {


                if (base.MinimizeBox)
                {
                    titleBarWidth = (this.DisplayRectangle.Width - offsetX - borderWidth) - (lNubWidth + borderWidth) + 2 - (barButtonHeight * 2) - 4;
                    offsetX += drawRemainderBar(e, offsetX, 0, barButtonHeight, titleBarWidth);
                    offsetX += 2;
                    offsetX += drawMinimizeButton(e, offsetX, 0, barButtonHeight, barButtonHeight);
                    offsetX += 2;
                    offsetX += drawMaximizeButton(e, offsetX, 0, barButtonHeight, barButtonHeight);

                    offsetX += 2;

                    Rectangle littleRightNub = new Rectangle(offsetX, 0, lNubWidth, barButtonHeight);
                    e.Graphics.FillRectangle(globalMig.stdWhiteBrush, littleRightNub);
                }
                else
                {
                    titleBarWidth = (this.DisplayRectangle.Width - offsetX - borderWidth) - (lNubWidth + borderWidth) + 2 - barButtonHeight;
                    offsetX += drawRemainderBar(e, offsetX, 0, barButtonHeight, titleBarWidth);
                    offsetX += 2;
                    offsetX += drawMaximizeButton(e, offsetX, 0, barButtonHeight, barButtonHeight);

                    offsetX += 2;

                    Rectangle littleRightNub = new Rectangle(offsetX, 0, lNubWidth, barButtonHeight);
                    e.Graphics.FillRectangle(globalMig.stdWhiteBrush, littleRightNub);
                }

            }
            else
            {
                titleBarWidth = (this.DisplayRectangle.Width - offsetX - borderWidth) - (lNubWidth + borderWidth) + 2;
                offsetX += drawRemainderBar(e, offsetX, 0, barButtonHeight, titleBarWidth);
                offsetX += 2;

                Rectangle littleRightNub = new Rectangle(offsetX, 0, lNubWidth, barButtonHeight);
                e.Graphics.FillRectangle(globalMig.stdWhiteBrush, littleRightNub);
            }






        }

        public int drawExitButton(PaintEventArgs e, int x, int y, int height, int width)
        {
            //return final x offset



            rectExitButton = new Rectangle(x, y, width, height);

            e.Graphics.FillRectangle(globalMig.stdWhiteBrush, rectExitButton);

            e.Graphics.FillRectangle(globalMig.stdBlueBrush, new Rectangle(x + 2, y + 2, width - 4, height - 4));

            e.Graphics.FillRectangle(globalMig.stdWhiteBrush, new Rectangle(x + 4, y + 4, width - 8, height - 8));
            e.Graphics.FillRectangle(globalMig.stdBlackBrush, new Rectangle(x + 8, y + 8, width - 16, height - 16));

            return width;

        }

        public int drawMinimizeButton(PaintEventArgs e, int x, int y, int height, int width)
        {
            //return final x offset



            rectMinTButton = new Rectangle(x, y, width, height);

            e.Graphics.FillRectangle(globalMig.stdWhiteBrush, rectMinTButton);



            e.Graphics.FillRectangle(globalMig.stdBlueBrush, new Rectangle(x + 3, y + 3, 16, 16));
            e.Graphics.FillRectangle(globalMig.stdWhiteBrush, new Rectangle(x + 5, y + 5, 12, 12));
            e.Graphics.FillRectangle(globalMig.stdBlueBrush, new Rectangle(x + 5, y + 11, 6, 6));

            return width;

        }

        public int drawMaximizeButton(PaintEventArgs e, int x, int y, int height, int width)
        {
            //return final x offset



            rectMaxButton = new Rectangle(x, y, width, height);

            e.Graphics.FillRectangle(globalMig.stdWhiteBrush, rectMaxButton);

            //  e.Graphics.FillRectangle(globalMig.stdBlueBrush, new Rectangle(x + 2, y + 2, width - 4, height - 4));

            e.Graphics.FillRectangle(globalMig.stdWhiteBrush, new Rectangle(x + 4, y + 4, width - 8, height - 8));

            if (base.WindowState == FormWindowState.Normal)
            {
                //  e.Graphics.FillRectangle(globalMig.stdBlackBrush, new Rectangle(x + 2, y + 2, 10, 10));



                e.Graphics.FillRectangle(globalMig.stdBlueBrush, new Rectangle(x + 3, y + 3, 16, 16));
                e.Graphics.FillRectangle(globalMig.stdWhiteBrush, new Rectangle(x + 5, y + 5, 12, 12));
                e.Graphics.FillRectangle(globalMig.stdBlueBrush, new Rectangle(x + 5, y + 5, 6, 6));
            }
            else
            {


                //  e.Graphics.FillRectangle(globalMig.stdBlackBrush, new Rectangle(x + 8, y + 8, 10, 10));
                //  e.Graphics.FillRectangle(globalMig.stdBlackBrush, new Rectangle(x + 4, y + 4, 4, 4));
                ////  e.Graphics.FillRectangle(globalMig.stdBlackBrush, new Rectangle(x + 6, height - 10, 12, 4));


                e.Graphics.FillRectangle(globalMig.stdBlackBrush, new Rectangle(x + 2, y + 2, 16, 16));
                e.Graphics.FillRectangle(globalMig.stdBlueBrush, new Rectangle(x + 14, y + 12, 8, 8));
                e.Graphics.FillRectangle(globalMig.stdWhiteBrush, new Rectangle(x + 15, y + 14, 6, 5));
                //  e.Graphics.FillRectangle(globalMig.stdWhiteBrush, new Rectangle(x + 4, y + 6, 12, 10));

            }


            return width;

        }


        public int drawRemainderBar(PaintEventArgs e, int x, int y, int height, int width)
        {
            int res = 0;
            remainderStart = x;
            rectToolBar = new Rectangle(x, y, width, height);

            e.Graphics.FillRectangle(globalMig.stdWhiteBrush, rectToolBar);
            int a = height / 2; //halfway point of bar


            int firstBluey = (height / 4);
            int secondBluey = (height - firstBluey) - (height / 5);


            Rectangle firstBlue = new Rectangle(x + 2, firstBluey, width - 4, height / 5);

            e.Graphics.FillRectangle(globalMig.stdBlueBrush, firstBlue);

            Rectangle secondBlue = new Rectangle(x + 2, secondBluey, width - 4, height / 5);

            e.Graphics.FillRectangle(globalMig.stdBlueBrush, secondBlue);

            res = width;

            return res;
        }


        protected override void WndProc(ref Message m)
        {
            const UInt32 WM_NCHITTEST = 0x0084;
            const UInt32 WM_MOUSEMOVE = 0x0200;
            const UInt32 WM_NCMBUTTONDOWN = 0x00A7;
            const UInt32 WM_NCMBUTTONUP = 0x00A8;
            const UInt32 WM_LBUTTONDOWN = 0x0201;
            const UInt32 WM_LBUTTONUP = 0x0202;
            const UInt32 WM_NCLBUTTONDOWN = 0x00A1;
            const UInt32 WM_NCLBUTTONUP = 0x00A2;
            const UInt32 HTLEFT = 10;
            const UInt32 HTRIGHT = 11;
            const UInt32 HTBOTTOMRIGHT = 17;
            const UInt32 HTBOTTOM = 15;
            const UInt32 HTBOTTOMLEFT = 16;
            const UInt32 HTTOP = 12;
            const UInt32 HTTOPLEFT = 13;
            const UInt32 HTTOPRIGHT = 14;
            const int HT_CAPTION = 0x2;
            const int RESIZE_HANDLE_SIZE = 10;
            const int Move_Handle_Size = 20;
            bool handled = false;
            bool handled2 = false;
            if (m.Msg == WM_LBUTTONUP || m.Msg == WM_NCLBUTTONUP)
            {
                Size formSize = this.Size;
                Point screenPoint = new Point(m.LParam.ToInt32());
                Point clientPoint = this.PointToClient(screenPoint);
                Rectangle hitRect = new Rectangle(screenPoint, new Size(3, 3));

                if (rectExitButton != null && !Rectangle.Intersect(hitRect, rectExitButton).IsEmpty)
                {
                   
                    handled = true;
                    Close();
                }
                if (rectMaxButton != null && !Rectangle.Intersect(hitRect, rectMaxButton).IsEmpty)
                {
                    handled = true;
                    if (base.WindowState == FormWindowState.Normal)
                    {
                        m.Result = (IntPtr)(HT_CAPTION);
                        base.WindowState = FormWindowState.Maximized;
                    }
                    else
                    {
                        base.WindowState = FormWindowState.Normal;
                    }
                }

                if (rectMinTButton != null && !Rectangle.Intersect(hitRect, rectMinTButton).IsEmpty)
                {
                     
                    handled = true;
                    base.WindowState = FormWindowState.Minimized;
                }
            }
            else if (m.Msg == WM_NCHITTEST || m.Msg == WM_MOUSEMOVE)
            {
                Size formSize = this.Size;
                Point screenPoint = new Point(m.LParam.ToInt32());
                Point clientPoint = this.PointToClient(screenPoint);



                Dictionary<UInt32, Rectangle> resizeboxes = new Dictionary<UInt32, Rectangle>() {
            //{HTBOTTOMLEFT, new Rectangle(0, formSize.Height - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)},
            //{HTBOTTOM, new Rectangle(RESIZE_HANDLE_SIZE, formSize.Height - RESIZE_HANDLE_SIZE, formSize.Width - 2*RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)},
            {HTBOTTOMRIGHT, new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, formSize.Height - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)}

        };

                Dictionary<UInt32, Rectangle> moveBoxes = new Dictionary<UInt32, Rectangle>() {

             
            {HTTOP,   rectToolBar},
             

        };

                if (IsResiable)
                {


                    foreach (KeyValuePair<UInt32, Rectangle> hitBox in resizeboxes)
                    {
                        if (hitBox.Value.Contains(clientPoint))
                        {
                            m.Result = (IntPtr)hitBox.Key;
                            handled = true;


                            break;
                        }
                    }
                }
                foreach (KeyValuePair<UInt32, Rectangle> hitBox in moveBoxes)
                {
                    if (hitBox.Value.Contains(clientPoint))
                    {
                        m.Result = (IntPtr)(HT_CAPTION);
                        handled = true;
                        break;
                    }
                }
            }




            if (!handled )
            {
                base.WndProc(ref m);
            }
            else
            {
            }

        }
        protected override void OnMaximizedBoundsChanged(EventArgs e)
        {

            this.Invalidate(true);
            base.OnMaximizedBoundsChanged(e);
        }

        protected override void OnMaximumSizeChanged(EventArgs e)
        {

            this.Invalidate(true);
            base.OnMaximumSizeChanged(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            this.Invalidate(true);

            base.OnSizeChanged(e);
        }
        protected override void OnResizeEnd(EventArgs e)
        {
            this.Invalidate(true);

            base.OnResizeEnd(e);
        }

    }
}
