namespace ConsoleApp2
{
    internal class FullName
    {
        protected char _firstNameLetter;
        protected char _lastNameLetter;

        public FullName()
        {
            _firstNameLetter = 'K';
            _lastNameLetter = 'N';
        }

        public FullName(FullName copyName)
        {
            _firstNameLetter = copyName._firstNameLetter;
            _lastNameLetter = copyName._lastNameLetter;
        }

        public FullName(char first, char second)
        {
            _firstNameLetter = first;
            _lastNameLetter = second;
        }

        protected string ConvertCharToString(char letter)
        {
            return letter.ToString();
        }

        public void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"{_firstNameLetter}.{_lastNameLetter}.";
        }
    }
}