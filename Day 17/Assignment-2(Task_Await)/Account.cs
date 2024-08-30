using System;
using System.Threading.Tasks;

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

    public async Task DepositAsync(double amount)
    {
        await Task.Run(() =>
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
        });
    }

    public async Task<bool> WithdrawAsync(double amount)
    {
        return await Task.Run(() =>
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
        });
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
