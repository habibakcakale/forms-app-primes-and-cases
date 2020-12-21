namespace FormsApp.Primes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PrimeProgram
    {
        public static void Main(string[] args) => new PrimeProgram().Run();

        private void Run()
        {
            var number = GetMaxPrimeNumber();
            //if (number <= 1) return;

            var primes = GetPrimeNumbers(2, number);
            var total = primes.Aggregate(1d, (current, next) => current * next);
            Console.WriteLine(total);
        }

        private int GetMaxPrimeNumber()
        {
            string userInput;
            int number;
            do
            {
                Console.Write("Enter a number or 'q' to quit:");
                userInput = Console.ReadLine();
            } while (!int.TryParse(userInput, out number) && !string.Equals(userInput, "q"));

            return number;
        }

        /// <summary>
        /// Get Prime numbers between given start and end 
        /// </summary>
        /// <param name="start">Starting Point</param>
        /// <param name="end">Maximum range</param>
        /// <returns></returns>
        public IEnumerable<int> GetPrimeNumbers(int start, int end)
        {
            if (start <= 1) // by definition prime number cannot be negative 
                start = 2;
            for (var currentNumber = start; currentNumber <= end; currentNumber++)
            {
                var dividerCount = 0;

                for (var divider = 2;
                    divider <= currentNumber / 2;
                    divider++) // A non-Prime number can only be divide by self/2  
                {
                    if (currentNumber % divider == 0 && ++dividerCount >= 2)
                    {
                        break;
                    }
                }

                if (dividerCount == 0)
                    yield return currentNumber;
            }
        }
    }
}