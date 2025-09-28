namespace CustomExceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            try
            {
                BankAccount account = new BankAccount("123456", 1000);
                Console.WriteLine($"I'm going to buy flowes: {account.Withdraw(500)}");
                Console.WriteLine($"I'm going to take her to the Cinepolis VIP: {account.Withdraw(300)}");
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine($"Custom Exception Caught: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Argument Exception Caught: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Exception Caught: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Thank you for using our banking system.");
            }
        }
        public class InsufficientBalanceException : Exception
        {
            public InsufficientBalanceException() : base("Insufficient balance for the transaction."){}
            public InsufficientBalanceException(string message) : base(message){}
            public InsufficientBalanceException(string message, Exception inner) : base(message, inner){}
        }
        public class BankAccount
        {
            public string AccountNumber { get; set; }
            public decimal Balance { get; private set; }
            public BankAccount(string accountNumber, decimal initialBalance)
            {
                AccountNumber = accountNumber;
                Balance = initialBalance;
            }
            public void Deposit(decimal amount)
            {
                if (amount <= 0)
                {
                    throw new ArgumentException("Deposit amount must be positive.");
                }
                Balance += amount;
            }
            public string Withdraw(decimal amount)
            {
                var originalBalance = Balance;
                if (amount > Balance)
                {
                    throw new InsufficientBalanceException($"Cannot withdraw {amount} from acount {AccountNumber} with balance {Balance}");
                }
                Balance -= amount;
                return $"Withdrew {amount} from acount {AccountNumber}. Original balace: {originalBalance}, New balance is {Balance}.";
            }
        }
    }
}
