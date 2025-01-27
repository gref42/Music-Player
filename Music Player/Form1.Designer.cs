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
            components = new System.ComponentModel.Container();
            volumeSlider = new NAudio.Gui.VolumeSlider();
            btnAddSong = new Button();
            btnPlayPause = new Button();
            listViewSongs = new ListView();
            Title = new ColumnHeader();
            Author = new ColumnHeader();
            Duration = new ColumnHeader();
            pnlCurrentSongDetails = new Panel();
            lblCurrentAuthor = new Label();
            lblCurrentSong = new Label();
            lblNowPlaying = new Label();
            btnPreviousSong = new Button();
            btnNextSong = new Button();
            btnAddFolder = new Button();
            seekBar = new TrackBar();
            panel1 = new Panel();
            lblTotalTime = new Label();
            lblTimer = new Label();
            songTimer = new System.Windows.Forms.Timer(components);
            pnlCurrentSongDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)seekBar).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // volumeSlider
            // 
            volumeSlider.BackColor = SystemColors.ActiveCaption;
            volumeSlider.BackgroundImageLayout = ImageLayout.None;
            volumeSlider.BorderStyle = BorderStyle.FixedSingle;
            volumeSlider.Location = new Point(489, 374);
            volumeSlider.Name = "volumeSlider";
            volumeSlider.Size = new Size(96, 16);
            volumeSlider.TabIndex = 0;
            volumeSlider.Volume = 0.1F;
            volumeSlider.VolumeChanged += volumeSlider_ValueChanged;
            // 
            // btnAddSong
            // 
            btnAddSong.Location = new Point(409, 41);
            btnAddSong.Name = "btnAddSong";
            btnAddSong.Size = new Size(75, 23);
            btnAddSong.TabIndex = 1;
            btnAddSong.Text = "Add Song";
            btnAddSong.UseVisualStyleBackColor = true;
            btnAddSong.Click += btnAddSong_Click;
            // 
            // btnPlayPause
            // 
            btnPlayPause.Location = new Point(471, 236);
            btnPlayPause.Name = "btnPlayPause";
            btnPlayPause.Size = new Size(75, 23);
            btnPlayPause.TabIndex = 2;
            btnPlayPause.Text = "Play";
            btnPlayPause.UseVisualStyleBackColor = true;
            btnPlayPause.Click += btnPlayPause_Click;
            // 
            // listViewSongs
            // 
            listViewSongs.Columns.AddRange(new ColumnHeader[] { Title, Author, Duration });
            listViewSongs.Location = new Point(0, 2);
            listViewSongs.Margin = new Padding(3, 2, 3, 2);
            listViewSongs.Name = "listViewSongs";
            listViewSongs.ShowItemToolTips = true;
            listViewSongs.Size = new Size(267, 269);
            listViewSongs.TabIndex = 3;
            listViewSongs.UseCompatibleStateImageBehavior = false;
            listViewSongs.View = View.Details;
            listViewSongs.MouseDoubleClick += listViewSongs_MouseDoubleClick;
            // 
            // Title
            // 
            Title.Text = "Title";
            Title.Width = 80;
            // 
            // Author
            // 
            Author.Text = "Author";
            Author.Width = 120;
            // 
            // Duration
            // 
            Duration.Text = "Duration";
            // 
            // pnlCurrentSongDetails
            // 
            pnlCurrentSongDetails.Controls.Add(lblCurrentAuthor);
            pnlCurrentSongDetails.Controls.Add(lblCurrentSong);
            pnlCurrentSongDetails.Controls.Add(lblNowPlaying);
            pnlCurrentSongDetails.Location = new Point(301, 87);
            pnlCurrentSongDetails.Name = "pnlCurrentSongDetails";
            pnlCurrentSongDetails.Size = new Size(200, 100);
            pnlCurrentSongDetails.TabIndex = 4;
            pnlCurrentSongDetails.Visible = false;
            // 
            // lblCurrentAuthor
            // 
            lblCurrentAuthor.AutoSize = true;
            lblCurrentAuthor.Location = new Point(3, 41);
            lblCurrentAuthor.Name = "lblCurrentAuthor";
            lblCurrentAuthor.Size = new Size(44, 15);
            lblCurrentAuthor.TabIndex = 2;
            lblCurrentAuthor.Text = "Author";
            // 
            // lblCurrentSong
            // 
            lblCurrentSong.AutoSize = true;
            lblCurrentSong.Location = new Point(3, 26);
            lblCurrentSong.Name = "lblCurrentSong";
            lblCurrentSong.Size = new Size(34, 15);
            lblCurrentSong.TabIndex = 1;
            lblCurrentSong.Text = "Song";
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
            btnPreviousSong.Location = new Point(309, 236);
            btnPreviousSong.Name = "btnPreviousSong";
            btnPreviousSong.Size = new Size(75, 23);
            btnPreviousSong.TabIndex = 5;
            btnPreviousSong.Text = "Previous";
            btnPreviousSong.UseVisualStyleBackColor = true;
            btnPreviousSong.Click += btnPreviousSong_Click;
            // 
            // btnNextSong
            // 
            btnNextSong.Location = new Point(390, 235);
            btnNextSong.Name = "btnNextSong";
            btnNextSong.Size = new Size(75, 23);
            btnNextSong.TabIndex = 6;
            btnNextSong.Text = "Next";
            btnNextSong.UseVisualStyleBackColor = true;
            btnNextSong.Click += btnNextSong_Click;
            // 
            // btnAddFolder
            // 
            btnAddFolder.Location = new Point(314, 41);
            btnAddFolder.Name = "btnAddFolder";
            btnAddFolder.Size = new Size(75, 23);
            btnAddFolder.TabIndex = 7;
            btnAddFolder.Text = "Add Folder";
            btnAddFolder.UseVisualStyleBackColor = true;
            btnAddFolder.Click += btnAddFolder_Click;
            // 
            // seekBar
            // 
            seekBar.LargeChange = 10;
            seekBar.Location = new Point(36, 13);
            seekBar.Maximum = 100;
            seekBar.Name = "seekBar";
            seekBar.Size = new Size(303, 45);
            seekBar.TabIndex = 8;
            seekBar.TickStyle = TickStyle.Both;
            seekBar.Scroll += seekBar_Scroll;
            seekBar.MouseUp += seekBar_MouseUp;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblTotalTime);
            panel1.Controls.Add(lblTimer);
            panel1.Controls.Add(seekBar);
            panel1.Location = new Point(42, 320);
            panel1.Name = "panel1";
            panel1.Size = new Size(384, 70);
            panel1.TabIndex = 9;
            // 
            // lblTotalTime
            // 
            lblTotalTime.AutoSize = true;
            lblTotalTime.Location = new Point(345, 26);
            lblTotalTime.Name = "lblTotalTime";
            lblTotalTime.Size = new Size(28, 15);
            lblTotalTime.TabIndex = 10;
            lblTotalTime.Text = "0:00";
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.Location = new Point(3, 26);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(28, 15);
            lblTimer.TabIndex = 9;
            lblTimer.Text = "0:00";
            // 
            // songTimer
            // 
            songTimer.Interval = 1000;
            songTimer.Tick += songTimer_Tick;
            // 
            // MusicPlayer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(597, 415);
            Controls.Add(panel1);
            Controls.Add(btnAddFolder);
            Controls.Add(btnNextSong);
            Controls.Add(btnPreviousSong);
            Controls.Add(pnlCurrentSongDetails);
            Controls.Add(listViewSongs);
            Controls.Add(btnPlayPause);
            Controls.Add(btnAddSong);
            Controls.Add(volumeSlider);
            MinimumSize = new Size(440, 310);
            Name = "MusicPlayer";
            Text = "Music Player";
            Load += Form1_Load;
            pnlCurrentSongDetails.ResumeLayout(false);
            pnlCurrentSongDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)seekBar).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private NAudio.Gui.VolumeSlider volumeSlider;
        private Button btnAddSong;
        private Button btnPlayPause;
        private ListView listViewSongs;
        private Panel pnlCurrentSongDetails;
        private Label lblNowPlaying;
        private Label lblCurrentAuthor;
        private Label lblCurrentSong;
        private Button btnPreviousSong;
        private Button btnNextSong;
        private ColumnHeader Title;
        private ColumnHeader Author;
        private ColumnHeader Duration;
        private Button btnAddFolder;
        private TrackBar seekBar;
        private Panel panel1;
        private Label lblTimer;
        private Label lblTotalTime;
        private System.Windows.Forms.Timer songTimer;
    }
}
