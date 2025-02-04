using System.Diagnostics;
using System.Text.Json;
using NAudio.Wave;

namespace Music_Player
{
    public partial class MusicPlayer : Form
    {
        private List<Song> songList;

        private WaveOutEvent? waveOutEvent;
        private AudioFileReader? audioFileReader;


        private LinkedList<Song>? songHistory;
        private Song? nextSong;
        private Song? currentSong;

        private bool manualStop;
        private bool previous;

        public MusicPlayer()
        {
            InitializeComponent();
            songList = new List<Song>();
            waveOutEvent = new WaveOutEvent();
            waveOutEvent.PlaybackStopped += OnPlayBackStopped;

            songHistory = new LinkedList<Song>();

            manualStop = false;
            previous = false;

            txtboxSessionInput.ForeColor = Color.Gray;
            txtboxSessionInput.Tag = false;
            var toolTip = new ToolTip();
            toolTip.SetToolTip(txtboxSessionInput,
                "Enter a session name here. It will be saved when you press 'Save Session'.");
        }

        private void MusicPlayer_Load(object sender, EventArgs e)
        {
            LoadSession("lastsession.session.json");
        }

        private void btnAddSong_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select a song",
                Filter = "Audio files|*.mp3;*.wav;*.flac;*.aac",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic),
                Multiselect = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] filePaths = openFileDialog.FileNames;

                foreach (var path in filePaths)
                {
                    var newSong = new Song(path);

                    if (newSong.IsValid)
                    {
                        songList.Add(newSong);

                        var item = new ListViewItem([newSong.Title, newSong.Artist, newSong.Length.ToString(@"mm\:ss")])
                        {
                            Tag = newSong
                        };

                        listViewSongs.Items.Add(item);
                    }
                }
            }
            else
            {
                MessageBox.Show("You haven't selected a song", "No selection");
            }
        }

        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            if (currentSong == null)
            {
                if (listViewSongs.SelectedItems.Count > 0)
                {
                    PlaySong(listViewSongs.SelectedItems[0].Tag as Song);
                    return;
                }
                else
                {
                    MessageBox.Show("Select a song to play");
                    return;
                }
            }

            if (btnPlayPause.Text == "Play")
            {
                if (waveOutEvent.PlaybackState == PlaybackState.Paused || waveOutEvent.PlaybackState == PlaybackState.Stopped)
                {
                    waveOutEvent.Play();

                }
                else
                {
                    try
                    {
                        if (listViewSongs.SelectedItems[0].Tag is Song song)
                        {
                            PlaySong(song);
                        }
                    }
                    catch (Exception ex)
                    {
                        return;
                    }
                }
                UpdateTimerState();
                UpdatePlayPauseBtn();
            }
            else
            {
                waveOutEvent?.Pause();
                UpdateTimerState();
                UpdatePlayPauseBtn();
            }

        }

        private void volumeSlider_ValueChanged(object sender, EventArgs e)
        {
            waveOutEvent.Volume = volumeSlider.Volume;
        }

        private void btnNextSong_Click(object sender, EventArgs e)
        {
            manualStop = true;
            waveOutEvent?.Stop();

            if (nextSong != null)
            {
                PlaySong(nextSong);
            }
        }

        private void btnPreviousSong_Click(object sender, EventArgs e)
        {
            if (audioFileReader.CurrentTime.TotalSeconds <= 5 && songHistory.Count > 0)
            {
                previous = true;
                manualStop = true;
                StopCurrentSong();
                PlaySong(songHistory.Last.Value);
                songHistory.RemoveLast();
            }
            else
            {
                audioFileReader.Position = 0;
                lblTimer.Text = "0:00";
                UpdateTimerState();
            }
        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFolderDialog = new FolderBrowserDialog()
            {
                Description = "Select a folder containing audio files",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic),
                Multiselect = true
            };

            if (openFolderDialog.ShowDialog() == DialogResult.OK)
            {
                string folderPath = openFolderDialog.SelectedPath;

                var audioFilesPath = Directory.GetFiles(folderPath, "*.*", SearchOption.TopDirectoryOnly)
                    .Where(file =>
                        file.EndsWith(".mp3") || file.EndsWith(".wav") || file.EndsWith(".flac") ||
                        file.EndsWith(".aac"));

                foreach (var path in audioFilesPath)
                {
                    var newSong = new Song(path);

                    if (newSong.IsValid)
                    {
                        songList.Add(newSong);

                        var item = new ListViewItem([newSong.Title, newSong.Artist, newSong.Length.ToString(@"mm\:ss")])
                        {
                            Tag = newSong
                        };
                        listViewSongs.Items.Add(item);
                    }
                }
            }
            else
            {
                //MessageBox.Show("You haven't selected a folder", "No selection");
            }
        }

        private void listViewSongs_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listViewSongs.SelectedItems.Count > 0)
            {
                if (listViewSongs.SelectedItems[0].Tag is Song song)
                {
                    manualStop = true;
                    StopCurrentSong();
                    PlaySong(song);
                }

            }
        }

        private void StopCurrentSong()
        {
            waveOutEvent?.Stop();
            waveOutEvent?.Dispose();
            waveOutEvent = null;
        }

        private void PlaySong(Song song)
        {
            if (RemoveMissingSongs(song)) return;

            AddSongToHistory();
            currentSong = song;

            if (audioFileReader != null)
            {
                audioFileReader.Dispose();
                audioFileReader = null;
            }

            audioFileReader = new AudioFileReader(currentSong.FilePath);
            waveOutEvent = new WaveOutEvent();

            seekBar.Maximum = (int)audioFileReader.TotalTime.TotalSeconds;
            lblTotalTime.Text = audioFileReader.TotalTime.ToString(@"m\:ss");

            waveOutEvent.Init(audioFileReader);
            waveOutEvent.Volume = volumeSlider.Volume;
            waveOutEvent.Play();

            lblTimer.Text = "0:00";
            seekBar.Value = 0;

            lblCurrentAuthor.Text = currentSong.Artist;
            lblCurrentSong.Text = currentSong.Title;
            pnlCurrentSongDetails.Visible = true;

            PickNextSong(currentSong);

            UpdateTimerState();
            UpdatePlayPauseBtn();

            manualStop = false;
            previous = false;
        }

        private int FindItemByTag(object tagValue)
        {
            try
            {
                foreach (ListViewItem item in listViewSongs.Items)
                {
                    if (item.Tag != null && item.Tag.Equals(tagValue))
                    {
                        return item.Index;
                    }
                }
            }
            catch (Exception e)
            {
                if (listViewSongs.Items.Count == 0)
                    return -1;
                return 0;
            }

            return -1;
        }

        private void seekBar_Scroll(object sender, EventArgs e)
        {
            if (waveOutEvent.PlaybackState != PlaybackState.Paused)
            {
                UpdateTimerState();
                waveOutEvent.Pause();
            }

            int minutes = seekBar.Value / 60;
            int seconds = seekBar.Value % 60;

            lblTimer.Text = $"{minutes:D2}:{seconds:D2}";
        }

        private void seekBar_MouseUp(object sender, MouseEventArgs e)
        {
            double pos = seekBar.Value;
            audioFileReader.CurrentTime = TimeSpan.FromSeconds(pos);

            UpdateTimerState();
            if (btnPlayPause.Text == "Pause")
                waveOutEvent?.Play();
        }

        private void songTimer_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = audioFileReader.CurrentTime.ToString(@"m\:ss");
            seekBar.Value = (int)audioFileReader.CurrentTime.TotalSeconds;
        }

        private void UpdateTimerState()
        {
            if (waveOutEvent.PlaybackState == PlaybackState.Playing)
            {
                if (!songTimer.Enabled)
                {
                    songTimer.Start();
                }
            }
            else
            {
                if (songTimer.Enabled)
                {
                    songTimer.Stop();
                }
            }
        }

        private void UpdatePlayPauseBtn()
        {
            if (waveOutEvent.PlaybackState == PlaybackState.Paused ||
                waveOutEvent.PlaybackState == PlaybackState.Stopped)
            {
                btnPlayPause.Text = "Play";
            }
            else
            {
                btnPlayPause.Text = "Pause";
            }

        }

        private void OnPlayBackStopped(object sender, StoppedEventArgs e)
        {
            StopCurrentSong();
            currentSong = null;
            if (!manualStop && nextSong != null)
                PlaySong(nextSong);
        }

        private void AddSongToHistory()
        {
            if (previous) return;
            if (currentSong == null) return;

            if (songHistory.Count >= 5)
            {
                songHistory.RemoveFirst();
                songHistory.AddLast(currentSong);
            }
            else
            {
                songHistory.AddLast(currentSong);
            }

            Console.WriteLine(songHistory.Last?.Value + "\n" + songHistory.First?.Value);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listViewSongs.SelectedItems.Count > 0)
            {
                for (int i = listViewSongs.SelectedItems.Count - 1; i >= 0; i--)
                {
                    int index = listViewSongs.SelectedItems[i].Index;

                    listViewSongs.Items.RemoveAt(index);
                    songList.RemoveAt(index);
                }
            }
        }

        private void SaveSession(string filename)
        {
            var sessionData = new SessionData()
            {
                CurrentSong = currentSong,
                Position = audioFileReader?.CurrentTime ?? TimeSpan.Zero,
                Songs = songList,
                SongHistory = songHistory,
                Volume = waveOutEvent?.Volume ?? 0.1f,
                Shuffle = chkboxShuffle.Checked
            };

            string json = JsonSerializer.Serialize(sessionData, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filename, json);
        }


        private void LoadSession(string filename)
        {
            try
            {
                if (File.Exists(filename))
                {
                    string json = File.ReadAllText(filename);
                    var sessionData = JsonSerializer.Deserialize<SessionData>(json);

                    if (sessionData != null)
                    {
                        currentSong = sessionData.CurrentSong;
                        songList = sessionData.Songs ?? new List<Song>();
                        songHistory = sessionData.SongHistory ?? new LinkedList<Song>();
                        volumeSlider.Volume = sessionData.Volume;
                        chkboxShuffle.Checked = sessionData.Shuffle;

                        listViewSongs.Items.Clear();
                        foreach (var song in songList)
                        {
                            var item = new ListViewItem(new[] { song.Title, song.Artist, song.Length.ToString(@"mm\:ss") })
                            {
                                Tag = song
                            };
                            listViewSongs.Items.Add(item);
                        }

                        if (currentSong != null && !string.IsNullOrEmpty(currentSong.FilePath) && File.Exists(currentSong.FilePath))
                        {
                            audioFileReader = new AudioFileReader(currentSong.FilePath);
                            audioFileReader.CurrentTime = sessionData.Position ?? TimeSpan.Zero;
                            waveOutEvent.Init(audioFileReader);
                            waveOutEvent.Volume = volumeSlider.Volume;

                            lblTotalTime.Text = audioFileReader.TotalTime.ToString(@"m\:ss");
                            lblTimer.Text = audioFileReader.CurrentTime.ToString(@"m\:ss");
                            seekBar.Maximum = (int)audioFileReader.TotalTime.TotalSeconds;
                            seekBar.Value = (int)audioFileReader.CurrentTime.TotalSeconds;

                            btnPlayPause.Text = "Play";

                            lblCurrentAuthor.Text = currentSong.Artist;
                            lblCurrentSong.Text = currentSong.Title;
                            pnlCurrentSongDetails.Visible = true;

                            PickNextSong(currentSong);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to load session: {e.Message}");
            }
        }

        private void MusicPlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSession("lastsession.session.json");
        }

        private void btnSaveSession_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtboxSessionInput.Text) || txtboxSessionInput.Text == "Session Name")
            {
                MessageBox.Show("Name can't be empty");
                return;
            }

            string filename = txtboxSessionInput.Text +
                              ".session.json";

            SaveSession(filename);
        }

        private void btnLoadSession_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Filter = "Session files (*.session.json)|*.session.json",
                InitialDirectory = Application.StartupPath,
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadSession(openFileDialog.FileName);
            }
        }

        private void txtboxSessionInput_Enter(object sender, EventArgs e)
        {
            if (txtboxSessionInput.Text == "Session Name")
            {
                txtboxSessionInput.Text = string.Empty;
                txtboxSessionInput.ForeColor = Color.Black;
            }
        }

        private void txtboxSessionInput_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtboxSessionInput.Text))
            {
                txtboxSessionInput.Text = "Session Name";
                txtboxSessionInput.ForeColor = Color.Gray;
            }
        }

        private void txtboxSessionInput_TextChanged(object sender, EventArgs e)
        {
        }

        private bool RemoveMissingSongs(Song song)
        {
            if (!File.Exists(song.FilePath))
            {
                MessageBox.Show("Music file has been moved or deleted.");

                songList.RemoveAll(s => s.Equals(song));

                foreach (ListViewItem item in listViewSongs.Items)
                {
                    if (item.Tag is Song tagSong && tagSong.Equals(song)) 
                    {
                        listViewSongs.Items.Remove(item);
                    }
                }

                return true;
            }

            return false;
        }

        private void PickNextSong(Song song)
        {
            if (chkboxShuffle.Checked)
            {
                var rand = new Random();
                int index;

                do
                {
                    index = rand.Next(songList.Count);
                } while (songList[index].Equals(song));

                nextSong = songList[index];
            }
            else
            {
                int index = FindItemByTag(song);

                if (index != -1)
                {
                    if (songList.Count <= index + 1)
                        nextSong = songList[0];
                    else
                        nextSong = songList[index + 1];
                }
            }
        }

    }

    [Serializable]
    public class Song
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public TimeSpan Length { get; set; }
        public string FilePath { get; set; }
        public bool IsValid { get; set; }

        public Song(string filePath)
        {
            FilePath = filePath;
            IsValid = true;

            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                IsValid = false;
                return;
            }

            try
            {
                using (var audioFile = new AudioFileReader(filePath))
                {
                    Length = audioFile.TotalTime;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"{filePath} could not be added.", "Error loading file.");
                IsValid = false;
                return;
            }

            string[] meta = Path.GetFileNameWithoutExtension(filePath).Split('-');

            Title = meta.Length > 1 ? meta[1].Trim() : meta[0].Trim();
            Artist = meta.Length > 1 ? meta[0].Trim() : "Unknown Author";
        }
    }

    [Serializable]
    public class SessionData
    {
        public Song? CurrentSong { get; set; }
        public TimeSpan? Position { get; set; }
        public List<Song> Songs { get; set; }
        public LinkedList<Song>? SongHistory { get; set; }
        public float Volume { get; set; }
        public bool Shuffle { get; set; }
    }
}
