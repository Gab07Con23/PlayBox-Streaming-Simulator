using System;

namespace PlayBox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Load data
            // We initialize the library once so it can be passed to our controllers
            List<Content> library = MockData.GetMockData();

            // 2. Simple User Login
            // In a real app, this would check a database, but for now we create a user object
            Console.WriteLine("=======================");
            Console.WriteLine("Welcome to Playbox!");
            Console.Write("Enter your username: ");
            string name = Console.ReadLine();

            // Assume a default plan for new users for now
            SubscriptionPlan defaultPlan = new SubscriptionPlan("Basic", 1, 9.99);
            User currentUser = new User(name, defaultPlan);

            // 3. Start the application
            // We pass the dependencies (user and library) to our MenuController
            MenuController app = new MenuController(currentUser, library);
            app.Run();
        }
    }
}
