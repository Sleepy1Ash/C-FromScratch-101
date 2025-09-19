namespace ControlFlowStatements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IfStatementExample();
            IfElseIfExample();
            SwitchStatementExample();
        }
        private static void IfStatementExample()
        {
            int number = 10;
            if (number >5)
                Console.WriteLine("The number is greater than 5.");
            else
                Console.WriteLine("The number is 5 or less.");
        }
        private static void IfElseIfExample()
        {
            int number = 10;
            if (number > 5)
            {
                Console.WriteLine("The number is greater than 5.");
            }
            else if (number == 5)
            {
                Console.WriteLine("The number is exactly 5.");
            }
            else
            {
                Console.WriteLine("The number is less than 5.");
            }
        }
        private static void SwitchStatementExample()
        {
            int day = 3;
            switch (day)
            {
                case 1:
                    Console.WriteLine("Monday");
                    break;
                case 2:
                    Console.WriteLine("Tuesday");
                    break;
                case 3:
                    Console.WriteLine("Wednesday");
                    break;
                case 4:
                    Console.WriteLine("Thursday");
                    break;
                case 5:
                    Console.WriteLine("Friday");
                    break;
                case 6:
                    Console.WriteLine("Saturday");
                    break;
                case 7:
                    Console.WriteLine("Sunday");
                    break;
                default:
                    Console.WriteLine("Invalid day");
                    break;
            }
        }
    }
}
