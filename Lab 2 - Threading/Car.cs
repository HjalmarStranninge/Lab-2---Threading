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
        private double _speed;

        public double Speed
        {
            get { return _speed; }
        }

        public string Name
        {
            get { return _name; }
        }

        public Car(string name)
        {
            _name = name;
            _speed = 120;
        }

        public static void ReduceSpeedBy1(Car car)
        {
            car._speed--;
        }
    }
}
