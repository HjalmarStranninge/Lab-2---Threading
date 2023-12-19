using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2___Threading
{
    // Handles the different hazards that can occur during a race.
    internal static class Hazards
    {
        
        public static void OutOfGas(Car car)
        {
            Console.WriteLine($"{car.Name} is out of fuel and will have to fill up. This will take 30 seconds.");
            Thread.Sleep(30000);
            Console.WriteLine($"{car.Name} is filled up and back on the track!");
        }

        public static void FlatTire (Car car)
        {
            Console.WriteLine($"{car.Name} has a flat tire, changing it will take 20 seconds.");
            Thread.Sleep(20000);
            Console.WriteLine($"{car.Name} had the flat tire swapped out. Race is back on!");
        }

        public static void BirdOnWindshield(Car car)
        {
            Console.WriteLine($"{car.Name} ran into a bird and will have to stop for 10 seconds to wipe of the windshield.");
            Thread.Sleep(10000);
            Console.WriteLine($"{car.Name} had the windshield cleaned and can keep going!");
        }

        public static void EngineFailure(Car car)
        {
            Car.ReduceSpeedBy1(car);
            Console.WriteLine($"{car.Name} had an engine failure, top speed is reduced to {car.Speed}");
        }


        // Generates a random hazard event.
        public static void GenerateHazard(Car car)
        {           
            var random = new Random();
            int roll = random.Next(0, 100);

            if (roll < 2)
            {
                OutOfGas(car);
            }
            else if (roll < 6)
            {
                FlatTire(car);
            }
            else if (roll < 16)
            {
                BirdOnWindshield(car);
            }
            else if (roll < 36)
            {
                EngineFailure(car);
            }
        }
    }
}
