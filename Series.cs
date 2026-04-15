using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayBox
{
    internal class Series : Content
    {
        public int Seasons {  get; protected set; }
        public List<Episode>Episodes {  get; protected set; }

        public Series(string title, string genre, double rating, int releaseyear, string description, int seasons)
            : base(title, genre, rating, releaseyear, description)
        {
            Seasons = seasons;
            Episodes = new List<Episode>();
        }

        // This function adds episodes to the list episode
        public void AddEpisode(Episode episode) 
        {
            Episodes.Add(episode);
        }

        // Displays the user the title and episodes, user must choose which episode to play
        public override void Play()
        {
            Console.WriteLine($"Series: {Title}");
            Console.WriteLine($"Select an episode to play:");

            // Displays the the season, episode number and episode title store in the list
            foreach (var episode in Episodes)
            {
                Console.WriteLine($"S{episode.SeasonNumber}E{episode.EpisodeNumber} - {episode.Title}");
            }
        }
    }
}
