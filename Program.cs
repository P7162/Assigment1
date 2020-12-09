using System;

namespace TwinPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isInputValid = IsInputValid(args, out int min, out int max);
            // find the input is valid or not
            if (isInputValid)
            {

                Console.WriteLine($"Twin primes between {min} and {max}:");

                if (min % 2 == 0)     
                    min++;

                for (int twin = min; twin <= max - 2; twin += 2)
                {
                    int secondTwin = twin + 2;
                    if (IsPrime(twin) && IsPrime(secondTwin))
                    {
                        Console.WriteLine($"{twin}, {secondTwin}");
                    }
                }
            }

            else
            {
                // If the input is more then 2 integer it show  throw the error message
                if (args.Length == 1)
                {
                    if (!int.TryParse(args[0], out int value1))
                    {
                        Console.WriteLine($"[ERROR]: The argument {args[0]} is not a valid integer");
                    }
                }
                else if (args.Length == 2)
                {
                    if (!int.TryParse(args[0], out int value1))
                    {
                        Console.WriteLine($"[ERROR]: The argument {args[0]} is not a valid integer");
                    }
                    if (!int.TryParse(args[1], out int value2))
                    {
                        Console.WriteLine($"[ERROR]: The argument {args[1]} is not a valid integer");
                    }
                }
                else if (args.Length > 2)
                {
                    Console.WriteLine($"[ERROR]: There are more than 2 arguments. You can only have 2 integer arguments");
                }
            }
        }

        private static bool IsInputValid(string[] args, out int min, out int max)
        {
            min = 0;
            max = 50;

            bool output = true;

            if (args.Length > 2)
            {
                output = false;
            }
            else if (args.Length == 2)
            {
                if (int.TryParse(args[0], out int value1) && int.TryParse(args[1], out int value2))
                {
                    min = value1;
                    max = value2;
                }
                else
                {
                    output = false;
                }
            }
            else if (args.Length == 1)
            {
                if (int.TryParse(args[0], out int value1))
                {
                    max = value1;
                }
                else
                {
                    output = false;
                }
            }

            return output;
        }
        
        // finding prime number
        private static bool IsPrime(int num)
        {
            if (num < 2)
            {
                return false;
            }
            else
            {
                for (int i = 2; i <= num / 2; i++)
                {
                    if (num % i == 0)
                        return false;
                }
                return true;
            }
        }
    }
}

