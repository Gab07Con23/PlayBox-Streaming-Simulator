using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayBox
{
    internal class RecommendationEngine
    {
        private List<Content> allContent;

        // Constructor
        public RecommendationEngine(List<Content> contentList)
        {
            allContent = contentList;
        }

        // Recommend by Genre
        public List<Content> RecommendByGenre(User user, string genre)
        {
            return allContent.Where(c => c.Genre == genre).ToList();
        }

        // Recommend Trending (simple: highest rating)
        public List<Content> RecommendTrending()
        {
            return allContent
                .OrderByDescending(c => c.Rating)
                .Take(5)
                .ToList();
        }

        // Recommend based on watch history
        public List<Content> RecommendBasedOnHistory(User user)
        {
            var historyGenres = user.GetWatchHistory()
                                     .Select(c => c.Genre)
                                     .Distinct();

            return allContent
                .Where(c => historyGenres.Contains(c.Genre))
                .Take(5)
                .ToList();
        }
    }
}
