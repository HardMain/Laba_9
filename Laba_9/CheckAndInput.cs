using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_9
{   
    internal static class CheckAndInput
    {
        static public int InputIntNumber(string msg = "", string errorMsg = "\nНекорректный ввод числа!\n")
        {
            string? strEl;
            int el = 0;
            do
            {
                Console.Write(msg);
                strEl = Console.ReadLine();
                if (!int.TryParse(strEl, out el))
                    Console.WriteLine(errorMsg);
            } while (!int.TryParse(strEl, out el));

            return el;
        }
        static public int InputIntNumberByCondition(string msg, string errorMsg, Func<int, bool> condition)
        {
            int el = 0;
            do
            {
                el = InputIntNumber(msg);
                if (condition(el))
                    Console.WriteLine(errorMsg);
            } while (condition(el));

            return el;
        }
    }
}
