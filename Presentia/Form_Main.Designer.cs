namespace Presentia {
    partial class Form_Main {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if( disposing && (components != null) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.pbVideo = new System.Windows.Forms.ProgressBar();
            this.btnPause = new System.Windows.Forms.Button();
            this.lbCurrent_Time = new System.Windows.Forms.Label();
            this.lbMax_Time = new System.Windows.Forms.Label();
            this.imgDisplay = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // pbVideo
            // 
            this.pbVideo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbVideo.BackColor = System.Drawing.Color.Black;
            this.pbVideo.ForeColor = System.Drawing.Color.Red;
            this.pbVideo.Location = new System.Drawing.Point(8, 432);
            this.pbVideo.MarqueeAnimationSpeed = 20;
            this.pbVideo.Maximum = 1000;
            this.pbVideo.Name = "pbVideo";
            this.pbVideo.Size = new System.Drawing.Size(784, 10);
            this.pbVideo.Step = 1;
            this.pbVideo.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbVideo.TabIndex = 2;
            this.pbVideo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbVideo_MouseDown);
            this.pbVideo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbVideo_MouseUp);
            // 
            // btnPause
            // 
            this.btnPause.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPause.Image = global::Presentia.Properties.Resources.pause2;
            this.btnPause.Location = new System.Drawing.Point(375, 375);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(50, 50);
            this.btnPause.TabIndex = 3;
            this.btnPause.UseVisualStyleBackColor = false;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // lbCurrent_Time
            // 
            this.lbCurrent_Time.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbCurrent_Time.BackColor = System.Drawing.Color.Transparent;
            this.lbCurrent_Time.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbCurrent_Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCurrent_Time.Location = new System.Drawing.Point(12, 397);
            this.lbCurrent_Time.Name = "lbCurrent_Time";
            this.lbCurrent_Time.Size = new System.Drawing.Size(357, 30);
            this.lbCurrent_Time.TabIndex = 4;
            this.lbCurrent_Time.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbMax_Time
            // 
            this.lbMax_Time.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbMax_Time.BackColor = System.Drawing.Color.Transparent;
            this.lbMax_Time.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbMax_Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMax_Time.Location = new System.Drawing.Point(431, 397);
            this.lbMax_Time.Name = "lbMax_Time";
            this.lbMax_Time.Size = new System.Drawing.Size(357, 30);
            this.lbMax_Time.TabIndex = 5;
            this.lbMax_Time.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imgDisplay
            // 
            this.imgDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgDisplay.BackColor = System.Drawing.SystemColors.Desktop;
            this.imgDisplay.Location = new System.Drawing.Point(0, 0);
            this.imgDisplay.Name = "imgDisplay";
            this.imgDisplay.Size = new System.Drawing.Size(800, 449);
            this.imgDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgDisplay.TabIndex = 0;
            this.imgDisplay.TabStop = false;
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbMax_Time);
            this.Controls.Add(this.lbCurrent_Time);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.pbVideo);
            this.Controls.Add(this.imgDisplay);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Name = "Form_Main";
            this.Text = "Presentia";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_Main_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.imgDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ProgressBar pbVideo;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Label lbCurrent_Time;
        private System.Windows.Forms.Label lbMax_Time;
        private System.Windows.Forms.PictureBox imgDisplay;
    }
}

