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
            pnlCurrentSongDetails.SuspendLayout();
            SuspendLayout();
            // 
            // volumeSlider
            // 
            volumeSlider.BackColor = SystemColors.ActiveCaption;
            volumeSlider.BackgroundImageLayout = ImageLayout.None;
            volumeSlider.BorderStyle = BorderStyle.FixedSingle;
            volumeSlider.Location = new Point(471, 374);
            volumeSlider.Name = "volumeSlider";
            volumeSlider.Size = new Size(96, 16);
            volumeSlider.TabIndex = 0;
            volumeSlider.VolumeChanged += volumeSlider_ValueChanged;
            // 
            // btnAddSong
            // 
            btnAddSong.Location = new Point(376, 325);
            btnAddSong.Name = "btnAddSong";
            btnAddSong.Size = new Size(75, 23);
            btnAddSong.TabIndex = 1;
            btnAddSong.Text = "Add Song";
            btnAddSong.UseVisualStyleBackColor = true;
            btnAddSong.Click += btnAddSong_Click;
            // 
            // btnPlayPause
            // 
            btnPlayPause.Location = new Point(477, 314);
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
            listViewSongs.Location = new Point(31, 39);
            listViewSongs.Margin = new Padding(3, 2, 3, 2);
            listViewSongs.Name = "listViewSongs";
            listViewSongs.Size = new Size(267, 269);
            listViewSongs.TabIndex = 3;
            listViewSongs.UseCompatibleStateImageBehavior = false;
            listViewSongs.View = View.Details;
            // 
            // Title
            // 
            Title.Text = "Title";
            Title.Width = 80;
            // 
            // Author
            // 
            Author.Text = "Author";
            Author.TextAlign = HorizontalAlignment.Center;
            Author.Width = 120;
            // 
            // Duration
            // 
            Duration.Text = "Duration";
            Duration.TextAlign = HorizontalAlignment.Center;
            // 
            // pnlCurrentSongDetails
            // 
            pnlCurrentSongDetails.Controls.Add(lblCurrentAuthor);
            pnlCurrentSongDetails.Controls.Add(lblCurrentSong);
            pnlCurrentSongDetails.Controls.Add(lblNowPlaying);
            pnlCurrentSongDetails.Location = new Point(352, 158);
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
            btnPreviousSong.Location = new Point(376, 264);
            btnPreviousSong.Name = "btnPreviousSong";
            btnPreviousSong.Size = new Size(75, 23);
            btnPreviousSong.TabIndex = 5;
            btnPreviousSong.Text = "Previous";
            btnPreviousSong.UseVisualStyleBackColor = true;
            btnPreviousSong.Click += btnPreviousSong_Click;
            // 
            // btnNextSong
            // 
            btnNextSong.Location = new Point(471, 285);
            btnNextSong.Name = "btnNextSong";
            btnNextSong.Size = new Size(75, 23);
            btnNextSong.TabIndex = 6;
            btnNextSong.Text = "Next";
            btnNextSong.UseVisualStyleBackColor = true;
            btnNextSong.Click += btnNextSong_Click;
            // 
            // btnAddFolder
            // 
            btnAddFolder.Location = new Point(237, 358);
            btnAddFolder.Name = "btnAddFolder";
            btnAddFolder.Size = new Size(75, 23);
            btnAddFolder.TabIndex = 7;
            btnAddFolder.Text = "Add Folder";
            btnAddFolder.UseVisualStyleBackColor = true;
            btnAddFolder.Click += btnAddFolder_Click;
            // 
            // MusicPlayer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(597, 415);
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
    }
}
