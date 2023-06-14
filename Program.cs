namespace Lab02UnitTesting
{
    public class Program
    {
        public static decimal Balance = 0;

        public static void Main(string[] args)
        {
            UserInterface();
        }

        public static void UserInterface()
        {
            string input;
            do
            {
                Console.WriteLine("ATM Menu:");
                Console.WriteLine("1. View Balance");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Deposit");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        decimal balance = ViewBalance();
                        Console.WriteLine($"Current Balance: {balance:C}");
                        break;
                    case "2":
                        Console.Write("Enter the amount to withdraw: ");
                        string withdrawAmountStr = Console.ReadLine();
                        decimal withdrawAmount;

                        if (decimal.TryParse(withdrawAmountStr, out withdrawAmount))
                        {
                            decimal newBalance = Withdraw(withdrawAmount);
                            Console.WriteLine($"Withdrawal successful. New Balance: {newBalance:c}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid amount.");
                        }

                        break;
                    case "3":
                        Console.Write("Enter the amount to deposit: ");
                        string depositAmountStr = Console.ReadLine();
                        decimal depositAmount;

                        if (decimal.TryParse(depositAmountStr, out depositAmount))
                        {
                            decimal newBalance = Deposit(depositAmount);
                            Console.WriteLine($"Deposit successful. New Balance: {newBalance:C}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid amount.");
                        }

                        break;
                    case "4":
                        Console.WriteLine("Thank you for using the ATM. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }

                Console.WriteLine();
            } while (input != "4");
        }

        public static decimal ViewBalance()
        {
            return Balance;
        }

        public static decimal Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                return Balance;
            }

            if (amount > Balance)
            {
                Console.WriteLine("Insufficient funds.");
                return Balance;
            }

            Balance -= amount;
            return Balance;
        }

        public static decimal Deposit(decimal amount)
        {
            if (amount < 0)
            {
                return Balance;
            }

            Balance += amount;
            return Balance;
        }
    }
}