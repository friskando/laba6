using ConsoleApp2;

internal class Program
{
    private static void Main(string[] args)
    {
        Ask();
    }

    private static void Ask()
    {
        Console.WriteLine("First person\n");
        Age person = new Age(Name(), LastName(), DateOfBirth());

        Console.WriteLine("\nSecond person\n");
        Age person2 = new Age(Name(), LastName(), DateOfBirth());

        person.Print();
        person2.Print();
        person.Difference(person2);

        Console.WriteLine("\nTree person");
        FullName defaultPerson = new FullName();

        FullName copiedPerson = new FullName(person2);

        Console.WriteLine("\nPerson default");
        defaultPerson.Print();

        Console.WriteLine("\nCopy Second person");
        copiedPerson.Print();
    }

    private static char Name()
    {
        Console.WriteLine("Введите первую букву имени:");
        char name = Console.ReadKey().KeyChar;
        Console.WriteLine();
        return name;
    }

    private static char LastName()
    {
        Console.WriteLine("Введите первую букву фамилии:");
        char lastName = Console.ReadKey().KeyChar;
        Console.WriteLine();
        return lastName;
    }

    private static string DateOfBirth()
    {
        while (true)
        {
            Console.Write("Введите дату рождения (дд.мм.гггг): ");
            string input = Console.ReadLine();

            if (DateTime.TryParse(input, out DateTime dateOfBirth))
            {
                return dateOfBirth.ToString("dd.MM.yyyy");
            }

            Console.WriteLine("Неверный формат даты! Используйте формат дд.мм.гггг");
        }
    }
}