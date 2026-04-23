using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Money
    {
        private uint _rub;
        private byte _kop;

        public Money()
        {
            _rub = 150;
            _kop = 15;
        }

        public Money(uint rubles, byte kopeks)
        {
            _rub = rubles;
            _kop = kopeks;
            Normalize();
        }

        private void Normalize()
        {
            if (_kop >= 100)
            {
                _rub += (uint)(_kop / 100);
                _kop = (byte)(_kop % 100);
            }
        }

        public void Minus(uint rublesToSubtract, byte kopToSubtract)
        {
            int currentTotal = (int)(_rub * 100 + _kop);
            int subtractTotal = (int)(rublesToSubtract * 100 + kopToSubtract);

            if (currentTotal < subtractTotal)
            {
                Console.WriteLine("В долг не дам");
                return;
            }
            else
            {
                int resultTotal = currentTotal - subtractTotal;
                _rub = (uint)(resultTotal / 100);
                _kop = (byte)(resultTotal % 100);
            }
        }
        public void Print()
        {
            Console.WriteLine($"Баланс: {ToString()}");
        }
        public override string ToString()
        {
            return $"{_rub} руб. {_kop} коп.";
        }

      




        public static Money operator ++(Money m)
        {
            byte newKopeks = (byte)(m._kop + 1);
            return new Money(m._rub, newKopeks);
        }

        public static Money operator --(Money m)
        {
            if (m._rub == 0 && m._kop == 0)
            {
                Console.WriteLine("Ошибка: нельзя вычесть копейку из нулевой суммы!");
                return new Money(0, 0);
            }

            if (m._kop == 0)
            {
                return new Money(m._rub - 1, 99);
            }
            else
            {
                return new Money(m._rub, (byte)(m._kop - 1));
            }
        }






        public static implicit operator uint(Money m)
        {
            return m._rub;
        }

        public static explicit operator double(Money m)
        {
            return m._kop / 100.0;
        }







        public static Money operator +(Money m, uint rubles)
        {
            return new Money(m._rub + rubles, m._kop);
        }
        public static Money operator +(uint rubles, Money m)
        {
            return new Money(m._rub + rubles, m._kop);
        }
        public static Money operator +(Money m1, Money m2)
        {
            uint totalRub = m1._rub + m2._rub;
            byte totalKop = (byte)(m1._kop + m2._kop);
            return new Money(totalRub, totalKop);
        }
        public static Money operator -(Money m, uint rubles)
        {
            if (m._rub < rubles)
            {
                Console.WriteLine("В долг незя");
                return new Money(0, 0);
            }
            return new Money(m._rub - rubles, m._kop);
        }
        public static Money operator -(uint rubles, Money m)
        {
            if (rubles < m._rub)
            {
                Console.WriteLine("В долг незя");
                return new Money(0, 0);
            }
            if (m._kop > 0)
            {
                if (rubles <= m._rub)
                {
                    Console.WriteLine("В долг незя");
                    return new Money(0, 0);
                }
                uint resultRub = rubles - m._rub - 1;
                byte resultKop = (byte)(100 - m._kop);
                return new Money(resultRub, resultKop);
            }
            return new Money(rubles - m._rub, 0);
        }
        public static Money operator -(Money m1, Money m2)
        {
            int total1 = (int)(m1._rub * 100 + m1._kop);
            int total2 = (int)(m2._rub * 100 + m2._kop);

            if (total1 < total2)
            {
                Console.WriteLine("В долг незя");
                return new Money(0, 0);
            }

            int result = total1 - total2;
            return new Money((uint)(result / 100), (byte)(result % 100));
        }

    }
}
