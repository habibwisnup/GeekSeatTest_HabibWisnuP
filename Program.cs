using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekSeatTest_HabibWisnuP
{
    class Program
    {
        public static List<Person> persons = new List<Person>();
        static void Main(string[] args)
        {
            bool shouldContinue = true;

            while (shouldContinue)
            {
                int countPerson = GetValue("Input Person Number : ");
                int flag = InputPerson(countPerson);

                if (flag < 0)
                {
                    Console.WriteLine("-1");
                    goto try_again;
                }
                else
                {
                    decimal deathCount = 0;
                    for (var i = 0; i < persons.Count; i++)
                    {
                        deathCount += persons[i].NumOfPeopleKilled;
                    }
                    Console.WriteLine("Average people death : " + deathCount / persons.Count);
                    goto try_again;
                }
            try_again:
                while (true)
                {

                    Console.WriteLine("Do you want to try again? y/n? ");
                    string response = Console.ReadLine();

                    if (response.Equals("y", StringComparison.CurrentCultureIgnoreCase) || response.Equals("yes", StringComparison.CurrentCultureIgnoreCase))
                    {
                        shouldContinue = true;
                        break;
                    }
                    else if (response.Equals("n", StringComparison.CurrentCultureIgnoreCase) || response.Equals("no", StringComparison.CurrentCultureIgnoreCase))
                    {
                        shouldContinue = false;
                        break;
                    }
                }
            }
        }

        private static int GetValue(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();
                int value;
                if (int.TryParse(input, out value))
                {
                    if (value <= 0)
                        Console.WriteLine("Please enter a positive number.");
                    else
                        return value;
                }
                else
                {
                    Console.WriteLine("Please enter a number.");
                }
            }
        }

        static int InputPerson(int numOfPerson)
        {
            for (int i = 0; i < numOfPerson; i++)
            {
                Console.Clear();
                var counter = i + 1;
                Person person = new Person();

                Console.WriteLine("Person " + counter + " Age of Death :");

                var AOD = Console.ReadLine();
                var isAODNumeric = int.TryParse(AOD, out int n);

                Console.WriteLine("Person " + counter + " Year of Death :");

                var YOD = Console.ReadLine();
                var isYODNumeric = int.TryParse(YOD, out int m);

                if (!isAODNumeric || !isYODNumeric || Convert.ToInt32(AOD) < 0 || Convert.ToInt32(YOD) < 0 || (Convert.ToInt32(YOD) - Convert.ToInt32(AOD) <= 0))
                {
                    Console.Clear();
                    return -1;
                }
                else
                {
                    person.BornYear = Convert.ToInt32(YOD) - Convert.ToInt32(AOD);
                    person.NumOfPeopleKilled = ConsolidatedPersonDeath(person.BornYear);
                    persons.Add(person);
                }
            }
            Console.Clear();
            return 1;
        }

        static int ConsolidatedPersonDeath(int year)
        {
            if (year <= 0)
                return 0;

            int[] counter = new int[year + 1];
            counter[0] = 0; counter[1] = 1;

            int sum = counter[0] + counter[1];

            for (int i = 2; i <= year; i++)
            {
                counter[i] = counter[i - 1] + counter[i - 2];
                sum += counter[i];
            }

            return sum;
        }
    }
}
