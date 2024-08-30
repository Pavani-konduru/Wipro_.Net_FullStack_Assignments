using System;

public class Account
{
    public string AccountId { get; }
    private double _balance;
    private readonly object _balanceLock = new object();  // Lock object for thread safety

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
                    Console.WriteLine($"Withdrew {amount} from account {AccountId}. New balance: {_balance}.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Insufficient funds in account {AccountId}. Withdrawal failed.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Withdrawal amount must be positive.");
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
