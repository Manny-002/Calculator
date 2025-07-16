using ConsoleTools;
using Serilog;
using Calculator.Calculations;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day) // zapisuje logy do souboru
    .CreateLogger();




Console.WriteLine("Toto je kalkulačka");


// vstupy pro kalkulačku
Console.Write("Zadej prvni cislo:");
int a = Convert.ToInt32(Console.ReadLine());

Console.Write("Zadej druhe cislo:");
int b = Convert.ToInt32(Console.ReadLine());


var menu = new ConsoleMenu(args, level: 0)
         .Add("Sčítání", () => {
             int result = Calculations.Sum(a, b);
             Console.WriteLine($"Výsledek: {result}");
             Log.Information("Sčítání: {A} + {B} = {Result}", a, b, result);
             Console.ReadKey();
         })
         .Add("Odčítání", () => {
             int result = Calculations.Difference(a, b);
             Console.WriteLine($"Výsledek: {result}");
             Log.Information("Odčítání: {A} - {B} = {Result}", a, b, result);
             Console.ReadKey();
         })
         .Add("Násobení", () => {
             int result = Calculations.Multiply(a, b);
             Console.WriteLine($"Výsledek: {result}");
             Log.Information("Násobení: {A} * {B} = {Result}", a, b, result);
             Console.ReadKey();
         })
         .Add("Dělení", () => {
             double result = Calculations.Division(a, b);
             Console.WriteLine($"Výsledek: {result}");
             Log.Information("Dělení: {A} / {B} = {Result}", a, b, result);
             Console.ReadKey();
         })
         .Add("Konec", ConsoleMenu.Close)
         .Configure(config =>
         {
             config.Selector = "--> ";
             config.EnableFilter = false;
             config.Title = "Kalkulačka – vyber operaci:";
             config.EnableWriteTitle = true;
         });

menu.Show();


//vypis operaci

int sum = a+b;
int difference = a - b;
int product = a * b;
int division = a / b;



//horsi zpusob

Console.WriteLine("Součet je:");
Console.WriteLine(sum);
Console.WriteLine("Rozdíl je:");
Console.WriteLine(difference);
Console.WriteLine("Součin je:");
Console.WriteLine(product);
Console.WriteLine("Podíl je:");
Console.WriteLine(division);

//logovani vypisu
Log.Information("Součet: {Sum}", sum);
Log.Information("Rozdíl: {Difference}", difference);
Log.Information("Součin: {Product}", product);
Log.Information("Podíl: {Division}", division);



//lepsi zpusob

Console.WriteLine("Soucin je {0} ", a * b);
Console.WriteLine("Soucet je {0} ", a + b);
Console.WriteLine("Rozdil je {0} ", a - b);
Console.WriteLine("Deleni je {0} ", (double)(a) / (double)b);


Console.WriteLine("Metody z knihovny");

// Volání metod z knihovny
Console.WriteLine("Součet je {0}", Calculator.Calculations.Calculations.Sum(a, b));
Console.WriteLine("Rozdíl je {0}", Calculator.Calculations.Calculations.Difference(a, b));
Console.WriteLine("Součin je {0}", Calculator.Calculations.Calculations.Multiply(a, b));
Console.WriteLine("Podíl je {0}", Calculator.Calculations.Calculations.Division(a, b));



Console.WriteLine("Log se uložil do kořenové složky programu");
Log.CloseAndFlush();
