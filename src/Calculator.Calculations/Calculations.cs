using Serilog;
using System;

namespace Calculator.Calculations
{
    public class Calculations
    {

        
        public static double Sum(double a, double b)
        {
            double result = a + b;
            Log.Information("Součet {A} + {B} = {Result}", a, b, result);
            return result;
        }

        public static double Difference(double a, double b)
        {
            double result = a - b;
            Log.Information("Rozdíl {A} - {B} = {Result}", a, b, result);
            return result;
        }

        public static double Multiply(double a, double b)
        {
            double result = a * b;
            Log.Information("Součin {A} * {B} = {Result}", a, b, result);
            return result;
        }

        public static double Division(double a, double b)
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
