using ConsoleTools;
using Serilog;
using Calculator.Calculations;

class Program
{
    // Proměnné na úrovni třídy
    static double a;
    static double b;

    static void Main(string[] args)
    {
        // Nastavení logování
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        Console.WriteLine("Toto je kalkulačka");

        // Hlavní menu
        var hlavniMenu = new ConsoleMenu(args, level: 0)
            .Add("Sčítání", OperationAdd)
            .Add("Odčítání", OperationDifference)
            .Add("Násobení", OperationSum)
            .Add("Dělení", OperationDivision)
            .Add("Konec", ConsoleMenu.Close)
            .Configure(config =>
            {
                config.Selector = "--> ";
                config.Title = "Kalkulačka – hlavní menu";
            });

        hlavniMenu.Show();
    }

    static List<double> numbers = new();

    static void EnterNumbers()
    {
        numbers.Clear();

        Console.WriteLine("Zadávání čísel. Pro ukončení stiskni ENTER bez zadání.");

        while (true)
        {
            Console.Write($"Zadej číslo č. {numbers.Count + 1}: ");
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                break;

            if (double.TryParse(input, out double number))
            {
                numbers.Add(number);
            }
            else
            {
                Console.WriteLine("Neplatný vstup. Zkus to znovu.");
            }
        }

        Log.Information("Zadána čísla: {Numbers}", string.Join(", ", numbers));
    }



    static void OperationAdd()
    {
        EnterNumbers();
        double result = Calculations.Sum(numbers);
        Console.WriteLine($"Výsledek: {result}");
        Console.ReadKey();
    }

    static void OperationDifference()
    {
        EnterNumbers();
        double result = Calculations.Difference(numbers);
        Console.WriteLine($"Výsledek: {result}");
        Console.ReadKey();
    }

    static void OperationSum()
    {
        EnterNumbers();
        double result = Calculations.Multiply(numbers);
        Console.WriteLine($"Výsledek: {result}");
        Console.ReadKey();
    }

    static void OperationDivision()
    {
        EnterNumbers();
        double result = Calculations.Division(numbers);
        Console.WriteLine($"Výsledek: {result}");
        Console.ReadKey();
    }
}


////vypis operaci

//int sum = a+b;
//int difference = a - b;
//int product = a * b;
//int division = a / b;



////horsi zpusob

//Console.WriteLine("Součet je:");
//Console.WriteLine(sum);
//Console.WriteLine("Rozdíl je:");
//Console.WriteLine(difference);
//Console.WriteLine("Součin je:");
//Console.WriteLine(product);
//Console.WriteLine("Podíl je:");
//Console.WriteLine(division);

////logovani vypisu
//Log.Information("Součet: {Sum}", sum);
//Log.Information("Rozdíl: {Difference}", difference);
//Log.Information("Součin: {Product}", product);
//Log.Information("Podíl: {Division}", division);



////lepsi zpusob

//Console.WriteLine("Soucin je {0} ", a * b);
//Console.WriteLine("Soucet je {0} ", a + b);
//Console.WriteLine("Rozdil je {0} ", a - b);
//Console.WriteLine("Deleni je {0} ", (double)(a) / (double)b);


//Console.WriteLine("Metody z knihovny");

//// Volání metod z knihovny
//Console.WriteLine("Součet je {0}", Calculator.Calculations.Calculations.Sum(a, b));
//Console.WriteLine("Rozdíl je {0}", Calculator.Calculations.Calculations.Difference(a, b));
//Console.WriteLine("Součin je {0}", Calculator.Calculations.Calculations.Multiply(a, b));
//Console.WriteLine("Podíl je {0}", Calculator.Calculations.Calculations.Division(a, b));



//Console.WriteLine("Log se uložil do kořenové složky programu");
//Log.CloseAndFlush(); 
