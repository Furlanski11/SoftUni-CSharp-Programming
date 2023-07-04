namespace Restaurant
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Fish fish = new("cipura", 5);
            System.Console.WriteLine(fish.Grams);
        }
    }
}