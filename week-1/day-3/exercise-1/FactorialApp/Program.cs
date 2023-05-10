using System.Linq.Expressions;

namespace FactorialApp
{
    public class Program
    {
        public static void Main()
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            long factorial = CalculateFactorial(number);

            Console.WriteLine($"The factorial of {number} is: {factorial}");
            Console.WriteLine("press key");
            Console.ReadKey();
        }

        public static long CalculateFactorial(int number)
        { 

            if(number < 0)
            {
                throw new ArgumentException();//expection of negative number given by user
            }
        

            long factorial = 1;
            for (int i = 1; i <= number; i++)
            {
                factorial *= i;
            }

            return factorial;

            //throw new NotImplementedException()          
            

        }
    }

        
    }
