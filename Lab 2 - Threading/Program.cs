namespace Lab_2___Threading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var car1 = new Car("Lightning McQueen");
            var car2 = new Car("Rory the Racecar");

            bool isFirst = true;

            Thread thread1 = new Thread(() => RaceFunctions.StartRace(car1, isFirst));
            Thread thread2 = new Thread(() => RaceFunctions.StartRace(car2, isFirst));

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();
        }
    }
}
