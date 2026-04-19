namespace ConsoleApp2
{
    internal class Age : FullName
    {
        private int _fullAge;
        private DateTime _dateOfBirth;

        // Конструктор по умолчанию
        public Age() : base()
        {
            _fullAge = 24;
            _dateOfBirth = DateTime.Parse("22.09.2002");
        }

        public Age(char first, char second, string birthDate) : base(first, second)
        {
            _dateOfBirth = DateTime.Parse(birthDate);
            _fullAge = CalculateAge(_dateOfBirth);
        }

        // Метод расчета возраста
        private int CalculateAge(DateTime dateOfBirth)
        {
            DateTime today = DateTime.Today;
            int FullAge = today.Year - dateOfBirth.Year;
            return FullAge;
        }

        public void Print()
        {
            Console.WriteLine(ToString());
        }

        public void Difference(Age otherPerson)
        {
            if (_fullAge > otherPerson._fullAge)
            {
                Console.WriteLine($"Возраст {_firstNameLetter}.{_lastNameLetter} больше на {_fullAge - otherPerson._fullAge}");
            }
            else if (otherPerson._fullAge > _fullAge)
            {
                Console.WriteLine($"Возраст {otherPerson._firstNameLetter}.{otherPerson._lastNameLetter} больше на {otherPerson._fullAge - _fullAge}");
            }
            else
            {
                Console.WriteLine($"Возраст {_firstNameLetter}.{_lastNameLetter} и {otherPerson._firstNameLetter}.{otherPerson._lastNameLetter} одинаковый");
            }
        }

        public override string ToString()
        {
            return $"{_firstNameLetter}.{_lastNameLetter}. Date of birth: {_dateOfBirth.ToShortDateString()} age = {_fullAge}";
        }
    }
}