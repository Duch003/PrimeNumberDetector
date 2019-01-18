using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumberDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Introduce();
                var input = Console.ReadLine();

                if (!ulong.TryParse(input, out ulong number))
                {
                    InputNotNumber();
                    continue;
                }

                IsPrimeNumber(PrimeNumberDetector.IsPrimeNumberV1(number));

                var allFactors = PrimeNumberDetector.GetFactors(number);

                CountFactors(allFactors);

                ShowPrimeFactors(allFactors);

                Console.ReadLine();
            } while (true);
        }
        //Check
        private static void Introduce()
        {
            Console.WriteLine("This is prime number detecor. I will check if given number is a number, " +
                              "a prime number, count all factorials and print all prime factorials. Have fun!");
            Console.Write("Type Your number: ");
        }

        private static void Check()
        {

        }

        private static void InputNotNumber()
        {
            Console.WriteLine("This is not a number. Press ENTER to continue...");
            Console.ReadLine();
        }

        private static void IsPrimeNumber(bool value)
        {
            Console.WriteLine(!value ? "Given number is not a prime number." : "Given number is a prime number.");
        }

        private static void CountFactors(List<ulong> input)
        {
            Console.WriteLine($"Given number have { input.Count } unique (not 1 and itself) factors.");
        }

        private static void ShowPrimeFactors(List<ulong> input)
        {
            var primeFactorials = PrimeNumberDetector.RetrievePrimeNumbers(input).OrderByDescending(z => z);

            if (!primeFactorials.Any())
            {
                Console.WriteLine("Given number doesn't have any uniqe prime factors.");
                return;
            }

            var finalMessage = $"All prime factors (from biggest one): ";
            foreach (var number in primeFactorials)
                finalMessage += $"{number}, ";

            finalMessage = finalMessage.Remove(finalMessage.Length - 2);
            finalMessage += ".";

            Console.WriteLine(finalMessage);
        }
    }
}
