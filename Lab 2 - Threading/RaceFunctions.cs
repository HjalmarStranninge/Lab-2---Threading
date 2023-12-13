using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2___Threading
{
    internal class RaceFunctions
    {
        public static void StartRace(Car car, bool isFirst)
        {
            Console.WriteLine($"{car.Name} started the race! VROOOM!!!");

            const double TrackLengthKm = 5;

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

                if ((currentTime - lastHazardCheck).TotalSeconds >= 10)
                {
                    Hazards.GenerateHazard(car);
                    lastHazardCheck = currentTime;
                }

                Thread.Sleep (500);
            }
            FinishLine(car, isFirst);
            

        }

        public static void FinishLine(Car car, bool isFirst)
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
