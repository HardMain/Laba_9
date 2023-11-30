using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    public class Money
    {
        int rubles, kopeks;

        public Money()
        {
            rubles = 0;
            kopeks = 0;
        }
        public Money(int rubles, int kopeks):this()
        {
            Rub = rubles; 
            Kop = kopeks;
        }
        public Money(Money other):this()
        {
            rubles = other.rubles;
            kopeks = other.kopeks;
        }
        public int Rub
        {
            get { return rubles; }
            set 
            { 
                if(value < 0)
                    return;
                
                rubles = value;
            }
        }
        public int Kop
        {
            get { return kopeks; }
            set
            {
                if(value < 0)
                {
                    if(rubles*100 < Math.Abs(value))
                        return;
                    
                    int temp = rubles;
                    rubles = 0;
                    Kop = temp * 100 + value;
                    return;
                }
                rubles += value / 100;
                kopeks = value % 100;
            }
        }
        public Money PlusKopeks(int kop)
        {
            Kop += kop;
            return this;
        }
        public static Money operator -(Money money1, int kop)
        {
            if (money1.Rub * 100 + money1.Kop < kop)
            {
                Console.Write("\n\nНедостаточно средств. Пополните баланс. Ваша денежная сумма не изменена.");
                return new Money();
            }

            Money temp = new Money(money1);
            temp.Kop -= kop;

            return temp;
        }
        public static Money operator -(int kop, Money money1)
        {
            if (money1.Rub * 100 + money1.Kop > kop)
            {
                Console.Write("\n\nНедостаточно средств. Пополните баланс. Ваша денежная сумма не изменена.");
                return new Money();
            }

            Money temp = new Money((kop - (money1.Rub * 100 + money1.Kop)) / 100, (kop - (money1.Rub * 100 + money1.Kop)) % 100);
            return temp;
        }
        public static Money operator +(Money money1, int kop)
        {
            Money temp = new Money(money1);
            temp.Kop += kop;
            return temp;
        }
        public static Money operator +(int kop, Money money1)
        {
            Money temp = new Money((kop + (money1.Rub * 100 + money1.Kop)) / 100, (kop + (money1.Rub * 100 + money1.Kop)) % 100);
            return temp;
        }

        public static Money operator ++(Money money)
        {
            return new Money(money.Rub, money.Kop +1);
        }
        public static Money operator --(Money money)
        {
            if (money.Rub * 100 + money.Kop <= 0)
            {
                Console.Write("\n\nНедостаточно средств. Пополните баланс. Ваша денежная сумма не изменена.");
                return new Money();
            }
            return new Money(money.Rub, money.Kop - 1);
        }

        public static explicit operator int(Money money)
        {
            return money.Rub;
        }
        public static implicit operator double(Money money)
        {
            return (double)money.Kop / 100;
        }
        public void ShowMoney()
        {
            Console.Write($"{this.rubles} руб. {this.kopeks} коп.");
        }

        public override bool Equals(object? obj)
        {
            if (obj is Money other)
            {
                return (Rub == other.Rub && Kop == other.Kop);
            }
            return false;
        }
    }
}
