namespace Music_Player
{
    partial class MusicPlayer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            volumeSlider = new NAudio.Gui.VolumeSlider();
            addSong_button = new Button();
            btnPlayPause = new Button();
            listView = new ListView();
            pnlCurrentSongDetails = new Panel();
            lblCurrentAuthor = new Label();
            lblCurrentSong = new Label();
            lblNowPlaying = new Label();
            btnPreviousSong = new Button();
            btnNextSong = new Button();
            pnlCurrentSongDetails.SuspendLayout();
            SuspendLayout();
            // 
            // volumeSlider
            // 
            volumeSlider.BackColor = SystemColors.ActiveCaption;
            volumeSlider.BackgroundImageLayout = ImageLayout.None;
            volumeSlider.BorderStyle = BorderStyle.FixedSingle;
            volumeSlider.Location = new Point(352, 292);
            volumeSlider.Name = "volumeSlider";
            volumeSlider.Size = new Size(96, 16);
            volumeSlider.TabIndex = 0;
            volumeSlider.VolumeChanged += volumeSlider_ValueChanged;
            // 
            // addSong_button
            // 
            addSong_button.Location = new Point(241, 88);
            addSong_button.Name = "addSong_button";
            addSong_button.Size = new Size(75, 23);
            addSong_button.TabIndex = 1;
            addSong_button.Text = "Add Song";
            addSong_button.UseVisualStyleBackColor = true;
            addSong_button.Click += addSong_button_Click;
            // 
            // btnPlayPause
            // 
            btnPlayPause.Location = new Point(352, 88);
            btnPlayPause.Name = "btnPlayPause";
            btnPlayPause.Size = new Size(75, 23);
            btnPlayPause.TabIndex = 2;
            btnPlayPause.Text = "Play";
            btnPlayPause.UseVisualStyleBackColor = true;
            btnPlayPause.Click += btnPlayPause_Click;
            // 
            // listView
            // 
            listView.Location = new Point(31, 29);
            listView.Margin = new Padding(3, 2, 3, 2);
            listView.Name = "listView";
            listView.Size = new Size(133, 279);
            listView.TabIndex = 3;
            listView.UseCompatibleStateImageBehavior = false;
            // 
            // pnlCurrentSongDetails
            // 
            pnlCurrentSongDetails.Controls.Add(lblCurrentAuthor);
            pnlCurrentSongDetails.Controls.Add(lblCurrentSong);
            pnlCurrentSongDetails.Controls.Add(lblNowPlaying);
            pnlCurrentSongDetails.Location = new Point(227, 152);
            pnlCurrentSongDetails.Name = "pnlCurrentSongDetails";
            pnlCurrentSongDetails.Size = new Size(168, 101);
            pnlCurrentSongDetails.TabIndex = 4;
            pnlCurrentSongDetails.Visible = false;
            // 
            // lblCurrentAuthor
            // 
            lblCurrentAuthor.AutoSize = true;
            lblCurrentAuthor.Location = new Point(3, 41);
            lblCurrentAuthor.Name = "lblCurrentAuthor";
            lblCurrentAuthor.Size = new Size(36, 15);
            lblCurrentAuthor.TabIndex = 2;
            lblCurrentAuthor.Text = "None";
            // 
            // lblCurrentSong
            // 
            lblCurrentSong.AutoSize = true;
            lblCurrentSong.Location = new Point(3, 26);
            lblCurrentSong.Name = "lblCurrentSong";
            lblCurrentSong.Size = new Size(36, 15);
            lblCurrentSong.TabIndex = 1;
            lblCurrentSong.Text = "None";
            // 
            // lblNowPlaying
            // 
            lblNowPlaying.AutoSize = true;
            lblNowPlaying.Location = new Point(3, 11);
            lblNowPlaying.Name = "lblNowPlaying";
            lblNowPlaying.Size = new Size(77, 15);
            lblNowPlaying.TabIndex = 0;
            lblNowPlaying.Text = "Now Playing:";
            // 
            // btnPreviousSong
            // 
            btnPreviousSong.Location = new Point(207, 297);
            btnPreviousSong.Name = "btnPreviousSong";
            btnPreviousSong.Size = new Size(75, 23);
            btnPreviousSong.TabIndex = 5;
            btnPreviousSong.Text = "Previous";
            btnPreviousSong.UseVisualStyleBackColor = true;
            btnPreviousSong.Click += btnPreviousSong_Click;
            // 
            // btnNextSong
            // 
            btnNextSong.Location = new Point(220, 335);
            btnNextSong.Name = "btnNextSong";
            btnNextSong.Size = new Size(75, 23);
            btnNextSong.TabIndex = 6;
            btnNextSong.Text = "Next";
            btnNextSong.UseVisualStyleBackColor = true;
            btnNextSong.Click += btnNextSong_Click;
            // 
            // MusicPlayer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(597, 415);
            Controls.Add(btnNextSong);
            Controls.Add(btnPreviousSong);
            Controls.Add(pnlCurrentSongDetails);
            Controls.Add(listView);
            Controls.Add(btnPlayPause);
            Controls.Add(addSong_button);
            Controls.Add(volumeSlider);
            MinimumSize = new Size(440, 310);
            Name = "MusicPlayer";
            Text = "Music Player";
            Load += Form1_Load;
            pnlCurrentSongDetails.ResumeLayout(false);
            pnlCurrentSongDetails.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private NAudio.Gui.VolumeSlider volumeSlider;
        private Button addSong_button;
        private Button btnPlayPause;
        private ListView listView;
        private Panel pnlCurrentSongDetails;
        private Label lblNowPlaying;
        private Label lblCurrentAuthor;
        private Label lblCurrentSong;
        private Button btnPreviousSong;
        private Button btnNextSong;
    }
}
