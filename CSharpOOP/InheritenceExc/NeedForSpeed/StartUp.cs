namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Car car = new(60, 50);
            car.Drive(5);
            System.Console.WriteLine(car.Fuel);
            RaceMotorcycle cbr1000 = new(120, 50);
            cbr1000.Drive(5);
            System.Console.WriteLine(cbr1000.Fuel);
        }
    }
}
