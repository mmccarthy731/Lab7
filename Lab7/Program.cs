using System;

namespace Lab7
{
    class Program
    {
        static string[] names = { "Beni", "David R", "David S", "Evan", "Jacob", "Jordan", "Jason", "Liam", "Michael", "Pierce", "Steve" };
        static string[] foods = { "popcorn", "pizza", "cheeseburgers", "tacos", "steak", "lasagna", "ribs", "burritos", "cookies", "hot dogs", "cake" };
        static string[] hometowns = { "Detroit", "Toledo", "Grand Rapids", "Warren", "Chicago", "Macomb", "Ann Arbor", "Pittsburgh", "Grosse Pointe", "Plymouth", "St. Clair" };

        static void Main(string[] args)
        {
            Console.Write("Weclome to our C# class. ");
            bool repeat = true;
            while(repeat)
            {
                int number = GetIndexNumber("Which student would you like to learn more about? (Enter a number from 1 to 11): ");
                string student = GetStudent(number);
                Console.Write($"Student {number} is {student}. ");
                while (repeat)
                {
                    string info = GetMoreInfo($"What would you like to know about {student}? (enter \"hometown\" or \"favorite food\"): ", number, student);
                    Console.WriteLine(info);
                    repeat = DoAgain($"Would you like to know more about {student}? (Y or N): ");
                }
                repeat = DoAgain("Would you like to learn about another student? (Y or N): ");
            }
            Console.WriteLine("Thank you!");
            Console.ReadLine();
        }

        private static int GetIndexNumber(string prompt)
        {
            Console.Write(prompt);
            if(!int.TryParse(Console.ReadLine(), out int number) || number < 1 || number > 11)
            {
                return GetIndexNumber("That student does not exist. Please try again. (Enter a number between 1 and 11): ");
            }
            return number;
        }

        private static string GetStudent(int number)
        {
            return names[number - 1];
        }

        private static string GetMoreInfo(string prompt, int number, string student)
        {
            Console.Write(prompt);
            string input = Console.ReadLine().ToLower();
            if(input == "hometown" || input == "home town")
            {
                return $"{student} is from {hometowns[number - 1]}.";
            }
            else if(input == "favorite food")
            {
                return $"{student}'s favorite food is {foods[number - 1]}.";
            }
            else
            {
                return GetMoreInfo("That data does not exist. Please try again. (enter \"hometown\" or \"favorite food\"): ", number, student);
            }

        }

        private static bool DoAgain(string prompt)
        {
            Console.Write(prompt);
            string response = Console.ReadLine().ToLower();
            if (response == "y" || response == "yes")
            {
                return true;
            }
            else if (response == "n" || response == "no")
            {
                return false;
            }
            else
            {
                Console.Write("Invalid input. ");
                return DoAgain(prompt);
            }
        }
    }
}
