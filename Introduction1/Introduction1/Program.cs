using System;

namespace Introduction1
{
    class Program
    {
        public static double FactorialRecursion(int number)
        {
            if (number == 1)
                return 1;
            else
                return number * FactorialRecursion(number - 1);
        }

        /// <summary>
        /// Returns int array with amount of years[0], days[1], hours[2], Minutes[3], seconds[4] n total days[5] from given date
        /// </summary>
        /// <param name="Dob">Date of the Birth</param>
        /// <returns>int array</returns>
        static int[] CalculateAge(DateTime Dob)
        {
            DateTime Now = DateTime.Now;
            int Years = new DateTime(DateTime.Now.Subtract(Dob).Ticks).Year - 1;
            DateTime PastYearDate = Dob.AddYears(Years);
            int Months = 0;
            for (int i = 1; i <= 12; i++)
            {
                if (PastYearDate.AddMonths(i) == Now)
                {
                    Months = i;
                    break;
                }
                else if (PastYearDate.AddMonths(i) >= Now)
                {
                    Months = i - 1;
                    break;
                }
            }

            int Days = Now.Subtract(PastYearDate.AddMonths(Months)).Days;
            int TotalDays = Days + (Years * 365);
            int Hours = Now.Subtract(PastYearDate).Hours;
            int Minutes = Now.Subtract(PastYearDate).Minutes;
            int Seconds = Now.Subtract(PastYearDate).Seconds;
            return new int[] { Years, Days, Hours, Minutes, Seconds, TotalDays };
        }

        static void Main(string[] args)
        {
            Console.WriteLine("HELLo World");
            Console.Write("Please, enter your name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Hello, " + name + "!");
            Console.Write("Your name has " + name.Length + " letters. ");
            Console.Write(name.Length + "! = " + FactorialRecursion(name.Length) + "\n");
            Console.Write("Please, enter your birth date in format (DD.MM.YYYY): ");
            var date = Console.ReadLine();
            DateTime birthDateTime = DateTime.Parse(date);
            DateTime today = DateTime.Today;

            var age = CalculateAge(birthDateTime);

            Console.Write($"Today is {today.Day}.{today.Month}.{today.Year}, you are {age[0]} year ({age[5]} days) old.");



            Console.ReadKey();
        }
    }
}
