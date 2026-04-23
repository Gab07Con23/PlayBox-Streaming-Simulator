using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayBox
{
    public class User
    {
        private string name;
        private SubscriptionPlan subscription;
        private List<Content> watchHistory;
        private List<Content> watchList; // Field is lowercase 'w'

        public User(string name, SubscriptionPlan subscription)
        {
            this.name = name;
            this.subscription = subscription;
            watchHistory = new List<Content>();
            watchList = new List<Content>();
        }

        public string Name => name;
        public SubscriptionPlan Subscription => subscription;

        // 1. ADD THIS PROPERTY: MenuController looks for 'Watchlist' (Uppercase 'W')
        public List<Content> Watchlist
        {
            get { return watchList; }
        }

        public void AddToWatchlist(Content c)
        {
            if (!watchList.Contains(c))
            {
                watchList.Add(c);
                Console.WriteLine($"{c.Title} added to watchlist.");
            }
        }

        // 2. ADD THIS METHOD: MenuController looks for 'RemoveFromWatchlist'
        public void RemoveFromWatchlist(Content c)
        {
            if (watchList.Contains(c))
            {
                watchList.Remove(c);
                Console.WriteLine($"{c.Title} removed from watchlist.");
            }
        }

        // Method that receives a rating number from the user
        public void RateContent(Content c, double rating)
        {
            c.AddRating(rating);
            Console.WriteLine($"{name} rated {c.Title} {rating}/10");
        }

        public List<Content> GetWatchHistory() => watchHistory;

        public void AddToHistory(Content c)
        {
            watchHistory.Add(c);
        }
    }
}
