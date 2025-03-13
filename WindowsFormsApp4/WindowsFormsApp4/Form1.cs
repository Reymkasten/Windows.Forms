using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        private ToolStripMenuItem lastfilesMenu;
        private ToolStripMenuItem darkTheme;
        private ToolStripMenuItem lightTheme;

        public Form1()
        {
            InitializeComponent();

            MenuStrip menuStrip = new MenuStrip();

            var fileMenu = new ToolStripMenuItem("File");
            var editMenu = new ToolStripMenuItem("Edit");
            var helpMenu = new ToolStripMenuItem("Help");
            var viewMenu = new ToolStripMenuItem("View");
            lastfilesMenu = new ToolStripMenuItem("Last Files");

            fileMenu.DropDownItems.Add(new ToolStripMenuItem("Open", null, Open_Click) { ShortcutKeys = Keys.Control | Keys.O });
            fileMenu.DropDownItems.Add(new ToolStripMenuItem("Save", null, Save_Click) { ShortcutKeys = Keys.Control | Keys.S });
            fileMenu.DropDownItems.Add(new ToolStripSeparator());
            fileMenu.DropDownItems.Add(new ToolStripMenuItem("Exit", null, Exit_Click) { ShortcutKeys = Keys.Control | Keys.X });

            darkTheme = new ToolStripMenuItem("Dark", null, darkTheme_Click) { CheckOnClick = true };
            lightTheme = new ToolStripMenuItem("Light", null, lightTheme_Click) { CheckOnClick = true };

            var Theme = new ToolStripMenuItem("Theme");
            var Options = new ToolStripMenuItem("Options");

            viewMenu.DropDownItems.Add(Theme);
            viewMenu.DropDownItems.Add(Options);

            Theme.DropDownItems.Add(darkTheme);
            Theme.DropDownItems.Add(lightTheme);

            var showToolbar = new ToolStripMenuItem("Show Toolbar") { CheckOnClick = true };
            var showStatusBar = new ToolStripMenuItem("Show Status Bar") { CheckOnClick = true };

            Options.DropDownItems.Add(showToolbar);
            Options.DropDownItems.Add(showStatusBar);

            lastfilesMenu.DropDownItems.Add("Add", null, Addfiles);

            menuStrip.Items.Add(fileMenu);
            menuStrip.Items.Add(editMenu);
            menuStrip.Items.Add(helpMenu);
            menuStrip.Items.Add(viewMenu);
            menuStrip.Items.Add(lastfilesMenu);

            this.MainMenuStrip = menuStrip;

            var contexMenu = new ContextMenuStrip();
            contexMenu.Items.Add("Paste", null, paste_Click);
            contexMenu.Items.Add("Delete", null, delete_Click);
            contexMenu.Items.Add("Copy", null, copy_Click);

            this.ContextMenuStrip = contexMenu;

            this.Controls.Add(menuStrip);
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            MessageBox.Show(item.Text);
        }

        private void Open_Click(object sender, EventArgs e)
        {
            MessageBox.Show("File Opened");
        }

        private void Save_Click(object sender, EventArgs e)
        {
            MessageBox.Show("File Saved");
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void darkTheme_Click(object sender, EventArgs e)
        {
            darkTheme.Checked = true;
            lightTheme.Checked = false;
            this.BackColor = Color.Black;
        }

        private void lightTheme_Click(object sender, EventArgs e)
        {
            lightTheme.Checked = true;
            darkTheme.Checked = false;
            this.BackColor = Color.White;
        }

        private void delete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Delete");
        }

        private void copy_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Copy");
        }

        private void paste_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Paste");
        }

        private void Addfiles(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var filepath = openFileDialog.FileName;
                var recentFileItem = new ToolStripMenuItem(filepath, null, RecentFile_Click);
                lastfilesMenu.DropDownItems.Add(recentFileItem);
            }
        }

        private void RecentFile_Click(object sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            MessageBox.Show(item.Text);
        }

        private void instrument_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Instrument");
        }

        private void status_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Status Bar");
        }
    }
}
