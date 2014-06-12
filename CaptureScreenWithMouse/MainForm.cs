using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CaptureScreenWithMouse
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            var hotkey = new HotKey(control: true, key: Keys.PrintScreen);
            hotkey.Pressed += Hotkey_Pressed;
            hotkey.Register(this);
        }

        void Hotkey_Pressed(object sender, HandledEventArgs e)
        {
            var bitmap = ScreenCapturer.Capture();
            Clipboard.SetImage(bitmap);
        }

        private void ConfigForm_SizeChanged(object sender, EventArgs e)
        {
            if (ClientSize.IsEmpty)
            {
                Hide();
            }
        }

        private void SysTrayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ToggleShowHide();
            }
        }

        private void ToggleShowHide()
        {
            if (Visible)
            {
                Hide();
            }
            else
            {
                Show();
            }
        }

        private void ToolStripMenuItem_Toggle_Click(object sender, EventArgs e)
        {
            ToggleShowHide();
        }

        private void ToolStripMenuItem_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ConfigForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Hide();
                e.Cancel = true;
            }
        }

        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
