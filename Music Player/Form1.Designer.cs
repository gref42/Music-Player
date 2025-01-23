namespace Music_Player
{
    partial class Form1
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
            play_button = new Button();
            listView = new ListView();
            SuspendLayout();
            // 
            // volumeSlider
            // 
            volumeSlider.Location = new Point(275, 335);
            volumeSlider.Margin = new Padding(3, 4, 3, 4);
            volumeSlider.Name = "volumeSlider";
            volumeSlider.Size = new Size(110, 21);
            volumeSlider.TabIndex = 0;
            // 
            // addSong_button
            // 
            addSong_button.Location = new Point(275, 118);
            addSong_button.Margin = new Padding(3, 4, 3, 4);
            addSong_button.Name = "addSong_button";
            addSong_button.Size = new Size(86, 31);
            addSong_button.TabIndex = 1;
            addSong_button.Text = "Add Song";
            addSong_button.UseVisualStyleBackColor = true;
            addSong_button.Click += addSong_button_Click;
            // 
            // play_button
            // 
            play_button.Location = new Point(402, 118);
            play_button.Margin = new Padding(3, 4, 3, 4);
            play_button.Name = "play_button";
            play_button.Size = new Size(86, 31);
            play_button.TabIndex = 2;
            play_button.Text = "Play";
            play_button.UseVisualStyleBackColor = true;
            play_button.Click += play_button_Click;
            // 
            // listView
            // 
            listView.Location = new Point(35, 39);
            listView.Name = "listView";
            listView.Size = new Size(151, 371);
            listView.TabIndex = 3;
            listView.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(682, 553);
            Controls.Add(listView);
            Controls.Add(play_button);
            Controls.Add(addSong_button);
            Controls.Add(volumeSlider);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(500, 400);
            Name = "Form1";
            Text = "Music Player";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private NAudio.Gui.VolumeSlider volumeSlider;
        private Button addSong_button;
        private Button play_button;
        private ListView listView;
    }
}
