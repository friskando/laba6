using ConsoleApp3;

internal class Program
{
    private static void Main(string[] args)
    {
        Test();
    }



    private static void Test()
    {
        Constructors();
        Mines();
        UnarOperator();
        //CastOperators();
        BinaryOperator();
    }
    
    //конструкторы
    private static void Constructors()
    {
        Console.WriteLine("конструкторы");

        Money defaultMoney = new Money();
        Console.Write("Конструктор по умолчанию:");
        defaultMoney.Print();

        Money money1 = new Money(15, 75);
        Console.Write("Конструктор с параметрами (15, 75):");
        money1.Print();

        Money copyMoney = new Money(money1);
        Console.Write("Конструктор копирования:");
        copyMoney.Print();

    }

    //вычитания
    private static void Mines()
    {
        Console.WriteLine("\n");

        Money money1 = InputMoney("Введите первую сумму");
        Money money2 = InputMoney("Введите выши гроши");

        Console.Write("Первая сумма: ");
        money1.Print();
        Console.Write("Вы насобирирали: ");
        money2.Print();

        Money result = money1.Subtract(money2);
        Console.Write("Результат вычитания");
        result.Print();

        Console.WriteLine();
    }
        
    //унарных операций ++ и --
    private static void UnarOperator()
    {

        Money money = InputMoney("Введите сумму для теста унарных операций:");

        Console.Write("Исходная сумма: ");
        money.Print();

        money++;
        Console.Write("После ++");
        money.Print();

        money--;
        money--;
        Console.Write("После --");
        money.Print();

        // Тест вычитания из нуля
        Console.Write("\nПроверка на банкрота ");
        Money zeroMoney = new Money(0, 0);
        zeroMoney.Print();
        zeroMoney--;
        zeroMoney.Print();

        Console.WriteLine();
    }

    //private static void CastOperators()
    //{

    //    Money money = InputMoney("Введите сумму для теста приведения типов:");

    //    Console.Write("Исходная сумма");
    //    money.Print();

    //    uint rublesOnly = money;
    //    Console.WriteLine($"Неявное приведение к uint (только рубли): {rublesOnly} руб.");

    //    Console.WriteLine();
    //}
    private static void BinaryOperator()
    {
        Console.WriteLine("Бинарные операции");

        // Тест Money - uint
        Money money1 = InputMoney("Введите сумму:");
        uint number = InputUint("Введите число для вычитания:");

        Console.Write("Исходная сумма: ");
        money1.Print();
        Console.WriteLine($"Вычитаем число: {number}");

        Money result1 = money1 - number;
        Console.Write("Результат (Money - uint): ");
        result1.Print();

        uint number2 = InputUint("Введите целое число:");
        Money money2 = InputMoney("Введите вычитаемую сумму:");

        Console.WriteLine($"Число: {number2}");
        Console.Write("Вычитаемая сумма: ");
        money2.Print();

        Money result2 = number2 - money2;
        Console.Write("Результат (uint - Money): ");
        result2.Print();

        Money money3 = InputMoney("Введите первую сумму:");
        Money money4 = InputMoney("Введите вторую сумму:");

        Console.Write("Первая сумма: ");
        money3.Print();
        Console.Write("Вторая сумма: ");
        money4.Print();

        Money result3 = money3 - money4;
        Console.Write("Результат (Money - Money): ");
        result3.Print();

        Console.WriteLine();
    }

    //ввод шекелей
    private static Money InputMoney(string request)
    {
        Console.WriteLine(request);

        uint rubles = InputUint("Введите рубли:");
        byte kopeks = InputByte("Введите гроши (0-99):");

        return new Money(rubles, kopeks);
    }

    private static uint InputUint(string request)
    {
        while (true)
        {
            Console.Write($"{request}: ");
            string input = Console.ReadLine();

            if (uint.TryParse(input, out uint result))
            {
                return result;
            }

            Console.WriteLine("Введите целое положительное число.");
        }
    }

    private static byte InputByte(string request)
    {
        while (true)
        {
            Console.Write($"{request}: ");
            string input = Console.ReadLine();

            if (byte.TryParse(input, out byte result) && result <= 99)
            {
                return result;
            }

            Console.WriteLine("Введите число от 0 до 99.");
        }
    }
}