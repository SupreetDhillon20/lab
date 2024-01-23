using System.ComponentModel.Design;

namespace C__Console_App_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.Write("Enter low number:");
            int lowNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter high number:");
            int highNumber = Convert.ToInt32(Console.ReadLine());
            int difference = highNumber - lowNumber;
            Console.WriteLine($"The difference between {highNumber} and {lowNumber} is {difference}.");

            do { Console.Write("Enter a positive low number:"); }
            while (!int.TryParse(Console.ReadLine(), out lowNumber) || lowNumber <= 0);
            do { Console.Write($"Enter a high number greater than {lowNumber}:"); }
            while (!int.TryParse(Console.ReadLine(), out highNumber) || highNumber <= lowNumber);
            Console.WriteLine($"Positive low number: {lowNumber}");
            Console.WriteLine($"High number greater than {lowNumber}: {highNumber}");

            int[] numberArray = new int[highNumber - lowNumber + 1];
            for (int i = 0; i < numberArray.Length; i++)
            {
                numberArray[i] = highNumber - i;
            }
            string filePath = "number.txt";

            try
            {
                using (StreamWriter streamwriter = new StreamWriter(filePath))
                {
                    // Write each number in reverse order to the file
                    foreach (int number in numberArray)
                    {
                        streamwriter.WriteLine(number);
                    }
                }
                Console.WriteLine($"{filePath} stores numbers of array in reverse order.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error occured: {ex.Message}");
            }

            double LowNumber = GetUserInput("Enter a low number: ");
            double HighNumber = GetUserInput("Enter a high number greater than the low number: ");

   
            List<double> numList = GetNumList(LowNumber, HighNumber);

            string FilePath = "number.txt";

            try
            {
                WriteNumToFile(numList, FilePath);
                Console.WriteLine($"{FilePath} stores numbers in reverse format.");

                List<double> numFromFile = ReadNumFromFile(FilePath);
                double sum = CalculateSum(numFromFile);
                Console.WriteLine($"Sum of the numbers is {sum}");

                PrimeNumbers(LowNumber, HighNumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            static double GetUserInput(string prompt)
            {
                double userInput;
                Console.Write(prompt);
                while (!double.TryParse(Console.ReadLine(), out userInput))
                {
                    Console.WriteLine("Invalid input");
                    Console.Write(prompt);
                }
                return userInput;
            }

            static List<double> GetNumList(double low, double high)
            {
                List<double> numList = new List<double>();
                for (double i = high; i >= low; i--)
                {
                    numList.Add(i);
                }
                return numList;
            }

            static void WriteNumToFile(List<double> numbers, string FilePath)
            {
                File.WriteAllLines(FilePath, Array.ConvertAll(numbers.ToArray(), n => n.ToString()));
            }

            static List<double> ReadNumFromFile(string FilePath)
            {
                List<double> numList = new List<double>();
                string[] lines = File.ReadAllLines(FilePath);
                foreach (string line in lines)
                {
                    if (double.TryParse(line, out double num))
                    {
                        numList.Add(num);
                    }
                }
                return numList;
            }

            static double CalculateSum(List<double> nums)
            {
                double sum = 0;
                foreach (double num in nums)
                {
                    sum += num;
                }
                return sum;
            }

            static bool IsPrime(double num)
            {
                if (num <= 1)
                {
                    return false;
                }

                for (double i = 2; i <= Math.Sqrt(num); i++)
                {
                    if (num % i == 0)
                    {
                        return false;
                    }
                }

                return true;
            }
            static void PrimeNumbers(double low, double high)
            {
                Console.WriteLine($"Prime numbers between {low} and {high}:");
                for (double i = low; i <= high; i++)
                {
                    if (IsPrime(i))
                    {
                        Console.Write($"{i} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}

