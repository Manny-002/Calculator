
Console.WriteLine("Toto je kalkulačka");


// vstupy pro kalkulačku
Console.Write("Zadej prvni cislo:");
int a = Convert.ToInt32(Console.ReadLine());

Console.Write("Zadej druhe cislo:");
int b = Convert.ToInt32(Console.ReadLine());

//vypis operaci

int sum = a+b;
int difference = a - b;



//horsi zpusob

Console.WriteLine("Součet je:");
Console.WriteLine(sum);
Console.WriteLine("Rozdíl je:");
Console.WriteLine(difference);

