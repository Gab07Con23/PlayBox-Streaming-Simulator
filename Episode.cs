using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayBox
{
    internal class Episode : Content
    {
        public int EpisodeNumber {  get; protected set; }
        public int SeasonNumber { get; protected set; }
        public int Duration { get; protected set; }

        public Episode(string title, string genre, double rating, int releaseyear, string description, int episodenumber, int seasonnumber, int duration )
            : base(title, genre, rating, releaseyear, description)
        {
            EpisodeNumber = episodenumber;
            SeasonNumber = seasonnumber;
            Duration = duration;
        }

        // Function displays the season number, episode number, the title and the duration
        public override void Play()
        {
            Console.WriteLine($"Playing S{SeasonNumber}E{EpisodeNumber}: {Title} ({Duration} minutes)");
        }
    }
}
