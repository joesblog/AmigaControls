using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExampleApplication
{

   
    public partial class Form1 : migControls.migform
    {
        public string exampleList = @"-==A List Box Example==-
Lorem ipsum dolor sit amet, consectetuer adipiscing elit.
Aliquam tincidunt mauris eu risus.
Vestibulum auctor dapibus neque.
Nunc dignissim risus id metus.
Cras ornare tristique elit.
Vivamus vestibulum nulla nec ante.
Praesent placerat risus quis eros.
Fusce pellentesque suscipit nibh.
Integer vitae libero ac risus egestas placerat.
Vestibulum commodo felis quis tortor.
Ut aliquam sollicitudin leo.
Cras iaculis ultricies nulla.
Donec quis dui at dolor tempor interdum.
Vivamus molestie gravida turpis.
Fusce lobortis lorem at ipsum semper sagittis.
Nam convallis pellentesque nisl.
Integer malesuada commodo nulla.";
        public Form1()
        {
            InitializeComponent();
        }

        private void mbtnExample_Click(object sender, EventArgs e)
        {
            migListView1.Items = new List<ListViewItem>();

            foreach (string i in exampleList.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
            {
                migListView1.Items.Add(new ListViewItem(i));
            }
            migListView1.itemsBound();
        }

        private void migListView1_OnLabelClicked(object sender, migControls.migListView.migListViewLabelEventArgs e)
        {
            MessageBox.Show(e.Name);
        }
    }
}
