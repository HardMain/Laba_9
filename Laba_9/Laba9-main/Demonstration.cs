using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    internal static class Demonstration
    {
        public static void CallDemonstration()
        {
            Console.WriteLine("Создан пустой объект: ");
            Money money = new Money();
            money.ShowMoney();

            Console.WriteLine("\n\n----Заполнение объекта----");
            Money moneyFill = Fill();
            Console.Write("\nПолученный объект: "); moneyFill.ShowMoney();

            Console.WriteLine("\n\n\n----Операция добавления копеек к типу Money----");

            Console.Write("\nВведите количество копеек для добавления: ");
            int kop = 0; string? kopS;
            kopS = Console.ReadLine();
            kop = Checks.checkOnNumb(ref kopS, ref kop);

            Console.Write("\nВыражение: "); moneyFill.ShowMoney(); Console.Write($" + {kop} коп.");
            Money res = moneyFill.PlusKopeks(kop);
            if (res.Rub + res.Kop > 0)
            {
                Console.Write(" = ");
                res.ShowMoney();
            };

            Console.WriteLine("\n\n\n----Операция вычитания из переменной типа Money переменную типа int----");
            Console.WriteLine("\n----Заполнение объекта----");
            Money moneyFill2 = Fill();
            int el = 0; string? elS;
            Console.Write("\nВведите целое число(копейки): ");
            elS = Console.ReadLine();
            el = Checks.checkOnNumb(ref elS, ref el);
            Console.Write("\n\nВыражение: "); moneyFill2.ShowMoney(); Console.Write($" - {el}");
            Money minusRes = moneyFill2 - el;
            if ((moneyFill2.Rub*100 + moneyFill2.Kop) >= el)
            {
                Console.Write(" = ");
                minusRes.ShowMoney();
            }

            Console.WriteLine("\n\n\n----Операция вычитания из переменной типа int переменную типа Money----");
            el = 0; elS = " ";
            Console.Write("\nВведите целое число(копейки): ");
            elS = Console.ReadLine();
            el = Checks.checkOnNumb(ref elS, ref el);
            Console.WriteLine("\n----Запонения объекта----");
            Money moneyFill3 = Fill();
            Console.Write($"\n\nВыражение: {el} - "); moneyFill3.ShowMoney();
            minusRes = el - moneyFill3;
            if (el >= (moneyFill3.Rub * 100 + moneyFill3.Kop))
            {
                Console.Write(" = ");
                minusRes.ShowMoney();
            }

            Console.WriteLine("\n\n\n----Операция сложения переменной типа Money и переменной типа int----");
            Console.WriteLine("\n----Заполнения объекта----");
            Money moneyFill5 = Fill();
            el = 0; elS = " ";
            Console.Write("\nВведите целое число(копейки): ");
            elS = Console.ReadLine();
            el = Checks.checkOnNumb(ref elS, ref el);
            Console.Write("\n\nВыражение: "); moneyFill5.ShowMoney(); Console.Write($" + {el}");
            Money plusRes = moneyFill5 + el;
            if (plusRes.Rub + plusRes.Kop > 0)
            {
                Console.Write(" = ");
                plusRes.ShowMoney();
            }

            Console.WriteLine("\n\n\n----Операция сложения переменной типа int и переменной типа Money----");
            el = 0; elS = " ";
            Console.Write("\nВведите целое число(копейки): ");
            elS = Console.ReadLine();
            el = Checks.checkOnNumb(ref elS, ref el);
            Console.WriteLine("\n----Запонения объекта----");
            Money moneyFill6 = Fill();
            Console.Write($"\n\nВыражение: {el} + "); moneyFill6.ShowMoney();
            plusRes = el + moneyFill6;
            if (plusRes.Rub + plusRes.Kop > 0)
            {
                Console.Write(" = ");
                plusRes.ShowMoney();
            }

            Console.WriteLine("\n\n\n----Операция инкремента----");
            Money moneyInc = Fill();
            moneyInc++;
            Console.Write("\nРезультат: "); moneyInc.ShowMoney();
            Console.WriteLine("\n\n\n----Операция декремента----");
            Money moneyDec = Fill();
            moneyDec--;
            if(moneyDec.Rub*100 + moneyDec.Kop > 0)
            {
                Console.Write("\nРезультат: ");
                moneyDec.ShowMoney();
            }

            Console.WriteLine("\n\nНажмите любую клавишу для продолжения");
            Console.ReadKey();
            Console.Clear();


            Console.WriteLine("----Работа с массивом----\n");

            int choice = 0; string choiceS;
            Console.Write("Выберите способ заполнения:\n1)Заполнение рандомными значениями\n2)Заполнение вручную\n0)Завершить выбор\nВаш выбор: ");
            choiceS = Console.ReadLine();
            choice = Checks.checkOnNumb(ref choiceS, ref choice);
            MoneyArray array = new MoneyArray();
            switch (choice)
            {
                case 1:
                    array.FillRandom();
                    break;
                case 2:
                    array.FillManual();
                    break;
                case 0:
                    break;
                default:
                    break;
            }
            Console.WriteLine("\nПолученный массив:");
            array.Show();

            Console.WriteLine("\n\n----Поиск минимальной денежной суммы в массиве----");

            Console.Write("\nМинимальная сумма денег в массиве: "); array.FindMin().ShowMoney(); Console.WriteLine();

            Console.WriteLine("\n\n----Использование оператора индексирования----");
            string indS;int ind = 0;
            ind = Checks.checkOnIndex(array.Length());

            Console.WriteLine("\nВведите новое значение для объекта: ");
            Money moneyInd = Fill();

            array[ind-1] = moneyInd;
            Console.WriteLine("\nПолученный массив:");
            array.Show();
        }
        public static Money Fill()
        {
            int rub = 0, kop = 0; string? rubS, kopS;
            do
            {
                Console.Write("\nВведите количество рублей: ");
                rubS = Console.ReadLine();
                rub = Checks.checkOnNumb(ref rubS, ref rub);
                if (rub < 0)
                    Console.WriteLine("\nРублей не может быть меньше 0\n");
            } while (rub < 0);
            do
            {
                Console.Write("Введите количество копеек: ");
                kopS = Console.ReadLine();
                kop = Checks.checkOnNumb(ref kopS, ref kop);
                if (kop < 0)
                    Console.WriteLine("\nКопеек не может быть меньше 0\n");
            } while (kop < 0);

            return new Money(rub, kop);
        }
    }
}
