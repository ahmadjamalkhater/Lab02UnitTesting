using System;

public class ATM
{
    public decimal Balance { get; set; }

    public decimal ViewBalance()
    {
        return Balance;
    }

    public decimal Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= Balance)
        {
            Balance -= amount;
            return amount;
        }

        return 0;
    }

    public decimal Deposit(decimal amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            return amount;
        }

        return 0;
    }

    public static void Main()
    {
        UserInterface();
    }

    public static void UserInterface()
    {
        ATM atm = new ATM();

        while (true)
        {
            Console.WriteLine("ATM Options:");
            Console.WriteLine("1. View Balance");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Deposit");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine($"Current balance: {atm.ViewBalance():C}");
                    break;
                case "2":
                    Console.Write("Enter withdrawal amount: ");
                    decimal withdrawalAmount;
                    if (decimal.TryParse(Console.ReadLine(), out withdrawalAmount))
                    {
                        decimal withdrawnAmount = atm.Withdraw(withdrawalAmount);
                        if (withdrawnAmount > 0)
                        {
                            Console.WriteLine($"Successfully withdrew {withdrawnAmount:C}. Current balance: {atm.ViewBalance():C}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid withdrawal amount or insufficient funds.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid withdrawal amount. Please enter a valid number.");
                    }
                    break;
                case "3":
                    Console.Write("Enter deposit amount: ");
                    decimal depositAmount;
                    if (decimal.TryParse(Console.ReadLine(), out depositAmount))
                    {
                        decimal depositedAmount = atm.Deposit(depositAmount);
                        if (depositedAmount > 0)
                        {
                            Console.WriteLine($"Successfully deposited {depositedAmount:C}. Current balance: {atm.ViewBalance():C}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid deposit amount.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid deposit amount. Please enter a valid number.");
                    }
                    break;
                case "4":
                    Console.WriteLine("Exiting the application...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
            Console.WriteLine();
        }
    }
}
