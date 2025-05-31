# Music Player

A Windows Forms music player built with C# (.NET 9) and NAudio for audio playback.

## Features

- Play, pause, and seek audio files (.mp3, .wav, .flac, .aac)  
- Add individual songs or entire folders to your playlist  
- Shuffle and sequential playback modes  
- Save and load sessions (playlist, playback position, shuffle state, etc.)  
- Remembers last session on startup  
- Volume control and song progress bar  
- Displays current song and artist  

## Usage

- **Add Songs:** Click "Add Song" or "Add Folder" to add music to your playlist.  
- **Play/Pause:** Use the play/pause button to control playback.  
- **Shuffle:** Toggle the shuffle checkbox for random playback.  
- **Save Session:** Enter a session name and click "Save Session" to save your playlist and state.  
- **Load Session:** Click "Load Session" to restore a previously saved session.  
- **Next/Previous:** Use the next/previous buttons to navigate songs.  

## Notes

- Only valid audio files are added to the playlist.  
- If a file is missing, it will be removed from the playlist.  
- Session files are saved as `.session.json`.  
