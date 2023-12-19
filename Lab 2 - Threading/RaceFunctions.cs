using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2___Threading
{
    // Class containing race related functions.
    internal class RaceFunctions
    {
        private static readonly object lockObject = new object();

        // Runs the race and tracks time and distance covered, as well as triggers the hazard generation every 30 seconds.
        public static void StartRace(Car car, ref bool isFirst)
        {
            Console.WriteLine($"{car.Name} started the race! VROOOM!!!");

            const double TrackLengthKm = 10;

            double currentPosition = 0;
            double timeElapsed = 0; 

            DateTime startTime = DateTime.Now;
            DateTime lastHazardCheck = startTime;         

            while (currentPosition < TrackLengthKm)
            {
                DateTime currentTime = DateTime.Now;
                double speedKilometersPerSecond = car.Speed / 3600;

                timeElapsed = (currentTime - startTime).TotalSeconds;

                currentPosition = speedKilometersPerSecond * timeElapsed;

                if ((currentTime - lastHazardCheck).TotalSeconds >= 30)
                {
                    Hazards.GenerateHazard(car);
                    currentTime = DateTime.Now;
                    lastHazardCheck = currentTime;
                }

                Thread.Sleep (500);
            }
            FinishLine(car, ref isFirst);          
        }

        // Tracks which car finishes the race first by updating a bool variable when the first car crosses the line.
        public static void FinishLine(Car car, ref bool isFirst)
        {
            lock (lockObject)
            {
                if (isFirst)
                {
                    Console.WriteLine($"{car.Name} won the race!");
                    isFirst = false;
                }
                else
                {
                    Console.WriteLine($"{car.Name} finished second and lost!");
                }
            }          
        }
    }
}
