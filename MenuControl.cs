using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayBox
{
    public class MenuController
    {
        private User _currentUser;
        private List<Content> _allContent;
        private MediaPlayer _player = new MediaPlayer();
        private RecommendationEngine _engine;

        public MenuController(User user, List<Content> content)
        {
            _currentUser = user;
            _allContent = content;
            _engine = new RecommendationEngine(content);
        }

        // Main navigation loop
        public void Run()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine($"\n--- Welcome to PlayBox, {_currentUser.Name} ---");
                Console.WriteLine("1. Browse\n2. Watchlist\n3. View Plan\n4. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": BrowseMenu(); break;
                    case "2": WatchlistMenu(); break;
                    case "3": _currentUser.Subscription.DisplayPlan(); Console.ReadKey(); break;
                    case "4": running = false; break;
                    default: Console.WriteLine("Invalid option."); Console.ReadKey(); break;
                }
            }
            Console.WriteLine("Thank you for using PlayBox!");
        }

        // Handles displaying content and playing media
        private void BrowseMenu()
        {
            Console.Clear();
            var recommendations = _engine.GetPersonalizedRecommendations(_currentUser);

            Console.WriteLine("--- Top Picks For You ---");
            recommendations.ForEach(c => c.DisplayInfo());

            Console.WriteLine("\n--- Browse All ---");
            _allContent.Except(recommendations).ToList().ForEach(c => c.DisplayInfo());

            Console.Write("\nEnter Title to play (or press Enter to go back): ");
            string title = Console.ReadLine();

            Content selected = _allContent.FirstOrDefault(c => c.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (selected != null)
            {
                // Check if selected content is a Series
                if (selected is Series series)
                {
                    Console.Clear();
                    Console.WriteLine($"Series: {series.Title}");
                    Console.WriteLine("Select an episode to play (e.g., S1E1):");

                    // Display all episodes
                    series.Episodes.ForEach(e => Console.WriteLine($"S{e.SeasonNumber}E{e.EpisodeNumber} - {e.Title}"));

                    Console.Write("\nEnter Episode code: ");
                    string epCode = Console.ReadLine();

                    // Find the specific episode
                    var episodeToPlay = series.Episodes.FirstOrDefault(e => $"S{e.SeasonNumber}E{e.EpisodeNumber}".Equals(epCode, StringComparison.OrdinalIgnoreCase));

                    if (episodeToPlay != null)
                    {
                        Console.WriteLine($"Starting playback of {episodeToPlay.Title}...");
                        // Note: Ensure your MediaPlayer has a way to play an Episode
                        _player.Play(episodeToPlay);
                    }
                    else
                    {
                        Console.WriteLine("Episode not found. Press any key to return.");
                        Console.ReadKey();
                        return;
                    }
                }
                else
                {
                    // If it's a Movie, just play it directly
                    _player.Play(selected);
                }

                // Now the rating prompt will ONLY show after the user has finished selecting/playing
                Console.Write("\nRate this content (0-10): ");
                if (double.TryParse(Console.ReadLine(), out double rating))
                {
                    _currentUser.RateContent(selected, rating);
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        // Manages adding, removing, and viewing watchlist
        private void WatchlistMenu()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("--- Watchlist Menu ---");
                Console.WriteLine("1. See Watchlist\n2. Add to Watchlist\n3. Remove from Watchlist\n4. Back");
                Console.Write("Select: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        _currentUser.Watchlist.ForEach(c => Console.WriteLine(c.Title));
                        Console.ReadKey(); break;
                    case "2":
                        Console.Write("Enter title to add: ");
                        string addTitle = Console.ReadLine();
                        var toAdd = _allContent.FirstOrDefault(c => c.Title.Equals(addTitle, StringComparison.OrdinalIgnoreCase));
                        if (toAdd != null) _currentUser.AddToWatchlist(toAdd);
                        break;
                    case "3":
                        Console.Write("Enter title to remove: ");
                        string remTitle = Console.ReadLine();
                        var toRem = _currentUser.Watchlist.FirstOrDefault(c => c.Title.Equals(remTitle, StringComparison.OrdinalIgnoreCase));
                        if (toRem != null) _currentUser.RemoveFromWatchlist(toRem);
                        break;
                    case "4": back = true; break;
                }
            }
        }
    }
}