using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    public class MoneyArray
    {
        static int j = 0, k = 0;
        static Random rand = new Random();
        Money[] array;

        public MoneyArray()
        {
            int count = 0; string? countS;
            Console.Write("Введите количество элементов массива: ");
            countS = Console.ReadLine();
            count = Checks.checkOnNumb(ref countS, ref count);
            count = Checks.checkOnLength(count);
            array = new Money[count];
        }
        public MoneyArray(int size)
        {
            array = new Money[size];
        }
        public void FillRandom()
        {
            for (int i = 0; i < array.Length; ++i)
                    array[i] = new Money(rand.Next(0, 99), rand.Next(0, 99));
        }
        public void FillManual()
        {            
            string? rubS, kopS; int rub = 0, kop = 0;
            for (int i = 0; i < array.Length; ++i)
            {
                Console.WriteLine($"Введите количество рублей для [{i + 1}]-го элемента");
                rubS = Console.ReadLine();
                rub = Checks.checkOnNumb(ref rubS, ref rub);

                Console.WriteLine($"Введите количество копеек для [{i + 1}]-го элемента");
                kopS = Console.ReadLine();
                kop = Checks.checkOnNumb(ref kopS, ref kop);

                array[i] = new Money(rub, kop);
            }            
        }
        public void Show()
        {
            foreach (var item in array)
            {
                item.ShowMoney();
                Console.WriteLine();
            }
        }
        public int Length()
        {
            return array.Length;
        }
        public Money FindMin()
        {
            int minEl = array[0].Rub * 100 + array[0].Kop;
            int index = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if ((array[i].Rub * 100 + array[i].Kop) < minEl)
                {
                    minEl = array[i].Rub * 100 + array[i].Kop;
                    index = i;
                }
            }
            return array[index];
        }
        public Money this[int key]
        {
            get 
            {
                if (key >= 0 && key < array.Length)
                    return array[key];
                
                Console.WriteLine("Неверный индекс");
                key = Checks.checkOnIndex(array.Length);
                return array[key - 1];
            }
            set 
            { 
                if(key >= 0 && key < array.Length)
                    array[key] = value;
                else
                {
                    Console.WriteLine("Неверный индекс");
                    key = Checks.checkOnIndex(array.Length);
                    array[key - 1] = value;
                }
                
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj is MoneyArray other)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (this[i].Rub != other[i].Rub || this[i].Kop != other[i].Kop)
                        return false;
                }
            }
            return true;
        }
    }
}
