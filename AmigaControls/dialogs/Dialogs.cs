using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace migControls
{
    public class Dialogs
    {
        public static DialogResult MsgBox(Control parent, string title, string question = "", MessageBoxButtons buttons = MessageBoxButtons.OKCancel) {
            DialogResult d = DialogResult.None;

            migRequester n = new migRequester();
            n.buttons = buttons;

            n.justMessage = true;
            n.title = title;
            n.question = question;
            n.StopMoving = true;
            n.onMigTextButtonClicked += (sender, e) => { d = e.res.Value; n.Close(); };

            n.ShowDialog(parent);


            return d;
        }

        public static DialogResult MsgBox(string title, string question = "", MessageBoxButtons buttons = MessageBoxButtons.OKCancel)
        {
            DialogResult d = DialogResult.None;
            migRequester n = new migRequester();
            n.buttons = buttons;
            n.justMessage = true;
            n.title = title;
            n.question = question;
            n.StopMoving = true;
            n.onMigTextButtonClicked += (sender, e) => { d = e.res.Value; n.Close(); };
            n.ShowDialog();

            return d;
        }

        public static migRequester.migRequesterResult InputBox(string title, string question = "", int reqAmount = 1, MessageBoxButtons buttons = MessageBoxButtons.OKCancel, bool hideQuestioBox = false)
        {
            migRequester.migRequesterResult r = new migRequester.migRequesterResult();
            migRequester n = new migRequester();
            n.buttons = buttons;
            n.RequesterAmount = reqAmount;
            n.title = title;
            n.question = question;
            n.StopMoving = true;
            n.justMessage = hideQuestioBox;
            n.onMigTextButtonClicked += (sender, e) => { r.res = e.res.Value; r.input = n.answer; n.Close(); r.inputs = n.getInputs.ToArray(); };
            n.ShowDialog();


            return r;

        }

        public static migRequester.migRequesterResult InputBox(string title, List<string> inputText , string question = "", int reqAmount = 1, MessageBoxButtons buttons = MessageBoxButtons.OKCancel, bool hideQuestioBox = false)
        {
            migRequester.migRequesterResult r = new migRequester.migRequesterResult();
            migRequester n = new migRequester();
            n.buttons = buttons;
            n.inputTexts = inputText;
            n.RequesterAmount = reqAmount;

            n.title = title;
            n.question = question;
            n.StopMoving = true;
            n.justMessage = hideQuestioBox;
            n.onMigTextButtonClicked += (sender, e) => { r.res = e.res.Value; r.input = n.answer; n.Close(); };
            n.ShowDialog();


            return r;

        }

        public static migRequester.migRequesterResult InputBox(string title, string question = "", MessageBoxButtons buttons = MessageBoxButtons.OKCancel)
        {
            return InputBox(title, question, 1, buttons);
        }
    }
}
