
Console.WriteLine("Toto je kalkulačka");


// vstupy pro kalkulačku
Console.Write("Zadej prvni cislo:");
int a = Convert.ToInt32(Console.ReadLine());

Console.Write("Zadej druhe cislo:");
int b = Convert.ToInt32(Console.ReadLine());

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

//lepsi zpusob

Console.WriteLine("Soucin je {0} ", a * b);
Console.WriteLine("Soucet je {0} ", a + b);
Console.WriteLine("Rozdil je {0} ", a - b);
Console.WriteLine("Deleni je {0} ", (double)(a) / (double)b);


Console.WriteLine("Metody z knihovny");

// Volání metod z knihovny
Console.WriteLine("Součet je {0}", Calculator.Calculations.Calculator.Sum(a, b));
Console.WriteLine("Rozdíl je {0}", Calculator.Calculations.Calculator.Difference(a, b));
Console.WriteLine("Součin je {0}", Calculator.Calculations.Calculator.Product(a, b));
Console.WriteLine("Podíl je {0}", Calculator.Calculations.Calculator.Division(a, b));
