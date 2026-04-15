using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayBox
{
    internal abstract class Content
    {
        // Declaring all variables used in the system in content class
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public string Genre { get; protected set; }
        public double Rating { get; protected set; }
        public int ReleaseYear { get; protected set; }

        // Constructor
        public Content(string title, string genre, double rating, int releaseyear, string description)
        {
            Title = title;
            Description = description;
            Genre = genre;
            Rating = rating;
            ReleaseYear = releaseyear;
        }

        // Displays the entire information of the content to the user 
        public virtual void DisplayInfo() 
        {
            Console.WriteLine("========================");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Genre: {Genre}");
            Console.WriteLine($"Rating: {Rating}");
            Console.WriteLine($"Release Year: {ReleaseYear}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine("========================");
        }

        // Makes the user able to play or pause the content selected (Movie, Series)
        public abstract void Play();
    }
}
