using NAudio.Wave;

namespace Music_Player
{
    public partial class Form1 : Form
    {
        private List<string> songPaths;

        private IWavePlayer waveOut;
        private AudioFileReader audioFile;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            songPaths = new List<string>();

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
                MessageBox.Show($"You have selected: {openFileDialog.FileName}", "Song selected");
                songPaths.Add(openFileDialog.FileName);
            }
            else
            {
                MessageBox.Show("You haven't selected a song", "No selection");
            }
        }

        private void play_button_Click(object sender, EventArgs e)
        {
            string filePath = $"{songPaths[songPaths.Count - 1]}";

            waveOut = new WaveOutEvent();
            audioFile = new AudioFileReader(filePath);

            waveOut.Init(audioFile);

            waveOut.Play();
        }
    }
}
