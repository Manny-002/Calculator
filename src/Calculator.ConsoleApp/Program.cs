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
            .Add("Sčítání", OperaceScitani)
            .Add("Odčítání", OperaceOdcitani)
            .Add("Násobení", OperaceNasobeni)
            .Add("Dělení", OperaceDeleni)
            .Add("Konec", ConsoleMenu.Close)
            .Configure(config =>
            {
                config.Selector = "--> ";
                config.Title = "Kalkulačka – hlavní menu";
            });

        hlavniMenu.Show();
    }

    // Pomocná metoda pro zadání čísel
    static void ZadejCisla()
    {
        a = NactiCislo("Zadej první číslo: ");
        b = NactiCislo("Zadej druhé číslo: ");
        Log.Information("Zadána čísla: {A}, {B}", a, b);
    }

    //osetreni vstupu na psani cisel
    static double NactiCislo(string vyzva)
    {
        while (true)
        {
            Console.Write(vyzva);
            string? vstup = Console.ReadLine();

            if (double.TryParse(vstup, out double cislo))
                return cislo;

            Console.WriteLine("Neplatný vstup. Zadej celé číslo.");
        }
    }


    static void OperaceScitani()
    {
        ZadejCisla();
        double result = Calculations.Sum(a, b);
        Console.WriteLine($"Výsledek: {result}");
        Console.ReadKey();
    }

    static void OperaceOdcitani()
    {
        ZadejCisla();
        double result = Calculations.Difference(a, b);
        Console.WriteLine($"Výsledek: {result}");
        Console.ReadKey();
    }

    static void OperaceNasobeni()
    {
        ZadejCisla();
        double result = Calculations.Multiply(a, b);
        Console.WriteLine($"Výsledek: {result}");
        Console.ReadKey();
    }

    static void OperaceDeleni()
    {
        ZadejCisla();
        double result = Calculations.Division(a, b);
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
