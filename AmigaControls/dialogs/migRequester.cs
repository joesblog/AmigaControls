using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace migControls
{
    public partial class migRequester : migControls.migform
    {

        public string title
        {
            get
            {
                return this.Text;
            }
            set { this.Text = value; }
        }
        public string question
        {

            get { return lblQuestion.Text; }
            set { lblQuestion.Text = value; }
        }
        public string answer
        {
            get
            {
                return tbAnswer.ebText;
            }
            set
            {
                tbAnswer.ebText = value;
            }
        }

        public bool justMessage
        {
            get; set;
        }

        public bool StopMoving { get; set; }
        public MessageBoxButtons buttons { get; set; }

        private int _RequesterAmount = 1;

        public int RequesterAmount { get { return _RequesterAmount; } set { _RequesterAmount = value; } }
        public migRequester()
        {

            InitializeComponent();



        }

        public string getInput(int index)
        {
            string r = "";

            if (index < inputs.Count())
            {
                r = inputs[index].ebText;
            }
            return r;

        }


        public List<migTextBox> inputs = new List<migTextBox>();
        public List<string> inputTexts = new List<string>();
        public delegate void migTextEventHandler(object sender, migTextRequestArgs e);
        public event migTextEventHandler onMigTextEntered;
        public event migTextEventHandler onMigTextButtonClicked;

        protected override void OnLoad(EventArgs e)
        {

          
            base.OnLoad(e);
        }
         
        public List<string> getInputs {

            get {
                List<string> res = new List<string>();

                if (RequesterAmount > 1)
                {
                    foreach (var i in this.Controls)
                    {
                        if (i is migTextBox)
                        {
                            var t = i as migTextBox;
             
                            res.Add(t.ebText);
                        }
                    }
                }
                else
                {
                    res.Add(tbAnswer.ebText);
                }

                return res.ToList();
            }
         
        }
        protected enum buttonPos { left = 0, mid = 1, right = 2 }
        protected migButton genButtonOk(ref int offset, buttonPos pos, int buttonHeight)
        {
            migButton n = new migButton();

            switch (pos)
            {
                case buttonPos.left:
                    n = new migButton();
                    n.Text = "Ok";
                    n.Left = offset;
                    offset += n.Width + 10;

                    n.Height = buttonHeight;
                    n.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;

                    break;
                case buttonPos.mid:

                    n = new migButton();
                    n.Text = "Ok";
                    n.Left = offset - n.Width / 2;


                    n.Height = buttonHeight;
                    n.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
                    break;
                case buttonPos.right:

                    n = new migButton();
                    n.Text = "Ok";
                    n.Left = (offset -= n.Width) + 8;

                    n.Height = buttonHeight;
                    n.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
                    break;
            }
            if (RequesterAmount > 1)
            {
                 
                n.Click += (sender, e) => { onMigTextButtonClicked?.Invoke(this, new migTextRequestArgs(getInputs, DialogResult.OK)); };


            }
            else {
                n.Click += (sender, e) => { onMigTextButtonClicked?.Invoke(this, new migTextRequestArgs(tbAnswer.ebText, DialogResult.OK)); };

            }



            return n;
        }
        protected migButton genButtonCancel(ref int offset, buttonPos pos, int buttonHeight)
        {
            migButton n = new migButton();

            switch (pos)
            {
                case buttonPos.left:
                    n = new migButton();
                    n.Text = "Cancel";
                    n.Left = offset;
                    offset += n.Width + 10;

                    n.Height = buttonHeight;
                    n.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
                    break;
                case buttonPos.mid:

                    n = new migButton();
                    n.Text = "Cancel";
                    n.Left = offset - n.Width / 2;


                    n.Height = buttonHeight;
                    n.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
                    break;
                case buttonPos.right:

                    n = new migButton();
                    n.Text = "Cancel";
                    n.Left = offset -= n.Width + 24;


                    n.Height = buttonHeight;
                    n.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
                    break;
            }
            if (RequesterAmount > 1)
            {

                n.Click += (sender, e) => { onMigTextButtonClicked?.Invoke(this, new migTextRequestArgs(getInputs, DialogResult.Cancel)); };


            }
            else
            {
                n.Click += (sender, e) => { onMigTextButtonClicked?.Invoke(this, new migTextRequestArgs(tbAnswer.ebText, DialogResult.Cancel)); };

            }


            return n;
        }
        protected migButton genButtonAbort(ref int offset, buttonPos pos, int buttonHeight)
        {
            migButton n = new migButton();

            switch (pos)
            {
                case buttonPos.left:
                    n = new migButton();
                    n.Text = "Abort";
                    n.Left = offset;
                    offset += n.Width + 10;

                    n.Height = buttonHeight;
                    n.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
                    break;
                case buttonPos.mid:

                    n = new migButton();
                    n.Text = "Abort";
                    n.Left = offset - n.Width / 2;


                    n.Height = buttonHeight;
                    n.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
                    break;
                case buttonPos.right:

                    n = new migButton();
                    n.Text = "Abort";
                    n.Left = offset -= n.Width + 16;


                    n.Height = buttonHeight;
                    n.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
                    break;
            }
           // n.Click += (sender, e) => { onMigTextButtonClicked?.Invoke(sender, new migTextRequestArgs(tbAnswer.ebText, DialogResult.Abort)); };
            if (RequesterAmount > 1)
            {

                n.Click += (sender, e) => { onMigTextButtonClicked?.Invoke(this, new migTextRequestArgs(getInputs, DialogResult.Abort)); };


            }
            else
            {
                n.Click += (sender, e) => { onMigTextButtonClicked?.Invoke(this, new migTextRequestArgs(tbAnswer.ebText, DialogResult.Abort)); };

            }

            return n;
        }
        protected migButton genButtonRetry(ref int offset, buttonPos pos, int buttonHeight)
        {
            migButton n = new migButton();

            switch (pos)
            {
                case buttonPos.left:
                    n = new migButton();
                    n.Text = "Retry";
                    n.Left = offset;
                    offset += n.Width + 10;

                    n.Height = buttonHeight;
                    n.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
                    break;
                case buttonPos.mid:

                    n = new migButton();
                    n.Text = "Retry";
                    n.Left = offset - n.Width / 2;


                    n.Height = buttonHeight;
                    n.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
                    break;
                case buttonPos.right:

                    n = new migButton();
                    n.Text = "Retry";
                    n.Left = offset -= n.Width + 16;


                    n.Height = buttonHeight;
                    n.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
                    break;
            }
         //   n.Click += (sender, e) => { onMigTextButtonClicked?.Invoke(sender, new migTextRequestArgs(tbAnswer.ebText, DialogResult.Retry)); };
            if (RequesterAmount > 1)
            {

                n.Click += (sender, e) => { onMigTextButtonClicked?.Invoke(this, new migTextRequestArgs(getInputs, DialogResult.Retry)); };


            }
            else
            {
                n.Click += (sender, e) => { onMigTextButtonClicked?.Invoke(this, new migTextRequestArgs(tbAnswer.ebText, DialogResult.Retry)); };

            }

            return n;
        }
        protected migButton genButtonIgnore(ref int offset, buttonPos pos, int buttonHeight)
        {
            migButton n = new migButton();

            switch (pos)
            {
                case buttonPos.left:
                    n = new migButton();
                    n.Text = "Ignore";
                    n.Left = offset;
                    offset += n.Width + 10;

                    n.Height = buttonHeight;
                    n.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
                    break;
                case buttonPos.mid:

                    n = new migButton();
                    n.Text = "Ignore";
                    n.Left = offset - n.Width / 2;


                    n.Height = buttonHeight;
                    n.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
                    break;
                case buttonPos.right:

                    n = new migButton();
                    n.Text = "Ignore";
                    n.Left = offset -= n.Width + 24;


                    n.Height = buttonHeight;
                    n.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
                    break;
            }
           // n.Click += (sender, e) => { onMigTextButtonClicked?.Invoke(sender, new migTextRequestArgs(tbAnswer.ebText, DialogResult.Ignore)); };
            if (RequesterAmount > 1)
            {

                n.Click += (sender, e) => { onMigTextButtonClicked?.Invoke(this, new migTextRequestArgs(getInputs, DialogResult.Ignore)); };


            }
            else
            {
                n.Click += (sender, e) => { onMigTextButtonClicked?.Invoke(this, new migTextRequestArgs(tbAnswer.ebText, DialogResult.Ignore)); };

            }
            return n;
        }
        protected migButton genButtonYes(ref int offset, buttonPos pos, int buttonHeight)
        {
            migButton n = new migButton();

            switch (pos)
            {
                case buttonPos.left:
                    n = new migButton();
                    n.Text = "Yes";
                    n.Left = offset;
                    offset += n.Width + 10;

                    n.Height = buttonHeight;
                    n.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;

                    break;
                case buttonPos.mid:

                    n = new migButton();
                    n.Text = "Yes";
                    n.Left = offset - n.Width / 2;


                    n.Height = buttonHeight;
                    n.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
                    break;
                case buttonPos.right:

                    n = new migButton();
                    n.Text = "Yes";
                    n.Left = (offset -= n.Width) + 0;

                    n.Height = buttonHeight;
                    n.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
                    break;
            }
           // n.Click += (sender, e) => { onMigTextButtonClicked?.Invoke(sender, new migTextRequestArgs(tbAnswer.ebText, DialogResult.Yes)); };
            if (RequesterAmount > 1)
            {

                n.Click += (sender, e) => { onMigTextButtonClicked?.Invoke(this, new migTextRequestArgs(getInputs, DialogResult.Yes)); };


            }
            else
            {
                n.Click += (sender, e) => { onMigTextButtonClicked?.Invoke(this, new migTextRequestArgs(tbAnswer.ebText, DialogResult.Yes)); };

            }


            return n;
        }
        protected migButton genButtonNo(ref int offset, buttonPos pos, int buttonHeight)
        {
            migButton n = new migButton();

            switch (pos)
            {
                case buttonPos.left:
                    n = new migButton();
                    n.Text = "No";
                    n.Left = offset;
                    offset += n.Width + 10;

                    n.Height = buttonHeight;
                    n.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;

                    break;
                case buttonPos.mid:

                    n = new migButton();
                    n.Text = "No";
                    n.Left = offset - n.Width / 2;


                    n.Height = buttonHeight;
                    n.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
                    break;
                case buttonPos.right:

                    n = new migButton();
                    n.Text = "No";
                    n.Left = (offset -= n.Width) + 8;

                    n.Height = buttonHeight;
                    n.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
                    break;
            }
            //n.Click += (sender, e) => { onMigTextButtonClicked?.Invoke(sender, new migTextRequestArgs(tbAnswer.ebText, DialogResult.No)); };
            if (RequesterAmount > 1)
            {

                n.Click += (sender, e) => { onMigTextButtonClicked?.Invoke(this, new migTextRequestArgs(getInputs, DialogResult.No)); };


            }
            else
            {
                n.Click += (sender, e) => { onMigTextButtonClicked?.Invoke(this, new migTextRequestArgs(tbAnswer.ebText, DialogResult.No)); };

            }


            return n;
        }
        public class migTextRequestArgs : EventArgs
        {
         
       

            public string answer { get; set; }
            public DialogResult? res { get; set; }

            private string[] _inputs;

            public string[] inputs
            {
                get { return _inputs; }
                set { _inputs = value; }
            }


            public migTextRequestArgs(string _answer)
            {

                answer = _answer;
            }
            public migTextRequestArgs(string _answer, DialogResult _res)
            {

                answer = _answer; res = _res;
            }

            public migTextRequestArgs(DialogResult _res)
            {

                res = _res;
            }

            public migTextRequestArgs(List<string> list, DialogResult _res)
            {
                this.inputs = list.ToArray();
                this.answer = string.Join(",", list);
                this.res = _res;
            }
        }

        public class migRequesterResult
        {
            public string input { get; set; }
            public string[] inputs { get; set; }
            public DialogResult res { get; set; }

            public migRequesterResult() { }
            public migRequesterResult(string i, DialogResult d) { input = i; res = d; }
            public migRequesterResult(string[] i, DialogResult d) { inputs = i; res = d; }

        }
        protected override void WndProc(ref Message m)
        {
            if (StopMoving)
            {

                const int WM_SYSCOMMAND = 0x0112;
                const int SC_MOVE = 0xF010;

                switch (m.Msg)
                {
                    case WM_SYSCOMMAND:
                        int command = m.WParam.ToInt32() & 0xfff0;
                        if (command == SC_MOVE)
                            return;
                        break;
                }
            }

            base.WndProc(ref m);
        }

        private void migRequester_Load(object sender, EventArgs e)
        {
            this.Width = lblQuestion.Width + 50;
            if (justMessage)
            {
                this.Height = this.Height - tbAnswer.Height;
                tbAnswer.Visible = false;
            }
            if (!justMessage && RequesterAmount > 1)
            {
                int width = ((tbAnswer.Width + 10) / RequesterAmount) - 10;

                tbAnswer.Width = width;
                Size tSize = TextRenderer.MeasureText(tbAnswer.ebText, globalMig.topaz_std12);


                inputs.Add(tbAnswer);
                int offset = tbAnswer.Width + 10;
                for (int i = 1; i < RequesterAmount; i++)
                {
                    migTextBox tbInputX = new migTextBox();
                    tbInputX.Name = "input" + i.ToString();
                    tbInputX.Width = width;
                    tbInputX.Left = offset + 10;
                    offset += tbInputX.Width + 10;
                    tbInputX.Top = tbAnswer.Top;
                    tbInputX.Height = tbAnswer.Height;
                    tbInputX.Pad = tbAnswer.Pad;
                    tbInputX.Padding = tbAnswer.Padding;
                    tbInputX.isSetPadding = tbAnswer.isSetPadding;
                    if (inputTexts.Count == RequesterAmount)
                    {
                        tbInputX.ebText = inputTexts[i];
                    }
                    this.Controls.Add(tbInputX);

                }
            }
            else
            {
                if (inputTexts.Count == 1)
                {
                    tbAnswer.ebText = inputTexts[0];
                }
                inputs.Add(tbAnswer);
            }
            int leftOffset = 0;
            int rightOffset = pnlButtons.Width + 4;
            int buttonHeight = 50;
            int midOffset = pnlButtons.Width / 2;
            switch (buttons)
            {
                case MessageBoxButtons.OK:
                default:
                    pnlButtons.Controls.Add(genButtonOk(ref leftOffset, buttonPos.left, buttonHeight));

                    break;
                case MessageBoxButtons.OKCancel:
                    pnlButtons.Controls.Add(genButtonOk(ref leftOffset, buttonPos.left, buttonHeight));
                    pnlButtons.Controls.Add(genButtonCancel(ref rightOffset, buttonPos.right, buttonHeight));
                    break;
                case MessageBoxButtons.AbortRetryIgnore:
                    pnlButtons.Controls.Add(genButtonAbort(ref leftOffset, buttonPos.left, buttonHeight));
                    pnlButtons.Controls.Add(genButtonRetry(ref rightOffset, buttonPos.right, buttonHeight));
                    pnlButtons.Controls.Add(genButtonIgnore(ref rightOffset, buttonPos.right, buttonHeight));

                    break;
                case MessageBoxButtons.RetryCancel:
                    pnlButtons.Controls.Add(genButtonRetry(ref leftOffset, buttonPos.left, buttonHeight));
                    pnlButtons.Controls.Add(genButtonCancel(ref rightOffset, buttonPos.right, buttonHeight));
                    break;
                case MessageBoxButtons.YesNo:
                    pnlButtons.Controls.Add(genButtonYes(ref leftOffset, buttonPos.left, buttonHeight));
                    pnlButtons.Controls.Add(genButtonNo(ref rightOffset, buttonPos.right, buttonHeight));
                    break;
                case MessageBoxButtons.YesNoCancel:
                    pnlButtons.Controls.Add(genButtonYes(ref leftOffset, buttonPos.left, buttonHeight));
                    pnlButtons.Controls.Add(genButtonCancel(ref rightOffset, buttonPos.right, buttonHeight));

                    pnlButtons.Controls.Add(genButtonNo(ref rightOffset, buttonPos.right, buttonHeight));
                    break;

            }
        }
    }
}
