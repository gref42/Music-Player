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
            SuspendLayout();
            // 
            // volumeSlider
            // 
            volumeSlider.Location = new Point(415, 289);
            volumeSlider.Name = "volumeSlider";
            volumeSlider.Size = new Size(96, 16);
            volumeSlider.TabIndex = 0;
            // 
            // addSong_button
            // 
            addSong_button.Location = new Point(157, 225);
            addSong_button.Name = "addSong_button";
            addSong_button.Size = new Size(75, 23);
            addSong_button.TabIndex = 1;
            addSong_button.Text = "Add Song";
            addSong_button.UseVisualStyleBackColor = true;
            addSong_button.Click += addSong_button_Click;
            // 
            // play_button
            // 
            play_button.Location = new Point(332, 157);
            play_button.Name = "play_button";
            play_button.Size = new Size(75, 23);
            play_button.TabIndex = 2;
            play_button.Text = "Play";
            play_button.UseVisualStyleBackColor = true;
            play_button.Click += play_button_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(play_button);
            Controls.Add(addSong_button);
            Controls.Add(volumeSlider);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private NAudio.Gui.VolumeSlider volumeSlider;
        private Button addSong_button;
        private Button play_button;
    }
}
