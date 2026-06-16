using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_s_salary_plus_overtime_pay
{
    /// <summary>
    /// This application calculates employee salaries including overtime pay.
    /// It is open-source and free for all developers to modify and distribute.
    /// </summary>
    internal class Program
    {
        // Magic Numbers defined as constants for easy maintenance
        private const double OvertimeMultiplier = 1.50;
        private const int MinValidSalary = 0;

        static void Main(string[] args)
        {
            bool bIsContinue = false;
            do
            {
                PrintMessage("      Welcome to the payroll calculator\n       with (overtime pay calculation)", '*');

                // Get number of employees
                int nNumOfEmployees = nNumberOfEmployees();

                // Collect employee names
                PrintMessage("Please enter the names of the employees:");
                string[] sNames = sNamesArr(nNumOfEmployees);

                // Collect salary and hours data
                double[,] dSalaryAndHours = SalaryAndHours(sNames, nNumOfEmployees);

                // Get hourly rate from user
                double nHourValue = HourValue();

                // Calculate and display results
                double[] nResult = CalculatingTheTotal(dSalaryAndHours, sNames, nHourValue);

                PrintMessage("", '*');

                // Check if user wants to continue
                PrintMessage("If you wish to continue, press the number 1\nor any key on the keyboard to exit.");
                bIsContinue = false;
                int nContinue;
                int.TryParse(Console.ReadLine(), out nContinue);
                if (nContinue == 1)
                {
                    bIsContinue = true;
                }
                Console.Clear();

            } while (bIsContinue);

            // Closing message
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════════════════╗");
            Console.WriteLine("║    Thank you for using our app! C#Fazza++ 😏     ║");
            Console.WriteLine("╚══════════════════════════════════════════════════╝");
            Console.ResetColor();
        }

        /// <summary>
        /// Calculates the total salary including overtime pay based on the multiplier.
        /// </summary>
        static double[] CalculatingTheTotal(double[,] dSalaryAndHour, string[] sNames, double nHourValue)
        {
            double[] nResult = new double[sNames.Length];
            for (int i = 0; i < nResult.Length; i++)
            {
                PrintMessage($"{i + 1}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($" {sNames[i]} : ");
                Console.ResetColor();

                // Applying the OvertimeMultiplier constant here
                nResult[i] = dSalaryAndHour[i, 1] * nHourValue * OvertimeMultiplier;
                nResult[i] += dSalaryAndHour[i, 0];

                Console.Write($"Basic salary: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{dSalaryAndHour[i, 0]} $");
                Console.ResetColor();

                Console.Write($"Number of overtime hours: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{dSalaryAndHour[i, 1]}");
                Console.ResetColor();

                Console.Write($"Total salary for this month:");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{nResult[i]} $");
                Console.ResetColor();
            }
            return nResult;
        }

        /// <summary>
        /// Prompts user to enter the hourly work rate.
        /// </summary>
        static double HourValue()
        {
            PrintMessage("Please enter the hourly rate:");
            double nHourValue;
            while (!double.TryParse(Console.ReadLine(), out nHourValue) || !(nHourValue > MinValidSalary))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Error: The number must be greater than 0.\n...Please Try again:");
                Console.ResetColor();
            }
            Console.Clear();
            Console.WriteLine("------------------------------------------------");
            Console.Write("The hourly rate is:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($" {nHourValue} $ ✅");
            Console.ResetColor();
            return nHourValue;
        }

        /// <summary>
        /// Collects salary and overtime hours for each employee.
        /// </summary>
        static double[,] SalaryAndHours(string[] sNames, int nNumOfEmploy)
        {
            double[,] dSalaryAndHours = new double[nNumOfEmploy, 2];
            for (int i = 0; i < nNumOfEmploy; i++)
            {
                PrintMessage("Enter the salary and then the number of overtime hours worked.");
                Console.WriteLine($"1= salary\n2= Hours");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($" {sNames[i]} : ");
                Console.ResetColor();

                for (int j = 0; j < 2; j++)
                {
                    Console.Write($"{j + 1} :");
                    while (!double.TryParse(Console.ReadLine(), out dSalaryAndHours[i, j]) || !(dSalaryAndHours[i, j] >= MinValidSalary))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("❌ Error: The input must be a valid positive number.\n...Please Try again:");
                        Console.ResetColor();
                    }
                }
            }
            Console.Clear();
            return dSalaryAndHours;
        }

        /// <summary>
        /// Captures employee names.
        /// </summary>
        static string[] sNamesArr(int nNumOfEmployees)
        {
            string[] sNames = new string[nNumOfEmployees];
            for (int i = 0; i < sNames.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($" {i + 1}\\ ");
                Console.ResetColor();
                sNames[i] = Console.ReadLine();
            }
            return sNames;
        }

        /// <summary>
        /// Validates the number of employees.
        /// </summary>
        static int nNumberOfEmployees()
        {
            int nNumOfEmpl;
            while (!int.TryParse(Console.ReadLine(), out nNumOfEmpl) || !(nNumOfEmpl > 0))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Error: The number must be greater than 0.\n...Please Try again:");
                Console.ResetColor();
            }
            Console.Clear();
            return nNumOfEmpl;
        }

        /// <summary>
        /// Helper to print styled messages to the console.
        /// </summary>
        static void PrintMessage(string message, char Pattern = '-')
        {
            Console.WriteLine(new string(Pattern, 48));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
            Console.WriteLine(new string(Pattern, 48));
        }
    }
}