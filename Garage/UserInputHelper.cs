using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageOne
{
    public static class UserInputHelper
    {
        public static string AskForString(string message)
        {
            bool success = false;
            string answer = "";
            try
            {
                do
                {
                    Console.WriteLine($"{message}");
                    answer = Console.ReadLine() ?? "";

                    if (string.IsNullOrWhiteSpace(answer))
                    {
                        Console.WriteLine($"You must enter a valid text");
                    }
                    else
                    {
                        success = true;
                    }

                } while (!success);
            }
            catch (OutOfMemoryException oEx)
            {
                Console.WriteLine("An out of memory error occurred: " + oEx.Message);
            }
            catch (ArgumentOutOfRangeException aogEx)
            {
                Console.WriteLine("An argument out of range error occurred: " + aogEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            return answer;
        }

        public static uint AskForUInt(string prompt)
        {

            do
            {
                string input = AskForString(prompt);
                if (uint.TryParse(input, out uint result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine($"You must enter a valid integer");
                }
            } while (true);
        }

        public static double AskForDouble(string prompt)
        {
            do
            {
                string input = AskForString(prompt);
                if (double.TryParse(input, out double result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine($"You must enter a valid float number");
                }
            } while (true);
        }
    }
}
