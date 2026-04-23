using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayBox
{
    public class RecommendationEngine
    {
        private List<Content> _allContent;

        public RecommendationEngine(List<Content> contentList)
        {
            _allContent = contentList;
        }

        public List<Content> GetPersonalizedRecommendations(User user)
        {
            var watchHistory = user.GetWatchHistory();

            return _allContent
                // 1. Filter out what they have already watched
                .Except(watchHistory)
                // 2. Project into a temporary object with a score
                .Select(c => new {
                    Content = c,
                    Score = CalculateScore(c, user, watchHistory)
                })
                // 3. Sort by the highest score
                .OrderByDescending(x => x.Score)
                .Select(x => x.Content)
                .Take(5) // Top 5 recommendations
                .ToList();
        }

        private double CalculateScore(Content c, User user, List<Content> history)
        {
            double score = 0;

            // Preference 1: Genre match (favored if user watches many of that genre)
            var favoriteGenres = history.GroupBy(h => h.Genre)
                                        .OrderByDescending(g => g.Count())
                                        .Select(g => g.Key).Take(2);

            if (favoriteGenres.Contains(c.Genre)) score += 5;

            // Preference 2: Quality (Rating)
            score += c.Rating * 0.5;

            // Preference 3: Recent releases (e.g., last 3 years)
            if (c.ReleaseYear >= 2023) score += 3;

            return score;
        }
    }
}
