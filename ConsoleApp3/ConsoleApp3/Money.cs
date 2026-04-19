using System;

namespace ConsoleApp3
{
    internal class Money
    {
        private uint _rubles;
        private byte _kopeks;

        // Конструкторы
        public Money()
        {
            _rubles = 0;
            _kopeks = 0;
        }

        public Money(uint rubles, byte kopeks)
        {
            _rubles = rubles;
            _kopeks = kopeks;
            //Normalize();
        }

        public Money(Money copyMoney)
        {
            _rubles = copyMoney._rubles;
            _kopeks = copyMoney._kopeks;
        }

        // Свойства
        public uint Rubles
        {
            get { return _rubles; }
            set { _rubles = value; }
        }

        public byte Kopeks
        {
            get { return _kopeks; }
            set
            {
                _kopeks = value;
                //Normalize();
            }
        }

        //private void Normalize()
        //{
        //    if (_kopeks >= 100)
        //    {
        //        _rubles += (uint)(_kopeks / 100);
        //        _kopeks = (byte)(_kopeks % 100);
        //    }
        //}

        public Money Subtract(Money other)
        {
            long TotoalGrosh = (long)_rubles * 100 + _kopeks;
            long otherTotalGrosh = (long)other._rubles * 100 + other._kopeks;
            long resultTotalGrosh = TotoalGrosh - otherTotalGrosh;

            // Проверка, что результат не отрицательный
            if (resultTotalGrosh < 0)
            {
                Console.WriteLine("ВЫ ВЗЯЛИ кредит");
                return new Money(0, 0);
            }

            uint resultRubles = (uint)(resultTotalGrosh / 100);
            byte resultKopeks = (byte)(resultTotalGrosh % 100);

            return new Money(resultRubles, resultKopeks);
        }

        public static Money operator ++(Money m)
        {
            // Добавление одной копейки
            byte newKopeks = (byte)(m._kopeks + 1);
            return new Money(m._rubles, newKopeks);
        }

        public static Money operator --(Money m)
        {
            // Вычитание одной копейки
            if (m._rubles == 0 && m._kopeks == 0)
            {
                Console.WriteLine("Нельзя взять кредит");
                return new Money(0, 0);
            }

            if (m._kopeks == 0)
            {
                return new Money(m._rubles - 1, 99);
            }
            else
            {
                return new Money(m._rubles, (byte)(m._kopeks - 1));
            }
        }

        public static Money operator -(Money m, uint number)
        {
            long totalKopeks = (long)m._rubles * 100 + m._kopeks;
            long subtractKopeks = (long)number * 100;
            long resultTotalGrosh = totalKopeks - subtractKopeks;

            if (resultTotalGrosh < 0)
            {
                Console.WriteLine("Ошибка");
                return new Money(0, 0);
            }

            uint resultRubles = (uint)(resultTotalGrosh / 100);
            byte resultKopeks = (byte)(resultTotalGrosh % 100);

            return new Money(resultRubles, resultKopeks);
        }

        public static Money operator -(uint number, Money m)
        {
            long totalKopeks = (long)number * 100;
            long subtractKopeks = (long)m._rubles * 100 + m._kopeks;
            long resultTotalGrosh = totalKopeks - subtractKopeks;

            if (resultTotalGrosh < 0)
            {
                Console.WriteLine("Ошибка");
                return new Money(0, 0);
            }

            uint resultRubles = (uint)(resultTotalGrosh / 100);
            byte resultKopeks = (byte)(resultTotalGrosh % 100);

            return new Money(resultRubles, resultKopeks);
        }

        public static Money operator -(Money m1, Money m2)
        {
            return m1.Subtract(m2);
        }

        public void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"{_rubles} руб. {_kopeks} коп.";
        }
    }
}