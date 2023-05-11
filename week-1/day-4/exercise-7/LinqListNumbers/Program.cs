namespace LinqListNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a list of integers
            List<int> numbers = new List<int> { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50 };
            var evenNumbers = numbers.Where(n => n % 2 == 0);
            Console.WriteLine("Even numbers:");
            foreach (var number in evenNumbers)
            {
                Console.WriteLine(number);
            }
            int threshold = 20;
            var greaterThanThreshold = numbers.Where(n => n > threshold);
            Console.WriteLine("\nNumbers greater than 20:");
            foreach (var number in greaterThanThreshold)
            {
                Console.WriteLine(number);
            }
            int sum = numbers.Sum();
            Console.WriteLine($"\nSum of all numbers: {sum}");
            double average = numbers.Average();
            Console.WriteLine($"Average of all numbers: {average}");
            int min = numbers.Min();
            int max = numbers.Max();
            Console.WriteLine($"\nMinimum value: {min}");
            Console.WriteLine($"Maximum value: {max}");
        }
    }
}