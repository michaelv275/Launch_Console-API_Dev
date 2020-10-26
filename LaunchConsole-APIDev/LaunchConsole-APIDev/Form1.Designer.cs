namespace LaunchConsole_APIDev
{
    partial class OutputWindows
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
            this.FauxEngineOutput = new System.Windows.Forms.TextBox();
            this.FauxEngineOutputLabel = new System.Windows.Forms.TextBox();
            this.ConsoleApiOutput = new System.Windows.Forms.TextBox();
            this.ConsoleApiOutputLabel = new System.Windows.Forms.TextBox();
            this.RefreshFauxEngineButton = new System.Windows.Forms.Button();
            this.ReloadConsoleApiButton = new System.Windows.Forms.Button();
            this.ConsoleWebOutput = new System.Windows.Forms.TextBox();
            this.ConsoleWebOutputLabel = new System.Windows.Forms.TextBox();
            this.ClearFauxEngineButton = new System.Windows.Forms.Button();
            this.ClearAPITerminalButton = new System.Windows.Forms.Button();
            this.ClearWebTerminalButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FauxEngineOutput
            // 
            this.FauxEngineOutput.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FauxEngineOutput.BackColor = System.Drawing.SystemColors.ControlDark;
            this.FauxEngineOutput.Cursor = System.Windows.Forms.Cursors.Default;
            this.FauxEngineOutput.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FauxEngineOutput.Location = new System.Drawing.Point(360, 19);
            this.FauxEngineOutput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FauxEngineOutput.Multiline = true;
            this.FauxEngineOutput.Name = "FauxEngineOutput";
            this.FauxEngineOutput.ReadOnly = true;
            this.FauxEngineOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.FauxEngineOutput.Size = new System.Drawing.Size(1531, 300);
            this.FauxEngineOutput.TabIndex = 0;
            this.FauxEngineOutput.WordWrap = false;
            // 
            // FauxEngineOutputLabel
            // 
            this.FauxEngineOutputLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FauxEngineOutputLabel.BackColor = System.Drawing.SystemColors.Desktop;
            this.FauxEngineOutputLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FauxEngineOutputLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FauxEngineOutputLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.FauxEngineOutputLabel.Location = new System.Drawing.Point(42, 109);
            this.FauxEngineOutputLabel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FauxEngineOutputLabel.Name = "FauxEngineOutputLabel";
            this.FauxEngineOutputLabel.Size = new System.Drawing.Size(310, 42);
            this.FauxEngineOutputLabel.TabIndex = 1;
            this.FauxEngineOutputLabel.Text = "Faux-Engine Output";
            // 
            // ConsoleApiOutput
            // 
            this.ConsoleApiOutput.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ConsoleApiOutput.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ConsoleApiOutput.Cursor = System.Windows.Forms.Cursors.Default;
            this.ConsoleApiOutput.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsoleApiOutput.Location = new System.Drawing.Point(360, 363);
            this.ConsoleApiOutput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ConsoleApiOutput.Multiline = true;
            this.ConsoleApiOutput.Name = "ConsoleApiOutput";
            this.ConsoleApiOutput.ReadOnly = true;
            this.ConsoleApiOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ConsoleApiOutput.Size = new System.Drawing.Size(1531, 307);
            this.ConsoleApiOutput.TabIndex = 0;
            this.ConsoleApiOutput.WordWrap = false;
            // 
            // ConsoleApiOutputLabel
            // 
            this.ConsoleApiOutputLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ConsoleApiOutputLabel.BackColor = System.Drawing.SystemColors.Desktop;
            this.ConsoleApiOutputLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ConsoleApiOutputLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsoleApiOutputLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.ConsoleApiOutputLabel.Location = new System.Drawing.Point(42, 422);
            this.ConsoleApiOutputLabel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ConsoleApiOutputLabel.Name = "ConsoleApiOutputLabel";
            this.ConsoleApiOutputLabel.Size = new System.Drawing.Size(310, 42);
            this.ConsoleApiOutputLabel.TabIndex = 1;
            this.ConsoleApiOutputLabel.Text = "Console-API Output";
            // 
            // RefreshFauxEngineButton
            // 
            this.RefreshFauxEngineButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RefreshFauxEngineButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RefreshFauxEngineButton.Location = new System.Drawing.Point(86, 161);
            this.RefreshFauxEngineButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RefreshFauxEngineButton.Name = "RefreshFauxEngineButton";
            this.RefreshFauxEngineButton.Size = new System.Drawing.Size(204, 51);
            this.RefreshFauxEngineButton.TabIndex = 2;
            this.RefreshFauxEngineButton.Tag = "Faux";
            this.RefreshFauxEngineButton.Text = "Reload faux-engine";
            this.RefreshFauxEngineButton.UseVisualStyleBackColor = true;
            this.RefreshFauxEngineButton.Click += new System.EventHandler(this.RefreshTerminal_Click);
            // 
            // ReloadConsoleApiButton
            // 
            this.ReloadConsoleApiButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ReloadConsoleApiButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReloadConsoleApiButton.Location = new System.Drawing.Point(86, 474);
            this.ReloadConsoleApiButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ReloadConsoleApiButton.Name = "ReloadConsoleApiButton";
            this.ReloadConsoleApiButton.Size = new System.Drawing.Size(204, 51);
            this.ReloadConsoleApiButton.TabIndex = 2;
            this.ReloadConsoleApiButton.Tag = "API";
            this.ReloadConsoleApiButton.Text = "Reload Console-API";
            this.ReloadConsoleApiButton.UseVisualStyleBackColor = true;
            this.ReloadConsoleApiButton.Click += new System.EventHandler(this.RefreshTerminal_Click);
            // 
            // ConsoleWebOutput
            // 
            this.ConsoleWebOutput.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ConsoleWebOutput.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ConsoleWebOutput.Cursor = System.Windows.Forms.Cursors.Default;
            this.ConsoleWebOutput.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsoleWebOutput.Location = new System.Drawing.Point(360, 711);
            this.ConsoleWebOutput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ConsoleWebOutput.Multiline = true;
            this.ConsoleWebOutput.Name = "ConsoleWebOutput";
            this.ConsoleWebOutput.ReadOnly = true;
            this.ConsoleWebOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ConsoleWebOutput.Size = new System.Drawing.Size(1531, 301);
            this.ConsoleWebOutput.TabIndex = 0;
            this.ConsoleWebOutput.WordWrap = false;
            // 
            // ConsoleWebOutputLabel
            // 
            this.ConsoleWebOutputLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ConsoleWebOutputLabel.BackColor = System.Drawing.SystemColors.Desktop;
            this.ConsoleWebOutputLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ConsoleWebOutputLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsoleWebOutputLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.ConsoleWebOutputLabel.Location = new System.Drawing.Point(42, 785);
            this.ConsoleWebOutputLabel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ConsoleWebOutputLabel.Name = "ConsoleWebOutputLabel";
            this.ConsoleWebOutputLabel.Size = new System.Drawing.Size(310, 42);
            this.ConsoleWebOutputLabel.TabIndex = 1;
            this.ConsoleWebOutputLabel.Text = "Console-Web Output";
            // 
            // ClearFauxEngineButton
            // 
            this.ClearFauxEngineButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ClearFauxEngineButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClearFauxEngineButton.Location = new System.Drawing.Point(86, 220);
            this.ClearFauxEngineButton.Name = "ClearFauxEngineButton";
            this.ClearFauxEngineButton.Size = new System.Drawing.Size(204, 48);
            this.ClearFauxEngineButton.TabIndex = 3;
            this.ClearFauxEngineButton.Tag = "Faux";
            this.ClearFauxEngineButton.Text = "Clear terminal";
            this.ClearFauxEngineButton.UseVisualStyleBackColor = true;
            this.ClearFauxEngineButton.Click += new System.EventHandler(this.ClearTerminal_Click);
            // 
            // ClearAPITerminalButton
            // 
            this.ClearAPITerminalButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ClearAPITerminalButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClearAPITerminalButton.Location = new System.Drawing.Point(86, 533);
            this.ClearAPITerminalButton.Name = "ClearAPITerminalButton";
            this.ClearAPITerminalButton.Size = new System.Drawing.Size(204, 48);
            this.ClearAPITerminalButton.TabIndex = 3;
            this.ClearAPITerminalButton.Tag = "API";
            this.ClearAPITerminalButton.Text = "Clear terminal";
            this.ClearAPITerminalButton.UseVisualStyleBackColor = true;
            this.ClearAPITerminalButton.Click += new System.EventHandler(this.ClearTerminal_Click);
            // 
            // ClearWebTerminalButton
            // 
            this.ClearWebTerminalButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ClearWebTerminalButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClearWebTerminalButton.Location = new System.Drawing.Point(86, 835);
            this.ClearWebTerminalButton.Name = "ClearWebTerminalButton";
            this.ClearWebTerminalButton.Size = new System.Drawing.Size(204, 48);
            this.ClearWebTerminalButton.TabIndex = 3;
            this.ClearWebTerminalButton.Tag = "Web";
            this.ClearWebTerminalButton.Text = "Clear terminal";
            this.ClearWebTerminalButton.UseVisualStyleBackColor = true;
            this.ClearWebTerminalButton.Click += new System.EventHandler(this.ClearTerminal_Click);
            // 
            // OutputWindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(1920, 1156);
            this.Controls.Add(this.ClearWebTerminalButton);
            this.Controls.Add(this.ClearAPITerminalButton);
            this.Controls.Add(this.ClearFauxEngineButton);
            this.Controls.Add(this.ReloadConsoleApiButton);
            this.Controls.Add(this.RefreshFauxEngineButton);
            this.Controls.Add(this.ConsoleWebOutputLabel);
            this.Controls.Add(this.ConsoleApiOutputLabel);
            this.Controls.Add(this.FauxEngineOutputLabel);
            this.Controls.Add(this.ConsoleWebOutput);
            this.Controls.Add(this.ConsoleApiOutput);
            this.Controls.Add(this.FauxEngineOutput);
            this.Name = "OutputWindows";
            this.Text = "Console-API Dev Environment";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OutputWindows_FormClosing);
            this.Load += new System.EventHandler(this.OutputWindows_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FauxEngineOutput;
        private System.Windows.Forms.TextBox FauxEngineOutputLabel;
        private System.Windows.Forms.TextBox ConsoleApiOutput;
        private System.Windows.Forms.TextBox ConsoleApiOutputLabel;
        private System.Windows.Forms.Button RefreshFauxEngineButton;
        private System.Windows.Forms.Button ReloadConsoleApiButton;
        private System.Windows.Forms.TextBox ConsoleWebOutput;
        private System.Windows.Forms.TextBox ConsoleWebOutputLabel;
        private System.Windows.Forms.Button ClearFauxEngineButton;
        private System.Windows.Forms.Button ClearAPITerminalButton;
        private System.Windows.Forms.Button ClearWebTerminalButton;
    }
}

