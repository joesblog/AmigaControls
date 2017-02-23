using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace migControls
{
    /// <summary>
    /// 
    /// </summary>
    public class migTextBox : Panel
    {

        public delegate void TextChangedHandler(object sender, EventArgs e);
        public delegate void TextBoxClickHandler(object sender, EventArgs e);
        public delegate void TextBoxKeyUpHandler(object sender, EventArgs e);
        public event TextBoxClickHandler onInnerTextClicked;
        public event TextChangedHandler OnInnerTextChanged;
        public event TextBoxKeyUpHandler onInnerTextKeyUp;
  

        public TextBox EditBox { get; set; }


     public int? borderThickness { get; set; }

        public bool hideMigBorder { get; set; }

        private static Padding defPadding = new Padding(2);

        public bool isSetPadding = false;

        [Description("inner panel padding"), Category("Layout")]
     
        public Padding Pad
        {
         get {
                if (!isSetPadding)
                {
                   
                    this.Padding = defPadding;
                }
                return this.Padding; }
            set { this.Padding = value; isSetPadding = true; }
        }
        public bool test;

   
        public bool readOnly { get { return EditBox.ReadOnly;  } set { EditBox.ReadOnly = value; } }

        [Description("inner panel dock"), Category("Layout")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [DefaultValue(DockStyle.Fill)]
        public DockStyle innerDock
        {
            get {
                return EditBox.Dock;
            }
            set
            {
                EditBox.Dock = value;
            }
        }
        public string ebText
        {
            get
            {
                if (EditBox != null)
                {
                    return EditBox.Text;
                }
                else
                {
                    return "";
                }
            }
            set
            {

                if (EditBox != null)
                {
                    EditBox.Text = value;
                }
            }
        }
        public bool MultiLine { get; set; }
        public migTextBox()
        {
            this.DoubleBuffered = true;
            this.Padding = new Padding(8);
            EditBox = new TextBox();
            EditBox.AutoSize = false;
            EditBox.BorderStyle = BorderStyle.None;
            
            EditBox.Dock = DockStyle.Fill;
            
            EditBox.Enter += new EventHandler(EditBox_Refresh);
            EditBox.Leave += new EventHandler(EditBox_Refresh);
            EditBox.Resize += new EventHandler(EditBox_Refresh);
            EditBox.TextChanged += EditBox_TextChanged;
            EditBox.KeyUp += EditBox_KeyUp;
            globalMig.LoadFont();

            if (!globalMig.loadBoringWindows)
            {
                this.BackColor = globalMig.stdColorBlue;

                EditBox.Font = globalMig.topaz_std12;
                EditBox.BackColor = globalMig.stdColorBlue;
                EditBox.ForeColor = globalMig.stdColorWhite;
                EditBox.BorderStyle = BorderStyle.None;


            }
            else {
                EditBox.BorderStyle = BorderStyle.FixedSingle;

            }


            EditBox.Click += (sender, e) => { onInnerTextClicked?.Invoke(sender, e); };
            this.Controls.Add(EditBox);
        }

        private void EditBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (onInnerTextKeyUp != null)
            {
                EventArgs e2 = new EventArgs();
                onInnerTextKeyUp(EditBox, e2);
            }
        }

        private void EditBox_TextChanged(object sender, EventArgs e)
        {
            if (OnInnerTextChanged == null) return;

            EventArgs e2 = new EventArgs();
            OnInnerTextChanged(EditBox, e2);
        }

        protected override void OnCreateControl()
        {
            EditBox.Multiline = this.MultiLine;

            base.OnCreateControl();
        }

        private void EditBox_Refresh(object sender, EventArgs e)
        {

            this.Invalidate();
        }



        protected override void OnPaint(PaintEventArgs e)
        {

            if (globalMig.loadBoringWindows)
            {
                base.OnPaint(e);
                return;
            }
         //   e.Graphics.Clear(SystemColors.Window);
            Rectangle nRect = new Rectangle();
            nRect = Rectangle.Inflate(this.ClientRectangle, -2, -2);

            e.Graphics.FillRectangle(globalMig.stdOrangeBrush, nRect);

            Pen cpen = globalMig.stdWhitePen;
            if (borderThickness.HasValue)
            {
                cpen.Width = borderThickness.Value;
            }

                e.Graphics.DrawRectangle(cpen, new Rectangle(0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1));
            e.Graphics.FillRectangle(globalMig.stdBlueBrush, new Rectangle(2, 2, this.ClientSize.Width - 4, this.ClientSize.Height - 4));
            // base.OnPaint(e);
        }
    }
}

/*
globalMig.LoadFont();
            this.Font = globalMig.topaz_std12;
            this.BackColor = globalMig.stdBlue;
            this.ForeColor = Color.White;
            this.BorderStyle = BorderStyle.Fixed3D  ;
            */
