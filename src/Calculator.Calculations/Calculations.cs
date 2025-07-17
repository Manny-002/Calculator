using Serilog;

namespace Calculator.Calculations
{
    public class Calculations
    {

        
        public static int Sum(int a, int b)
        {
            int result = a + b;
            Log.Information("Součet {A} + {B} = {Result}", a, b, result);
            return result;
        }

        public static int Difference(int a, int b)
        {
            int result = a - b;
            Log.Information("Rozdíl {A} - {B} = {Result}", a, b, result);
            return result;
        }

        public static int Multiply(int a, int b)
        {
            int result = a * b;
            Log.Information("Součin {A} * {B} = {Result}", a, b, result);
            return result;
        }

        public static double Division(int a, int b)
        {
            if (b == 0)
            {
                Log.Warning("Dělení nulou: {A} / {B}", a, b);
                return double.NaN;
            }

            double result = (double)a / b;
            Log.Information("Podíl {A} / {B} = {Result}", a, b, result);
            return result;
        }
    }
}
