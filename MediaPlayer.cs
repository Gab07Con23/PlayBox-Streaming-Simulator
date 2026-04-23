using System;

namespace PlayBox
{ 
	public class MediaPlayer
	{
		public Content CurrentContent {  get; private set; }
		public string State {  get; private set; }
		
		public MediaPlayer()
		{
			State = "Stopped";
		}

		public void Play(Content c) 
		{
			CurrentContent = c;
			State = "Playing";
			Console.WriteLine($"Starting playback....");
			c.Play(); // Executest the overriden play() method of the movie/episode
		}

		public void Pause() 
		{
			if (State == "Playing")
			{
				State = "Paused";
				Console.WriteLine($"Paused. {CurrentContent.Title}");
			}
		}

		public void Stop()
		{
			State = "Stopped";
			Console.WriteLine("Playback stopped.");
			CurrentContent = null;
		}

		public void Resume() 
		{
            if (State == "Paused")
            {
                State = "Playing";
                Console.WriteLine($"Resuming: {CurrentContent.Title}");
            }
        }
	}
}
