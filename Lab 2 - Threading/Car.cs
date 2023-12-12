using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2___Threading
{
    internal class Car
    {
        private string _name;
        private int _speed;

        public Car(string name)
        {
            name = _name;
            _speed = 120;
        }

        public static void SetSpeed(Car car, int speed)
        {
            car._speed = speed;
        }
    }
}
