namespace PlayBox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Movie m  = new Movie("Ted", "Comedy", 9.0, 2013, "A funny teddy", 120);
            m.DisplayInfo();
            m.Play();

            Content C1 = new Movie("It", "Horror", 8.5, 2016, "Killer Clown", 110);
            Content C2 = new Series("The Boys", "Comedy", 7.9, 2022, "Supes dominating the world", 5);
            C1.DisplayInfo();
            C1.Play();
            C2.DisplayInfo();

            Series S = new Series("The Boys", "Comedy", 7.9, 2022, "Supes dominating the world", 5);
            Episode e1 = new Episode("Pilot", "Violence", 6.5, 2022, "A war hero is ready to comeback", 1, 1, 44);
            Episode e2 = new Episode("Bloodbath", "Action", 8.5, 2022, "The war starts and hopes seems to fade away.", 2, 1, 47);
            S.AddEpisode(e1);
            S.AddEpisode(e2);
            S.Play();
            e1.Play();
            e2.Play();
        }
    }
}
