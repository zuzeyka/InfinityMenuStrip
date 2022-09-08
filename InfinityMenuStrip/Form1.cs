using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfinityMenuStrip
{
    public partial class Form1 : Form
    {
        MenuStrip menuStrip1;
        int counter = 1;
        ToolStripMenuItem parent;
        public Form1()
        {
            InitializeComponent();
            menuStrip1 = new MenuStrip();
            this.Controls.Add(menuStrip1);
            menuStrip1.Items.Add(parent = new ToolStripMenuItem(counter.ToString()));
            parent.MouseHover += ItemMouseHover;
        }

        private void ItemMouseHover(object sender, EventArgs e)
        {
            parent.DropDownItems.Add(parent = new ToolStripMenuItem(counter.ToString()));
            parent.MouseHover += ItemMouseHover;
            counter++;
        }
    }
}
