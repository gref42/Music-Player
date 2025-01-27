using System.Diagnostics;
using NAudio.Wave;

namespace Music_Player
{
    public partial class MusicPlayer : Form
    {
        private List<Song> songList;

        private WaveOutEvent? waveOutEvent;
        private AudioFileReader? audioFileReader;


        private LinkedList<string> songHistory;

        public MusicPlayer()
        {
            InitializeComponent();
            songList = new List<Song>();
            waveOutEvent = new WaveOutEvent();
            songHistory = new LinkedList<string>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
            if (btnPlayPause.Text == "Play")
            {
                if(waveOutEvent.PlaybackState == PlaybackState.Paused)
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
                waveOutEvent.Pause();
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

        }

        private void btnPreviousSong_Click(object sender, EventArgs e)
        {
            if (audioFileReader != null && audioFileReader.CurrentTime.TotalSeconds > 5)
            {
                audioFileReader.Position = 0;
                lblTimer.Text = "0:00";
                UpdateTimerState();
            }
            else
            {
                // TODO: GO TO PREVIOUS SONG (DOUBLE ENDED QUEUE?)
                songHistory.RemoveLast();
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
            audioFileReader = new AudioFileReader(song.FilePath);
            waveOutEvent = new WaveOutEvent();

            seekBar.Maximum = (int)audioFileReader.TotalTime.TotalSeconds;
            lblTotalTime.Text = audioFileReader.TotalTime.ToString(@"m\:ss");

            waveOutEvent.Init(audioFileReader);
            waveOutEvent.Play();

            lblTimer.Text = "0:00";
            seekBar.Value = 0;

            UpdateTimerState();
            UpdatePlayPauseBtn();
        }

        private void PlaySong(string path)
        {
            audioFileReader = new AudioFileReader(path);
            waveOutEvent = new WaveOutEvent();

            seekBar.Maximum = (int)audioFileReader.TotalTime.TotalSeconds;
            lblTotalTime.Text = audioFileReader.TotalTime.ToString(@"m\:ss");

            waveOutEvent.Init(audioFileReader);
            waveOutEvent.Play();

            lblTimer.Text = "0:00";
            seekBar.Value = 0;

            UpdateTimerState();
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
            waveOutEvent.Play();
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
    }

    public class Song
    {
        public string Title { get; }
        public string Artist { get; }
        public TimeSpan Length { get; }
        public string FilePath { get; }
        public bool IsValid { get; }

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
}
