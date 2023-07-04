namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Animal geroge = new("ffqf");

            Bear bear = new("bear");

            System.Console.WriteLine(bear.Name);
            System.Console.WriteLine(geroge.Name);
        }
    }
}