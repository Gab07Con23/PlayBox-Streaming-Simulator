using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayBox
{
    public class User
    {
        // Private fields
        private string name;
        private SubscriptionPlan subscription;
        private List<Content> watchHistory;
        private List<Content> watchList;

        // Constructor
        public User(string name, SubscriptionPlan subscription)
        {
            this.name = name;
            this.subscription = subscription;
            watchHistory = new List<Content>();
            watchList = new List<Content>();
        }

        // Properties
        public string Name
        {
            get { return name; }
        }

        public SubscriptionPlan Subscription
        {
            get { return subscription; }
        }

        // Methods
        public void AddToWatchList(Content c)
        {
            watchList.Add(c);
            Console.WriteLine($"{c.Title} added to watchlist.");
        }

        public void RateContent(Content c, double rating)
        {
            c.AddRating(rating);
            Console.WriteLine($"{name} rated {c.Title} {rating}/10");
        }

        public List<Content> GetWatchHistory()
        {
            return watchHistory;
        }

        public void AddToHistory(Content c)
        {
            watchHistory.Add(c);
        }
    }
}
