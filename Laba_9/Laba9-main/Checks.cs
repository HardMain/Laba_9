using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    public class Checks
    {
        static public int checkOnNumb(ref string? from, ref int at)
        {
            while (!(int.TryParse(from, out at)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nВведено неверное значение."); Console.ResetColor();
                Console.Write($"\nЗадайте новое: ");
                from = Console.ReadLine();
                int.TryParse(from, out at);
            }
            from = at.ToString();
            return at;
        }
        static public int checkOnLength(int length)
        {
            while (length <= 0)
            {
                string? lengthS;
                Console.Write("\nКоличество элементов массива не может быть отрицательным\n\nВведите другое значение:");
                lengthS = Console.ReadLine();
                length = checkOnNumb(ref lengthS, ref length);
            }
            return length;
        }
        static public int checkOnIndex(int count)
        {
            string? indS; int ind = 0;
            do
            {
                Console.WriteLine($"Введите номер элемента массива от 1 до {count}");
                indS = Console.ReadLine();
                ind = checkOnNumb(ref indS, ref ind);
            } while (ind <= 0 || ind > count);
            return ind;
        }
    }
}
