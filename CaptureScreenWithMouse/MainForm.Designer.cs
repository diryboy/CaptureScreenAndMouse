namespace CaptureScreenWithMouse
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.SysTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.TrayIconContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_Toggle = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.Label_HotKeyTips = new System.Windows.Forms.Label();
            this.Label_Usage = new System.Windows.Forms.Label();
            this.TrayIconContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // SysTrayIcon
            // 
            this.SysTrayIcon.ContextMenuStrip = this.TrayIconContextMenuStrip;
            this.SysTrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("SysTrayIcon.Icon")));
            this.SysTrayIcon.Text = "Capture Config";
            this.SysTrayIcon.Visible = true;
            this.SysTrayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SysTrayIcon_MouseClick);
            // 
            // TrayIconContextMenuStrip
            // 
            this.TrayIconContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Toggle,
            this.ToolStripMenuItem_Exit});
            this.TrayIconContextMenuStrip.Name = "TrayIconContextMenuStrip";
            this.TrayIconContextMenuStrip.Size = new System.Drawing.Size(112, 48);
            // 
            // ToolStripMenuItem_Toggle
            // 
            this.ToolStripMenuItem_Toggle.Name = "ToolStripMenuItem_Toggle";
            this.ToolStripMenuItem_Toggle.Size = new System.Drawing.Size(111, 22);
            this.ToolStripMenuItem_Toggle.Text = "&Toggle";
            this.ToolStripMenuItem_Toggle.Click += new System.EventHandler(this.ToolStripMenuItem_Toggle_Click);
            // 
            // ToolStripMenuItem_Exit
            // 
            this.ToolStripMenuItem_Exit.Name = "ToolStripMenuItem_Exit";
            this.ToolStripMenuItem_Exit.Size = new System.Drawing.Size(111, 22);
            this.ToolStripMenuItem_Exit.Text = "&Exit";
            this.ToolStripMenuItem_Exit.Click += new System.EventHandler(this.ToolStripMenuItem_Exit_Click);
            // 
            // Label_HotKeyTips
            // 
            this.Label_HotKeyTips.AutoSize = true;
            this.Label_HotKeyTips.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_HotKeyTips.Location = new System.Drawing.Point(28, 9);
            this.Label_HotKeyTips.Name = "Label_HotKeyTips";
            this.Label_HotKeyTips.Size = new System.Drawing.Size(376, 27);
            this.Label_HotKeyTips.TabIndex = 0;
            this.Label_HotKeyTips.Text = "Press Ctrl + PrintScreen !";
            // 
            // Label_Usage
            // 
            this.Label_Usage.AutoSize = true;
            this.Label_Usage.Location = new System.Drawing.Point(51, 46);
            this.Label_Usage.Name = "Label_Usage";
            this.Label_Usage.Size = new System.Drawing.Size(330, 65);
            this.Label_Usage.TabIndex = 1;
            this.Label_Usage.Text = resources.GetString("Label_Usage.Text");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 126);
            this.Controls.Add(this.Label_Usage);
            this.Controls.Add(this.Label_HotKeyTips);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Capture screen and cursor!";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigForm_FormClosing);
            this.SizeChanged += new System.EventHandler(this.ConfigForm_SizeChanged);
            this.TrayIconContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon SysTrayIcon;
        private System.Windows.Forms.Label Label_HotKeyTips;
        private System.Windows.Forms.ContextMenuStrip TrayIconContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Toggle;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Exit;
        private System.Windows.Forms.Label Label_Usage;
    }
}

