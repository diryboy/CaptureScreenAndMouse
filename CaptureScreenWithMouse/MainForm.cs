using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CaptureScreenWithMouse
{
    public partial class MainForm : Form
    {
        const string StartUpMinimized = "StartUpMinimized";

        public MainForm()
        {
            InitializeComponent();
            Opacity = 0;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var hotkey = new HotKey(control: true, key: Keys.PrintScreen);
            hotkey.Pressed += Hotkey_Pressed;
            hotkey.Register(this);

            BeginInvoke(new Action(() =>
            {
                if (File.Exists(StartUpMinimized))
                {
                    CheckBox_StartUpMinimized.Checked = true;
                    Visible = false;
                }
                else
                {
                    Visible = true;
                }

                this.Opacity = 1;
            }));
        }

        void Hotkey_Pressed(object sender, HandledEventArgs e)
        {
            var bitmap = ScreenCapturer.Capture();
            Clipboard.SetImage(bitmap);
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
            if ((DateTime.Now - TimeLastDeactivated).TotalMilliseconds < 500)
            {
                Visible = true;
            }

            Visible = !Visible;
            if (Visible)
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Minimized;
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
                Visible = false;
                e.Cancel = true;
            }
        }

        DateTime TimeLastDeactivated;
        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            TimeLastDeactivated = DateTime.Now;
            Visible = false;
        }

        private void CheckBox_StartUpMinimized_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_StartUpMinimized.Checked)
            {
                File.WriteAllText(StartUpMinimized, "");
            }
            else
            {
                if (File.Exists(StartUpMinimized))
                {
                    File.Delete(StartUpMinimized);
                }
            }
        }
    }
}
