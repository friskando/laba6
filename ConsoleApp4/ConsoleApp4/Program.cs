using ConsoleApp4;
using System.Data;

internal class Program
{
    private static void Main(string[] args)
    {
        TestBinary();
        //TestCompite();
        //TestUnarOperator();
        //DefoultMoney();
        //PayMoney();


    }
    private static void DefoultMoney()
    {
        Money DefMoney = new Money();
        DefMoney.Print();

    }
    private static void PayMoney()
    {
        uint rubles = 0;
        byte kopeks = 0;
        uint tempKopeks;

        Console.Write("Введите рубли: ");
        while (!uint.TryParse(Console.ReadLine(), out rubles))
            Console.Write("Ошибка! Введите целое положительное число: ");

        Console.Write("Введите копейки (0-255): ");
        while (!uint.TryParse(Console.ReadLine(), out tempKopeks) || tempKopeks > 255)
        {
            if (tempKopeks > 255)
                Console.Write("Ошибка! Копейки не могут быть больше 255: ");
            else
                Console.Write("Ошибка! Введите целое положительное число: ");
        }
        kopeks = (byte)tempKopeks;

        Money PayMoney = new Money(rubles, kopeks);
        PayMoney.Print();


        Console.WriteLine("Cколько хотите отдать? ");
        Console.Write("Введите рубли: ");
        while (!uint.TryParse(Console.ReadLine(), out rubles))
            Console.Write("Ошибка! Введите целое положительное число: ");

        Console.Write("Введите копейки (0-255): ");
        while (!uint.TryParse(Console.ReadLine(), out tempKopeks) || tempKopeks > 255)
        {
            if (tempKopeks > 255)
                Console.Write("Ошибка! Копейки не могут быть больше 255: ");
            else
                Console.Write("Ошибка! Введите целое положительное число: ");
        }
        kopeks = (byte)tempKopeks;

        PayMoney.Minus(rubles, kopeks);
        Console.WriteLine("После вычитания ");
        PayMoney.Print();
    }


    private static void TestUnarOperator()
    {
        Money money = new Money(0,5);
        money.Print(); 

        Money result = money++;
        money.Print(); 
        result = money--;
        result = money--;
        result = money--;
        result = money--;
        result = money--;
        result = money--;
        result = money--;

        money.Print(); 
    }


    private static void TestCompite()
    {
        Money money = new Money();
        //  неявно
        uint rubOnly = money;  
        Console.WriteLine($"Только рубли: {rubOnly}");

        // явно
        double kopOnly = (double)money;  
        Console.WriteLine($"Копейки в рублях: {kopOnly}");  
    }


    private static void TestBinary()
    {
        Money money1 = new Money();
        Money money2 = new Money(10,15);
        money1.Print();
        money2.Print();
        Console.WriteLine($"После действий: ");

        Money result1 = money1 + 3;
        result1.Print(); 

        Money result2 = 3 + money1;
        result2.Print();  

        Money result3 = money1 + money2;
        result3.Print();  

        Money result4 = money1 - 3;
        result4.Print();  

        Money result5 = 20 - money1;
        result5.Print();  

        Money result6 = money1 - money2;
        result6.Print(); 

        Money result7 = money1 - 100;  
        result7.Print(); 


    }

}
