using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_9
{
    public class TimeArray
    {
        static Random random = new Random();
        Time[] arr;

        public TimeArray()
        {
            string msg = "";
            string errorMsg = "";
            Func<int, bool> condition;

            msg = "Введите количество элементов в массиве: ";
            errorMsg = "\nКоличество элементов должно быть положительным числом!\n";
            condition = (numberRows) => (numberRows < 1);
            int count = CheckAndInput.InputIntNumberByCondition(msg, errorMsg, condition);

            arr = new Time[count];
        }
        public TimeArray(int count)
        {
            arr = new Time[count];
        }

        public void FillRandom()
        {
            for (int i = 0; i < arr.Length; i++)
                arr[i] = new Time(random.Next(0, 100), random.Next(0, 100));
        }
        public void FillManual()
        {
            int hours = 0, minutes = 0;
            string msg = "", msg2 = "";
            string errorMsg = "", errorMsg2 = "";
            Func<int, bool> condition;

            msg = "Введите количество часов: ";
            errorMsg = "\nКоличество часов должно быть неотрицательным числом!\n";
            condition = (hours) => (hours < 0);

            msg2 = "Введите количество минут: ";
            errorMsg2 = "\nКоличество минут должно быть неотрицательным числом!\n";

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"\tЭлемент {i + 1}");
                hours = CheckAndInput.InputIntNumberByCondition(msg, errorMsg, condition);
                minutes = CheckAndInput.InputIntNumberByCondition(msg2, errorMsg2, condition);

                arr[i] = new Time(hours, minutes);
                Console.WriteLine();
            }
        }
        public void ShowArray()
        {
            Console.WriteLine("    [Элементы массива]");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"\tЭлемент {i + 1}");
                arr[i].ShowTime();
                Console.WriteLine();
            }
        }
        public void FindAverage()
        {
            double averageHours = 0, averageMinutes = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                averageHours += arr[i].Hours;
                averageMinutes += arr[i].Minutes;
            }

            averageHours /=  arr.Length;
            averageMinutes /= arr.Length;

            Console.WriteLine($"   [Среднее количество часов\\минут из {arr.Length} элементов]\nЧасы: {averageHours}\nМинуты: {averageMinutes}");
        }

        public Time this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                    throw new IndexOutOfRangeException();

                return arr[index];
            }
            set
            {
                if (index < 0 || index >= Length)
                    throw new IndexOutOfRangeException();

                arr[index] = value;
            }
        }

        public int Length { get { return arr.Length; } }

        public override bool Equals(object? obj)
        {
            if (obj is TimeArray other)
            {
                for (int i = 0; i < this.Length; i++)
                {
                    if (this[i].Hours != other[i].Hours || this[i].Minutes != other[i].Minutes)
                        return false;
                }
            }

            return true;
        }
    }   
}
