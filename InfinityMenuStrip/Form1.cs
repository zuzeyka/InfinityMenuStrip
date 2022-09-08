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
    internal struct Point3
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        internal Point3(double X, double Y, double Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }
    }
    public partial class Form1 : Form
    {
        internal MenuStrip menuStrip;
        internal ContextMenu contextMenu;
        internal Point3 objects_count = new Point3(3, 3, 3);
        internal ToolStripMenuItem parent;
        internal int counter = 1;
        public Form1()
        {
            InitializeComponent();
            menuStrip = new MenuStrip();
            contextMenu = new ContextMenu();
            this.Controls.Add(menuStrip);
            menuStrip.Items.Add(parent = new ToolStripMenuItem(counter.ToString()));
            parent.MouseHover += ItemMouseHover;
            contextMenu.MenuItems.Add(new MenuItem($"Button({objects_count.X})"));
            contextMenu.MenuItems.Add(new MenuItem($"Text({objects_count.Y})"));
            contextMenu.MenuItems.Add(new MenuItem($"Check({objects_count.Z})"));
            this.ContextMenu = contextMenu;
            contextMenu.MenuItems[0].Click += AddButton;
            contextMenu.MenuItems[1].Click += AddText;
            contextMenu.MenuItems[2].Click += AddCheck;
        }

        private void ItemMouseHover(object sender, EventArgs e)
        {
            parent.DropDownItems.Add(parent = new ToolStripMenuItem(counter.ToString()));
            parent.MouseHover += ItemMouseHover;
            counter++;
        }

        private void AddButton(object sender, EventArgs e)
        {
            if (objects_count.X > 0)
            {
                var button = new Button();
                this.Controls.Add(button);
                button.Location = new Point(MousePosition.X, MousePosition.Y);
                objects_count.X--;
                contextMenu.MenuItems[0].Text = $"Button({objects_count.X})";
            }
            else
                contextMenu.MenuItems[0].Enabled = false;
            
        }
        private void AddText(object sender, EventArgs e)
        {
            if (objects_count.Y > 0)
            {
                var text = new TextBox();
                this.Controls.Add(text);
                text.Location = new Point(MousePosition.X, MousePosition.Y);
                objects_count.Y--;
                contextMenu.MenuItems[1].Text = $"Text({objects_count.Y})";
            }
            else
                contextMenu.MenuItems[1].Enabled = false;
        }

        private void AddCheck(object sender, EventArgs e)
        {
            if (objects_count.Z > 0)
            {
                var check = new CheckBox();
                this.Controls.Add(check);
                check.Location = new Point(MousePosition.X, MousePosition.Y);
                objects_count.Z--;
                contextMenu.MenuItems[2].Text = $"Check({objects_count.Z})";
            }
            else
                contextMenu.MenuItems[2].Enabled = false;
        }
    }
}
