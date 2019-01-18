using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumberDetector
{
    public class PrimeNumberDetector
    {
        //Source: https://en.wikipedia.org/wiki/Primality_test
        public static bool IsPrimeNumberV1(ulong input)
        {
            //Check for first two numbers
            if (input <= 3)
                return input > 1;

            //Checking most predictable numbers
            if (input % 2 == 0 || input % 3 == 0)
                return false;

            //Simple prime-checking formula
            for (ulong i = 5; (i * i) <= input; i += 6)
            {
                if (input % i == 0 || input % (i + 2) == 0)
                    return false;
            }

            return true;
        }


        //Returns factors of given number except 1 and itself
        public static List<ulong> GetFactors(ulong input)
        {
            List<ulong> output = new List<ulong>();

            //2 and 3 are skipped because method returns only factors which are not 1 and number itself
            if (input == 2 || input == 3)
                return output;

            for (ulong i = 2; i < input; i++)
            {
                if(input % i == 0)
                    output.Add(i);
            }

            return output;
        }

        public static List<ulong> RetrievePrimeNumbers(List<ulong> input)
        {
            List<ulong> output = new List<ulong>();

            foreach (var number in input)
                if(IsPrimeNumberV1(number))
                    output.Add(number);

            return output;
        }
    }
}
