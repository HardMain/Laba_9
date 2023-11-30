using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_9
{
    public class Time
    {
        private int _hours, _minutes;
        private static int count = 0;

        public static Time operator +(Time time1, int minutes)
        {
            Time temp = new Time(time1);
            temp.Minutes += minutes;

            return temp;
        }
        public static Time operator +(int minutes, Time time1)
        {
            return time1 + minutes;
        }
        public static Time operator -(Time time1, int minutes)
        {
            Time temp = new Time(time1);
            temp.Minutes -= minutes; //temp.Minutes = temp.Minutes - minutes;

            return temp;
        }
        public static Time operator -(int minutes, Time time1)
        {
            minutes -= time1.Minutes + time1.Hours * 60;

            return new Time(0, minutes);
        }
        public static Time operator ++(Time time1)
        {
            return new Time(time1.Hours, time1.Minutes + 1);
        }
        public static Time operator --(Time time1)
        {
            return new Time(time1.Hours, time1.Minutes - 1);
        }

        public static explicit operator int(Time time1)
        {
            return time1.Hours;
        }
        public static implicit operator bool(Time time1)
        {
            return time1.Hours != 0 && time1.Minutes != 0;
        }

        public Time()
        {
            _hours = 0;
            _minutes = 0;

            count++;
        }
        public Time(int hours, int minutes) : this()
        {
            Hours = hours;
            Minutes = minutes;
        }
        public Time(Time other) : this()
        {
            _hours = other._hours;
            _minutes = other._minutes;
        }

        public int Hours
        {
            get { return _hours; }
            set { _hours = value; }
        }
        public int Minutes
        {
            get { return _minutes; }
            set
            {
                if (value < 0)
                {
                    if (_hours * 60 < Math.Abs(value))
                        return;

                    int temp = _hours;
                    _hours = 0;
                    Minutes = temp * 60 - Math.Abs(value);
                    return;
                }

                _hours += value / 60;
                _minutes = value % 60;
            }
        }
        public static int Count{ get { return count; } }

        public void ShowTime()
        {
            Console.WriteLine($"Часы: {Hours}");
            Console.WriteLine($"Минуты: {Minutes}");
        }
        public Time PlusMinutes(int minutes)
        {
            Minutes += minutes;

            return this;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Time other)
                return Hours == other.Hours && Minutes == other.Minutes;

            return false;
        }
    }
}
