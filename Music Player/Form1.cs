using System.Diagnostics;
using NAudio.Wave;

namespace Music_Player
{
    public partial class MusicPlayer : Form
    {
        private List<Song> songList;

        private WaveOutEvent? waveOutEvent;
        private AudioFileReader? audioFileReader;

        private bool hasStarted = false;
        private bool isPlaying = false;
        private int currentlyPlayingIndex = -1;

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
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show($"You have selected: {openFileDialog.FileName}", "Song selected");
                var newSong = new Song(openFileDialog.FileName);
                songList.Add(newSong);

                var item = new ListViewItem([newSong.Title, newSong.Artist, newSong.Length.ToString(@"mm\:ss")]);
                listViewSongs.Items.Add(item);
            }
            else
            {
                MessageBox.Show("You haven't selected a song", "No selection");
            }
        }

        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            int selectedSong;
            try
            {
                selectedSong = listViewSongs.SelectedItems[0].Index;
            }
            catch (Exception exception)
            {
                if (hasStarted)
                    selectedSong = currentlyPlayingIndex;
                else
                    selectedSong = 0;
            }

            if (!hasStarted || currentlyPlayingIndex != selectedSong)
            {
                hasStarted = true;

                waveOutEvent = new WaveOutEvent();

                try
                {
                    audioFileReader = new AudioFileReader(songList[selectedSong].FilePath);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }


                lblCurrentSong.Text = songList[selectedSong].Title;
                lblCurrentAuthor.Text = songList[selectedSong].Artist;

                pnlCurrentSongDetails.Visible = true;

                waveOutEvent.Init(audioFileReader);
                waveOutEvent.Volume = volumeSlider.Volume;
            }


            if (isPlaying) // When song is playing
            {
                isPlaying = false;
                btnPlayPause.Text = "Play";

                waveOutEvent?.Pause();
            }
            else // When song is paused
            {
                isPlaying = true;
                btnPlayPause.Text = "Pause";

                waveOutEvent?.Play();
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
            if (audioFileReader != null && hasStarted && audioFileReader.CurrentTime.TotalSeconds > 5)
            {
                audioFileReader.Position = 0;
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
                    songList.Add(newSong);

                    var item = new ListViewItem([newSong.Title, newSong.Artist, newSong.Length.ToString(@"mm\:ss")]);
                    item.Tag = newSong.FilePath;
                    listViewSongs.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("You haven't selected a folder", "No selection");
            }
        }

        private void listViewSongs_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listViewSongs.SelectedItems.Count > 0)
            {
                string path = listViewSongs.SelectedItems[0].Tag as string;
                if (!string.IsNullOrEmpty(path))
                {
                    StopCurrentSong();

                    PlaySong(path);
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
            waveOutEvent.Init(audioFileReader);
            waveOutEvent.Play();
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
    }

    public class Song
    {
        public string Title;
        public string Artist;
        public TimeSpan Length;
        public string FilePath;

        public Song(string filePath)
        {
            FilePath = filePath;

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
            }
            

            string[] meta = Path.GetFileNameWithoutExtension(filePath).Split('-');

            Title = meta.Length > 1 ? meta[1].Trim() : meta[0].Trim();
            Artist = meta.Length > 1 ? meta[0].Trim() : "Unknown Author";
        }

    }
}
