using System.Diagnostics.CodeAnalysis;
using System.DirectoryServices.ActiveDirectory;
using NAudio.Wave;

namespace Music_Player
{
    public partial class MusicPlayer : Form
    {
        private List<string> songPaths;

        private WaveOutEvent waveOut;
        private AudioFileReader? audioFileReader;

        private bool hasStarted = false;
        private bool isPlaying = false;

        private LinkedList<string> songHistory;

        public MusicPlayer()
        {
            InitializeComponent();
            songPaths = new List<string>();
            waveOut = new WaveOutEvent();
            songHistory = new LinkedList<string>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void addSong_button_Click(object sender, EventArgs e)
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
                songPaths.Add(openFileDialog.FileName);
            }
            else
            {
                MessageBox.Show("You haven't selected a song", "No selection");
            }
        }

        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            if (!hasStarted)
            {
                hasStarted = true;

                string filePath = $"{songPaths[songPaths.Count - 1]}";

                waveOut = new WaveOutEvent();
                audioFileReader = new AudioFileReader(filePath);

                string[] meta = Path.GetFileNameWithoutExtension(filePath).Split('-');

                lblCurrentSong.Text = meta.Length > 1 ? meta[1].Trim() : meta[0].Trim();
                lblCurrentAuthor.Text = meta.Length > 1 ? meta[0].Trim() : "Unknown Author";

                pnlCurrentSongDetails.Visible = true;

                waveOut.Init(audioFileReader);
            }


            if (isPlaying) // When song is playing
            {
                isPlaying = false;
                btnPlayPause.Text = "Play";

                waveOut.Pause();
            }
            else // When song is paused
            {
                isPlaying = true;
                btnPlayPause.Text = "Pause";

                waveOut.Play();
            }

        }

        private void volumeSlider_ValueChanged(object sender, EventArgs e)
        {
            if (waveOut != null && waveOut.PlaybackState == PlaybackState.Playing)
            {
                waveOut.Volume = volumeSlider.Volume;
            }
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
    }
}
