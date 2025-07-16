namespace Calculator.Calculations
{
    public class Calculator
    {
        public static int Sum(int a, int b) => a + b;
        public static int Difference(int a, int b) => a - b;

        public static int Product(int a, int b) => a * b;
        public static double Division(int a, int b) => (double)a / (double)b; // pro deleni s desetinnym vysledkem

    }
}
