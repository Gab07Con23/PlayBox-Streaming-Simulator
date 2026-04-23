using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayBox
{
    public static class MockData
    {
        private static readonly Random _random = new Random();

        public static List<Content> GetMockData()
        {
            List<Content> AllContent = new List<Content>();
            string[] genres = { "Action", "Comedy", "Sci-Fi", "Horror", "Documentary", "Fantasy" };

            // Generate 10 movies with random properties 
            for (int i = 1; i < 10; i++)
            {
                string randomGenre = genres[_random.Next(genres.Length)];
                int randomYear = _random.Next(2000, 2026);
                AllContent.Add(new Movie($"Movie {i}", randomGenre, 7.0, randomYear, "An interesting film", 120));
            }

            // Generate 6 series with random properties 
            for (int i = 1; i < 10; i++) 
            {
                string randomGenre = genres[_random.Next(genres.Length)];
                Series s = new Series($"Series {i}",  randomGenre, 8.0, 2022, "A gripping series", 3);

                for (int sNum = 1; sNum <= 3; sNum++) 
                {
                    for (int eNum = 1; eNum <= 3; eNum++) 
                    {
                        s.AddEpisode(new Episode($"Ep {eNum}", randomGenre, 8.5, 2022, "Desc", eNum, sNum, 45));
                    }
                }
                AllContent.Add(s);
            }
            return AllContent;
        }
       
    }
}
