class WeeklyPayCalculator
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Employee Weekly Pay Calculator!");

        double hourlyRate = GetPositiveDouble("Enter the hourly rate: ");
        double hoursWorked = GetPositiveDouble("Enter the number of hours worked: ");

        double regularPay = Math.Min(40, hoursWorked) * hourlyRate;
        double overtimePay = Math.Max(0, hoursWorked - 40) * hourlyRate * 1.5;
        double grossPay = regularPay + overtimePay;

        double tax = grossPay * 0.20;
        double netPay = grossPay - tax;

        Console.WriteLine($"\nGross Pay: {grossPay:C}");
        Console.WriteLine($"Tax (20%): {tax:C}");
        Console.WriteLine($"Net Pay: {netPay:C}");
    }

    static double GetPositiveDouble(string message)
    {
        double value;
        while (true)
        {
            Console.Write(message);
            string input = Console.ReadLine();

            if (double.TryParse(input, out value) && value >= 0)
                return value;

            Console.WriteLine("Invalid input! Please enter a positive numeric value.");
        }
    }
}
