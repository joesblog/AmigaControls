﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace migControls
{



    public class migListView : Panel
    {
        public delegate void LabelClickedEventHandler(object sender, migListViewLabelEventArgs e);
        public event LabelClickedEventHandler OnLabelClicked;
        public List<migListViewItem> Items { get; set; }
        public Panel innerPanel { get; set; }
        public CustomScrollbar customScrollbar1 { get; set; }
        public bool singleCol { get; set; }


        private int _margin;
        public int gMargin
        {
            get
            {
                if (_margin == 0)
                {
                    _margin = 5;
                }
                return _margin;

            }
            set
            {
                _margin = value;
            }


        }


        private string _TopText, _BotText;


        public string topText
        {
            get
            {

                if (_TopText == null || _TopText == "")
                {
                    _TopText = "U";
                }
                return _TopText;
            }
            set
            {
                _TopText = value;
            }
        }

        public string botText
        {
            get
            {

                if (_BotText == null || _BotText == "")
                {
                    _BotText = "D";
                }
                return _BotText;
            }
            set
            {
                _BotText = value;
            }
        }
        public void itemsBound()
        {
            this.PerformLayout();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();


            this.ResumeLayout(false);

        }


        public class migListViewItem
        {
            public migListViewItem() { }
            public migListViewItem(string text)
            {
                this.Text = text;
            }
            public migListViewItem(string _text, string _tag)
            {
                this.Text = _text; this.tag = _tag;
            }
            public migListViewItem(string _text, string _tag,string _tag2)
            {
                this.Text = _text; this.tag = _tag; this.tag2 = _tag2;
            }

            public string tag { get; set; }

            public string tag2 { get; set; }
         public   string Text { get; set; }
            public object obj { get; set; }
            public object[] otherData { get; set; }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
        }

        internal void labelClickBubble(migLVLabel dat)
        {
            migListViewLabelEventArgs evs = new migListViewLabelEventArgs(dat);
            OnLabelClicked(dat, evs);
        }
        protected override void OnLayout(LayoutEventArgs levent)
        {
            this.ResizeRedraw = true;

            if (Items != null)
            {
                this.topText = "F";
                if (customScrollbar1 != null) customScrollbar1.Dispose();
                if (innerPanel != null) innerPanel.Dispose();
                innerPanel = new Panel();
                innerPanel.BorderStyle = BorderStyle.None;
                this.AutoScroll = false;


                innerPanel.Layout += InnerPanel_Layout;
                this.HorizontalScroll.Enabled = false;
                this.HorizontalScroll.Visible = false;
                innerPanel.HorizontalScroll.Maximum = 0;
                innerPanel.AutoScroll = false;
                innerPanel.HorizontalScroll.Enabled = false;
                innerPanel.HorizontalScroll.Visible = false;
                innerPanel.AutoScroll = true;
                // innerPanel.Height = this.DisplayRectangle.Height ;
                customScrollbar1 = new CustomScrollbar();
                innerPanel.Left += 1;
                innerPanel.Top += 1;
                innerPanel.Height = this.DisplayRectangle.Height - 5;
                innerPanel.Width = this.DisplayRectangle.Width + 20;
                customScrollbar1.topText = this.topText;
                customScrollbar1.botText = this.botText;
                customScrollbar1.Left = this.DisplayRectangle.Width - customScrollbar1.Width - 20;

                customScrollbar1.Height = this.DisplayRectangle.Height;
                customScrollbar1.Maximum = this.innerPanel.DisplayRectangle.Height + 20;
                this.customScrollbar1.Minimum = 0;
                this.customScrollbar1.LargeChange = customScrollbar1.Maximum / customScrollbar1.Height + this.innerPanel.Height;
                this.customScrollbar1.SmallChange = 15;
                this.customScrollbar1.Value = Math.Abs(this.innerPanel.AutoScrollPosition.Y);
                this.customScrollbar1.Scroll += CustomScrollbar1_Scroll;
                this.Controls.Add(customScrollbar1);
                this.Controls.Add(innerPanel);



            }
            base.OnLayout(levent);
        }

        private void CustomScrollbar1_Scroll(object sender, EventArgs e)
        {
            innerPanel.AutoScrollPosition = new Point(0, customScrollbar1.Value);

            customScrollbar1.Invalidate();
            Application.DoEvents();

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);

            Rectangle outerRect = new Rectangle(this.DisplayRectangle.X, this.DisplayRectangle.Y, this.DisplayRectangle.Width - 21, this.DisplayRectangle.Height - 1);

            e.Graphics.DrawRectangle(globalMig.stdWhitePen, outerRect);
            Rectangle innerRect = new Rectangle(this.DisplayRectangle.X + 1, this.DisplayRectangle.Y + 1, this.DisplayRectangle.Width - 20, this.DisplayRectangle.Height - 24);

            // e.Graphics.FillRectangle(globalMig.stdOrangeBrush, innerRect);
        }

        private void InnerPanel_Layout(object sender, LayoutEventArgs e)
        {


            this.SuspendLayout();
            int reqWidth = 0;
            int reqHeight = 0;
            Items.ForEach(p =>
            {

                int thisWidth = TextRenderer.MeasureText(p.Text, globalMig.topaz_std12).Width;
                int thisHeight = TextRenderer.MeasureText(p.Text, globalMig.topaz_std12).Height;
                if (reqWidth < thisWidth)
                { reqWidth = thisWidth; }
                if (reqHeight < thisHeight) reqHeight = thisHeight;
            });
            reqHeight = reqHeight + gMargin;


            int count = 0;
            int itemRowLimit = (e.AffectedControl.DisplayRectangle.Width) / (reqWidth + gMargin);
            if (singleCol) itemRowLimit = 1;
            int itemsInRow = 0;
            int row = 0;
            foreach (var i in Items)
            {
                migLVLabel nlabl = new migLVLabel();
                nlabl.scIndex = count;

                nlabl.italic = i.tag == "FILE";
                nlabl.Tag = i.tag;
                nlabl.tag2 = i.tag2;
              
                nlabl.Text = i.Text;
                nlabl.Data = i.obj ?? null;
                e.AffectedControl.Controls.Add(nlabl);
                if (count != 0)
                {
                    nlabl.Left = gMargin + (count * reqWidth) + (gMargin * count);
                }
                else
                {
                    nlabl.Left = gMargin;
                }

                nlabl.Top = gMargin + (row * reqHeight) + (gMargin * row);
                nlabl.Width = reqWidth;

                if (itemsInRow + 2 < itemRowLimit)
                {
                    itemsInRow++;
                    count++;
                }
                else
                {
                    itemsInRow = 0;
                    row = row + 1;
                    count = 0;
                }


            }
            this.ResumeLayout();
            this.Invalidate(true);
        }
        public class migLVLabel : Label
        {

            public int x { get; set; }
            public int y { get; set; }

            public bool italic { get; set; }
            public bool bold { get; set; }

            public string tag2 { get; set; }

            public object Data { get; set; }

            private Brush _whatBrush;
            public Brush whatBrush
            {
                get
                {

                    if (_whatBrush == null)
                    {
                        _whatBrush = globalMig.stdWhiteBrush;
                    }
                    return _whatBrush;
                }
                set
                {
                    _whatBrush = value;
                }
            }

            public int scIndex { get; set; }


            protected override void OnClick(EventArgs e)
            {
                if (typeof(migListView) == this.Parent.Parent.GetType())
                {
                    migListView grpar = (migListView)this.Parent.Parent;
                    grpar.labelClickBubble(this);



                }

                base.OnClick(e);
            }


            protected override void OnMouseEnter(EventArgs e)
            {
                this.whatBrush = globalMig.stdOrangeBrush;
                this.Invalidate();
                base.OnMouseEnter(e);
            }

            protected override void OnMouseLeave(EventArgs e)
            {
                this.whatBrush = globalMig.stdWhiteBrush;
                this.Invalidate();

                base.OnMouseLeave(e);
            }
            protected override void OnCreateControl()
            {

                if (this.Parent.GetType() != typeof(Panel))
                {
                    throw new Exception("Not supported on this control, list view only");
                }

                base.OnCreateControl();
            }


            protected override void OnPaint(PaintEventArgs e)
            {

                Font fontToUse = globalMig.topaz_std12;

                if (this.italic) fontToUse = globalMig.topaz_std12_italic;

                Size sx = TextRenderer.MeasureText(this.Text, fontToUse);

                if (sx.Width > this.Parent.Parent.DisplayRectangle.Width)
                {
                    //apply wrapping
                    StringFormat fmt = new StringFormat(StringFormatFlags.NoWrap);
                    Rectangle rc = new Rectangle(0, 0, this.Parent.Parent.DisplayRectangle.Width - 200, 200);
                    e.Graphics.DrawString(this.Text, fontToUse, this.whatBrush, rc, fmt);


                }
                else
                {
                    int xpos = (this.DisplayRectangle.Width / 2) - (sx.Width / 2);
                    int ypos = (this.DisplayRectangle.Height / 2) - (sx.Height / 2);
                    e.Graphics.DrawString(this.Text, fontToUse, this.whatBrush, 0, ypos);
                }

                //   base.OnPaint(e);
            }


        }


        public class migListViewLabelEventArgs : EventArgs
        {
            public migListViewLabelEventArgs(migLVLabel label)
            {
                this.Data = label.Data;
                this.Name = label.Text;
                this.tag = (string)label.Tag;
                this.tag2 = label.tag2;
            }
            public string Name { get; private set; }
            public string tag { get; private set; }
            public string tag2 { get; private set; }
            public object Data { get; private set; }
        }
    }

}

