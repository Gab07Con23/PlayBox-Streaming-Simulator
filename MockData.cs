using System;
using System.Collections.Generic;

namespace PlayBox
{
    public static class MockData
    {
        // Static Random instance created once for the whole program
        private static readonly Random _random = new Random();

        public static List<Content> GetMockData()
        {
            List<Content> allContent = new List<Content>();
            string[] genres = { "Action", "Comedy", "Sci-Fi", "Horror", "Documentary" };

            // Generate 10 Movies
            for (int i = 1; i <= 10; i++)
            {
                string randomGenre = genres[_random.Next(genres.Length)];
                int randomYear = _random.Next(2000, 2026);

                // Using hardcoded rating of 8.0 for consistency
                allContent.Add(new Movie($"Movie {i}", randomGenre, 8.0, randomYear, "Description...", 120));
            }

            // Generate 6 Series
            for (int i = 1; i <= 6; i++)
            {
                string randomGenre = genres[_random.Next(genres.Length)];
                Series s = new Series($"Series {i}", randomGenre, 8.0, 2022, "Description...", 3);

                for (int sNum = 1; sNum <= 3; sNum++)
                {
                    for (int eNum = 1; eNum <= 4; eNum++)
                    {
                        s.AddEpisode(new Episode($"Ep {eNum}", randomGenre, 8.0, 2022, "Desc", eNum, sNum, 45));
                    }
                }
                allContent.Add(s);
            }

            return allContent;
        }
    }
}