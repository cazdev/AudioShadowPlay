namespace AudioShadowPlay
{
    partial class ASP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ASP));
            this.RestartRecording = new System.Windows.Forms.Timer(this.components);
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlRecording = new System.Windows.Forms.Panel();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.btnSaveDir = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSamplingRate = new System.Windows.Forms.TextBox();
            this.chkLog = new System.Windows.Forms.CheckBox();
            this.lblTick = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFileExpire = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTempSave = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSettings = new System.Windows.Forms.Button();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // RestartRecording
            // 
            this.RestartRecording.Interval = 30000;
            this.RestartRecording.Tick += new System.EventHandler(this.RestartRecording_Tick);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(129, 50);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(123, 54);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start ASP";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnStop.Enabled = false;
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Location = new System.Drawing.Point(129, 241);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(123, 54);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop ASP";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(119, 144);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(143, 63);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save Audio";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // pnlRecording
            // 
            this.pnlRecording.BackColor = System.Drawing.Color.Maroon;
            this.pnlRecording.Location = new System.Drawing.Point(368, 12);
            this.pnlRecording.Name = "pnlRecording";
            this.pnlRecording.Size = new System.Drawing.Size(20, 20);
            this.pnlRecording.TabIndex = 3;
            this.pnlRecording.Visible = false;
            // 
            // pnlSettings
            // 
            this.pnlSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.pnlSettings.Controls.Add(this.btnSaveDir);
            this.pnlSettings.Controls.Add(this.label4);
            this.pnlSettings.Controls.Add(this.txtSamplingRate);
            this.pnlSettings.Controls.Add(this.chkLog);
            this.pnlSettings.Controls.Add(this.lblTick);
            this.pnlSettings.Controls.Add(this.label2);
            this.pnlSettings.Controls.Add(this.txtFileExpire);
            this.pnlSettings.Controls.Add(this.btnApply);
            this.pnlSettings.Controls.Add(this.label1);
            this.pnlSettings.Controls.Add(this.txtTempSave);
            this.pnlSettings.Location = new System.Drawing.Point(12, 68);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(161, 213);
            this.pnlSettings.TabIndex = 6;
            this.pnlSettings.Visible = false;
            // 
            // btnSaveDir
            // 
            this.btnSaveDir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSaveDir.FlatAppearance.BorderSize = 0;
            this.btnSaveDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveDir.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveDir.ForeColor = System.Drawing.Color.White;
            this.btnSaveDir.Location = new System.Drawing.Point(6, 177);
            this.btnSaveDir.Name = "btnSaveDir";
            this.btnSaveDir.Size = new System.Drawing.Size(37, 28);
            this.btnSaveDir.TabIndex = 13;
            this.btnSaveDir.Text = "📂";
            this.btnSaveDir.UseVisualStyleBackColor = false;
            this.btnSaveDir.Click += new System.EventHandler(this.BtnSaveDir_Click);
            // 
            // label4
            // 
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(4, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 37);
            this.label4.TabIndex = 12;
            this.label4.Text = "Sampling rate";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.label4, "Samples per second (default = 32000)");
            // 
            // txtSamplingRate
            // 
            this.txtSamplingRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.txtSamplingRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSamplingRate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSamplingRate.ForeColor = System.Drawing.Color.White;
            this.txtSamplingRate.Location = new System.Drawing.Point(76, 96);
            this.txtSamplingRate.Name = "txtSamplingRate";
            this.txtSamplingRate.Size = new System.Drawing.Size(75, 23);
            this.txtSamplingRate.TabIndex = 11;
            this.txtSamplingRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkLog
            // 
            this.chkLog.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkLog.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkLog.ForeColor = System.Drawing.Color.White;
            this.chkLog.Location = new System.Drawing.Point(6, 128);
            this.chkLog.Name = "chkLog";
            this.chkLog.Size = new System.Drawing.Size(83, 37);
            this.chkLog.TabIndex = 10;
            this.chkLog.Text = "Enable files log\r\n";
            this.chkLog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.chkLog, "Show the files log (default = disabled)");
            this.chkLog.UseVisualStyleBackColor = true;
            this.chkLog.CheckedChanged += new System.EventHandler(this.ChkLog_CheckedChanged);
            // 
            // lblTick
            // 
            this.lblTick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTick.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTick.ForeColor = System.Drawing.Color.Lime;
            this.lblTick.Location = new System.Drawing.Point(116, 177);
            this.lblTick.Name = "lblTick";
            this.lblTick.Size = new System.Drawing.Size(41, 28);
            this.lblTick.TabIndex = 9;
            this.lblTick.Text = "✔️";
            this.lblTick.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTick.Visible = false;
            // 
            // label2
            // 
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 37);
            this.label2.TabIndex = 4;
            this.label2.Text = "Temp file expire";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.label2, "Time before temp files are deleted (default = 120)");
            // 
            // txtFileExpire
            // 
            this.txtFileExpire.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.txtFileExpire.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFileExpire.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileExpire.ForeColor = System.Drawing.Color.White;
            this.txtFileExpire.Location = new System.Drawing.Point(76, 54);
            this.txtFileExpire.Name = "txtFileExpire";
            this.txtFileExpire.Size = new System.Drawing.Size(75, 23);
            this.txtFileExpire.TabIndex = 3;
            this.txtFileExpire.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFileExpire.TextChanged += new System.EventHandler(this.TxtFileExpire_TextChanged);
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnApply.FlatAppearance.BorderSize = 0;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.ForeColor = System.Drawing.Color.White;
            this.btnApply.Location = new System.Drawing.Point(51, 177);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(62, 28);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Temp file length";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.label1, "Length of temp audio files (default = 30)");
            // 
            // txtTempSave
            // 
            this.txtTempSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.txtTempSave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTempSave.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTempSave.ForeColor = System.Drawing.Color.White;
            this.txtTempSave.Location = new System.Drawing.Point(76, 13);
            this.txtTempSave.Name = "txtTempSave";
            this.txtTempSave.Size = new System.Drawing.Size(75, 23);
            this.txtTempSave.TabIndex = 0;
            this.txtTempSave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTempSave.TextChanged += new System.EventHandler(this.TxtTempSave_TextChanged);
            this.txtTempSave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtTempSave_KeyPress);
            // 
            // label3
            // 
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(302, 321);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "v1.2.4";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lstFiles
            // 
            this.lstFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lstFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstFiles.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFiles.ForeColor = System.Drawing.Color.White;
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.ItemHeight = 15;
            this.lstFiles.Location = new System.Drawing.Point(271, 83);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(120, 180);
            this.lstFiles.TabIndex = 9;
            this.lstFiles.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::AudioShadowPlay.Properties.Resources.Speaker_512;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(346, 296);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 42);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // btnSettings
            // 
            this.btnSettings.BackgroundImage = global::AudioShadowPlay.Properties.Resources.Settings_01;
            this.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.Location = new System.Drawing.Point(12, 12);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(53, 50);
            this.btnSettings.TabIndex = 5;
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // ASP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.ClientSize = new System.Drawing.Size(400, 350);
            this.Controls.Add(this.lstFiles);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.pnlRecording);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ASP";
            this.Text = "AudioShadowPlay";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ASP_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.ASP_Click);
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer RestartRecording;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlRecording;
        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.TextBox txtTempSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFileExpire;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTick;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.CheckBox chkLog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSamplingRate;
        private System.Windows.Forms.Button btnSaveDir;
    }
}

