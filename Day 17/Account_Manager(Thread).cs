using System;
using System.Threading;

public class Account
{
    public string AccountId { get; }
    private double _balance;
    private readonly object _balanceLock = new object(); 

    public Account(string accountId, double initialBalance)
    {
        AccountId = accountId;
        _balance = initialBalance;
    }

    public void Deposit(double amount)
    {
        lock (_balanceLock)
        {
            if (amount > 0)
            {
                _balance += amount;
                Console.WriteLine($"Deposited {amount} to account {AccountId}. New balance: {_balance}.");
            }
            else
            {
                Console.WriteLine("Deposit amount must be positive.");
            }
        }
        Console.WriteLine();

    }

    public bool Withdraw(double amount)
    {
        lock (_balanceLock)
        {
            if (amount > 0)
            {
                if (_balance >= amount)
                {
                    _balance -= amount;
                    Console.WriteLine();
                    Console.WriteLine($"Withdraw {amount} from account {AccountId}. New balance: {_balance}.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Insufficient funds in account {AccountId}. Withdrawl failed.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Withdrawl amount must be positive.");
                return false;
            }
        }
    }

    public double GetBalance()
    {
        lock (_balanceLock)
        {
            return _balance;
        }
    }
    public void PrintInitialBalance()
    {
        Console.WriteLine($"Initial balance of account {AccountId}: {_balance}");
    }
}

public class AccountManager
{
    private readonly object _transferLock = new object(); 

    public void Transfer(Account fromAccount, Account toAccount, double amount)
    {
        if (fromAccount == toAccount)
        {
            Console.WriteLine("Cannot transfer to the same account.");
            return;
        }

        if (amount <= 0)
        {
            Console.WriteLine("Transfer amount must be positive.");
            return;
        }

        lock (_transferLock)
        {
            bool success = fromAccount.Withdraw(amount);
            if (success)
            {
                toAccount.Deposit(amount);
                Console.WriteLine($"Successfully transferred {amount} from account {fromAccount.AccountId} to account {toAccount.AccountId}.");
            }
        }
    }
}

public class Program
{
    private static void PerformTransaction(AccountManager manager, Account fromAccount, Account toAccount, double amount)
    {
        Console.WriteLine($"Transfer of {amount} from {fromAccount.AccountId} to {toAccount.AccountId}.");
        manager.Transfer(fromAccount, toAccount, amount);
    }

    public static void Main()
    {
        Account acc1 = new Account("1", 1500.0);
        Account acc2 = new Account("2", 1000.0);

        acc1.PrintInitialBalance();
        acc2.PrintInitialBalance();

        AccountManager manager = new AccountManager();

        Thread thread1 = new Thread(() => PerformTransaction(manager, acc1, acc2, 200.0));      
        // Start threads
        thread1.Start();
        thread1.Join();
        Console.WriteLine();

        Console.WriteLine($"Final balance of account {acc1.AccountId}: {acc1.GetBalance()}");
   Console.WriteLine($"Final balance of account {acc2.AccountId}: {acc2.GetBalance()}");
    }
}