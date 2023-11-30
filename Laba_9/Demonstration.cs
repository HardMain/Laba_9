using Laba_9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_9
{
    internal static class Demonstration
    {
        static public void CallDemonstration()
        {
            Func<int, bool> condition = (hours) => (hours < 0);
            
            string errorMsg = "\nКоличество часов должно быть неотрицательным числом!\n",
                   errorMsg2 = "\nКоличество минут должно быть неотрицательным числом!\n";

            //----------------------------------------------------------------------

            Console.WriteLine("Пустой объект 'A'(конструктор по умолчанию): ");

            Time time = new Time();
            time.ShowTime();
            Console.WriteLine('\n' + new string('-', 35) + '\n');

            //----------------------------------------------------------------------

            int hours = 0, minutes = 0;

            string msg = "Введите количество часов для заполнения объекта 'B': ",
                   msg2 = "Введите количество минут для заполнения объекта 'B': ";

            hours = CheckAndInput.InputIntNumberByCondition(msg, errorMsg, condition);
            minutes = CheckAndInput.InputIntNumberByCondition(msg2, errorMsg2, condition);

            Console.WriteLine("\nЗаполненный объект 'B'(конструктор с параметрами): ");

            Time time2 = new Time(hours, minutes);
            time2.ShowTime();
            Console.WriteLine('\n' + new string('-', 35) + '\n');

            //----------------------------------------------------------------------

            Console.WriteLine("Заполненный объект 'C' из объекта 'B'(конструктор копирования): ");

            Time time3 = new Time(time2);
            time3.ShowTime();

            Console.WriteLine();
            string msg3 = "Введите количество минут для добавления к объекту 'C': ";
            minutes = CheckAndInput.InputIntNumberByCondition(msg3, errorMsg2, condition);

            Console.Write($"\nДобавление минут к объекту 'C': {time3.Hours}ч {time3.Minutes}м + {minutes}м = ");

            time3 = time3 + minutes;

            Console.WriteLine($"{time3.Hours}ч {time3.Minutes}м");

            Console.WriteLine('\n' + new string('-', 35) + '\n');

            //----------------------------------------------------------------------

            Console.WriteLine("объект 'C': ");
            time3.ShowTime();

            Console.WriteLine();
            string msg4 = "Введите количество минут для вычитания из объекта 'C': ";
            minutes = CheckAndInput.InputIntNumberByCondition(msg4, errorMsg2, condition);

            Console.Write($"\nВычитание минут из объекта 'C': {time3.Hours}ч {time3.Minutes}м - {minutes}м = ");

            time3 = time3 - minutes; 

            Console.WriteLine($"{time3.Hours}ч {time3.Minutes}м");

            Console.WriteLine('\n' + new string('-', 35) + '\n');

            //----------------------------------------------------------------------

            Console.WriteLine($"Постфиксный инкремент объекта 'C':\n");

            Console.WriteLine("В момент инкремента 'C': ");
            (time3++).ShowTime();
            Console.WriteLine();

            Console.WriteLine("После инкремента 'C': ");
            time3.ShowTime();

            Console.WriteLine('\n' + new string('-', 35) + '\n');

            //----------------------------------------------------------------------

            Console.WriteLine($"Постфиксный декремент объекта 'C':\n");

            Console.WriteLine("В момент декремента 'C': ");
            (time3--).ShowTime();
            Console.WriteLine();

            Console.WriteLine("После декремента 'C': ");
            time3.ShowTime();

            Console.WriteLine('\n' + new string('-', 35) + '\n');

            //----------------------------------------------------------------------

            Console.WriteLine("объект 'C': ");
            time3.ShowTime();

            Console.WriteLine($"\nЯвное приведение типов (оставить количество часов): int obj = (int)'C':\n");

            int obj = (int)time3;

            Console.WriteLine($"obj = {obj}");

            Console.WriteLine('\n' + new string('-', 35) + '\n');

            //----------------------------------------------------------------------

            Console.WriteLine("объект 'C': ");
            time3.ShowTime();

            Console.WriteLine($"\nНеявное приведение типов (проверить наличие времени): bool isNonEmpty = 'C':\n");

            bool isNonEmpty = time3;

            Console.WriteLine($"isNonEmpty = {isNonEmpty}");

            Console.WriteLine('\n' + new string('-', 35) + '\n');

            //----------------------------------------------------------------------

            Console.WriteLine("Создание коллекции - объект 'D':\n");
            
            TimeArray timeArray = new TimeArray();

            string msg5 = "\nВыберите способ заполнения\n1.Вручную\n2.Рандомно\n->";
            string errorMsg3 = "Некорректный ввод пункта. Повторите попытку!";
            int choice = 0;
            Func<int, bool> condition2 = (choice) => (choice < 1 || choice > 2);

            choice = CheckAndInput.InputIntNumberByCondition(msg5, errorMsg3, condition2);

            Console.WriteLine();
            switch (choice)
            {
                case 1:
                    timeArray.FillManual(); break;
                case 2:
                    timeArray.FillRandom(); break;
            }

            timeArray.ShowArray();

            Console.WriteLine(new string('-', 35) + '\n');

            //----------------------------------------------------------------------

            Console.WriteLine("\tКоллекция 'D':\n");
            timeArray.FindAverage();
            Console.WriteLine('\n' + new string('-', 35) + '\n');

            //----------------------------------------------------------------------

            Console.WriteLine($"\tПервый объект коллекции D[0]:");
            timeArray[0].ShowTime();
        }

    }
}