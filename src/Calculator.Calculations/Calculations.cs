using Serilog;
using System;

namespace Calculator.Calculations
{
    public class Calculations
    {

        public static double Sum(List<double> numbers)
        {
            double result = numbers.Sum();
            Log.Information("Součet {Expression} = {Result}", string.Join(" + ", numbers), result);
            return result;
        }

        public static double Difference(List<double> numbers)
        {
            double result = numbers.Aggregate((x, y) => x - y);
            Log.Information("Rozdíl {Expression} = {Result}", string.Join(" - ", numbers), result);
            return result;
        }

        public static double Multiply(List<double> numbers)
        {
            double result = numbers.Aggregate((x, y) => x * y);
            Log.Information("Součin {Expression} = {Result}", string.Join(" * ", numbers), result);
            return result;
        }

        public static double Division(List<double> numbers)
        {
            if (numbers == null || numbers.Count == 0)
            {
                Log.Warning("Dělení nulou: {A} / {B}");
                return double.NaN;
            }

            // kontrola: nesmí být nula od druhého prvku dál
            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] == 0)
                {
                    Log.Warning("Dělení nulou: {Expression}", string.Join(" / ", numbers));
                    return double.NaN;
                }
            }

            double result = numbers.Aggregate((x, y) => x / y);
            Log.Information("Podíl {Expression} = {Result}", string.Join(" / ", numbers), result);
            return result;
        }
    }
}
