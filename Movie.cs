using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayBox
{
    internal class Movie: Content
    {
        private int Duration {  get; set; }

        public Movie (string title, string genre, double rating, int releaseyear, string description, int duration) 
            : base(title, genre, rating, releaseyear, description)
        {
            Duration = duration;
        }
        // Displays the user when the movie is playing along with the duration
        public override void Play()
        {
            Console.WriteLine($"Now playing movie: {Title} ({Duration} minutes.)");   
        }   
    }
}
