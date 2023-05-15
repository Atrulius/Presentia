using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Presentia {

    public partial class Form_Main : System.Windows.Forms.Form {

        bool bUsing_Slider = false;

        bool bMoved_Mouse = true;

        bool bPaused = false;

        float fLast_Mouse_X = 0;
        float fLast_Mouse_Y = 0;

        float fBar_Position_Y = 0;

        int pbPosition_Y;
        int btnPosition_Y;
        int lbCurrent_Position_Y;
        int lbMax_Position_Y;

        Stopwatch Mouse_Moved = new Stopwatch();

        public Form_Main() {

            InitializeComponent();
        }

        private void Form_Main_Load( object sender, EventArgs e ) {

            foreach (System.Drawing.Image image in Global.images) {

                imgDisplay.Image = image;
            }

            KeyPreview = true;

            Mouse_Moved.Start();
            Global.output.Play();

            pbPosition_Y = pbVideo.Location.Y - this.Size.Height;
            btnPosition_Y = btnPause.Location.Y - this.Size.Height;
            lbCurrent_Position_Y = lbCurrent_Time.Location.Y - this.Size.Height;
            lbMax_Position_Y = lbMax_Time.Location.Y - this.Size.Height;

            lbMax_Time.Text = Global.Time_Format((int)Global.reader.TotalTime.TotalSeconds);
            lbCurrent_Time.Parent = imgDisplay;
            lbMax_Time.Parent = imgDisplay;
        }

        private void timer_Tick( object sender, EventArgs e ) {

            if ((fLast_Mouse_X != MousePosition.X ||
                 fLast_Mouse_Y != MousePosition.Y) &&
                 MousePosition.X > this.Location.X &&
                 MousePosition.Y > this.Location.Y &&
                 MousePosition.X < this.Location.X + this.Width &&
                 MousePosition.Y < this.Location.Y + this.Height &&
                 Mouse_Moved.IsRunning && !bPaused) {

                Mouse_Moved.Restart();
            }

            fLast_Mouse_X = MousePosition.X;
            fLast_Mouse_Y = MousePosition.Y;

            double milliseconds = Global.reader.CurrentTime.TotalMilliseconds;

            if (Mouse_Moved.ElapsedMilliseconds < 2500) {

                fBar_Position_Y -= 0.05f;

                if (!bMoved_Mouse) Cursor.Show();

                bMoved_Mouse = true;
            } else {

                fBar_Position_Y += 0.05f;

                if (bMoved_Mouse) Cursor.Hide();

                bMoved_Mouse = false;
            }

            if ( fBar_Position_Y > 1 ) {
                fBar_Position_Y = 1;
            }
            if( fBar_Position_Y < 0 ) {
                fBar_Position_Y = 0;
            }

            btnPause.Location = new System.Drawing.Point(btnPause.Location.X, this.Size.Height + btnPosition_Y + (int)(fBar_Position_Y * fBar_Position_Y * 76) );
            pbVideo.Location = new System.Drawing.Point(pbVideo.Location.X, this.Size.Height + pbPosition_Y + (int)(fBar_Position_Y * fBar_Position_Y * 76));
            lbCurrent_Time.Location = new System.Drawing.Point( lbCurrent_Time.Location.X, this.Size.Height + lbCurrent_Position_Y + (int)(fBar_Position_Y * fBar_Position_Y * 76) );
            lbMax_Time.Location = new System.Drawing.Point( lbMax_Time.Location.X, this.Size.Height + lbMax_Position_Y + (int)(fBar_Position_Y * fBar_Position_Y * 76) );

            if( !bUsing_Slider ) {

                pbVideo.Value = (int)(1000 * (double)Global.reader.CurrentTime.TotalMilliseconds / (double)Global.reader.TotalTime.TotalMilliseconds);
            }
            else {

                int value = (int)((float)(MousePosition.X - this.Location.X - pbVideo.Location.X * 2) / pbVideo.Size.Width * 1000);

                if (value >= pbVideo.Minimum && value <= pbVideo.Maximum) {

                    pbVideo.Value = value;
                } else if (value < pbVideo.Minimum) {

                    pbVideo.Value = pbVideo.Minimum;
                } else if (value > pbVideo.Maximum) {

                    pbVideo.Value = pbVideo.Maximum;
                }

                milliseconds = (float)value / 1000 * Global.reader.TotalTime.TotalMilliseconds;
            }

            if (milliseconds < 0.0) {

                milliseconds = 0;
            } else if (milliseconds > Global.reader.TotalTime.TotalMilliseconds) {

                milliseconds = Global.reader.TotalTime.TotalMilliseconds;
            }

            lbCurrent_Time.Text = Global.Time_Format( (int)Math.Floor((float)milliseconds / 1000) );

            for ( int i = 0 ; i < Global.times.Count - 1 ; i++ ) {

                if ( milliseconds >= Global.times[i] &&
                    milliseconds < Global.times[i + 1] ) {

                    imgDisplay.Image = Global.images[i];

                    return;
                }
            }

            imgDisplay.Image = Global.images[Global.images.Count - 1];
        }

        private void pbVideo_MouseDown( object sender, MouseEventArgs e ) {

            bUsing_Slider = true;
            Global.output.Stop();

            Mouse_Moved.Stop();
        }

        private void pbVideo_MouseUp( object sender, MouseEventArgs e ) {

            bUsing_Slider = false;

            TimeSpan time = TimeSpan.FromMilliseconds((float)pbVideo.Value / 1000 * Global.reader.TotalTime.TotalMilliseconds);

            Global.reader.CurrentTime = time;

            Global.output.Stop();
            Global.output.Init(Global.reader);

            if( !bPaused ) {

                Global.output.Play();
            }

            if (!bPaused) {
                Mouse_Moved.Restart();
            }
        }

        private void btnPause_Click( object sender, EventArgs e ) {

            bPaused = !bPaused;

            if (!bPaused) {

                btnPause.Image = System.Drawing.Image.FromFile( Global.appPath + "\\images\\pause2.png" );
                Global.output.Play();

                Mouse_Moved.Restart();
            } else {

                btnPause.Image = System.Drawing.Image.FromFile( Global.appPath + "\\images\\play2.png" );
                Global.output.Pause();

                Mouse_Moved.Reset();
            }
        }

        private void Form_Main_KeyDown( object sender, KeyEventArgs e ) {

            if( e.KeyCode.ToString() == "F11" ) {

                if( FormBorderStyle == FormBorderStyle.Sizable ) {
                    FormBorderStyle = FormBorderStyle.None;
                    WindowState = FormWindowState.Maximized;
                } else {
                    FormBorderStyle = FormBorderStyle.Sizable;
                    WindowState = FormWindowState.Normal;
                }
            }
        }
    }
}