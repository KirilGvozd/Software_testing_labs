using System;
using System.Threading.Channels;
namespace Calculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"Add: {Calculator.Add(2, 3)}");
            Console.WriteLine($"Substract: {Calculator.Substract(2, 3)}");
            Console.WriteLine($"Multiply: {Calculator.Multiply(10, 9)}");
            Console.WriteLine($"Divide: {Calculator.Divide(10, 3)}");
            Console.WriteLine($"ExtractRoot: {Calculator.ExtractRoot(4, 3)}");
            Console.WriteLine($"ExtractSquareRoot: {Calculator.ExtractSquareRoot(25)}");
            Console.WriteLine($"RaiseToThePower: {Calculator.RaiseToThePower(2, 10)}");
        }
    }
}