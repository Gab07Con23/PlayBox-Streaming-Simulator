using System;

namespace PlayBox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // testing for MockData.cs 
            // retrieve movies and series
            List<Content> library = MockData.GetMockData();

            foreach (var item in library) 
            {
                item.DisplayInfo();
            }


            // testing for mediaplayer.cs
            /*MediaPlayer player = new MediaPlayer();
            List<Content> library = MockData.GetMockData();

            player.Play(library[3]);

            player.Pause();
            player.Resume();
            player.Stop();
            */
        }
    }
}
